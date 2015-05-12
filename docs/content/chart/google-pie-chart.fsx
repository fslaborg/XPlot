(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"
open XPlot.GoogleCharts

(**
Google Pie Chart
================
*)
(*** define-output:pie ***) 
[
    "Work", 11
    "Eat", 2
    "Commute", 2
    "Watch TV", 2
    "Sleep", 7
]
|> Chart.Pie
|> Chart.WithTitle "My Daily Activities"
|> Chart.WithLegend true
(*** include-it:pie ***)
