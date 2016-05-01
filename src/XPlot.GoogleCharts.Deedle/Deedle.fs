[<AutoOpen>]
module XPlot.GoogleCharts.Deedle

open XPlot.GoogleCharts
open Deedle
open Deedle.``F# Frame extensions``
open System

type Chart with

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options Annotation

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options Area

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Bar

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:Frame<string, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Bubble

    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:Series<DateTime, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Calendar

    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:Frame<DateTime, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Calendar

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Candlestick

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Column

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Column

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Column

    /// <summary>Creates a combo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Combo(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Combo

    /// <summary>Creates a combo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Combo(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Combo

    /// <summary>Creates a gauge chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Gauge(data:Series<string, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Gauge

    /// <summary>Creates a gauge chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Gauge(data:Frame<string, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Gauge

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:Series<string, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Geo

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<Series<string, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Geo

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:Frame<string, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Geo

    /// <summary>Creates a histogram chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Histogram(data:Series<string, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Histogram

    /// <summary>Creates a histogram chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Histogram(data:Frame<string, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Histogram

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Line

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Line

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Line

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:Series<string, string>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Map

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Map

    /// <summary>Creates a pie chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Pie(data:Series<string, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Pie

    /// <summary>Creates a pie chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Pie(data:Frame<string, #value>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Pie

    /// <summary>Creates a sankey diagram.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Sankey(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Sankey

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Scatter

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Scatter

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Scatter

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.SteppedArea

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.SteppedArea

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.SteppedArea

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:Series<'K, #value>, ?Labels, ?Options) =
        let series =
            data
            |> Series.observations
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options ChartGallery.Table

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<Series<'K, #value>> when 'K :> key, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Series.observations
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options ChartGallery.Table

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Table

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.Timeline

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:Frame<'K, 'V>, ?Options) =
        let dt = data.ToDataTable(["Key"])
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.CreateFromDataTable dt options ChartGallery.TreeMap