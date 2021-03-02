(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Gauge Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=google-gauge-chart.ipynb)

*)
open XPlot.GoogleCharts

let data = ["Memory", 80; "CPU", 55; "Network", 68]

let options =
    Options(
        width = 400,
        height = 120,
        redFrom = 90,
        redTo = 100,
        yellowFrom = 75,
        yellowTo = 90,
        minorTicks = 5
    )

let chart =
    Chart.Gauge data
    |> Chart.WithOptions options
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
