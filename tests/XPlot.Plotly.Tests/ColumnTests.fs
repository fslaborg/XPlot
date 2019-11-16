module ColumnTests

open System.IO
open Expecto
open Column
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "column")

[<Tests>]
let testArea =
    testList "Column" [
        test "Column1 generated JS did not regress" {
            let c1 = Path.Combine(baselineDir, "column-1.js")
            let expectedJS = File.ReadAllText(c1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column1"
        }

        test "Column2 generated JS did not regress" {
            let c2 = Path.Combine(baselineDir, "column-2.js")
            let expectedJS = File.ReadAllText(c2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column2"
        }

        test "Column3 generated JS did not regress" {
            let c3 = Path.Combine(baselineDir, "column-3.js")
            let expectedJS = File.ReadAllText(c3)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column3"
        }

        test "Column4 generated JS did not regress" {
            let c4 = Path.Combine(baselineDir, "column-4.js")
            let expectedJS = File.ReadAllText(c4)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column4"
        }

        test "Column5 generated JS did not regress" {
            let c5 = Path.Combine(baselineDir, "column-5.js")
            let expectedJS = File.ReadAllText(c5)
            let actualJS = Chart5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column5"
        }

        test "Column6 generated JS did not regress" {
            let c6 = Path.Combine(baselineDir, "column-6.js")
            let expectedJS = File.ReadAllText(c6)
            let actualJS = Chart6.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column6"
        }

        test "Column7 generated JS did not regress" {
            let c7 = Path.Combine(baselineDir, "column-7.js")
            let expectedJS = File.ReadAllText(c7)
            let actualJS = Chart7.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column7"
        }

        test "Column8 generated JS did not regress" {
            let c8 = Path.Combine(baselineDir, "column-8.js")
            let expectedJS = File.ReadAllText(c8)
            let actualJS = Chart8.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column8"
        }

        test "Column9 generated JS did not regress" {
            let c9 = Path.Combine(baselineDir, "column-9.js")
            let expectedJS = File.ReadAllText(c9)
            let actualJS = Chart9.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column9"
        }

        test "Column10 generated JS did not regress" {
            let c10 = Path.Combine(baselineDir, "column-10.js")
            let expectedJS = File.ReadAllText(c10)
            let actualJS = Chart10.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column10"
        }
    ]