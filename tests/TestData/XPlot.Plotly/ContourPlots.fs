namespace ContourPlots

open System
open System.IO
open XPlot.Plotly

[<AutoOpen>]
module GetData =
    let getLinearSpacedDataXOrY line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "basic-linear-spaced-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

    let getLargerLinearSpacedData line =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "larger-linear-spaced-data.txt")
            File.ReadAllLines path

        data.[line]
        |> fun x -> x.Split ','
        |> Array.map float

    let getLinearSpacedDataZ () =
        let data =
            let path = Path.Combine(__SOURCE_DIRECTORY__, "numerical-data", "basic-linear-spaced-data.txt")
            File.ReadAllLines path

        let columns = data.[2].Trim('|').Trim(',').Split('|')

        let z = Array2D.create columns.Length columns.Length 0.0

        for i = 0 to columns.Length-1 do
            let items = columns.[i].Trim('|').Trim(',').Split(',')
            for j = 0 to items.Length-1 do
                z.[i,j] <- float items.[j]
        z

module BasicContourPlot =
    let trace =
        Contour(
            z = getLinearSpacedDataZ (),
            x = getLinearSpacedDataXOrY 0,
            y = getLinearSpacedDataXOrY 1
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Basic Contour Plot"
        chart.GetInlineJS()

module TwoDHistogramContourPlotHistogramSubplots =
    let trace1 =
        Scatter(
            x = getLargerLinearSpacedData 0,
            y = getLargerLinearSpacedData 1,
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
            x = getLargerLinearSpacedData 0,
            y = getLargerLinearSpacedData 1,
            name = "density",
            ncontours = 20,
            colorscale = "Hot",
            reversescale = true,
            showscale = false
        ) :> Trace

    let trace3 =
        Histogram(
            x = getLargerLinearSpacedData 0,
            name = "x density",
            marker = Marker(color = "rgb(102,0,0)"),
            yaxis = "y2"
        ) :> Trace

    let trace4 =
        Histogram(
            y = getLargerLinearSpacedData 1,
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
