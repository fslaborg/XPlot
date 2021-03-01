(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.Plotly"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly Area Plots
=================
Basic Overlaid Area Chart
-------------------------
*)
open XPlot.Plotly

let trace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [0; 2; 3; 5],
        fill = "tozeroy"
    )

let trace2 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [3; 5; 1; 7],
        fill = "tonexty"
    )

let layout =
    Layout(
        title = "Basic Overlaid Area Chart",
        width = 700.,
        height = 500.
    )

let chart =
    [trace1; trace2]
    |> Chart.Plot
    |> Chart.WithLayout layout
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
