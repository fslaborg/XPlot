module ThreeDPlotsTests

open System.IO
open Expecto
open ThreeDPlots
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "3D")

[<Tests>]
let testArea =
    testList "3D Plots" [
        test "3D Random Walk generated JS did not regress" {
            let g = Path.Combine(baselineDir, "3D-1.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = ThreeDRandomWalk.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "3D Random Walk"
        }

        test "3D Scatter Plot generated JS did not regress" {
            let g = Path.Combine(baselineDir, "3D-2.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = ThreeDScatterPlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "3D Scatter Plot"
        }

        test "Topographical 3D Surface Plot generated JS did not regress" {
            let g = Path.Combine(baselineDir, "3D-3.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = Topographical3DSurfacePlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Topographical 3D Surface Plot"
        }
    ]