(*** hide ***)
#I "../../../bin"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Heatmaps
===============

Basic Heatmap
-------------
*)
(*** define-output:chart ***)
let layout = Layout(title = "Basic Heatmap")

Heatmap(
    z = [[1; 20; 30]; [20; 1; 60]; [30; 60; 1]]
)
|> Chart.Plot
|> Chart.WithLayout layout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it:chart ***)

(*** hide ***)

//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/365.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Heatmap with Categorical Axis Labels
//------------------------------------
//*)
//
//let categoricalData =
//    Data(
//        [
//            Heatmap(
//                z = [[1; 20; 30; 50; 1]; [20; 1; 60; 80; 30]; [30; 60; 1; -10; 20]],
//                x = ["Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"],
//                y = ["Morning"; "Afternoon"; "Evening"]
//            )
//        ]
//    )
//
//let categoricalLayout = Layout(title = "Heatmap with Categorical Axis Labels")
//
//Figure(categoricalData, categoricalLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/369.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Custom Colorscale
//-----------------
//*)
//       
//let customZ =
//    [
//        for x in 1 .. 50 do
//            let lst = List.map (fun y -> y + x) [1..50]
//            yield lst
//    ]
//
//let colorScale =
//    [
//        [box 0.0; box "rgb(165,0,38)"]
//        [0.1111111111111111; "rgb(215,48,39)"]
//        [0.2222222222222222; "rgb(244,109,67)"]
//        [0.3333333333333333; "rgb(253,174,97)"]
//        [0.4444444444444444; "rgb(254,224,144)"]
//        [0.5555555555555556; "rgb(224,243,248)"]
//        [0.6666666666666666; "rgb(171,217,233)"]
//        [0.7777777777777778; "rgb(116,173,209)"]
//        [0.8888888888888888; "rgb(69,117,180)"]
//        [1.0; "rgb(49,54,149)"]
//    ]
//
//let customData =
//    Data(
//        [
//            Heatmap(
//                z = customZ,
//                colorscale = colorScale
//            )
//        ]
//    )
//
//let customLayout = Layout(title = "Custom Colorscale")
//
//Figure(customData, customLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/370.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//Earth Colorscale
//----------------
//*)
//       
//let earthZ =
//    [
//        for x in 1 .. 50 ->
//            List.map (fun y -> y + x) [1..50]
//    ]
//
//let earthData =
//    Data(
//        [
//            Heatmap(
//                z = earthZ,
//                colorscale = "Earth"
//            )
//        ]
//    )
//
//let earthLayout = Layout(title = "Earth Colorscale")
//
//Figure(earthData, earthLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/371.embed?width=640&height=480" ></iframe>
//*)
//
//(**
//YIGnBu Colorscale
//-----------------
//*)
//       
//let yignbuZ =
//    [
//        for x in 1 .. 50 ->
//            List.map (fun y -> y + x) [1..50]
//    ]
//
//let yignbuData =
//    Data(
//        [
//            Heatmap(
//                z = yignbuZ,
//                colorscale = "YIGnBu"
//            )
//        ]
//    )
//
//let yignbuLayout = Layout(title = "YIGnBu Colorscale")
//
//Figure(yignbuData, yignbuLayout)
//
//(**
//<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/372.embed?width=640&height=480" ></iframe>
//*)
