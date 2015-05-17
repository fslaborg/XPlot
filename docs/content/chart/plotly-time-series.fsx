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

module TimeSeriesPlotDatetimeObjects =

    let x =
        [
            DateTime(2013, 10, 4);
            DateTime(2013, 11, 5);
            DateTime(2013, 12, 6)
        ]

    let data =
        Data(
            [
                Scatter(
                    x = x,
                    y = [1; 3; 6]
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Time Series Plot with datetime Objects Test")

    figure.Show()

module DateStrings =

    let data =
        Data(
            [
                Scatter(
                    x = ["2013-10-04 22:23:00"; "2013-11-04 22:23:00"; "2013-12-04 22:23:00"],
                    y = [1; 3; 6]
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Date Strings Test")

    figure.Show()
