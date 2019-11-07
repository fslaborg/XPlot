(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open System
open XPlot.Plotly

let x =
    [
        DateTime(2013, 10, 4);
        DateTime(2013, 11, 5);
        DateTime(2013, 12, 6)
    ]

(**
Plotly Time Series
==================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-time-series.fsx)

Time Series Plot with DateTime Objects
--------------------------------------
*)

(*** define-output: chart1 ***)
let layout = Layout(title = "Time Series Plot with datetime Objects")

Scatter(
    x = x,
    y = [1; 3; 6]
)
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
Date Strings
------------
*)

(*** define-output: chart2 ***)
let stringLayout = Layout(title = "Date Strings")

Scatter(
    x =
        ["2013-10-04 22:23:00";
            "2013-11-04 22:23:00";
            "2013-12-04 22:23:00"],
    y = [1; 3; 6]
)
|> Chart.Plot
|> Chart.WithLayout stringLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart2 ***)
