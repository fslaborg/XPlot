#I "../../bin/XPlot.GoogleCharts/net45"
#r "XPlot.GoogleCharts.dll"
 
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