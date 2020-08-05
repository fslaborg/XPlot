(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Area Chart
=================
*)
let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

let options =
    Options(
        title = "Company Performance",
        hAxis =
            Axis(
                title = "Year",
                titleTextStyle = TextStyle(color = "#333")
            ),
        vAxis = Axis(minValue = 0)
    )

(*** define-output:area ***)
[sales; expenses]
|> Chart.Area
|> Chart.WithLabels ["Sales"; "Expenses"]
|> Chart.WithOptions options
(*** include-it:area ***)