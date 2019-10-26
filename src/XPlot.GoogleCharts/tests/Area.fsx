#I "../../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Area
|> Chart.Show

// single series
sales
|> Chart.Area
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Area
|> Chart.Show

// with options
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
|> Chart.WithOptions options
|> Chart.Show
