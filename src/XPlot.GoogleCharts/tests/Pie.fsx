#I "../../../bin/XPlot.GoogleCharts/net45"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

[
    "Work", 11
    "Eat", 2
    "Commute", 2
    "Watch TV", 2
    "Sleep", 7
]
|> Chart.Pie
|> Chart.Show

let chart1 =
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

let chart2 =
    let options =
        Options(
            title = "My Daily Activities",
            is3D = true
        )
    [
        "Work", 11
        "Eat", 2
        "Commute", 2
        "Watch TV", 2
        "Sleep", 7
    ]
    |> Chart.Pie
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show

let chart3 =
    let options =
        Options(
            title = "My Daily Activities",
            pieHole = 0.4
        )
    [
        "Work", 11
        "Eat", 2
        "Commute", 2
        "Watch TV", 2
        "Sleep", 7
    ]
    |> Chart.Pie
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show

let chart4 =
    let options =
        Options(
            pieSliceText = "label",
            title = "Swiss Language Use (100 degree rotation)",
            pieStartAngle = 100
        )
    [
        "German", 5.85
        "French", 1.66
        "Italian", 0.316
        "Romansh", 0.0791        
    ]
    |> Chart.Pie
    |> Chart.WithOptions options
    |> Chart.Show
