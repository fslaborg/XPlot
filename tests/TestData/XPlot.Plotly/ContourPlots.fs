namespace ContourPlots

open System.IO
open XPlot.Plotly

[<AutoOpen>]
module GetData =
    let getLinearSpacedData line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "linear-spaced-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

    let getNormalData line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "normal-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

module BasicContourPlot =
    let trace =
        Contour(
            z = getLinearSpacedData 2,
            x = getLinearSpacedData 0,
            y = getLinearSpacedData 1
        )

    let js =
        let x = new System.String('t', 100)
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Basic Contour Plot"
        chart.GetInlineJS()

module TwoDHistogramContourPlotHistogramSubplots =
    let t = getLinearSpacedData 0
    let sample = getNormalData 0

    let x = Array.mapi (fun i x -> t.[i] ** 3. + 0.3 * x) sample
    let y = Array.mapi (fun i x -> t.[i] ** 6. + 0.3 * x) sample

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
            title = "2D Histogram Contour Plot with Histogram Subplots",
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
        chart.GetInlineJS()
