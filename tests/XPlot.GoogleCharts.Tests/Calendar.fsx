﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open System 
open XPlot.GoogleCharts
  
let data =
    let rnd = Random()
    [
        for x in 1. .. 600. ->
            DateTime(2013, 1, 9).AddDays(x), rnd.Next(0, 5)
    ]
 
let options =
    Options(
        title = "GitHub Contributions",
        height = 350
    )
 
let chart =
    data
    |> Chart.Calendar
    |> Chart.WithOptions options
    |> Chart.Show