#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let treemap1 =
    let data =
        [
            "Global", "", 0
            "America", "Global", 0
            "Europe", "Global", 0
            "Asia", "Global", 0
            "Australia", "Global", 0
            "Africa", "Global", 0
            "Brazil", "America", 11
            "USA", "America", 52
            "Mexico", "America", 24
            "Canada", "America", 16
            "France", "Europe", 42
            "Germany", "Europe", 31
            "Sweden", "Europe", 22
            "Italy", "Europe", 17
            "UK", "Europe", 21
            "China", "Asia", 36
            "Japan", "Asia", 20
            "India", "Asia", 40
            "Laos", "Asia", 4
            "Mongolia", "Asia", 1
            "Israel", "Asia", 12
            "Iran", "Asia", 18
            "Pakistan", "Asia", 11
            "Egypt", "Africa", 21
            "S. Africa", "Africa", 30
            "Sudan", "Africa", 12
            "Congo", "Africa", 10
            "Zaire", "Africa", 8
        ]

    let options =
        Options(
            minColor = "#f00",
            midColor = "#ddd",
            maxColor = "#0d0",
            headerHeight = 15,
            fontColor = "black",
            showScale = true        
        )

    data
    |> Chart.Treemap
    |> Chart.WithLabels  ["Location"; "Parent"; "Market trade volume (size)"]
    |> Chart.WithOptions options
    |> Chart.Show

let treemap2 =
    let data =
        [
            "Global", "", 0, 0
            "America", "Global", 0, 0
            "Europe", "Global", 0, 0
            "Asia", "Global", 0, 0
            "Australia", "Global", 0, 0
            "Africa", "Global", 0, 0
            "Brazil", "America", 11, 10
            "USA", "America", 52, 31
            "Mexico", "America", 24, 12
            "Canada", "America", 16, -23
            "France", "Europe", 42, -11
            "Germany", "Europe", 31, -2
            "Sweden", "Europe", 22, -13
            "Italy", "Europe", 17, 4
            "UK", "Europe", 21, -5
            "China", "Asia", 36, 4
            "Japan", "Asia", 20, -12
            "India", "Asia", 40, 63
            "Laos", "Asia", 4, 34
            "Mongolia", "Asia", 1, -5
            "Israel", "Asia", 12, 24
            "Iran", "Asia", 18, 13
            "Pakistan", "Asia", 11, -52
            "Egypt", "Africa", 21, 0
            "S. Africa", "Africa", 30, 43
            "Sudan", "Africa", 12, 2
            "Congo", "Africa", 10, 12
            "Zaire", "Africa", 8, 10
        ]

    let options =
        Options(
            minColor = "#f00",
            midColor = "#ddd",
            maxColor = "#0d0",
            headerHeight = 15,
            fontColor = "black",
            showScale = true        
        )

    data
    |> Chart.Treemap
    |> Chart.WithOptions options
    |> Chart.WithLabels  ["Location"; "Parent"; "Market trade volume (size)"; "Market increase/decrease (color)"]
    |> Chart.Show
