(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#nowarn "211"
#I "../../../bin"
#I "../../../packages/MathNet.Numerics/lib/portable-net45+netcore45+MonoAndroid1+MonoTouch1"

#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"
#r "MathNet.Numerics.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

open System

let rnd = Random()

let randn count min max =
    [1 .. count]
    |> List.map (fun _ -> rnd.NextDouble() * (max - min) + min)

let y0 = randn 50 -1.86 1.67
let y1 = randn 50 -1.2 3.44

let trace1 = Box(y = y0)
let trace2 = Box(y = y1)

let data = Data [trace1; trace2]

let figure = Figure(data)

let plotlyResponse = figure.Plot("Basic Box Plot")

figure.Show()


      

Box Plot That Displays the Underlying Data

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.3.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let trace =
    Box(
        y = [0; 1; 1; 2; 3; 5; 8; 13; 21],
        boxpoints = "all",
        jitter = 0.3,
        pointpos = -1.8
    )

let data = Data [trace]

let figure = Figure(data)

let plotlyResponse = figure.Plot("Box Plot That Displays the Underlying Data")

figure.Show()


      

Grouped Box Plot

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.3.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let x = ["day 1"; "day 1"; "day 1"; "day 1"; "day 1"; "day 1";
        "day 2"; "day 2"; "day 2"; "day 2"; "day 2"; "day 2"]

let trace1 =
    Box(
        y = [0.2; 0.2; 0.6; 1.0; 0.5; 0.4; 0.2; 0.7; 0.9; 0.1; 0.5; 0.3],
        x = x,
        name = "kale",
        marker = Marker(color = "#3D9970")
    )

let trace2 =
    Box(
        y = [0.6; 0.7; 0.3; 0.6; 0.0; 0.5; 0.7; 0.9; 0.5; 0.8; 0.7; 0.2],
        x = x,
        name = "radishes",
        marker = Marker(color = "#FF4136")
    )

let trace3 =
    Box(
        y = [0.1; 0.3; 0.1; 0.9; 0.6; 0.6; 0.9; 1.0; 0.3; 0.6; 0.8; 0.5],
        x = x,
        name = "carrots",
        marker = Marker(color = "#FF851B")
    )

let data = Data [trace1; trace2; trace3]

let layout =
    Layout(
        yaxis =
            Yaxis(
                title = "normalized moisture",
                zeroline = false
            ),
        boxmode = "group"
    )

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Grouped Box Plot")

figure.Show()
