(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

(**
Google Area Chart
=================
*)
(*** define-output:area ***)
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

[sales; expenses]
|> Chart.Area
|> Chart.WithLabels ["Sales"; "Expenses"]
|> Chart.WithOptions options
(*** include-it:area ***)