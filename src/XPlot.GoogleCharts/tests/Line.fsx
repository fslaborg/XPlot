#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
    
// single data series
let chart1 =
    sales
    |> Chart.Line
    |> Chart.Show

// multiple series
let chart2 =
    [sales; expenses]
    |> Chart.Line
    |> Chart.WithTitle "Company Performance"
    |> Chart.WithLabels ["Sales"; "Expenses"]
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
