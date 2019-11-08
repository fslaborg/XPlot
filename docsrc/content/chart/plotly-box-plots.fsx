(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open System

open XPlot.Plotly

let rnd = Random()

let randn count min max =
    [1 .. count]
    |> List.map (fun _ -> rnd.NextDouble() * (max - min) + min)

let y0 = randn 50 -1.86 1.67
let y1 = randn 50 -1.2 3.44

(**
Plotly Box Plots
================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-box-plots.fsx)

Basic Box Plot
--------------
*)

(*** define-output: chart1 ***)
let trace1 = Box(y = y0)
let trace2 = Box(y = y1)

[trace1; trace2]
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
Box Plot That Displays the Underlying Data
------------------------------------------
*)

(*** define-output: chart2 ***)
Box(
    y = [0; 1; 1; 2; 3; 5; 8; 13; 21],
    boxpoints = "all",
    jitter = 0.3,
    pointpos = -1.8
)
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart2 ***)

(**
Grouped Box Plot
----------------
*)

(*** define-output: chart3 ***)
let x = ["day 1"; "day 1"; "day 1"; "day 1"; "day 1"; "day 1";
        "day 2"; "day 2"; "day 2"; "day 2"; "day 2"; "day 2"]

let groupedTrace1 =
    Box(
        y = [0.2; 0.2; 0.6; 1.0; 0.5; 0.4; 0.2; 0.7; 0.9; 0.1; 0.5; 0.3],
        x = x,
        name = "kale",
        marker = Marker(color = "#3D9970")
    )

let groupedTrace2 =
    Box(
        y = [0.6; 0.7; 0.3; 0.6; 0.0; 0.5; 0.7; 0.9; 0.5; 0.8; 0.7; 0.2],
        x = x,
        name = "radishes",
        marker = Marker(color = "#FF4136")
    )

let groupedTrace3 =
    Box(
        y = [0.1; 0.3; 0.1; 0.9; 0.6; 0.6; 0.9; 1.0; 0.3; 0.6; 0.8; 0.5],
        x = x,
        name = "carrots",
        marker = Marker(color = "#FF851B")
    )

let layout =
    Layout(
        yaxis =
            Yaxis(
                title = "normalized moisture",
                zeroline = false
            ),
        boxmode = "group"
    )

[groupedTrace1; groupedTrace2; groupedTrace3]
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart3 ***)
