#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
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
