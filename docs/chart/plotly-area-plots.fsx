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
Plotly Area Plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=plotly-area-plots.ipynb)

Basic Overlaid Area Chart
-------------------------
*)
open XPlot.Plotly

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

let chart =
    [trace1; trace2]
    |> Chart.Plot
    |> Chart.WithLayout layout
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
