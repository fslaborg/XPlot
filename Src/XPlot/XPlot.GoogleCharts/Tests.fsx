#r """.\bin\Release\XPlot.GoogleCharts.dll"""

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// single data series
let chart1 =
    sales
    |> Chart.Area
    |> Chart.WithTitle "Company Sales"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.Show

// multiple data series
let chart2 =
    [sales; expenses]
    |> Chart.Area
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithTitle "Company Performance"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.WithId "my_chart"
    |> Chart.WithLegend true
    |> Chart.Show

// custom options
let options = Options()

options.title <- "Company Performance"

let hAxisOptions = Axis()
hAxisOptions.title <- "Year"
hAxisOptions.titleTextStyle <- TextStyle(color = "#333")
options.hAxis <- hAxisOptions

options.vAxis <- Axis(minValue = 0)

let chart3 =
    [sales; expenses]
    |> Chart.Area
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show




