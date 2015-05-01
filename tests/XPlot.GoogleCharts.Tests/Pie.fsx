#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let chart =
    [
        "Work", 11
        "Eat", 2
        "Commute", 2
        "Watch TV", 2
        "Sleep", 7
    ]
    |> Chart.Pie
    |> Chart.WithTitle "My Daily Activities"
    |> Chart.WithLegend true
    |> Chart.Show