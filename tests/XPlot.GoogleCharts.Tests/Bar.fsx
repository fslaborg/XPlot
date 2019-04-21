﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
 
let options = Options()
 
options.title <- "Company Performance"
 
let vAxisOptions = Axis()
vAxisOptions.title <- "Year"
vAxisOptions.titleTextStyle <- TextStyle(color = "red")
options.vAxis <- vAxisOptions
 
let chart3 =
    [sales; expenses]
    |> Chart.Bar
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show