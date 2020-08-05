(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Sankey Diagram
=====================
*)
let data = 
    [
        "A", "X", 5 
        "A", "Y", 7 
        "A", "Z", 6 
        "B", "X", 2 
        "B", "Y", 9 
        "B", "Z", 4
    ]

(*** define-output:sankey ***) 
data
|> Chart.Sankey
|> Chart.WithHeight 300
|> Chart.WithWidth 600
(*** include-it:sankey ***)
