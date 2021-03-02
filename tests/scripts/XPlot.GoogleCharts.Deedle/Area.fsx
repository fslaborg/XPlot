#I "../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"

open Deedle
open XPlot.GoogleCharts

let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

let chart1 =
    sales
    |> Chart.Area
    |> Chart.WithTitle "Company Sales"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.Show

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

let chart3 =
    ["Sales" => sales; "Expenses" => expenses]
    |> Frame.ofColumns
    |> Chart.Area
    |> Chart.WithTitle "Company Performance"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.WithId "my_chart"
    |> Chart.WithLegend true
    |> Chart.Show

let options = Options()
options.title <- "Company Performance"
let hAxisOptions = Axis()
hAxisOptions.title <- "Year"
hAxisOptions.titleTextStyle <- TextStyle(color = "#333")
options.hAxis <- hAxisOptions
options.vAxis <- Axis(minValue = 0)

let chart4 =
    ["Sales" => sales; "Expenses" => expenses]
    |> Frame.ofColumns
    |> Chart.Area
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show
