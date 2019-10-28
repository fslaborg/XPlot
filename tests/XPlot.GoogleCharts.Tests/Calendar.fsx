#I "../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"
 
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