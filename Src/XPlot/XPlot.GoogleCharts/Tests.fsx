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

open System

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
                DateTime(2314, 2, 15), 12400, "", ""
                DateTime(2314, 2, 16), 24045, "Lalibertines", "First encounter"
                DateTime(2314, 2, 17), 35022, "Lalibertines", "They are very tall"
                DateTime(2314, 2, 18), 12284, "Lalibertines", "Attack on our crew!"
                DateTime(2314, 2, 19), 8476, "Lalibertines", "Heavy casualties"
                DateTime(2314, 2, 20), 0, "Lalibertines", "All crew lost"
            ]
        let gliese =
            [
                DateTime(2314, 2, 15), 10645, "", ""
                DateTime(2314, 2, 16), 12374, "", ""
                DateTime(2314, 2, 17), 15766, "Gallantors", "First Encounter"
                DateTime(2314, 2, 18), 34334, "Gallantors", "Statement of shared principles"
                DateTime(2314, 2, 19), 66467, "Gallantors", "Mysteries revealed"
                DateTime(2314, 2, 20), 79463, "Gallantors", "Omniscience achieved"
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



