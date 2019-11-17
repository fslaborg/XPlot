module ShapesTests

open System.IO
open Expecto
open Shapes
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "shapes")

[<Tests>]
let testShapes =
    testList "Shapes" [
        test "Shape1 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-1.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape1"
        }

        test "Shape2 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-2.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape2"
        }

        test "Shape3 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-3.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape3"
        }

        test "Shape4 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-4.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape4"
        }

        test "Shape5 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-5.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape5"
        }

        test "Shape6 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-6.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart6.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape6"
        }

        test "Shape7 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-7.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart7.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape7"
        }

        test "Shape8 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "shape-8.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart8.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Shape8"
        }
    ]