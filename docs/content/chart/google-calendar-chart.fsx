(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"
open XPlot.GoogleCharts
open System

let data =
    let rnd = Random()
    [
        for x in 1. .. 600. ->
            DateTime(2013, 1, 9).AddDays(x), rnd.Next(0, 5)
    ]

(**
Google Calendar Chart
=====================
*)
(*** define-output:calendar ***)  
let options =
    Options(
        title = "GitHub Contributions",
        height = 350
    )
 
data
|> Chart.Calendar
|> Chart.WithOptions options
(*** include-it:calendar ***)