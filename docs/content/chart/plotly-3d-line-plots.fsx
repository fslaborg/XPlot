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


open System.IO

let data =
    let path = Path.Combine(__SOURCE_DIRECTORY__, "3DLineData.txt")
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
