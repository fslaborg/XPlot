#I "../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

["", 1, 10, "", 40; "",  2, 11, "", 60; "",  3, 12, "", 80; "", 4, 13, "", 100]
|> Chart.Bubble
|> Chart.Show

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

let test1 =
    data
    |> Chart.Bubble
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Life Expectancy"; "Fertility Rate"; "Region"; "Population"]
    |> Chart.Show

let chart2 =
    let options = Options(colorAxis = ColorAxis(colors = [|"yellow"; "red"|]))
    [
        "1", 80, 167, 120
        "2", 79, 136, 130
        "3", 78, 184, 50
        "4", 72, 278, 230
        "5", 81, 200, 210
        "6", 72, 170, 100
        "7", 68, 477, 80        
    ]
    |> Chart.Bubble
    |> Chart.WithOptions options
    |> Chart.WithLabels ["X"; "Y"; "Temperature"]
    |> Chart.Show
