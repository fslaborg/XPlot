(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#I "../../../packages/MathNet.Numerics/lib/net40"
#r "XPlot.Plotly.dll"
#r "MathNet.Numerics.dll"

open MathNet.Numerics.Distributions
open XPlot.Plotly

let normal = new Normal(0., 1.0)

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

let uniform = new ContinuousUniform(0., 1.0)

let x1 =
    uniform.Samples()
    |> Seq.take 50

let y1 =
    uniform.Samples()
    |> Seq.take 50
    |> Seq.map (fun x -> x + 1.)

let x' = Seq.concat [x0; x1]
let y' = Seq.concat [y0; y1]

(** 
Plotly 2D Histograms
====================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-2d-histograms.fsx)

2D Histogram of a Bivariate Normal Distribution
-----------------------------------------------
*)

(*** define-output: chart1 ***)
Histogram2d(
    x = x,
    y = y
)
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
2D Histogram Binning and Styling Options
----------------------------------------
*)

(*** define-output: chart2 ***)
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
(*** include-it: chart2 ***)

(**
2D Histogram Overlaid with a Scatter Chart
------------------------------------------
*)

(*** define-output: chart3 ***)
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

[trace1 :> Trace; trace2 :> _; trace3 :> _]
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
|> Chart.WithLayout layout
(*** include-it: chart3 ***)
