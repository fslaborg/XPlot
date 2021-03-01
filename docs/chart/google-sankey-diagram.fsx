(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Sankey Diagram
=====================
*)
open XPlot.GoogleCharts

let data =
    [
        "A", "X", 5
        "A", "Y", 7
        "A", "Z", 6
        "B", "X", 2
        "B", "Y", 9
        "B", "Z", 4
    ]

let chart =
    data
    |> Chart.Sankey
    |> Chart.WithHeight 300
    |> Chart.WithWidth 600
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
