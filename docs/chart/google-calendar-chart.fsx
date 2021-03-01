(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Calendar Chart
=====================
*)
open XPlot.GoogleCharts
open System

let data =
    let rnd = Random()
    [
        for x in 1. .. 600. ->
            DateTime(2013, 1, 9).AddDays(x), rnd.Next(0, 5)
    ]

let options =
    Options(
        title = "GitHub Contributions",
        height = 350
    )

let chart =
    data
    |> Chart.Calendar
    |> Chart.WithOptions options
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
