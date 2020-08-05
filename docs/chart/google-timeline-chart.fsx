(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts
open System

(**
Google Timeline Chart
=====================
*)
let data = 
    [
        "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
        "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
        "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
    ]
(*** define-output:timeline ***) 
data
|> Chart.Timeline
|> Chart.WithLabels ["Start"; "End"]
(*** include-it:timeline ***)
