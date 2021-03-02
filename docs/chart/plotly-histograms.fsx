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
Plotly Histograms

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=plotly-histograms.ipynb)

Basic Histogram
---------------
*)
open XPlot.Plotly
open MathNet.Numerics.Distributions

let normal = Normal(0., 1.0)

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

let chart1 =
    Histogram(x = basicX)
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
Horizontal Histogram
--------------------
*)

(*** define-output: chart2 ***)
let horizontalLayout = Layout(title = "Horizontal Histogram")

let chart2 =
    Histogram(y = horizontalY)
    |> Chart.Plot
    |> Chart.WithLayout horizontalLayout
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
Overlaid Histogram
------------------
*)

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

let chart3 =
    [overlaidTrace1; overlaidTrace2]
    |> Chart.Plot
    |> Chart.WithLayout overlaidLayout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart3
#endif // IPYNB
(*** hide ***)
chart3.GetHtml()
(*** include-it-raw ***)

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

let chart4 =
    [stackedTrace1; stackedTrace2]
    |> Chart.Plot
    |> Chart.WithLayout stackedLayout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart4
#endif // IPYNB
(*** hide ***)
chart4.GetHtml()
(*** include-it-raw ***)

(**
Colored and Styled Histograms
-----------------------------
*)

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

let chart5 =
    [coloredTrace1; coloredTrace2]
    |> Chart.Plot
    |> Chart.WithLayout coloredLayout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart5
#endif // IPYNB
(*** hide ***)
chart5.GetHtml()
(*** include-it-raw ***)
