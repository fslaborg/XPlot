(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Bar Chart
=================
*)
let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

(*** define-output:bar ***) 
let options =
    Options(
        title = "Company Performance",
        vAxis =
            Axis(
                title = "Year",
                titleTextStyle = TextStyle(color = "red")
            )
    )
 
[sales; expenses]
|> Chart.Bar
|> Chart.WithOptions options
|> Chart.WithLabels ["Sales"; "Expenses"]
(*** include-it:bar ***)
