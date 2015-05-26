(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#nowarn "211"
#I "../../../bin"

#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

open System

let rnd = Random()

let randn count min max =
    [1 .. count]
    |> List.map (fun _ -> rnd.NextDouble() * (max - min) + min)

let y0 = randn 50 -1.86 1.67
let y1 = randn 50 -1.2 3.44

(**
Plotly Box Plots
================

Basic Box Plot
--------------
*)

let trace1 = Box(y = y0)
let trace2 = Box(y = y1)

Figure(Data.From [trace1; trace2])

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/206.embed?width=640&height=480" ></iframe>
*)

(**
Box Plot That Displays the Underlying Data
------------------------------------------
*)
       
let trace =
    Box(
        y = [0; 1; 1; 2; 3; 5; 8; 13; 21],
        boxpoints = "all",
        jitter = 0.3,
        pointpos = -1.8
    )

Figure(Data.From [trace])

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/207.embed?width=640&height=480" ></iframe>
*)

(**
Grouped Box Plot
----------------
*)
       
let x = ["day 1"; "day 1"; "day 1"; "day 1"; "day 1"; "day 1";
        "day 2"; "day 2"; "day 2"; "day 2"; "day 2"; "day 2"]

let groupedTrace1 =
    Box(
        y = [0.2; 0.2; 0.6; 1.0; 0.5; 0.4; 0.2; 0.7; 0.9; 0.1; 0.5; 0.3],
        x = x,
        name = "kale",
        marker = Marker(color = "#3D9970")
    )

let groupedTrace2 =
    Box(
        y = [0.6; 0.7; 0.3; 0.6; 0.0; 0.5; 0.7; 0.9; 0.5; 0.8; 0.7; 0.2],
        x = x,
        name = "radishes",
        marker = Marker(color = "#FF4136")
    )

let groupedTrace3 =
    Box(
        y = [0.1; 0.3; 0.1; 0.9; 0.6; 0.6; 0.9; 1.0; 0.3; 0.6; 0.8; 0.5],
        x = x,
        name = "carrots",
        marker = Marker(color = "#FF851B")
    )

let layout =
    Layout(
        yaxis =
            YAxis(
                title = "normalized moisture",
                zeroline = false
            ),
        boxmode = "group"
    )

Figure(Data.From [groupedTrace1; groupedTrace2; groupedTrace3], layout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/208.embed?width=640&height=480" ></iframe>
*)
