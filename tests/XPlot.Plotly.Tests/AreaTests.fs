module AreaTests

open System.IO
open Expecto
open Area
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "area")

[<Tests>]
let testArea =
    testList "Area" [
        test "Area1 generated JS did not regress" {
            let area1 = Path.Combine(baselineDir, "area-1.js")
            let expectedJS = File.ReadAllText(area1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Area1"
        }

        test "Area2 generated JS did not regress" {
            let area2 = Path.Combine(baselineDir, "area-2.js")
            let expectedJS = File.ReadAllText(area2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Area2"
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

        test "Stacked area via stackgroup works correctly" {
            let stackedArea = Path.Combine(baselineDir, "stacked-area.js")
            let expectedJS = File.ReadAllText(stackedArea)
            let actualJS = ChartStackedArea.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "ChartStackedArea"
        }
    ]
