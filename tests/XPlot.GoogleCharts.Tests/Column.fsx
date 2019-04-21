﻿#load "../packages/XPlot.GoogleCharts.1.0.1/XPlot.GoogleCharts.fsx"
 
open XPlot.GoogleCharts
 
let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
 
let options = Options()
 
options.title <- "Company Performance"
 
let hAxisOptions = Axis()
hAxisOptions.title <- "Year"
hAxisOptions.titleTextStyle <- TextStyle(color = "red")
options.hAxis <- hAxisOptions
 
let chart =
    [sales; expenses]
    |> Chart.Column
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show