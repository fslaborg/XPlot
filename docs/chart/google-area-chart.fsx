(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Area Chart
=================
*)
open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

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

let chart =
    [sales; expenses]
    |> Chart.Area
    |> Chart.WithLabels ["Sales"; "Expenses"]
    |> Chart.WithOptions options
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
