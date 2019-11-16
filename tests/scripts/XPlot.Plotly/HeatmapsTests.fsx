#r @".\.\bin\Release\XPlot.Plotly.dll"
#load "Credentials.fsx"
// TESTED under CI now


open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

module BasicHeatmap =

    let data =
        Data(
            [
                Heatmap(
                    z = [[1; 20; 30]; [20; 1; 60]; [30; 60; 1]]
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Basic Heatmap Test")
    
    figure.Show()

module HeatmapCategoricalAxisLabels =

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

    let plotlyResponse = figure.Plot("Heatmap with Categorical Axis Labels Test")
    
    figure.Show()

#r @"C:\Users\AHMED\Documents\GitHub\XPlot\Src\XPlot\packages\Newtonsoft.Json.6.0.8\lib\net45\Newtonsoft.Json.dll"

module CustomColorscale =

    let z =
        [
            for x in 1 .. 50 do
                let lst = List.map (fun y -> y + x) [1..50]
                yield lst
        ]
        |> array2D

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

    let plotlyResponse = figure.Plot("Custom Colorscale Test")
    
    figure.Show()

module EarthColorscale =

    let z =
        [
            for x in 1 .. 50 do
                let lst = List.map (fun y -> y + x) [1..50]
                yield lst
        ]
        |> array2D

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

    let plotlyResponse = figure.Plot("Earth Colorscale Test")
    
    figure.Show()

module YIGnBuColorscale =

    let z =
        [
            for x in 1 .. 50 do
                let lst = List.map (fun y -> y + x) [1..50]
                yield lst
        ]
        |> array2D

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

    let plotlyResponse = figure.Plot("YIGnBu Colorscale Test")
    
    figure.Show()
