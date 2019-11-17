module ContourTests

open System.IO
open Expecto
open ContourPlots
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "contour")

[<Tests>]
let testContour =
    testList "Contour plots" [
        test "BasicContourPlot generated JS did not regress" {
            let g = Path.Combine(baselineDir, "basic-contour.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = BasicContourPlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BasicContourPlot"
        }

        test "TwoDHistogramContourPlotHistogramSubplots generated JS did not regress" {
            let g = Path.Combine(baselineDir, "2d-histogram-contour-plot.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = TwoDHistogramContourPlotHistogramSubplots.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "TwoDHistogramContourPlotHistogramSubplots"
        }
    ]