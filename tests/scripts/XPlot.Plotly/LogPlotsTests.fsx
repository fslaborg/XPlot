#r """.\.\bin\Release\XPlot.Plotly.dll"""
#r """..\XPlot.Plotly.WPF\bin\Release\XPlot.Plotly.WPF.dll"""
#r """..\packages\MathNet.Numerics.3.6.0\lib\net40\MathNet.Numerics.dll"""
#load "Credentials.fsx"

// TESTED under CI now

open MathNet.Numerics.Distributions
open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

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

