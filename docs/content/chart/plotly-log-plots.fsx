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

module LogarithmicAxes =

    let trace1 =
        Scatter(
            x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
            y = [8; 7; 6; 5; 4; 3; 2; 1; 0]
        )

    let trace2 =
        Scatter(
            x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
            y = [0; 1; 2; 3; 4; 5; 6; 7; 8]
        )

    let data = Data([trace1; trace2])

    let layout =
        Layout(
            xaxis =
                XAxis(
                    ``type`` = "log",
                    autorange = true
                ),
            yaxis =
                YAxis(
                    ``type`` = "log",
                    autorange = true
                )
        )

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Logarithmic Axes Test")

    figure.Show()

