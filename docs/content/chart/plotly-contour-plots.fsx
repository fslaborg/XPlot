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

let size = 100

let x = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let y = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let z = Array2D.create size size 0.

for i in 0 .. 99 do
    for j in 0 .. 99 do
        let r2 = x.[i] ** 2. + y.[j] ** 2.
        z.[i,j] <- sin x.[i] * cos y.[j] * sin r2 / log(r2 + 1.)

let trace =
    Contour(
        z = z,
        x = x,
        y = y
    )

let data = Data [trace]

let figure = Figure(data)

let plotlyResponse = figure.Plot("Basic Contour Plot")

figure.Show()


      

2D Histogram Contour Plot with Histogram Subplots

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.5.0/Lib/Net45/XPlot.Plotly.dll"""
#r """../packages/MathNet.Numerics.3.6.0/lib/net40/MathNet.Numerics.dll"""

open MathNet.Numerics
open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let t = Generate.LinearSpaced(2000, -1., 1.2)

let normal = new Normal(0., 1.0)

let sample =
    normal.Samples()
    |> Seq.take 2000
    |> Seq.toArray

let x = Array.mapi (fun i x -> t.[i] ** 3. + 0.3 * x) sample
let y = Array.mapi (fun i x -> t.[i] ** 6. + 0.3 * x) sample

let trace1 =
    Scatter(
        x = x,
        y = y,
        mode = "markers",
        name = "points",
        marker =
            Marker(
                color = "rgb(102,0,0)",
                size = 2,
                opacity = 0.4
            )
    )

let trace2 =
    Histogram2dContour(
        x = x,
        y = y,
        name = "density",
        ncontours = 20.,
        colorscale = "Hot",
        reversescale = true,
        showscale = false
    )

let trace3 =
    Histogram(
        x = x,
        name = "x density",
        marker = Marker(color = "rgb(102,0,0)"),
        yaxis = "y2"
    )

let trace4 =
    Histogram(
        y = y,
        name = "y density",
        marker = Marker(color = "rgb(102,0,0)"),
        xaxis = "x2"
    )

let data = Data [trace1; trace2; trace3; trace4]

let layout =
    Layout(
        showlegend = false,
        autosize = false,
        width = 600.,
        height = 550.,
        xaxis =
            Xaxis(
                domain = [|0.; 0.85|],
                showgrid = false,
                zeroline = false
            ),
        yaxis =
            Yaxis(
                domain = [|0.; 0.85|],
                showgrid = false,
                zeroline = false
            ),
        margin = Margin(t = 50.),
        hovermode = "closest",
        bargap = 0.,
        xaxis2 =
            Xaxis(
                domain = [|0.85; 1.|],
                showgrid = false,
                zeroline = false
            ),
        yaxis2 =
            Yaxis(
                domain = [|0.85; 1.|],
                showgrid = false,
                zeroline = false
            )
    )

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("2D Histogram Contour Plot with Histogram Subplots")

figure.Show()


      
