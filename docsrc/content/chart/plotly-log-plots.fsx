(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Log Plots
================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-log-plots.fsx)

Logarithmic Axes
----------------
*)

(*** define-output: chart ***)
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

let layout =
    Layout(
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

[trace1; trace2]
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart ***)
