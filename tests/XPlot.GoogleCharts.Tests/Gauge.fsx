﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let data = ["Memory", 80; "CPU", 55; "Network", 68]
 
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
 
let chart =
    Chart.Gauge data
    |> Chart.WithOptions options
    |> Chart.Show