module ChartTests

open System.IO
open Expecto
open Chart
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "chart")

[<Tests>]
let testArea =
    testList "Chart" [
        test "Chart1 generated JS did not regress" {
            let c1 = Path.Combine(baselineDir, "chart-1.js")
            let expectedJS = File.ReadAllText(c1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart1"
        }

        test "Chart2 generated JS did not regress" {
            let c2 = Path.Combine(baselineDir, "chart-2.js")
            let expectedJS = File.ReadAllText(c2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart2"
        }

        test "Chart3 generated JS did not regress" {
            let c3 = Path.Combine(baselineDir, "chart-3.js")
            let expectedJS = File.ReadAllText(c3)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart3"
        }
    ]
