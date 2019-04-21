#I "../../../bin/XPlot.GoogleCharts/net45"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Line
|> Chart.Show

// single series
sales
|> Chart.Line
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Line
|> Chart.Show
        
// spline
let chart3 =
    let options =
        Options(
            title = "Company Performance",
            curveType = "function",
            legend = Legend(position = "bottom")
        )
    [sales; expenses]
    |> Chart.Line
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.Show

let a = [1, 10.0; 2, 11.0; 3, 12.0]
let b = [0, 5.0; 1, 6.0; 2, 7.0; 3, 8.0]

[a; b]
|> Chart.Line
|> Chart.Show

