(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Heatmaps
===============

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-heatmaps.fsx)

Basic Heatmap
-------------
*)

(*** define-output: chart1 ***)
let layout = Layout(title = "Basic Heatmap")

Heatmap(
    z = [[1; 20; 30]; [20; 1; 60]; [30; 60; 1]]
)
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
Heatmap with Categorical Axis Labels
------------------------------------
*)

(*** define-output: chart2 ***)
let categoricalLayout = Layout(title = "Heatmap with Categorical Axis Labels")

Heatmap(
    z = [[1; 20; 30; 50; 1]; [20; 1; 60; 80; 30]; [30; 60; 1; -10; 20]],
    x = ["Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"],
    y = ["Morning"; "Afternoon"; "Evening"]
)
|> Chart.Plot
|> Chart.WithLayout categoricalLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart2 ***)

(**
Custom Colorscale
-----------------
*)

(*** define-output: chart3 ***)
let customZ =
    [
        for x in 1 .. 50 do
            let lst = List.map (fun y -> y + x) [1..50]
            yield lst
    ]

let colorScale =
    [
        [box 0.0; box "rgb(165,0,38)"]
        [0.1111111111111111; "rgb(215,48,39)"]
        [0.2222222222222222; "rgb(244,109,67)"]
        [0.3333333333333333; "rgb(253,174,97)"]
        [0.4444444444444444; "rgb(254,224,144)"]
        [0.5555555555555556; "rgb(224,243,248)"]
        [0.6666666666666666; "rgb(171,217,233)"]
        [0.7777777777777778; "rgb(116,173,209)"]
        [0.8888888888888888; "rgb(69,117,180)"]
        [1.0; "rgb(49,54,149)"]
    ]

let customLayout = Layout(title = "Custom Colorscale")

Heatmap(
    z = customZ,
    colorscale = colorScale
)
|> Chart.Plot
|> Chart.WithLayout customLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart3 ***)

(**
Earth Colorscale
----------------
*)

(*** define-output: chart4 ***)
let earthZ =
    [
        for x in 1 .. 50 ->
            List.map (fun y -> y + x) [1..50]
    ]

let earthLayout = Layout(title = "Earth Colorscale")

Heatmap(
    z = earthZ,
    colorscale = "Earth"
)
|> Chart.Plot
|> Chart.WithLayout earthLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart4 ***)

(**
YIGnBu Colorscale
-----------------
*)

(*** define-output: chart5 ***)
let yignbuZ =
    [
        for x in 1 .. 50 ->
            List.map (fun y -> y + x) [1..50]
    ]

let yignbuLayout = Layout(title = "YIGnBu Colorscale")

Heatmap(
    z = yignbuZ,
    colorscale = "YIGnBu"
)
|> Chart.Plot
|> Chart.WithLayout yignbuLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart5 ***)
