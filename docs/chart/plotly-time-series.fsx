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
Plotly Time Series

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=plotly-time-series.ipynb)

Time Series Plot with DateTime Objects
--------------------------------------
*)
open System
open XPlot.Plotly

let x =
    [
        DateTime(2013, 10, 4);
        DateTime(2013, 11, 5);
        DateTime(2013, 12, 6)
    ]

let layout = Layout(title = "Time Series Plot with datetime Objects")

let chart1 =
    Scatter(
        x = x,
        y = [1; 3; 6]
    )
    |> Chart.Plot
    |> Chart.WithLayout layout
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
Date Strings
------------
*)

let stringLayout = Layout(title = "Date Strings")

let chart2 =
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
(*** condition: ipynb ***)
#if IPYNB
chart2
#endif // IPYNB
(*** hide ***)
chart2.GetHtml()
(*** include-it-raw ***)
