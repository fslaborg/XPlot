#I "../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"
 
open XPlot.GoogleCharts
 
let options = Options(showTip = true)
 
let chart =
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