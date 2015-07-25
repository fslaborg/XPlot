namespace XPlot.GoogleCharts

open Google.DataTable.Net.Wrapper.Extension
open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open System
open System.Data
open System.Globalization

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

    let makeDataTable series labels groupByKey =

        let dps =
            series
            |> Seq.map (fun x -> x.DataPoints)
            |> Seq.concat

        let keys =
            dps
            |> Seq.map (fun x -> x.X)
            |> Seq.distinct

        let rows =
            match groupByKey with
            | false ->
                series
                |> Seq.nth 0
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
            | true ->
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

        sysDt.Columns.Add(Seq.nth 0 labels', (fst longestRow).GetType())
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
            sysDt.Columns.Add(Seq.nth (idx + 1) labels', columnType)
            |> ignore
        )

        rows
        |> Seq.iter (fun (key, values) -> 
            let row = sysDt.NewRow()
            row.SetField(0, key)
            values
            |> Seq.iter (fun (value, column) ->
                match value with
                | Some v -> row.SetField(column, v)
                | _ -> ()
            )
            sysDt.Rows.Add(row)
        )

        sysDt

[<AutoOpen>]
module Templates =

    let jsTemplate =
        """google.setOnLoadCallback(drawChart);
            function drawChart() {
                var data = new google.visualization.DataTable({DATA});

                var options = {OPTIONS} 

                var chart = new google.visualization.{TYPE}(document.getElementById('{GUID}'));
                chart.draw(data, options);
            }"""

    let inlineTemplate = """
    <script type="text/javascript">
        {JS}
    </script>
    <div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>"""

    let template =
        """<!DOCTYPE html>
    <html>
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE=edge" />
            <title>Google Chart</title>
            <script type="text/javascript" src="https://www.google.com/jsapi"></script>
            <script type="text/javascript">
                google.load("visualization", "{VERSION}", {packages:["{PACKAGES}"]})
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
    
    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString()
        with get, set

    /// The height of the chart container element.
    member val Height = 500 with get, set

    /// The width of the chart container element.
    member val Width = 900 with get, set

    static member Create data labels options ``type`` =
        let dt =
            match ``type`` with
            | Sankey | Timeline -> makeDataTable data labels false
            | _ -> makeDataTable data labels true
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

    /// The chart's JavaScript code. Doesn't contain the
    /// necessary line for loading the appropiate Google
    /// visualization package. 
    member __.Js =
        let dataJson = __.dataTable.ToGoogleDataTable().GetJson()         
        let optionsJson = JsonConvert.SerializeObject(__.options)
        jsTemplate.Replace("{DATA}", dataJson)
            .Replace("{OPTIONS}", optionsJson)
            .Replace("{TYPE}", __.``type``.ToString())
            .Replace("{GUID}", __.Id)

    /// The chart's complete HTML code.
    member __.Html =
        let version =
            match __.``type`` with
            | Calendar | Sankey -> "1.1"            
            | _ -> "1"
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
        template.Replace("{VERSION}", version)
            .Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.Js)
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))

    /// Inline HTML that can be embedded in a larger page (provided that the page
    /// has a reference to Google APIs and loads required Google Charts)
    member __.InlineHtml =
        inlineTemplate
            .Replace("{JS}", __.Js)
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    member __.WithLabel label =
        let columns = __.dataTable.Columns
        columns.[1].ColumnName <- label
        __.WithLegend true

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    member __.WithLabels labels =
        let columns = __.dataTable.Columns
        let names =
            match (Seq.length labels) = columns.Count with
            | false -> Seq.append ["Column 1"] labels
            | true -> labels
        names
        |> Seq.iteri (fun idx x -> columns.[idx].ColumnName <- x)
        __.WithLegend true
            
    /// Sets the chart's title.
    member __.WithTitle title =
        __.options.title <- title

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
                
    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the chart's configuration options.
    member __.WithOptions options = __.options <- options

    /// Sets the chart's height.
    member __.WithHeight height = __.Height <- height

    /// Sets the chart's width.
    member __.WithWidth width = __.Width <- width

    /// Sets the chart's width and height.
    member __.WithSize (width, height) = 
      __.Height <- height
      __.Width <- width

type Chart =

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<DateTime * #value * string * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Annotation

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<#seq<DateTime * 'V * string * string>> when 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Annotation

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Area

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Bar

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble
     
    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:seq<DateTime * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Calendar
 
    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#key * #value * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Candlestick

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#seq<'K * 'V * 'V * 'V * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Candlestick

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Column

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Column

    /// <summary>Creates a combo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Combo(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Combo

    /// <summary>Creates a gauge chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Gauge(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Gauge

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Geo

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Geo

    /// <summary>Creates a histogram chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Histogram(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Histogram

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Line

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Line
     
    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<string * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Map

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<float * float * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Map

    /// <summary>Creates a pie chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Pie(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Pie

    /// <summary>Creates a sankey diagram.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Sankey(data:seq<string * string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Sankey

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Scatter

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Scatter

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options SteppedArea

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options SteppedArea

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Table

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Table

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Timeline

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Timeline

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options TreeMap

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options TreeMap
        
type Chart with

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

    /// Sets the chart's title.
    static member WithTitle title (chart:GoogleChart) =
        chart.WithTitle title
        chart

    /// Sets the chart's X-axis title.
    static member WithXTitle xTitle (chart:GoogleChart) =
        chart.WithXTitle xTitle
        chart

    /// Sets the chart's Y-axis title.
    static member WithYTitle yTitle (chart:GoogleChart) =
        chart.WithYTitle yTitle
        chart

    /// Display/hide the legend.
    static member WithLegend enabled (chart:GoogleChart) =
        chart.WithLegend enabled
        chart

    /// Sets the chart's container div id.
    static member WithId id (chart:GoogleChart) =
        chart.WithId id
        chart

    /// Sets the chart's configuration options.
    static member WithOptions options (chart:GoogleChart) =
        chart.WithOptions options
        chart

    /// Sets the chart's height.
    static member WithHeight height (chart:GoogleChart) =
        chart.WithHeight height
        chart

    /// Sets the chart's width.
    static member WithWidth width (chart:GoogleChart) =
        chart.WithWidth width
        chart

    /// Sets the chart's height.
    static member WithSize size (chart:GoogleChart) =
        chart.WithSize size
        chart
