#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly

// Basic Overlaid Area Chart
module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [0; 2; 3; 5],
            fill = "tozeroy"
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [3; 5; 1; 7],
            fill = "tonexty"
        )

    [trace1; trace2]
    |> Plotly.Plot
    |> Plotly.Show

// Overlaid Chart Without Boundary Lines
module Chart2 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [0; 2; 3; 5],
            fill = "tozeroy",
            mode = "none"
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [3; 5; 1; 7],
            fill = "tonexty",
            mode = "none"
        )

    let layout = Layout(title = "Overlaid Chart Without Boundary Lines")

    [trace1; trace2]
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show
    
// ==========
// Pipe style
// ==========

// Basic Overlaid Area Chart
module Chart1' =

    let trace1 = [1, 0; 2, 2; 3, 3; 4, 5]
    let trace2 = [1, 3; 2, 5; 3, 1; 4, 7]

    [trace1; trace2]
    |> Plotly.Area
    |> Plotly.Show
