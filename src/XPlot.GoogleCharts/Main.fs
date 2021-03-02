namespace XPlot.GoogleCharts

open Google.DataTable.Net.Wrapper.Extension
open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open System
open System.Data
open System.Globalization
open System.IO
open System.Runtime.InteropServices
open System.Diagnostics

type key = IConvertible
type value = IConvertible

[<AutoOpen>]
module Data =

    type Datum =
        {
            X : key
            Y1 : value
            Y2 : value option
            Y3 : value option
            Y4 : value option
        }

        static member New(x, y) = {X = x; Y1 = y; Y2 = None; Y3 = None; Y4 = None}

        static member New(x, y1, y2) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = None; Y4 = None}

        static member New(x, y1, y2, y3) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = Some y3; Y4 = None}

        static member New(x, y1, y2, y3, y4) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = Some y3; Y4 = Some y4}

    type Series =
        {
            DataPoints : seq<Datum>
        }

        static member New dps = {DataPoints = dps}

        static member New (data: seq<#key * #value>) =
            data
            |> Seq.map Datum.New
            |> Series.New

        static member New (data: seq<#key * #value * #value>) =
            data
            |> Seq.map Datum.New
            |> Series.New

        static member New (data: seq<#key * #value * #value * #value>) =
            data
            |> Seq.map Datum.New
            |> Series.New

        static member New (data: seq<#key * #value * #value * #value * #value>) =
            data
            |> Seq.map Datum.New
            |> Series.New

    let makeDataTable series labels =

        let rows =
            match Seq.length series with
            | 1 ->
                series
                |> Seq.item 0
                |> fun x ->
                    x.DataPoints
                    |> Seq.map (fun dp ->
                        let key = dp.X
                        let fields =
                            [
                                    yield Some dp.Y1
                                    if dp.Y2.IsSome then yield dp.Y2
                                    if dp.Y3.IsSome then yield dp.Y3
                                    if dp.Y4.IsSome then yield dp.Y4
                            ]
                            |> List.mapi (fun idx x -> x, idx + 1)
                        key, fields)
            | _ ->
                let dps =
                    series
                    |> Seq.map (fun x -> x.DataPoints)
                    |> Seq.concat

                let keys =
                    dps
                    |> Seq.map (fun x -> x.X)
                    |> Seq.distinct

                keys
                |> Seq.map (fun key ->
                    let datapoints =
                        series
                        |> Seq.map (fun x -> Seq.tryFind (fun dp -> dp.X = key) x.DataPoints)
                    let fields' =
                        [
                            for x in datapoints do
                                if x.IsSome then
                                    let x' = Option.get x
                                    yield Some x'.Y1
                                    if x'.Y2.IsSome then yield x'.Y2
                                    if x'.Y3.IsSome then yield x'.Y3
                                    if x'.Y4.IsSome then yield x'.Y4
                                else yield None
                        ]
                        |> List.mapi (fun idx x -> x, idx + 1)
                    key, fields'
                )

        let sysDt = new System.Data.DataTable()
        sysDt.Locale <- CultureInfo.InvariantCulture

        let longestRow = Seq.maxBy (snd >> Seq.length) rows

        let labels' =
            let length = snd longestRow |> Seq.length
            match labels with
            | None -> seq {for x in 1 .. (length + 1) -> "Column " + string x}
            | Some labelsSeq ->
                match (Seq.length labelsSeq) = length with
                | false -> Seq.append ["Column 1"] labelsSeq
                | true -> labelsSeq

        sysDt.Columns.Add(Seq.item 0 labels', (fst longestRow).GetType())
        |> ignore

        let values = Seq.map snd rows

        (snd longestRow)
        |> List.iteri (fun idx _ ->
            let columnType =
                values
                |> Seq.tryPick (fun x ->
                    match x.Length with
                    | l when l < idx + 1 -> None
                    | _ -> fst x.[idx])
                |> Option.get
                |> fun x -> x.GetType()
            sysDt.Columns.Add(Seq.item (idx + 1) labels', columnType)
            |> ignore
        )

        rows
        |> Seq.iter (fun (key, values) ->
            let row = sysDt.NewRow()
            row.[0] <- key // SetField(0, key)
            values
            |> Seq.iter (fun (value, column) ->
                match value with
                | Some v -> row.[column]  <- v // SetField(column, v)
                | _ -> ()
            )
            sysDt.Rows.Add(row)
        )

        sysDt

module Html =

    let formatDatasetTemplate =
        """
        var __number_formatter_{COLUME} = new google.visualization.NumberFormat({FORMAT});
        __number_formatter_{COLUME}.format(data, {COLUME});
        """

    let jsTemplate =
        """google.charts.setOnLoadCallback(drawChart_{GUID});
            function drawChart_{GUID}() {
                if ("{KEY}")
                    google.visualization.mapsApiKey = "{KEY}"

                var data = new google.visualization.DataTable({DATA});

                {FORMAT}

                var options = {OPTIONS}

                var chart = new google.visualization.{TYPE}(document.getElementById('{GUID}'));
                chart.draw(data, options);
            }"""

    let inlineTemplate =
        """<script type="text/javascript">
    {JS}
</script>
<div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>"""

    let pageTemplate =
        """<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <title>Google Chart</title>
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">
            google.charts.load('current', {
              packages: ["{PACKAGES}"]
            });
            {JS}
        </script>
    </head>
    <body>
        <div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>
    </body>
</html>"""

type ChartGallery =
    | Annotation
    | Area
    | Bar
    | Bubble
    | Calendar
    | Candlestick
    | Column
    | Combo
    | Gauge
    | Geo
    | Histogram
    | Line
    | Map
    | Pie
    | Sankey
    | Scatter
    | SteppedArea
    | Table
    | Timeline
    | TreeMap

    override __.ToString() =
        match FSharpValue.GetUnionFields(__, typeof<ChartGallery>) with
        | case, _ ->
            let name = case.Name
            match name with
            | "Calendar"
            | "Gauge"
            | "Histogram"
            | "Map"
            | "Sankey"
            | "Table"
            | "Timeline"
            | "TreeMap" -> name
            | _ -> name + "Chart"

type GoogleChart() =

    [<DefaultValue>]
    val mutable private dataTable : DataTable

    [<DefaultValue>]
    val mutable private options : Options

    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery

    static member Create data labels options ``type`` =
        let dt = makeDataTable data labels
        let gc = GoogleChart()
        gc.dataTable <- dt
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    static member CreateFromDataTable dataTable options ``type`` =
        let gc = GoogleChart()
        gc.dataTable <- dataTable
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    /// Returns the chart's full HTML source.
    member __.GetHtml() =
        let packages =
            match __.``type`` with
            | Annotation -> "annotationchart"
            | Calendar -> "calendar"
            | Gauge -> "gauge"
            | Geo -> "geochart"
            | Map -> "map"
            | Sankey -> "sankey"
            | Table -> "table"
            | Timeline -> "timeline"
            | TreeMap -> "treemap"
            | _ -> "corechart"
        Html.pageTemplate
            .Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.GetInlineJS())
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))

    /// Inline markup that can be embedded in a HTML document (provided that it has
    /// a reference to Google APIs and loads the required Google Charts packages).
    member __.GetInlineHtml() =
        Html.inlineTemplate
            .Replace("{JS}", __.GetInlineJS())
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))

    /// The chart's inline JavaScript code.
    member __.GetInlineJS() =
        let dataJson = __.dataTable.ToGoogleDataTable().GetJson()
        let optionsJson = JsonConvert.SerializeObject(__.options)

        let formatTemplate =
            match __.options.datasetNumberFormats with
            | Some formats ->
                formats
                |> List.map (fun (col, format) ->
                    Html.formatDatasetTemplate.Replace("{FORMAT}", JsonConvert.SerializeObject(format)).Replace("{COLUME}", col.ToString()))
                |> String.concat Environment.NewLine
            | None -> ""

        Html.jsTemplate.Replace("{DATA}", dataJson)
            .Replace("{OPTIONS}", optionsJson)
            .Replace("{TYPE}", __.``type``.ToString())
            .Replace("{GUID}", __.Id)
            .Replace("{FORMAT}", formatTemplate)
            .Replace("{KEY}", string(__.ApiKey))

    /// The height of the chart container element.
    member val Height = -1 with get, set

    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString().Replace("-", "_")
        with get, set

    /// The Google Maps API Key, used with Goe and Map charts.
    member val ApiKey =
        String.Empty
        with get, set

    /// Displays a chart in the default browser.
    member __.Show() =
        let html = __.GetHtml()
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" __.Id
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        if RuntimeInformation.IsOSPlatform(OSPlatform.Windows) then
            let psi = new ProcessStartInfo(FileName = path, UseShellExecute = true)
            Process.Start(psi) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.Linux) then
            Process.Start("xdg-open", path) |> ignore
        elif RuntimeInformation.IsOSPlatform(OSPlatform.OSX) then
            Process.Start("open", path) |> ignore
        else
            invalidOp "Not supported OS platform"

    /// The width of the chart container element.
    member val Width = -1 with get, set

    /// Sets the chart's height.
    member __.WithHeight height = __.Height <- height

    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the Google Maps API Key, used by Goe and Map charts.
    member __.WithApiKey newApiKey = __.ApiKey<- newApiKey

    /// Sets the data series label. Use this method if the
    /// chart's data is a single series.
    member __.WithLabel label =
        let columns = __.dataTable.Columns
        columns.[1].ColumnName <- label
        __.WithLegend true

    /// Sets the data series labels. Use this method if the
    /// chart's data is a series collection.
    member __.WithLabels labels =
        let columns = __.dataTable.Columns
        let names =
            match (Seq.length labels) = columns.Count with
            | false -> Seq.append (seq {for x in 1 .. (columns.Count - (Seq.length labels)) -> "Column " + string x}) labels
            | true -> labels
        names
        |> Seq.iteri (fun idx x -> columns.[idx].ColumnName <- x)
        __.WithLegend true

    /// Display/hide the legend.
    member __.WithLegend enabled =
        match enabled with
        | false ->
            try
                __.options.legend.position <- "none"
            with _ -> __.options.legend <- Legend(position = "none")
        | true ->
            try
                __.options.legend.position <- "right"
            with _ -> __.options.legend <- Legend(position = "right")

    /// Sets the chart's configuration options.
    member __.WithOptions (options:Options) =
        // If the chart title has been set,
        // do not overwrite it.
        let currentTitle = __.options.title
        if not (String.IsNullOrEmpty currentTitle)
        then
            options.title <- currentTitle

        __.options <- options

    /// Sets the chart's width and height.
    member __.WithSize (width, height) =
        __.Height <- height
        __.Width <- width

    /// Sets the chart's title.
    member __.WithTitle title =
        __.options.title <- title

    /// Sets the chart's width.
    member __.WithWidth width = __.Width <- width

    /// Sets the chart's X-axis title.
    member __.WithXTitle xTitle =
        try
            __.options.hAxis.title <- xTitle
        with _ ->
            __.options.hAxis <- Axis(title = xTitle)

    /// Sets the chart's Y-axis title.
    member __.WithYTitle yTitle =
        try
            __.options.vAxis.title <- yTitle
        with _ ->
            __.options.vAxis <- Axis(title = yTitle)

