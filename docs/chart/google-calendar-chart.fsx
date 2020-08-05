(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts
open System

(**
Google Calendar Chart
=====================
*)
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
 
(*** define-output:calendar ***)  
data
|> Chart.Calendar
|> Chart.WithOptions options
(*** include-it:calendar ***)