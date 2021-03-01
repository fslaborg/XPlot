(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Timeline Chart
=====================
*)
open XPlot.GoogleCharts
open System

let data =
    [
        "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
        "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3)
        "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)
    ]

let chart =
    data
    |> Chart.Timeline
    |> Chart.WithLabels ["Start"; "End"]
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
