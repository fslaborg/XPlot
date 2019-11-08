(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Area Plots
=================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-area-plots.fsx)

Basic Overlaid Area Chart
-------------------------
*)

(*** define-output: chart ***)
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

let layout =
    Layout(
        title = "Basic Overlaid Area Chart",
        width = 700.,
        height = 500.
    )

[trace1; trace2]
|> Chart.Plot
|> Chart.WithLayout layout
(*** include-it: chart ***)
