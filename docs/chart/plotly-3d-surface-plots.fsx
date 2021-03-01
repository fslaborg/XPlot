(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.Plotly"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly 3D Surface Plots
=======================
Topographical 3D Surface Plot
-----------------------------
*)
open XPlot.Plotly
open System

let z =
    let rnd = Random()
    [ for _ in 1 .. 25 ->
        [ for _ in 1 .. 25 ->
            rnd.Next(0, 400)
        ]
    ]

let layout =
    Layout(
        autosize = false,
        margin =
            Margin(
                l = 65.,
                r = 50.,
                b = 65.,
                t = 90.
            )
    )

let chart =
    Surface(z = z)
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
