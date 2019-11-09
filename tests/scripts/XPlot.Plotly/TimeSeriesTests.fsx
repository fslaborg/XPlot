#r """.\.\bin\Release\XPlot.Plotly.dll"""
#load "Credentials.fsx"

open System
open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

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
