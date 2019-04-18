#I "../../../bin/XPlot.GoogleCharts/net45"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let test1 =
    [
        "Germany", 200
        "United States", 300
        "Brazil", 400
        "Canada", 500
        "France", 600
        "RU", 700
    ]
    |> Chart.Geo
    |> Chart.WithLabel "Popularity"
    |> Chart.Show

let test2 =
    let options =
        Options(
            region = "IT",
            displayMode = "markers",
            colorAxis = ColorAxis(colors = [|"green"; "blue"|])
        ) 
    [
        "Rome", 2761477, 1285.31
        "Milan", 1324110, 181.76
        "Naples", 959574, 117.27
        "Turin", 907563, 130.17
        "Palermo", 655875, 158.9
        "Genoa", 607906, 243.60
        "Bologna", 380181, 140.7
        "Florence", 371282, 102.41
        "Fiumicino", 67370, 213.44
        "Anzio", 52192, 43.43
        "Ciampino", 38262, 11.
    ]
    |> Chart.Geo
    |> Chart.WithLabels ["Population"; "Area"]
    |> Chart.WithOptions options
    |> Chart.Show

let test3 =
    let options =
        Options(
            sizeAxis = SizeAxis(minValue = 0, maxValue = 100),
            region = "155",
            displayMode = "markers",
            colorAxis = ColorAxis(colors = [|"#e7711c"; "#4374e0"|])
        ) 
    [
        "France", 65700000, 50
        "Germany", 81890000, 27
        "Poland", 38540000, 23
    ]
    |> Chart.Geo
    |> Chart.WithLabels ["Population"; "Area Percentage"]
    |> Chart.WithOptions options
    |> Chart.Show

let test4 =
    let options = Options(displayMode = "text")
    [
        "South America", 600
        "Canada", 500
        "France", 600
        "Russia", 700
        "Australia", 600
    ]
    |> Chart.Geo
    |> Chart.WithLabel "Popularity"
    |> Chart.WithOptions options
    |> Chart.Show


let test5 =
    let options = Options (
        region = "IT",
        displayMode = "markers",
        colorAxis = ColorAxis(colors = [|"green"; "blue"|])
    )
    [
        41.890, 12.49, 25, 20
        43.890, 11.49, 30, 20
        45.467,  9.189, 35, 20
    ]
    |> Chart.Geo
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Popularity"; "Area"]
    |> Chart.Show
