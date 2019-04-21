﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let data =
    [
        "Rome", 2761477, 1285.31
        "Milan", 1324110, 181.76
        "Naples", 959574, 117.27
        "Turin", 907563, 130.17
        "Palermo", 655875, 158.9
        "Genoa", 607906, 243.60
        "Bologna", 380181, 140.7
        "Florence", 371282, 102.41
        "Fiumicino", 67370, 213.44
        "Anzio", 52192, 43.43
        "Ciampino", 38262, 11.
    ]
 
let options =
    Options(
        region = "IT",
        displayMode = "markers",
        colorAxis = ColorAxis(colors = [|"green"; "blue"|])
    ) 
 
let chart =
    data
    |> Chart.Geo
    |> Chart.WithLabels ["Population"; "Area"]
    |> Chart.WithOptions options
    |> Chart.Show