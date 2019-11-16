module PieTests

open System.IO
open Expecto
open Pie
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "pie")

[<Tests>]
let testArea =
    testList "Pie" [
        test "Pie1 generated JS did not regress" {
            let pie = Path.Combine(baselineDir, "pie-1.js")
            let expectedJS = File.ReadAllText(pie)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Pie1"
        }

        test "Pie2 generated JS did not regress" {
            let pie = Path.Combine(baselineDir, "pie-2.js")
            let expectedJS = File.ReadAllText(pie)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Pie2"
        }
        
        test "Pie3 generated JS did not regress" {
            let pie = Path.Combine(baselineDir, "pie-3.js")
            let expectedJS = File.ReadAllText(pie)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Pie3"
        }

        test "Pie4 generated JS did not regress" {
            let pie = Path.Combine(baselineDir, "pie-4.js")
            let expectedJS = File.ReadAllText(pie)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Pie4"
        }
    ]
