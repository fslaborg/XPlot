(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Gauge Chart
==================
*)
let data = ["Memory", 80; "CPU", 55; "Network", 68]

(*** define-output:gauge ***)  
let options =
    Options(
        width = 400,
        height = 120,
        redFrom = 90,
        redTo = 100,
        yellowFrom = 75,
        yellowTo = 90,
        minorTicks = 5
    )
 
Chart.Gauge data
|> Chart.WithOptions options
(*** include-it:gauge ***)