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
Plotly Bubble Charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=plotly-bubble-charts.ipynb)

Marker Size, Color, and Symbol as an Array
------------------------------------------
*)
open XPlot.Plotly

let trace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [10; 11; 12; 13],
        mode = "markers",
        marker =
            Marker(
                color = ["hsl(0,100,40)"; "hsl(33,100,40)"; "hsl(66,100,40)"; "hsl(99,100,40)"],
                size = [12; 22; 32; 42],
                opacity = [0.6, 0.7, 0.8, 0.9]
            )
    )

let trace2 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [11; 12; 13; 14],
        mode = "markers",
        marker =
            Marker(
                color = "rgb(31, 119, 180)",
                size = 18,
                symbol = ["circle"; "square"; "diamond"; "cross"]
            )
    )

let trace3 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [12; 13; 14; 15],
        mode = "markers",
        marker =
            Marker(
                size = 18,
                line =
                    Line(
                        color = ["rgb(120,120,120)"; "rgb(120,120,120)"; "red"; "rgb(120,120,120)"],
                        width = [2; 2; 6; 2]
                    )
            )
    )

let chart =
    [trace1; trace2; trace3]
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
