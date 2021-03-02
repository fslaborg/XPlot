#I "../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Column
|> Chart.Show

// single series
sales
|> Chart.Column
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Column
|> Chart.Show

let options =
    Options(
        title = "Company Performance",
        hAxis =
            Axis(
                title = "Year",
                titleTextStyle = TextStyle(color = "red")
            )
    )

let test1 =
    [sales; expenses]
    |> Chart.Column
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.Show

let test2 =
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
    |> Chart.Column
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Fantasy & Sci Fi"; "Romance"; "Mystery/Crime"; "General"; "Western"; "Literature"]
    |> Chart.Show
