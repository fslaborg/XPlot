module CountourTests

open System.IO
open Expecto
open Contour
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "contour")

[<Tests>]
let testArea =
    testList "Contour" [
        test "Basic contour generated JS did not regress" {
            let c1 = Path.Combine(baselineDir, "contour-1.js")
            let expectedJS = File.ReadAllText(c1)
            let actualJS = BasicContourPlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BasicContourPlot"
        }
    ]