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
Google Map Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=google-map-chart.ipynb)

*)
open XPlot.GoogleCharts

let data =
    [
        "China", "China: 1,363,800,000"
        "India", "India: 1,242,620,000"
        "US", "US: 317,842,000"
        "Indonesia", "Indonesia: 247,424,598"
        "Brazil", "Brazil: 201,032,714"
        "Pakistan", "Pakistan: 186,134,000"
        "Nigeria", "Nigeria: 173,615,000"
        "Bangladesh", "Bangladesh: 152,518,015"
        "Russia", "Russia: 146,019,512"
        "Japan", "Japan: 127,120,000"
    ]

let options = Options(showTip = true)

let chart =
    data
    |> Chart.Map
    |> Chart.WithOptions options
    |> Chart.WithHeight 420
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
