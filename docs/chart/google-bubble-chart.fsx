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
Google Bubble Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=google-bubble-chart.ipynb)

*)
open XPlot.GoogleCharts

let data =
    [
        "CAN", 80.66, 1.67, "North America", 33739900
        "DEU", 79.84, 1.36, "Europe", 81902307
        "DNK", 78.6, 1.84, "Europe", 5523095
        "EGY", 72.73, 2.78, "Middle East", 79716203
        "GBR", 80.05, 2., "Europe", 61801570
        "RUS", 68.6, 1.54, "Europe", 141850000
        "USA", 78.09, 2.05, "North America", 307007000
    ]

let options =
    Options(
        title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
        hAxis = Axis(title = "Life Expectancy"),
        vAxis = Axis(title = "Fertility Rate"),
        bubble = Bubble(textStyle = TextStyle(fontSize = 11))
    )

let chart =
    data
    |> Chart.Bubble
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Life Expectancy"; "Fertility Rat"; "Region"; "Population"]
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
