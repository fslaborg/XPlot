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
Google Treemap Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-treemap-chart.ipynb)

*)
open XPlot.GoogleCharts

let data =
    [
        "Global", "", 0, 0
        "America", "Global", 0, 0
        "Europe", "Global", 0, 0
        "Asia", "Global", 0, 0
        "Australia", "Global", 0, 0
        "Africa", "Global", 0, 0
        "Brazil", "America", 11, 10
        "USA", "America", 52, 31
        "Mexico", "America", 24, 12
        "Canada", "America", 16, -23
        "France", "Europe", 42, -11
        "Germany", "Europe", 31, -2
        "Sweden", "Europe", 22, -13
        "Italy", "Europe", 17, 4
        "UK", "Europe", 21, -5
        "China", "Asia", 36, 4
        "Japan", "Asia", 20, -12
        "India", "Asia", 40, 63
        "Laos", "Asia", 4, 34
        "Mongolia", "Asia", 1, -5
        "Israel", "Asia", 12, 24
        "Iran", "Asia", 18, 13
        "Pakistan", "Asia", 11, -52
        "Egypt", "Africa", 21, 0
        "S. Africa", "Africa", 30, 43
        "Sudan", "Africa", 12, 2
        "Congo", "Africa", 10, 12
        "Zaire", "Africa", 8, 10
    ]

let options =
    Options(
        minColor = "#f00",
        midColor = "#ddd",
        maxColor = "#0d0",
        headerHeight = 15,
        fontColor = "black",
        showScale = true
    )

let chart =
    data
    |> Chart.Treemap
    |> Chart.WithOptions options
    |> Chart.WithLabels
        [
            "Location"
            "Parent"
            "Market trade volume (size)"
            "Market increase/decrease (color)"
        ]
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
