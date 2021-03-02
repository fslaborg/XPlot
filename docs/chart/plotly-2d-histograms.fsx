(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/MathNet.Numerics/lib/netstandard2.0/MathNet.Numerics.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.Plotly"
#r "nuget: MathNet.Numerics"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly 2D Histograms

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=plotly-2d-histograms.ipynb)

2D Histogram of a Bivariate Normal Distribution
-----------------------------------------------
*)
open MathNet.Numerics.Distributions
open XPlot.Plotly

let normal = Normal(0., 1.0)

let x =
    normal.Samples()
    |> Seq.take 500

let y =
    normal.Samples()
    |> Seq.take 500
    |> Seq.map (fun x -> x + 1.)

let x0 =
    normal.Samples()
    |> Seq.take 100
    |> Seq.map (fun x -> x / 5. + 0.5)

let y0 =
    normal.Samples()
    |> Seq.take 100
    |> Seq.map (fun x -> x / 5. + 0.5)

let uniform = ContinuousUniform(0., 1.0)

let x1 =
    uniform.Samples()
    |> Seq.take 50

let y1 =
    uniform.Samples()
    |> Seq.take 50
    |> Seq.map (fun x -> x + 1.)

let x' = Seq.concat [x0; x1]
let y' = Seq.concat [y0; y1]

let chart1 =
    Histogram2d(
        x = x,
        y = y
    )
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart1
#endif // IPYNB

(*** hide ***)
chart1.GetHtml()
(*** include-it-raw ***)

(**
2D Histogram Binning and Styling Options
----------------------------------------
*)

let chart2 =
    Histogram2d(
        x = x,
        y = y,
        histnorm = "probability",
        autobinx = false,
        xbins =
            Xbins(
                start = -3.,
                ``end`` = 3.,
                size = 0.1
            ),
        autobiny = false,
        ybins =
            Ybins(
                start = -2.5,
                ``end`` = 4.,
                size = 0.1
            ),
        colorscale =
            [
                [box 0; box "rgb(12,51,131)"]
                [0.25; "rgb(10,136,186)"]
                [0.5; "rgb(242,211,56)"]
                [0.75; "rgb(242,143,56)"]
                [1; "rgb(217,30,30)"]
            ]
    )
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart2
#endif // IPYNB
(*** hide ***)
chart2.GetHtml()
(*** include-it-raw ***)

(**
2D Histogram Overlaid with a Scatter Chart
------------------------------------------
*)

let trace1 =
    Scatter(
        x = x0,
        y = y0,
        mode = "markers",
        marker =
            Marker(
                symbol = "circle",
                opacity = 0.7
            )
    )

let trace2 =
    Scatter(
        x = x1,
        y = y1,
        mode = "markers",
        marker =
            Marker(
                symbol = "square",
                opacity = 0.7
            )
    )

let trace3 =
    Histogram2d(
        x = x',
        y = y'
    )

let layout = Layout(showlegend = false)

let chart3 =
    [trace1 :> Trace; trace2 :> _; trace3 :> _]
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
    |> Chart.WithLayout layout
(*** condition: ipynb ***)
#if IPYNB
chart3
#endif // IPYNB
(*** condition: prepare ***)
chart3.GetHtml()
(*** include-it-raw ***)
