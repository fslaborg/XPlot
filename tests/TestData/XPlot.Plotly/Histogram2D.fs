namespace Histogram2D

open System.IO
open XPlot.Plotly

[<AutoOpen>]
module GetData =
    let getNormalData line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "normal-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

    let getContinuousUniformData line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "continuous-uniform-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

module Histogram2DBivariate =
    let data =
        Histogram2d(
            x = getNormalData 0,
            y = getNormalData 1
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "2D Histogram of a Bivariate Normal Distribution Test"
        chart.GetInlineJS()

module Histogram2DBinningStyling =
    let data =
        Histogram2d(
            x = getNormalData 0,
            y = getNormalData 1,
            histnorm = "probability",
            autobinx = false,
            xbins =
                Xbins(
                    start = -3.,
                    ``end`` = 3.,
                    size = 0.1
                ),
            autobiny = false,
            ybins =
                Ybins(
                    start = -2.5,
                    ``end`` = 4.,
                    size = 0.1
                ),
            colorscale =
                [
                    [box 0; box "rgb(12,51,131)"]
                    [0.25; "rgb(10,136,186)"]
                    [0.5; "rgb(242,211,56)"]
                    [0.75; "rgb(242,143,56)"]
                    [1; "rgb(217,30,30)"]
                ]
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "2D Histogram Binning and Styling Options"
        chart.GetInlineJS()

module Histogram2DOverlaidScatter =
    let x0 =
        getNormalData 0
        |> Seq.take 100
        |> Seq.map (fun x -> x / 5.0 + 0.5)

    let y0 =
        getNormalData 1
        |> Seq.take 100
        |> Seq.map (fun x -> x / 5.0 + 0.5)

    let x1 =
        getContinuousUniformData 0
        |> Seq.take 50

    let y1 =
        getContinuousUniformData 1
        |> Seq.take 50

    let x = Seq.concat [x0; x1]
    let y = Seq.concat [y0; y1]

    let trace1 =
        Scatter(
            x = x0,
            y = y0,
            mode = "markers",
            marker =
                Marker(
                    symbol = "circle",
                    opacity = 0.7
                )
        ) :> Trace

    let trace2 =
        Scatter(
            x = x1,
            y = y1,
            mode = "markers",
            marker =
                Marker(
                    symbol = "square",
                    opacity = 0.7
                )
        ) :> Trace

    let trace3 =
        Histogram2d(
            x = x,
            y = y
        ) :> Trace

    let js =
        let chart =
            [ trace1; trace2; trace3 ]
            |> Chart.Plot
            |> Chart.WithTitle "2D Histogram Overlaid with a Scatter Chart"
        chart.GetInlineJS()
