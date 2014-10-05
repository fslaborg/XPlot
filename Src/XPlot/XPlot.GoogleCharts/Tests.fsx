#r """.\bin\Release\XPlot.GoogleCharts.dll"""

open System
open XPlot.GoogleCharts

module Annotation =

    let chart1 =
        [
            DateTime(2314, 2, 15), 12400, "", ""
            DateTime(2314, 2, 16), 24045, "Lalibertines", "First encounter"
            DateTime(2314, 2, 17), 35022, "Lalibertines", "They are very tall"
            DateTime(2314, 2, 18), 12284, "Lalibertines", "Attack on our crew!"
            DateTime(2314, 2, 19), 8476, "Lalibertines", "Heavy casualties"
            DateTime(2314, 2, 20), 0, "Lalibertines", "All crew lost"
        ]
        |> Chart.Annotation
        |> Chart.WithOptions(Options(displayAnnotations = true))
        |> Chart.WithLabels ["Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"]
        |> Chart.Show

    let chart2 =
        let kepler =
            [
                DateTime(2314, 3, 15), 12400, "", ""
                DateTime(2314, 3, 16), 24045, "Lalibertines", "First encounter"
                DateTime(2314, 3, 17), 35022, "Lalibertines", "They are very tall"
                DateTime(2314, 3, 18), 12284, "Lalibertines", "Attack on our crew!"
                DateTime(2314, 3, 19), 8476, "Lalibertines", "Heavy casualties"
                DateTime(2314, 3, 20), 0, "Lalibertines", "All crew lost"
            ]
        let gliese =
            [
                DateTime(2314, 3, 15), 10645, "", ""
                DateTime(2314, 3, 16), 12374, "", ""
                DateTime(2314, 3, 17), 15766, "Gallantors", "First Encounter"
                DateTime(2314, 3, 18), 34334, "Gallantors", "Statement of shared principles"
                DateTime(2314, 3, 19), 66467, "Gallantors", "Mysteries revealed"
                DateTime(2314, 3, 20), 79463, "Gallantors", "Omniscience achieved"
            ]
        [kepler; gliese]
        |> Chart.Annotation
        |> Chart.WithOptions(Options(displayAnnotations = true))
        |> Chart.WithLabels
            [
                "Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"
                "Gliese 163 mission"; "Gliese title"; "Gliese text"            
            ]
        |> Chart.Show

module Area =

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

module Bar =

    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

    // single data series
    let chart1 =
        sales
        |> Chart.Bar
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Amount"
        |> Chart.WithYTitle "Year"
        |> Chart.Show

    // multiple data series
    let chart2 =
        [sales; expenses]
        |> Chart.Bar
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Amount"
        |> Chart.WithYTitle "Year"
        |> Chart.WithLegend true
        |> Chart.Show

    // custom options
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

    // stacked
    let chart4 =
        let fantasy = ["2010", 10; "2020", 16; "2030", 28]
        let romance = ["2010", 24; "2020", 22; "2030", 19]
        let mystery = ["2010", 20; "2020", 23; "2030", 29]
        let general = ["2010", 32; "2020", 30; "2030", 30]
        let western = ["2010", 18; "2020", 16; "2030", 12]
        let literature = ["2010", 5; "2020", 9; "2030", 13]

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

    let options =
        Options(
            title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
            hAxis = Axis(title = "Life Expectancy"),
            vAxis = Axis(title = "Fertility Rate"),
            bubble = Bubble(textStyle = TextStyle(fontSize = 11))
        )

    let chart =
        data
        |> Chart.Bubble
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Life Expectancy"; "Fertility Rat"; "Region"; "Population"]
        |> Chart.WithLegend true
        |> Chart.Show




