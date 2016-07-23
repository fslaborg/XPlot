(*** hide ***)
#I "../../../bin"
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

Basic Histogram
---------------
*)
(*** define-output:chart ***)
Histogram(x = basicX)
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it:chart ***)

(*** hide ***)

//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/388.embed?width=640&height=480" ></iframe>
//*)
//      
//(**
//Horizontal Histogram
//--------------------
//*)
//       
//let horizontalData = Data([Histogram(y = horizontalY)])
//
//let horizontalLayout = Layout(title = "Horizontal Histogram")
//
//Figure(horizontalData, horizontalLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/389.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Overlaid Histogram
//------------------
//*)
//       
//let overlaidTrace1 =
//    Histogram(
//        x = overlaidX0,
//        opacity = 0.75
//    )
//
//let overlaidTrace2 =
//    Histogram(
//        x = overlaidX1,
//        opacity = 0.75
//    )
//
//let overlaidLayout =
//    Layout(
//        barmode = "overlay",
//        title = "Overlaid Histogram"
//    )
//
//Figure(Data.From [overlaidTrace1; overlaidTrace2], overlaidLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/390.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Stacked Histograms
//------------------
//*)
//       
//let stackedTrace1 = Histogram(x = stackedX0)
//
//let stackedTrace2 = Histogram(x = stackedX1)
//
//let stackedLayout =
//    Layout(
//        barmode = "stack",
//        title = "Stacked Histograms"
//    )
//
//Figure(Data.From [stackedTrace1; stackedTrace2], stackedLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/394.embed?width=640&height=480" ></iframe>
//*)
//      
//(**
//Colored and Styled Histograms
//-----------------------------
//*)
//
//let coloredTrace1 =
//    Histogram(
//        x = coloredX0,
//        histnorm = "count",
//        name = "control",
//        autobinx = false,
//        xbins =
//            XBins(
//                start = -3.2,
//                ``end`` = 2.8,
//                size = 0.2
//            ),
//        marker =
//            Marker(
//                color = "fuchsia",
//                line =
//                    Line(
//                        color = "grey",
//                        width = 0
//                    ),
//                opacity = 0.75
//            )
//    )
//
//let coloredTrace2 =
//    Histogram(
//        x = coloredX1,
//        name = "experimental",
//        autobinx = false,
//        xbins =
//            XBins(
//                start = -1.8,
//                ``end`` = 4.2,
//                size = 0.2
//            ),
//        marker = Marker(color = "rgb(255, 217, 102)"),
//        opacity = 0.75
//    )
//
//let coloredLayout =
//    Layout(
//        title = "Colored and Styled Histograms",
//        xaxis = XAxis(title = "Value"),
//        yaxis = YAxis(title = "Count"),
//        barmode = "overlay",
//        bargap = 0.25,
//        bargroupgap = 0.3
//    )
//
//Figure(Data.From [coloredTrace1; coloredTrace2], coloredLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/395.embed?width=640&height=480" ></iframe>
//*)
