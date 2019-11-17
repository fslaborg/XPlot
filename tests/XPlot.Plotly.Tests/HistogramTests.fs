module HistogramTests

open System.IO
open Expecto
open Histogram
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "histogram")

[<Tests>]
let testArea =
    testList "Histogram" [
        test "BasicHistogram generated JS did not regress" {
            let g = Path.Combine(baselineDir, "basic-histogram.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = BasicHistogram.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BasicHistogram"
        }
        
        test "HorizontalHistogram generated JS did not regress" {
            let g = Path.Combine(baselineDir, "horizontal-histogram.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = HorizontalHistogram.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "HorizontalHistogram"
        }
        
        test "OverlaidHistgram generated JS did not regress" {
            let g = Path.Combine(baselineDir, "overlaid-histogram.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = OverlaidHistgram.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "OverlaidHistgram"
        }
        
        test "StackedHistograms generated JS did not regress" {
            let g = Path.Combine(baselineDir, "stacked-histograms.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = StackedHistograms.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "StackedHistograms"
        }
        
        test "ColoredStyledHistograms generated JS did not regress" {
            let g = Path.Combine(baselineDir, "colored-styled-histograms.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = ColoredStyledHistograms.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "ColoredStyledHistograms"
        }
    ]