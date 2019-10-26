#I "../../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Scatter
|> Chart.Show

// single series
sales
|> Chart.Scatter
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Scatter
|> Chart.Show

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
