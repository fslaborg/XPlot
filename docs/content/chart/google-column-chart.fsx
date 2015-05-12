(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"
open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

(**
Google Bar Chart
=================
*)
(*** define-output:column ***) 
let options =
    Options(
        title = "Company Performance",
        hAxis =
            Axis(
                title = "Year",
                titleTextStyle = TextStyle(color = "red")
            )
    )
  
[sales; expenses]
|> Chart.Column
|> Chart.WithOptions options
|> Chart.WithLabels ["Sales"; "Expenses"]
(*** include-it:column ***)