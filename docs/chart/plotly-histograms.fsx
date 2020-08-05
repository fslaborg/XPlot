(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#I "../../../packages/MathNet.Numerics/lib/net40"
#r "XPlot.Plotly.dll"
#r "MathNet.Numerics.dll"

open XPlot.Plotly
open MathNet.Numerics.Distributions

let normal = new Normal(0., 1.0)

let basicX =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let horizontalY =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let overlaidX0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let overlaidX1 = Array.map (fun x -> x + 1.) overlaidX0

let stackedX0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let stackedX1 = Array.map (fun x -> x + 1.) stackedX0

let coloredX0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let coloredX1 = Array.map (fun x -> x + 1.) coloredX0

(**
Plotly Histograms
=================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-histograms.fsx)

Basic Histogram
---------------
*)

(*** define-output: chart1 ***)
Histogram(x = basicX)
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
Horizontal Histogram
--------------------
*)

(*** define-output: chart2 ***)
let horizontalLayout = Layout(title = "Horizontal Histogram")
       
Histogram(y = horizontalY)
|> Chart.Plot
|> Chart.WithLayout horizontalLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart2 ***)

(**
Overlaid Histogram
------------------
*)

(*** define-output: chart3 ***)       
let overlaidTrace1 =
    Histogram(
        x = overlaidX0,
        opacity = 0.75
    )

let overlaidTrace2 =
    Histogram(
        x = overlaidX1,
        opacity = 0.75
    )

let overlaidLayout =
    Layout(
        barmode = "overlay",
        title = "Overlaid Histogram"
    )

[overlaidTrace1; overlaidTrace2]
|> Chart.Plot
|> Chart.WithLayout overlaidLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart3 ***)

(**
Stacked Histograms
------------------
*)

(*** define-output: chart4 ***)
let stackedTrace1 = Histogram(x = stackedX0)

let stackedTrace2 = Histogram(x = stackedX1)

let stackedLayout =
    Layout(
        barmode = "stack",
        title = "Stacked Histograms"
    )

[stackedTrace1; stackedTrace2]
|> Chart.Plot
|> Chart.WithLayout stackedLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart4 ***)

(**
Colored and Styled Histograms
-----------------------------
*)

(*** define-output: chart5 ***)
let coloredTrace1 =
    Histogram(
        x = coloredX0,
        histnorm = "count",
        name = "control",
        autobinx = false,
        xbins =
            Xbins(
                start = -3.2,
                ``end`` = 2.8,
                size = 0.2
            ),
        marker =
            Marker(
                color = "fuchsia",
                line =
                    Line(
                        color = "grey",
                        width = 0
                    ),
                opacity = 0.75
            )
    )

let coloredTrace2 =
    Histogram(
        x = coloredX1,
        name = "experimental",
        autobinx = false,
        xbins =
            Xbins(
                start = -1.8,
                ``end`` = 4.2,
                size = 0.2
            ),
        marker = Marker(color = "rgb(255, 217, 102)"),
        opacity = 0.75
    )

let coloredLayout =
    Layout(
        title = "Colored and Styled Histograms",
        xaxis = Xaxis(title = "Value"),
        yaxis = Yaxis(title = "Count"),
        barmode = "overlay",
        bargap = 0.25,
        bargroupgap = 0.3
    )

[coloredTrace1; coloredTrace2]
|> Chart.Plot
|> Chart.WithLayout coloredLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart5 ***)
