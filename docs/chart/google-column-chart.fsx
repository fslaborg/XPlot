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
Google Column Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-column-chart.ipynb)

*)
open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

let options =
    Options(
        title = "Company Performance",
        hAxis =
            Axis(
                title = "Year",
                titleTextStyle = TextStyle(color = "red")
            )
    )

let chart =
    [sales; expenses]
    |> Chart.Column
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Sales"; "Expenses"]
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
