namespace Bubble

open XPlot.Plotly

module BasicBubble =
    let trace = [
        1, 10, 40
        2, 11, 60
        3, 12, 80
        4, 13, 100
    ]

    let js =
        let chart =
            trace
            |> Chart.Bubble
        chart.GetInlineJS()

// Marker Size on Bubble Charts
module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            mode = "markers",
            marker =
                Marker (
                    size = [40; 60; 80; 100]
                )
        )

    let options =
        Options(
            title = "Marker Size",
            showlegend = false,
            height = 600.,
            width = 600.
        )

    let js =
        let chart =
            trace1
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()   

// Marker Size and Color on Bubble Charts
module Chart2 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            mode = "markers",
            marker =
                Marker(
                    color = ["rgb(93, 164, 214)"; "rgb(255, 144, 14)"; "rgb(44, 160, 101)"; "rgb(255, 65, 54)"],
                    opacity = [1.; 0.8; 0.6; 0.4],
                    size = [40; 60; 80; 100]
                )
        )

    let options =
        Options(
            title = "Marker Size and Color",
            showlegend = false,
            height = 600.,
            width = 600.
        )

    let js =
        let chart =
            trace1
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

// Hover Text on Bubble Charts
module Chart3 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            text = ["A size = 40"; "B size = 60"; "C size = 80"; "D size = 100"],
            mode = "markers",
            marker =
                Marker(
                    color = ["rgb(93,164,214)"; "rgb(255,144,14)";  "rgb(44,160,101)"; "rgb(255,65,54)"],
                    size = [40; 60; 80; 100]
                )
        )


    let options =
        Options(
            title = "Bubble Chart Hover Text",
            showlegend = false,
            height = 600.,
            width = 600.
        )

    let js =
        let chart =
            trace1
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

// Bubble Size Scaling on Charts
module Chart4 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            text = ["A size = 40"; "B size = 60"; "C size = 80"; "D size = 100"],
            mode = "markers",
            marker =
                Marker(
                    size = [400; 600; 800; 1000],
                    sizemode = "area"
                )
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [14; 15; 16; 17],
            text = ["A size = 40 sizeref = 0.2"; "B size = 60 sizeref = 0.2"; "C size = 80 sizeref = 0.2"; "D size = 100 sizeref = 0.2"],
            mode = "markers",
            marker =
                Marker(
                    size = [400; 600; 800; 1000],
                    sizeref = 2.,
                    sizemode = "area"
                )
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [20; 21; 22; 23],
            text = ["A size = 40 sizeref = 2"; "B size = 60 sizeref = 2"; "C size = 80 sizeref = 2"; "D size = 100 sizeref = 2"],
            mode = "markers",
            marker =
                Marker(
                    size = [400; 600; 800; 1000],
                    sizeref = 0.2,
                    sizemode = "area"
                )
        )

    let data = [trace1; trace2; trace3]

    let options =
        Options(
            title = "Bubble Chart Size Scaling",
            showlegend = false,
            height = 600.,
            width = 600.
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

// Marker Size, Color, and Symbol as an Array
module Chart5 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            mode = "markers",
            marker =
                Marker(
                    color = ["hsl(0,100,40)"; "hsl(33,100,40)"; "hsl(66,100,40)"; "hsl(99,100,40)"],
                    size = [12; 22; 32; 42],
                    opacity = [0.6; 0.7; 0.8; 0.9]
                )
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [11; 12; 13; 14],
            mode = "markers",
            marker =
                Marker(
                    color = "rgb(31,119,180)",
                    size = 18,
                    symbol = ["circle"; "square"; "diamond"; "cross"]
                )
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 13; 14; 15],
            mode = "markers",
            marker =
                Marker(
                    size = 18,
                    line =
                        Line(
                            color = ["rgb(120,120,120)"; "rgb(120,120,120)"; "red"; "rgb(120,120,120)"],
                            width = [2; 2; 6; 2]
                        )
                )
        )

    let data = [trace1; trace2; trace3]

    let options = Options(showlegend = false)

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

module Chart6 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 11; 12; 13],
            mode = "markers",
            marker =
                Marker(
                    color = ["hsl(0,100,40)"; "hsl(33,100,40)"; "hsl(66,100,40)"; "hsl(99,100,40)"],
                    size = [12; 22; 32; 42],
                    opacity = [0.6, 0.7, 0.8, 0.9]
                )
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [11; 12; 13; 14],
            mode = "markers",
            marker =
                Marker(
                    color = "rgb(31, 119, 180)",
                    size = 18,
                    symbol = ["circle"; "square"; "diamond"; "cross"]
                )
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 13; 14; 15],
            mode = "markers",
            marker =
                Marker(
                    size = 18,
                    line =
                        Line(
                            color = ["rgb(120,120,120)"; "rgb(120,120,120)"; "red"; "rgb(120,120,120)"],
                            width = [2; 2; 6; 2]
                        )
                )
        )

    let options = Options(showlegend=false, title="Marker Size, Color, and Symbol as an Array")

    let js =
        let chart =
            [trace1; trace2; trace3]
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()
