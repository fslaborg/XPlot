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

let data = Data [trace1; trace2; trace3]

let layout = Layout(showlegend = false)

let figure = Figure(data, layout)

let plotlyResponse = figure.Plot("Marker Size, Color, and Symbol as an Array")

figure.Show()

