(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts
open System

(**
Google Timeline Chart
=====================
*)
(*** define-output:timeline ***) 
[
    "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
    "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
    "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
]
|> Chart.Timeline
|> Chart.WithLabels ["Start"; "End"]
(*** include-it:timeline ***)
