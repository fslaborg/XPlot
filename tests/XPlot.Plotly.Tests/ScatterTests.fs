module ScatterTests

open System.IO
open Expecto
open Scatter
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "scatter")

[<Tests>]
let testLine =
    testList "Scatter" [
        test "Scatter1 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-1.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter1"
        }

        test "Scatter2 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-2.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter2"
        }

        test "Scatter3 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-3.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter3"
        }

        test "Scatter4 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-4.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter4"
        }

        test "Scatter5 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-5.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter5"
        }

        test "Scatter6 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-6.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart6.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter6"
        }

        test "Scatter7 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-7.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart7.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter7"
        }

        test "Scatter8 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-8.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart8.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter8"
        }

        test "Scatter9 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "scatter-9.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart9.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Scatter9"
        }
    ]