type Chart =

    /// Displays a chart in the default browser.
    static member Show(chart : GoogleChart) = chart.Show()

    /// Sets the chart's height.
    static member WithHeight height (chart:GoogleChart) =
        chart.WithHeight height
        chart

    /// Sets the chart's container div id.
    static member WithId id (chart:GoogleChart) =
        chart.WithId id
        chart

    /// Sets Google API Key.
    static member WithApiKey apiKey (chart:GoogleChart) =
        chart.WithApiKey apiKey
        chart

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    static member WithLabel label (chart:GoogleChart) =
        chart.WithLabel label
        chart

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    static member WithLabels labels (chart:GoogleChart) =
        chart.WithLabels labels
        chart

    /// Display/hide the legend.
    static member WithLegend enabled (chart:GoogleChart) =
        chart.WithLegend enabled
        chart

    /// Sets the chart's configuration options.
    static member WithOptions options (chart:GoogleChart) =
        chart.WithOptions options
        chart

    /// Sets the chart's height.
    static member WithSize size (chart:GoogleChart) =
        chart.WithSize size
        chart

    /// Sets the chart's title.
    static member WithTitle title (chart:GoogleChart) =
        chart.WithTitle title
        chart

    /// Sets the chart's width.
    static member WithWidth width (chart:GoogleChart) =
        chart.WithWidth width
        chart

    /// Sets the chart's X-axis title.
    static member WithXTitle xTitle (chart:GoogleChart) =
        chart.WithXTitle xTitle
        chart

    /// Sets the chart's Y-axis title.
    static member WithYTitle yTitle (chart:GoogleChart) =
        chart.WithYTitle yTitle
        chart


