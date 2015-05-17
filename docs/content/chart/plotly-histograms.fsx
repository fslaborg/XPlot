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

let normal = new Normal(0., 1.0)

let x =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let data = Data([Histogram(x = x)])

let figure = Figure(data)

let plotlyResponse = figure.Plot("Basic Histogram")

figure.Show()


      

Horizontal Histogram

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.8.0/Lib/Net45/XPlot.Plotly.dll"""
#r """../packages/MathNet.Numerics.3.6.0/lib/net40/MathNet.Numerics.dll"""

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let normal = new Normal(0., 1.0)

let y =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let data = Data([Histogram(y = y)])

let figure = Figure(data)

let plotlyResponse = figure.Plot("Horizontal Histogram")

figure.Show()

      

Overlaid Histogram

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.8.0/Lib/Net45/XPlot.Plotly.dll"""
#r """../packages/MathNet.Numerics.3.6.0/lib/net40/MathNet.Numerics.dll"""

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let normal = new Normal(0., 1.0)

let x0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let x1 = Array.map (fun x -> x + 1.) x0
    
let trace1 =
    Histogram(
        x = x0,
        opacity = 0.75
    )

let trace2 =
    Histogram(
        x = x1,
        opacity = 0.75
    )

let data = Data([trace1; trace2])

let layout = Layout(barmode = "overlay")

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Overlaid Histogram")

figure.Show()

      

Stacked Histograms

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.8.0/Lib/Net45/XPlot.Plotly.dll"""
#r """../packages/MathNet.Numerics.3.6.0/lib/net40/MathNet.Numerics.dll"""

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let normal = new Normal(0., 1.0)

let x0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let x1 = Array.map (fun x -> x + 1.) x0
    
let trace1 = Histogram(x = x0)

let trace2 = Histogram(x = x1)

let data = Data([trace1; trace2])

let layout = Layout(barmode = "stack")

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Stacked Histograms")

figure.Show()

      

Colored and Styled Histograms

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.8.0/Lib/Net45/XPlot.Plotly.dll"""
#r """../packages/MathNet.Numerics.3.6.0/lib/net40/MathNet.Numerics.dll"""

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let normal = new Normal(0., 1.0)

let x0 =
    normal.Samples()
    |> Seq.take 500
    |> Seq.toArray

let x1 = Array.map (fun x -> x + 1.) x0

let trace1 =
    Histogram(
        x = x0,
        histnorm = "count",
        name = "control",
        autobinx = false,
        xbins =
            XBins(
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

let trace2 =
    Histogram(
        x = x1,
        name = "experimental",
        autobinx = false,
        xbins =
            XBins(
                start = -1.8,
                ``end`` = 4.2,
                size = 0.2
            ),
        marker = Marker(color = "rgb(255, 217, 102)"),
        opacity = 0.75
    )

let data = Data([trace1; trace2])

let layout =
    Layout(
        title = "Sampled Results",
        xaxis = XAxis(title = "Value"),
        yaxis = YAxis(title = "Count"),
        barmode = "overlay",
        bargap = 0.25,
        bargroupgap = 0.3
    )

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Colored and Styled Histograms")

figure.Show()

      

Built with WebSharper

Facebook
Twitter
Email
Print
More