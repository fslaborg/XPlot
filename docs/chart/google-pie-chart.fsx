(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Pie Chart
================
*)
let data = 
    [
        "Work", 11
        "Eat", 2
        "Commute", 2
        "Watch TV", 2
        "Sleep", 7
    ]

(*** define-output:pie ***) 
data
|> Chart.Pie
|> Chart.WithTitle "My Daily Activities"
|> Chart.WithLegend true
(*** include-it:pie ***)
