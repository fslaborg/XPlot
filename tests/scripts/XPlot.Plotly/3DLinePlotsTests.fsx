#r """.\.\bin\Release\XPlot.Plotly.dll"""
#r """..\XPlot.Plotly.WPF\bin\Release\XPlot.Plotly.WPF.dll"""
#r """..\packages\MathNet.Numerics.3.6.0\lib\net40\MathNet.Numerics.dll"""
#load "Credentials.fsx"

// TESTED under CI now

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

open System.IO

let data =
    Path.
    let path = Path.Combine(__SOURCE_DIRECTORY__, "..", "3DLineData.txt")
    File.ReadAllLines path

let getData line =
    data.[line]
    |> fun x -> x.Split ','
    |> Array.map float

module ThreeDRandomWalk =

    let trace1 =
        Scatter3d(
            x = getData 0,
            y = getData 1,
            z = getData 2,
            mode = "lines",
            marker =
                Marker(
                    color = "#1f77b4",
                    size = 12.,
                    symbol = "circle",
                    line =
                        Line(
                            color = "rgb(0,0,0)",
                            width = 0.
                        )
                ),
            line =
                Line(
                    color = "#1f77b4",
                    width = 1.
                )
        )

    let trace2 =
        Scatter3d(
            x = getData 3,
            y= getData 4,
            z = getData 5,
            mode = "lines",
            marker =
                Marker(
                    color = "#9467bd",
                    size = 12.,
                    symbol = "circle",
                    line =
                        Line(
                            color = "rgb(0,0,0)",
                            width = 0.
                        )
                ),
            line =
                Line(
                    color = "rgb(44, 160, 44)",
                    width = 1.
                )
        )

    let trace3 =
        Scatter3d(
            x = getData 6,
            y = getData 7,
            z = getData 8,
            mode = "lines",
            marker =
                Marker(
                    color = "#bcbd22",
                    size = 12.,
                    symbol = "circle",
                    line =
                        Line(
                            color = "rgb(0,0,0)",
                            width = 0.
                        )
                ),
            line =
                Line(
                    color = "#bcbd22",
                    width = 1.
                )
        )

    let data = Data([trace1; trace2; trace3])

    let layout =
        Layout(
            autosize = false,
            width = 500.,
            height = 500.,
            margin =
                Margin(
                    l = 0.,
                    r = 0.,
                    b = 0.,
                    t = 65.
                )
        )

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("3D Random Walk Test")

    figure.Show()
