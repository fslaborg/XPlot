namespace Heatmaps

open XPlot.Plotly

module BasicHeatmap =
    let series =
        Heatmap(
            z = [[1; 20; 30]; [20; 1; 60]; [30; 60; 1]]
        )

    let js =
        let chart =
            series
            |> Chart.Plot
            |> Chart.WithTitle "Basic Heatmap"
        chart.GetInlineJS()

module HeatmapCategoricalAxisLabels =
    let series =
        Heatmap(
            z = [[1; 20; 30; 50; 1]; [20; 1; 60; 80; 30]; [30; 60; 1; -10; 20]],
            x = ["Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"],
            y = ["Morning"; "Afternoon"; "Evening"]
        )

    let js =
        let chart =
            series
            |> Chart.Plot
            |> Chart.WithTitle "Heatmap with Categorical Axis Labels"
        chart.GetInlineJS()

module CustomColorscale =
    let z =
        [
            for x in 1 .. 50 ->
                [1..50]
                |> List.map (fun y -> y + x) 
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

    let series =
        Heatmap(
            z = z,
            colorscale = colorScale
        )

    let js =
        let chart =
            series
            |> Chart.Plot
            |> Chart.WithTitle "Custom Colorscale"
        chart.GetInlineJS()

module EarthColorscale =
    let z =
        [
            for x in 1 .. 50 ->
                [1..50]
                |> List.map (fun y -> y + x)
        ]
        |> array2D

    let series =
        Heatmap(
            z = z,
            colorscale = "Earth"
        )

    let js =
        let chart =
            series
            |> Chart.Plot
            |> Chart.WithTitle "Earth Colorscale"
        chart.GetInlineJS()

module YIGnBuColorscale =
    let z =
        [
            for x in 1 .. 50 ->
                [1..50]
                |> List.map (fun y -> y + x)
        ]
        |> array2D

    let series =
        Heatmap(
            z = z,
            colorscale = "YIGnBu"
        )

    let js =
        let chart =
            series
            |> Chart.Plot
            |> Chart.WithTitle "YIGnBu Colorscale"
        chart.GetInlineJS()
