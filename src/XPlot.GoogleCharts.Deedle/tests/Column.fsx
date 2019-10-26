#I "../../../bin/XPlot.GoogleCharts.Deedle/net472"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"

open Deedle
open XPlot.GoogleCharts

let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

let chart1 =
    sales
    |> Chart.Column
    |> Chart.WithTitle "Company Sales"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.Show

let chart2 =
    [sales; expenses]
    |> Chart.Column
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithTitle "Company Performance"
    |> Chart.WithXTitle "Year"
    |> Chart.WithYTitle "Amount"
    |> Chart.WithLegend true
    |> Chart.Show

let options = Options()

options.title <- "Company Performance"

let hAxisOptions = Axis()
hAxisOptions.title <- "Year"
hAxisOptions.titleTextStyle <- TextStyle(color = "red")
options.hAxis <- hAxisOptions

let chart3 =
    ["Sales" => sales; "Expenses" => expenses]
    |> Frame.ofColumns
    |> Chart.Column
    |> Chart.WithOptions options
    |> Chart.WithLegend true
    |> Chart.Show

let chart4 =
    let fantasy = series ["2010" => 10; "2020" => 16; "2030" => 28]
    let romance = series ["2010" => 24; "2020" => 22; "2030" => 19]
    let mystery = series ["2010" => 20; "2020" => 23; "2030" => 29]
    let general = series ["2010" => 32; "2020" => 30; "2030" => 30]
    let western = series ["2010" => 18; "2020" => 16; "2030" => 12]
    let literature = series ["2010" => 5; "2020" => 9; "2030" => 13]

    let options =
        Options(
            width = 600,
            height = 400,
            legend = Legend(position = "top", maxLines = 3),
            bar = Bar(groupWidth = "75%"),
            isStacked = true
        )

    [fantasy; romance; mystery; general; western; literature]
    |> Chart.Column
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Fantasy & Sci Fi"; "Romance"; "Mystery/Crime"; "General"; "Western"; "Literature"]
    |> Chart.Show
