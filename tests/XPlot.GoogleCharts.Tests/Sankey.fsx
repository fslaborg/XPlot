#I "../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"
 
open XPlot.GoogleCharts
 
let diagram =
    [
        "A", "X", 5 
        "A", "Y", 7 
        "A", "Z", 6 
        "B", "X", 2 
        "B", "Y", 9 
        "B", "Z", 4
    ]
    |> Chart.Sankey
    |> Chart.WithHeight 300
    |> Chart.WithWidth 600
    |> Chart.Show