﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts

let salary =
    [
        "Mike", 10000
        "Jim", 8000
        "Alice", 12500
        "Bob", 7000
    ]
    |> List.map (fun (x, y) -> x, y :> value)

let fulltime =
    [
        "Mike", true
        "Jim", false
        "Alice", true
        "Bob", true
    ]
    |> List.map (fun (x, y) -> x, y :> value)
 
let table =
    [salary; fulltime]        
    |> Chart.Table
    |> Chart.WithOptions(Options(showRowNumber = true))
    |> Chart.WithLabels ["Name"; "Salary"; "Full Time Employee"]
    |> Chart.Show