#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"

open System
open XPlot.GoogleCharts

let rnd = Random()

let data =
    [
        for x in 1. .. 500. ->
            DateTime(2013, 1, 9).AddDays(x), rnd.Next(0, 9)
    ]

let options =
    Options(
        title = "GitHub Contributions",
        height = 350
    )

let test1 =
    data
    |> Chart.Calendar
    |> Chart.WithOptions options
    |> Chart.Show

let test2 =
    options.calendar <- Calendar(cellSize = 10)
    data
    |> Chart.Calendar
    |> Chart.WithOptions options
    |> Chart.Show
