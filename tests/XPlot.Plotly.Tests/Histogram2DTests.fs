module Histogram2DTests

open System.IO
open Expecto
open Histogram2D
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "histogram2d")

[<Tests>]
let testArea =
    testList "Histogram2D" [
        test "Histogram2DBivariate generated JS did not regress" {
            let g = Path.Combine(baselineDir, "histogram-2d-bivariate.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = Histogram2DBivariate.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Histogram2DBivariate"
        }

        test "Histogram2DOverlaidScatter generated JS did not regress" {
            let g = Path.Combine(baselineDir, "histogram-2d-overlaid-scatter.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = Histogram2DOverlaidScatter.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Histogram2DOverlaidScatter"
        }

        test "Histogram2DBinningStyling generated JS did not regress" {
            let g = Path.Combine(baselineDir, "histogram-2d-binning-styling.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = Histogram2DBinningStyling.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Histogram2DBinningStyling"
        }
    ]