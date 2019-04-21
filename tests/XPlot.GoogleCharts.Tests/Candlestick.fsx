﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let data =
    [
        "Mon", 20, 28, 38, 45
        "Tue", 31, 38, 55, 66
        "Wed", 50, 55, 77, 80
        "Thu", 77, 77, 66, 50
        "Fri", 68, 66, 22, 15        
    ]
        
let chart =
    Chart.Candlestick data
    |> Chart.Show