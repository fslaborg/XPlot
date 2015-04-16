#r @".\.\bin\Release\XPlot.Plotly.dll"
#r @"..\packages\MathNet.Numerics.3.6.0\lib\net40\MathNet.Numerics.dll"
#load "Credentials.fsx"

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

module BasicHistogram =

    let normal = new Normal(0., 1.0)

    let x =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let data = Data([Histogram(x = x)])

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Basic Histogram Test")

    figure.Show()

module HorizontalHistogram =

    let normal = new Normal(0., 1.0)

    let y =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let data = Data([Histogram(y = y)])

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Horizontal Histogram Test")

    figure.Show()

module OverlaidHistgram =

    let normal = new Normal(0., 1.0)

    let x0 =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let x1 = Array.map (fun x -> x + 1.) x0
    
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

    let data = Data([trace1; trace2])

    let layout = Layout(barmode = "overlay")

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Overlaid Histogram Test")

    figure.Show()

module StackedHistograms =

    let normal = new Normal(0., 1.0)

    let x0 =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let x1 = Array.map (fun x -> x + 1.) x0
    
    let trace1 =
        Histogram(
            x = x0
        )

    let trace2 =
        Histogram(
            x = x1
        )

    let data = Data([trace1; trace2])

    let layout = Layout(barmode = "stack")

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Stacked Histograms Test")

    figure.Show()

module ColoredStyledHistograms =

    let normal = new Normal(0., 1.0)

    let x0 =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let x1 = Array.map (fun x -> x + 1.) x0

    let trace1 =
        Histogram(
            x = x0,
            histnorm = "count",
            name = "control",
            autobinx = false,
            xbins =
                XBins(
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
                XBins(
                    start = -1.8,
                    ``end`` = 4.2,
                    size = 0.2
                ),
            marker = Marker(color = "rgb(255, 217, 102)"),
            opacity = 0.75
        )

    let data = Data([trace1; trace2])

    let layout =
        Layout(
            title = "Sampled Results",
            xaxis = XAxis(title = "Value"),
            yaxis = YAxis(title = "Count"),
            barmode = "overlay",
            bargap = 0.25,
            bargroupgap = 0.3
        )

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Colored and Styled Histograms Test")

    figure.Show()
