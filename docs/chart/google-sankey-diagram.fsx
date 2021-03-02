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
Google Sankey Diagram

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-sankey-diagram.ipynb)

*)
open XPlot.GoogleCharts

let data =
    [
        "A", "X", 5
        "A", "Y", 7
        "A", "Z", 6
        "B", "X", 2
        "B", "Y", 9
        "B", "Z", 4
    ]

let chart =
    data
    |> Chart.Sankey
    |> Chart.WithHeight 300
    |> Chart.WithWidth 600
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
