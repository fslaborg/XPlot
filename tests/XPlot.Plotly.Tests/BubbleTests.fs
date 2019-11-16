module BubbleTests

open System.IO
open Expecto
open Bubble
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "bubble")

[<Tests>]
let testArea =
    testList "Bubble" [
        test "Bubble 1 generated JS did not regress" {
            let b1 = Path.Combine(baselineDir, "bubble-1.js")
            let expectedJS = File.ReadAllText(b1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 1"
        }

        test "Bubble 2 generated JS did not regress" {
            let b2 = Path.Combine(baselineDir, "bubble-2.js")
            let expectedJS = File.ReadAllText(b2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 2"
        }

        test "Bubble 3 generated JS did not regress" {
            let b3 = Path.Combine(baselineDir, "bubble-3.js")
            let expectedJS = File.ReadAllText(b3)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 3"
        }

        test "Bubble 4 generated JS did not regress" {
            let b4 = Path.Combine(baselineDir, "bubble-4.js")
            let expectedJS = File.ReadAllText(b4)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 4"
        }

        test "Bubble 5 generated JS did not regress" {
            let b5 = Path.Combine(baselineDir, "bubble-5.js")
            let expectedJS = File.ReadAllText(b5)
            let actualJS = Chart5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 5"
        }

        test "Bubble 6 generated JS did not regress" {
            let b6 = Path.Combine(baselineDir, "bubble-6.js")
            let expectedJS = File.ReadAllText(b6)
            let actualJS = Chart6.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble 6"
        }
    ]
