#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly

module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers"
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines"
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers"
        )

    [trace1; trace2; trace3]
    |> Plotly.Plot
    |> Plotly.Show

module Chart2 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [1; 6; 3; 6; 1],
            mode = "markers",
            name = "Team A",
            text = ["A-1"; "A-2"; "A-3"; "A-4"; "A-5"],
            marker = Marker (size = 12.)
        )

    let trace2 =
        Scatter(
            x = [1.5; 2.5; 3.5; 4.5; 5.5],
            y = [4; 1; 7; 1; 4],
            mode = "markers",
            name = "Team B",
            text = ["B-a"; "B-b"; "B-c"; "B-d"; "B-e"],
            marker = Marker (size = 12.)
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            xaxis = Xaxis(range = [0.75; 5.25]),
            yaxis = Yaxis(range = [0.; 8.]),
            title = "Data Labels Hover"
        )

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

