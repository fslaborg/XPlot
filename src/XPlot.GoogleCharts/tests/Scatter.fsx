﻿#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let options =
    Options(
        title = "Age vs. Weight comparison",
        hAxis = Axis(title = "Age", minValue = 0, maxValue = 15),
        vAxis = Axis(title = "Weight", minValue = 0, maxValue = 15)
    )

let chart =
    [8., 12.; 4., 5.5; 11., 14.; 4., 5.; 3., 3.5; 6.5, 7.]
    |> Chart.Scatter
    |> Chart.WithOptions options
    |> Chart.Show


let rnd = new System.Random(0)
let data = [for i in 1 .. 1000 -> (rnd.Next(10),rnd.Next(10))]

[data]
|> Chart.Scatter
|> Chart.Show
