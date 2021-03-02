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
Plotly Log Plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=plotly-log-plots.ipynb)

Logarithmic Axes
----------------
*)
open XPlot.Plotly

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

let chart =
    [trace1; trace2]
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
