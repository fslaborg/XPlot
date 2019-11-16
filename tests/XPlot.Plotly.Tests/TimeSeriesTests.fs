module TimeSeriesTests

open System.IO
open Expecto
open TimeSeries
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "timeseries")

[<Tests>]
let testLine =
    testList "Time Series" [
        test "DateString time series generated JS did not regress" {
            let s = Path.Combine(baselineDir, "date-strings.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = TimeSeriesWithDateStrings.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "TimeSeriesWithDateStrings"
        }

        test "DateTime time series generated JS did not regress" {
            let s = Path.Combine(baselineDir, "date-time.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = TimeSeriesWithDateTime.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "TimeSeriesWithDateTime"
        }
    ]