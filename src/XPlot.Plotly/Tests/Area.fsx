#r @"../../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"

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
    |> Chart.Plot
    |> Chart.Show

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
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show
    
// ==========
// Pipe style
// ==========

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Area
|> Chart.Show

// single series
sales
|> Chart.Area
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Area
|> Chart.Show
