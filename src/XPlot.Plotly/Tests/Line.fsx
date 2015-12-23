#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly

// Basic line plot
module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17]
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [16; 5; 11; 9]
        )

    let data = [trace1; trace2]

    data
    |> Plotly.Plot
    |> Plotly.Show

// Line and scatter plot
module Chart2 =

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

    let data = [ trace1; trace2; trace3 ]

    let layout = Layout(title ="Line and Scatter Plot")

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Adding names to line and scatter plot
module Chart3 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers",
            name = "Scatter"
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines",
            name = "Lines"
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers",
            name = "Scatter + Lines"
        )

    let data = [ trace1; trace2; trace3 ]

    let layout = Layout(title ="Adding Names to Line and Scatter Plot")

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Line and scatter styling
module Chart4 =

