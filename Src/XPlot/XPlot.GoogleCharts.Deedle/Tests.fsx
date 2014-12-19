#load "../packages/XPlot.GoogleCharts.1.1.3/XPlot.GoogleCharts.fsx"
#r """../packages/Deedle.1.0.6/lib/net40/Deedle.dll"""
#r """./bin/Release/XPlot.GoogleCharts.Deedle.dll"""

open Deedle
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle
open System

module Area =

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

module Bar =

    let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
    let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

    let chart1 =
        sales
        |> Chart.Bar
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.Show

    let chart2 =
        [sales; expenses]
        |> Chart.Bar
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.WithLegend true
        |> Chart.Show

    let options = Options()

    options.title <- "Company Performance"

    let vAxisOptions = Axis()
    vAxisOptions.title <- "Year"
    vAxisOptions.titleTextStyle <- TextStyle(color = "red")
    options.vAxis <- vAxisOptions

    let chart3 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Bar
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
        |> Chart.Bar
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Fantasy & Sci Fi"; "Romance"; "Mystery/Crime"; "General"; "Western"; "Literature"]
        |> Chart.Show

module Bubble =

    type Correlation =
        {
            country : string
            lifeExpectancy : float
            fertilityRate : float
            region : string
            population : int
        }

        static member New (c, l, f, r, p) =
            {
                country = c
                lifeExpectancy = l
                fertilityRate = f
                region = r
                population = p
            }

    let data =
        [
            "CAN", 80.66, 1.67, "North America", 33739900
            "DEU", 79.84, 1.36, "Europe", 81902307
            "DNK", 78.6, 1.84, "Europe", 5523095
            "EGY", 72.73, 2.78, "Middle East", 79716203
            "GBR", 80.05, 2., "Europe", 61801570
            "RUS", 68.6, 1.54, "Europe", 141850000
            "USA", 78.09, 2.05, "North America", 307007000
        ]
        |> List.map Correlation.New

    let options =
        Options(
            title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
            hAxis = Axis(title = "Life Expectancy"),
            vAxis = Axis(title = "Fertility Rate"),
            bubble = Bubble(textStyle = TextStyle(fontSize = 11))
        )

    let chart1 =
        data
        |> Frame.ofRecords
        |> Frame.indexRowsString "country"     
        |> Chart.Bubble
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Life Expectancy"; "Fertility Rate"; "Region"; "Population"]
        |> Chart.WithLegend true
        |> Chart.Show

module Calendar =

    let rnd = Random()

    let data =
        series [
            for x in 1. .. 500. ->
                DateTime(2013, 1, 9).AddDays(x) => rnd.Next(0, 9)
        ]

    let options =
        Options(
            title = "GitHub Contributions",
            height = 350
        )

    let chart1 =
        data
        |> Chart.Calendar
        |> Chart.WithOptions options
        |> Chart.Show
