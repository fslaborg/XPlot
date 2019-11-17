#r """.\.\bin\Release\XPlot.Plotly.dll"""
#r """..\packages\MathNet.Numerics.3.6.0\lib\net40\MathNet.Numerics.dll"""
#load "Credentials.fsx"

// TESTED under CI now

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

module Histogram2DBivariate =

    let normal = new Normal(0., 1.0)

    let x =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let y =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray
        |> Array.map (fun x -> x + 1.)

    let data =
        Data(
            [
                Histogram2d(
                    x = x,
                    y = y
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("2D Histogram of a Bivariate Normal Distribution Test")

    figure.Show()

module Histogram2DBinningStyling =

    let normal = new Normal(0., 1.0)

    let x =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray

    let y =
        normal.Samples()
        |> Seq.take 500
        |> Seq.toArray
        |> Array.map (fun x -> x + 1.)

    let data =
        Data(
            [
                Histogram2d(
                    x = x,
                    y = y,
                    histnorm = "probability",
                    autobinx = false,
                    xbins =
                        XBins(
                            start = -3.,
                            ``end`` = 3.,
                            size = 0.1
                        ),
                    autobiny = false,
                    ybins =
                        YBins(
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
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("2D Histogram Binning and Styling Options Test")

    figure.Show()

module Histogram2DOverlaidScatter =

    let normal = new Normal(0., 1.0)
    let uniform = new ContinuousUniform(0., 1.0)

    let x0 =
        normal.Samples()
        |> Seq.take 100
        |> Seq.toArray
        |> Array.map (fun x -> x / 5. + 0.5)

    let y0 =
        normal.Samples()
        |> Seq.take 100
        |> Seq.toArray
        |> Array.map (fun x -> x / 5. + 0.5)

    let x1 =
        uniform.Samples()
        |> Seq.take 50
        |> Seq.toArray

    let y1 =
        uniform.Samples()
        |> Seq.take 50
        |> Seq.toArray
        |> Array.map (fun x -> x + 1.)

    let x = Array.concat [x0; x1]
    let y = Array.concat [y0; y1]

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
        )

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
        )

    let trace3 =
        Histogram2d(
            x = x,
            y = y
        )

    let data = Data([trace1; trace2; trace3])

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("2D Histogram Overlaid with a Scatter Chart Test")

    figure.Show()
