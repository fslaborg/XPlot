namespace Contour

open MathNet.Numerics
open MathNet.Numerics.Distributions
open System
open XPlot.Plotly

module BasicContourPlot =
    let size = 100
    let x = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
    let y = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
    let z = Array2D.create size size 0.0

    for i in 0 .. 99 do
        for j in 0 .. 99 do
            let r2 = x.[i] ** 2. + y.[j] ** 2.
            z.[i,j] <- sin x.[i] * cos y.[j] * sin r2 / log(r2 + 1.)

    let trace =
        Contour(
            z = z,
            x = x,
            y = y
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Basic Contour Plot"
        chart.GetInlineJS()

// Not under test due to randomness
module TwoDHistogramContourPlotHistogramSubplots =
    let t = Generate.LinearSpaced(2000, -1., 1.2)

    let normal = new Normal(0., 1.0)

    let sample =
        normal.Samples()
        |> Seq.take 2000
        |> Seq.toArray

    let x = sample |> Array.mapi (fun i x -> t.[i] ** 3. + 0.3 * x)
    let y = sample |> Array.mapi (fun i x -> t.[i] ** 6. + 0.3 * x)

    let trace1 =
        Scatter(
            x = x,
            y = y,
            mode = "markers",
            name = "points",
            marker =
                Marker(
                    color = "rgb(102,0,0)",
                    size = 2,
                    opacity = 0.4
                )
        ) :> Trace

    let trace2 =
        Histogram2dcontour(
            x = x,
            y = y,
            name = "density",
            ncontours = 20,
            colorscale = "Hot",
            reversescale = true,
            showscale = false
        ) :> Trace

    let trace3 =
        Histogram(
            x = x,
            name = "x density",
            marker = Marker(color = "rgb(102,0,0)"),
            yaxis = "y2"
        ) :> Trace

    let trace4 =
        Histogram(
            y = y,
            name = "y density",
            marker = Marker(color = "rgb(102,0,0)"),
            xaxis = "x2"
        ) :> Trace

    let data = [trace1; trace2; trace3; trace4]

    let options =
        Options(
            showlegend = false,
            autosize = false,
            width = 600.,
            height = 550.,
            xaxis =
                Xaxis(
                    domain = [|0.; 0.85|],
                    showgrid = false,
                    zeroline = false
                ),
            yaxis =
                Yaxis(
                    domain = [|0.; 0.85|],
                    showgrid = false,
                    zeroline = false
                ),
            margin = Margin(t = 50.),
            hovermode = "closest",
            bargap = 0.,
            xaxis2 =
                Xaxis(
                    domain = [|0.85; 1.|],
                    showgrid = false,
                    zeroline = false
                ),
            yaxis2 =
                Yaxis(
                    domain = [|0.85; 1.|],
                    showgrid = false,
                    zeroline = false
                )
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
            |> Chart.WithTitle "2D Histogram Contour Plot with Histogram Subplots"
        chart.GetInlineJS()
