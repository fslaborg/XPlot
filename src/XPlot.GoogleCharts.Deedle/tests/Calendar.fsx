#I "../../../bin"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open Deedle
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle
open System

let rnd = Random()

let data =
    series [
        for x in 1. .. 500. ->
            DateTime(2013, 1, 9).AddDays(x) => rnd.Next(0, 9)
    ]

let options =
    Options(
        title = "GitHub Contributions",
        height = 350
    )

let chart1 =
    data
    |> Chart.Calendar
    |> Chart.WithOptions options
    |> Chart.Show

let chart2 =
    ["GitHub Contributions" => data]
    |> Frame.ofColumns
    |> Chart.Calendar
    |> Chart.WithOptions options
    |> Chart.Show
