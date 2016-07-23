(*** hide ***)
#I "../../../bin"
#r "XPlot.Plotly.dll"

open System
open XPlot.Plotly

let x =
    [
        DateTime(2013, 10, 4);
        DateTime(2013, 11, 5);
        DateTime(2013, 12, 6)
    ]

(**
Plotly Time Series
==================

Time Series Plot with DateTime Objects
--------------------------------------
*)
(*** define-output:chart ***)
let layout = Layout(title = "Time Series Plot with datetime Objects")

Scatter(
    x = x,
    y = [1; 3; 6]
)
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it:chart ***)

(*** hide ***)

//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/530.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Date Strings
//------------
//*)
//
//let stringData =
//    Data(
//        [
//            Scatter(
//                x =
//                    ["2013-10-04 22:23:00";
//                     "2013-11-04 22:23:00";
//                     "2013-12-04 22:23:00"],
//                y = [1; 3; 6]
//            )
//        ]
//    )
//
//let stringLayout = Layout(title = "Date Strings")
//
//Figure(stringData, stringLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/532.embed?width=640&height=480" ></iframe>
//*)
