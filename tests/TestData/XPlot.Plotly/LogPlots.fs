namespace LogPlots

open XPlot.Plotly

module LogarithmicAxes =
    let trace1 =
        Scatter(
            x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
            y = [8; 7; 6; 5; 4; 3; 2; 1; 0]
        )

    let trace2 =
        Scatter(
            x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
            y = [0; 1; 2; 3; 4; 5; 6; 7; 8]
        )

    let data = [trace1; trace2]

    let options =
        Options(
            title = "Logarithmic Axes",
            xaxis =
                Xaxis(
                    ``type`` = "log",
                    autorange = true
                ),
            yaxis =
                Yaxis(
                    ``type`` = "log",
                    autorange = true
                )
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()