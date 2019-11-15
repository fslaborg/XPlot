module BarTests

open System.IO
open Expecto
open Bar
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "bar")

[<Tests>]
let testArea =
    testList "Bar" [
        test "Area1 generated JS did not regress" {
            let bar1 = Path.Combine(baselineDir, "bar-1.js")
            let expectedJS = File.ReadAllText(bar1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bar1"
        }

        test "Area2 generated JS did not regress" {
            let bar2 = Path.Combine(baselineDir, "bar-2.js")
            let expectedJS = File.ReadAllText(bar2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bar2"
        }

        test "Area3 generated JS did not regress" {
            let bar3 = Path.Combine(baselineDir, "bar-3.js")
            let expectedJS = File.ReadAllText(bar3)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bar3"
        }

        test "Multiple series generated JS did not regress" {
            let mul = Path.Combine(baselineDir, "multiple-series.js")
            let expectedJS = File.ReadAllText(mul)
            let actualJS = PipeStyle.multipleSeriesJS |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Multiple series"
        }

        test "Single series generated JS did not regress" {
            let single = Path.Combine(baselineDir, "single-series.js")
            let expectedJS = File.ReadAllText(single)
            let actualJS = PipeStyle.singleSeriesJS |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Multiple series"
        }

        test "Y-values series generated JS did not regress" {
            let yval = Path.Combine(baselineDir, "y-values.js")
            let expectedJS = File.ReadAllText(yval)
            let actualJS = PipeStyle.yValuesJS |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Y-values"
        }
    ]
