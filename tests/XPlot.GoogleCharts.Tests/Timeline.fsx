﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open System 
open XPlot.GoogleCharts
 
let timeline =
    [
        "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
        "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
        "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
    ]
    |> Chart.Timeline
    |> Chart.WithLabels ["Start"; "End"]
    |> Chart.Show