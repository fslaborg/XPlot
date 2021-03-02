(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.Plotly"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly Box Plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=plotly-box-plots.ipynb)

Basic Box Plot
--------------
*)
open System
open XPlot.Plotly

let rnd = Random()

let randn count min max =
    [1 .. count]
    |> List.map (fun _ -> rnd.NextDouble() * (max - min) + min)

let y0 = randn 50 -1.86 1.67
let y1 = randn 50 -1.2 3.44

let trace1 = Box(y = y0)
let trace2 = Box(y = y1)

let chart1 =
    [trace1; trace2]
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart1
#endif // IPYNB
(*** hide ***)
chart1.GetHtml()
(*** include-it-raw ***)

(**
Box Plot That Displays the Underlying Data
------------------------------------------
*)

let chart2 =
    Box(
        y = [0; 1; 1; 2; 3; 5; 8; 13; 21],
        boxpoints = "all",
        jitter = 0.3,
        pointpos = -1.8
    )
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart2
#endif // IPYNB
(*** hide ***)
chart2.GetHtml()
(*** include-it-raw ***)

(**
Grouped Box Plot
----------------
*)

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

let chart3 =
    [groupedTrace1; groupedTrace2; groupedTrace3]
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart3
#endif // IPYNB
(*** hide ***)
chart3.GetHtml()
(*** include-it-raw ***)
