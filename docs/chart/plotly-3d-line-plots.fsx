(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.Plotly"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly 3D Line Plots
====================
3D Random Walk
--------------
*)
open System.IO
open XPlot.Plotly

let data =
    Path.Combine(__SOURCE_DIRECTORY__, "3DLineData.txt")
    |> File.ReadAllLines

let getData line =
    data.[line]
    |> fun x -> x.Split ','
    |> Array.map float

let x1 = getData 0
let y1 = getData 1
let z1 = getData 2
let x2 = getData 3
let y2 = getData 4
let z2 = getData 5
let x3 = getData 6
let y3 = getData 7
let z3 = getData 8

let trace1 =
    Scatter3d(
        x = x1,
        y = y1,
        z = z1,
        mode = "lines",
        marker =
            Marker(
                color = "#1f77b4",
                size = 12.,
                symbol = "circle",
                line =
                    Line(
                        color = "rgb(0,0,0)",
                        width = 0.
                    )
            ),
        line =
            Line(
                color = "#1f77b4",
                width = 1.
            )
    )

let trace2 =
    Scatter3d(
        x = x2,
        y= y2,
        z = z2,
        mode = "lines",
        marker =
            Marker(
                color = "#9467bd",
                size = 12.,
                symbol = "circle",
                line =
                    Line(
                        color = "rgb(0,0,0)",
                        width = 0.
                    )
            ),
        line =
            Line(
                color = "rgb(44, 160, 44)",
                width = 1.
            )
    )

let trace3 =
    Scatter3d(
        x = x3,
        y = y3,
        z = z3,
        mode = "lines",
        marker =
            Marker(
                color = "#bcbd22",
                size = 12.,
                symbol = "circle",
                line =
                    Line(
                        color = "rgb(0,0,0)",
                        width = 0.
                    )
            ),
        line =
            Line(
                color = "#bcbd22",
                width = 1.
            )
    )

let layout =
    Layout(
        title = "3D Random Walk",
        autosize = false,
        margin =
            Margin(
                l = 0.,
                r = 0.,
                b = 0.,
                t = 65.
            )
    )
let chart =
    [trace1; trace2; trace3]
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
