#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let options = Options(showTip = true)

let chart1 =
    [
        "China", "China: 1,363,800,000"
        "India", "India: 1,242,620,000"
        "US", "US: 317,842,000"
        "Indonesia", "Indonesia: 247,424,598"
        "Brazil", "Brazil: 201,032,714"
        "Pakistan", "Pakistan: 186,134,000"
        "Nigeria", "Nigeria: 173,615,000"
        "Bangladesh", "Bangladesh: 152,518,015"
        "Russia", "Russia: 146,019,512"
        "Japan", "Japan: 127,120,000"
    ]
    |> Chart.Map
    |> Chart.WithOptions options
    |> Chart.WithHeight 420
    |> Chart.Show
            
let chart2 =
    [
        37.4232, -122.0853, "Work"
        37.4289, -122.1697, "University"
        37.6153, -122.3900, "Airport"
        37.4422, -122.1731, "Shopping"            
    ]
    |> Chart.Map
    |> Chart.WithOptions options
    |> Chart.Show
