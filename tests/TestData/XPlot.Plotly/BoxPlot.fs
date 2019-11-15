namespace BoxPlot

open XPlot.Plotly

module BasicBoxPlot =
    let trace1 = Box(y = [0; 1; 1; 2; 5; 7; 9; 9; 1; 0; 3])
    let trace2 = Box(y = [4; 5; 2; 9; 6; 1; 3; 0; 0; 5; 6])

    let options = Options (title="Basic box plot")
    
    let js =
        let chart =
            [trace1; trace2]
            |> Chart.Plot
            |> Chart.WithOptions options

        chart.GetInlineJS()

module BoxPlotDisplaysUnderlyingData =

    let trace =
        Box(
            y = [0; 1; 1; 2; 3; 5; 8; 13; 21],
            boxpoints = "all",
            jitter = 0.3,
            pointpos = -1.8
        )

    let options = Options(title="Box Plot That Displays the Underlying Data")

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

module GroupedBoxPlot =

    let x = ["day 1"; "day 1"; "day 1"; "day 1"; "day 1"; "day 1";
            "day 2"; "day 2"; "day 2"; "day 2"; "day 2"; "day 2"]

    let trace1 =
        Box(
            y = [0.2; 0.2; 0.6; 1.0; 0.5; 0.4; 0.2; 0.7; 0.9; 0.1; 0.5; 0.3],
            x = x,
            name = "kale",
            marker = Marker(color = "#3D9970")
        )

    let trace2 =
        Box(
            y = [0.6; 0.7; 0.3; 0.6; 0.0; 0.5; 0.7; 0.9; 0.5; 0.8; 0.7; 0.2],
            x = x,
            name = "radishes",
            marker = Marker(color = "#FF4136")
        )

    let trace3 =
        Box(
            y = [0.1; 0.3; 0.1; 0.9; 0.6; 0.6; 0.9; 1.0; 0.3; 0.6; 0.8; 0.5],
            x = x,
            name = "carrots",
            marker = Marker(color = "#FF851B")
        )

    let options =
        Options(
            yaxis =
                Yaxis(
                    title = "normalized moisture",
                    zeroline = false
                ),
            boxmode = "group"
        )

    let js =
        let chart =
            [trace1; trace2; trace3]
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()
