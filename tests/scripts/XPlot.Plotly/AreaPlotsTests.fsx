#r @".\.\bin\Release\XPlot.Plotly.dll"
#load "Credentials.fsx"

// TESTED under CI now

open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

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

let data = Data [trace1; trace2]

let figure = Figure(data)

let plotlyResponse = figure.Plot("Basic Overlaid Area Chart")

figure.Show()