type Chart with

    static member private Create (data: seq<#seq<'T>>) labels options chartType datumNew =
        let seriesFromData x =
            x
            |> Seq.map (fun y ->
                y
                |> Seq.map datumNew
                |> Series.New
            )
        let series = seriesFromData data
        let options = defaultArg options <| Configuration.Options()
        GoogleChart.Create series labels options chartType

    static member private Create' (data: seq<#value>) labels options chartType =
        let data' =
            data
            |> Seq.mapi (fun i x -> i, x)
        Chart.Create [data'] labels options chartType Datum.New

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<DateTime * #value * string * string>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Annotation Datum.New

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<#seq<DateTime * 'V * string * string>> when 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Annotation Datum.New

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#value>, ?Labels, ?Options) =
        Chart.Create' data Labels Options Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Area Datum.New

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Area Datum.New

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#value>, ?Labels, ?Options) =
        Chart.Create' data Labels Options Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Bar Datum.New

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Bar Datum.New

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Bubble Datum.New

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Bubble Datum.New

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Bubble Datum.New

    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:seq<DateTime * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Calendar Datum.New

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#key * #value * #value * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Candlestick Datum.New

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#seq<'K * 'V * 'V * 'V * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Candlestick Datum.New

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#value>, ?Labels, ?Options) =
        Chart.Create' data Labels Options Column

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Column Datum.New

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Column Datum.New

    /// <summary>Creates a combo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Combo(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Combo Datum.New

    /// <summary>Creates a gauge chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Gauge(data:seq<string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Gauge Datum.New

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Geo Datum.New

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Geo Datum.New

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<float * float>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Geo Datum.New

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<float * float * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Geo Datum.New

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<float * float * #value  * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Geo Datum.New

    /// <summary>Creates a histogram chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Histogram(data:seq<string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Histogram Datum.New

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#value>, ?Labels, ?Options) =
        Chart.Create' data Labels Options Line

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Line Datum.New

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Line Datum.New

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<string * string>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Map Datum.New

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<float * float * string>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Map Datum.New

    /// <summary>Creates a pie chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Pie(data:seq<string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Pie Datum.New

    /// <summary>Creates a sankey diagram.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Sankey(data:seq<string * string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Sankey Datum.New

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#value>, ?Labels, ?Options) =
        Chart.Create' data Labels Options Scatter

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Scatter Datum.New

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Scatter Datum.New

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options SteppedArea Datum.New

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options SteppedArea Datum.New

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#key * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Table Datum.New

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        Chart.Create data Labels Options Table Datum.New

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Timeline Datum.New

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options Timeline Datum.New

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options TreeMap Datum.New

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        Chart.Create [data] Labels Options TreeMap Datum.New
