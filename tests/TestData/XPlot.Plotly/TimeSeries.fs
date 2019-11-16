namespace TimeSeries

open System
open XPlot.Plotly

module TimeSeriesWithDateStrings =
    let data =
        Scatter(
            x = ["2013-10-04 22:23:00"; "2013-11-04 22:23:00"; "2013-12-04 22:23:00"],
            y = [1; 3; 6]
        )

    let js =
        let chart =
            data
            |> Chart.Plot
        chart.GetInlineJS()

module TimeSeriesWithDateTime =
    let x =
        [
            DateTime(2013, 10, 4);
            DateTime(2013, 11, 5);
            DateTime(2013, 12, 6)
        ]

    let data =
        Scatter(
            x = x,
            y = [1; 3; 6]
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "Time Series Plot with datetime Objects Test"
        chart.GetInlineJS()
