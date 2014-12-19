module XPlot.GoogleCharts.Deedle

open XPlot.GoogleCharts
open Deedle
open Deedle.FSharpFrameExtensions

type Chart with

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:Series<'K, 'V>, ?Labels, ?Options) =
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
    static member Area(data:seq<Series<'K, 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
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
    static member Bar(data:Series<'K, 'V>, ?Labels, ?Options) =
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
    static member Bar(data:seq<Series<'K, 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
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
