namespace Histogram

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

module BasicHistogram =
    let x =
        getNormalData 0
        |> Seq.take 500

    let data = Histogram(x = x)

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "Basic Histogram"
        chart.GetInlineJS()

module HorizontalHistogram =
    let y =
        getNormalData 0
        |> Seq.take 500

    let data = Histogram(y = y)

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "Basic Horizontal Histogram"
        chart.GetInlineJS()

module OverlaidHistgram =
    let x0 =
        getNormalData 0
        |> Seq.take 500

    let x1 = x0 |> Seq.map (fun x -> x + 1.)
    
    let trace1 =
        Histogram(
            x = x0,
            opacity = 0.75
        )

    let trace2 =
        Histogram(
            x = x1,
            opacity = 0.75
        )

    let data = [trace1; trace2]

    let options = Options(barmode = "overlay", title = "Overlaid Histogram Test")
    
    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

module StackedHistograms =
    let x0 =
        getNormalData 0
        |> Seq.take 500

    let x1 = x0 |> Seq.map (fun x -> x + 1.)
    
    let trace1 =
        Histogram(
            x = x0
        )

    let trace2 =
        Histogram(
            x = x1
        )

    let data = [trace1; trace2]

    let options = Options(barmode = "stack", title = "Stacked Histograms Test")

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

module ColoredStyledHistograms =
    let x0 =
        getNormalData 0
        |> Seq.take 500

    let x1 = x0 |> Seq.map (fun x -> x + 1.)

    let trace1 =
        Histogram(
            x = x0,
            histnorm = "count",
            name = "control",
            autobinx = false,
            xbins =
                Xbins(
                    start = -3.2,
                    ``end`` = 2.8,
                    size = 0.2
                ),
            marker =
                Marker(
                    color = "fuchsia",
                    line =
                        Line(
                            color = "grey",
                            width = 0
                        ),
                    opacity = 0.75
                )
        )

    let trace2 =
        Histogram(
            x = x1,
            name = "experimental",
            autobinx = false,
            xbins =
                Xbins(
                    start = -1.8,
                    ``end`` = 4.2,
                    size = 0.2
                ),
            marker = Marker(color = "rgb(255, 217, 102)"),
            opacity = 0.75
        )

    let data = [trace1; trace2]

    let options =
        Options(
            title = "Colored and Styled Histograms",
            xaxis = Xaxis(title = "Value"),
            yaxis = Yaxis(title = "Count"),
            barmode = "overlay",
            bargap = 0.25,
            bargroupgap = 0.3
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()
