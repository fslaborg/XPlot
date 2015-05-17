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

let data =
    Data(
        [
            Heatmap(
                z = [[1; 20; 30]; [20; 1; 60]; [30; 60; 1]]
            )
        ]
    )

let figure = Figure(data)

let plotlyResponse = figure.Plot("Basic Heatmap")
    
figure.Show()


      

Heatmap with Categorical Axis Labels

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.7.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let data =
    Data(
        [
            Heatmap(
                z = [[1; 20; 30; 50; 1]; [20; 1; 60; 80; 30]; [30; 60; 1; -10; 20]],
                x = ["Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"],
                y = ["Morning"; "Afternoon"; "Evening"]
            )
        ]
    )

let figure = Figure(data)

let plotlyResponse = figure.Plot("Heatmap with Categorical Axis Labels")
    
figure.Show()


      

Custom Colorscale

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.7.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let z =
    [
        for x in 1 .. 50 do
            let lst = List.map (fun y -> y + x) [1..50]
            yield lst
    ]

let colorScale =
    [
        [box 0.0; box "rgb(165,0,38)"]
        [0.1111111111111111; "rgb(215,48,39)"]
        [0.2222222222222222; "rgb(244,109,67)"]
        [0.3333333333333333; "rgb(253,174,97)"]
        [0.4444444444444444; "rgb(254,224,144)"]
        [0.5555555555555556; "rgb(224,243,248)"]
        [0.6666666666666666; "rgb(171,217,233)"]
        [0.7777777777777778; "rgb(116,173,209)"]
        [0.8888888888888888; "rgb(69,117,180)"]
        [1.0; "rgb(49,54,149)"]
    ]

let data =
    Data(
        [
            Heatmap(
                z = z,
                colorscale = colorScale
            )
        ]
    )

let figure = Figure(data)

let plotlyResponse = figure.Plot("Custom Colorscale")
    
figure.Show()


      

Earth Colorscale

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.7.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let z =
    [
        for x in 1 .. 50 ->
            List.map (fun y -> y + x) [1..50]
    ]

let data =
    Data(
        [
            Heatmap(
                z = z,
                colorscale = "Earth"
            )
        ]
    )

let layout = Layout(title = "Earth")

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Earth Colorscale")
    
figure.Show()

      

YIGnBu Colorscale

       
#r """../packages/Http.fs.1.5.1/lib/net40/HttpClient.dll"""
#r """../packages/XPlot.Plotly.0.7.0/Lib/Net45/XPlot.Plotly.dll"""

open XPlot.Plotly

Plotly.Signin("Username", "API Key")

let z =
    [
        for x in 1 .. 50 ->
            List.map (fun y -> y + x) [1..50]
    ]

let data =
    Data(
        [
            Heatmap(
                z = z,
                colorscale = "YIGnBu"
            )
        ]
    )

let layout = Layout(title = "YIGnBu")

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("YIGnBu Colorscale")
    
figure.Show()


      

Built with WebSharper

Facebook
Twitter
Email
Print
More