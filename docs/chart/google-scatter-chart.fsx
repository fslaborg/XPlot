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
Google Scatter Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-scatter-chart.ipynb)

Creating scatter plots (or point charts) is easy. The following example generates 1000
points by multiplying two numbers for the X coordinate and two numbers for the Y coordinate:
*)
open XPlot.GoogleCharts

let rnd = System.Random()
let next() = rnd.NextDouble() * rnd.NextDouble()
let points = [ for i in 0 .. 100 -> next(), next() ]

let chart = points |> Chart.Scatter
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
