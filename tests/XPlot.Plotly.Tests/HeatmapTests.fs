module HeatmapTests

open System.IO
open Expecto
open Heatmaps
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "heatmaps")

[<Tests>]
let testArea =
    testList "Heatmaps" [
        test "Basic Heatmap generated JS did not regress" {
            let g = Path.Combine(baselineDir, "basic-heatmap.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = BasicHeatmap.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BasicHeatmap"
        }

        test "HeatmapCategoricalAxisLabels generated JS did not regress" {
            let g = Path.Combine(baselineDir, "categorical-axis-labels-heatmap.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = HeatmapCategoricalAxisLabels.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "HeatmapCategoricalAxisLabels"
        }

        test "CustomColorscale generated JS did not regress" {
            let g = Path.Combine(baselineDir, "custom-colorscale.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = CustomColorscale.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "CustomColorscale"
        }

        test "EarthColorscale generated JS did not regress" {
            let g = Path.Combine(baselineDir, "earth-colorscale.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = EarthColorscale.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "EarthColorscale"
        }

        test "YIGnBuColorscale generated JS did not regress" {
            let g = Path.Combine(baselineDir, "yignbu-colorscale.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = YIGnBuColorscale.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "YIGnBuColorscale"
        }
    ]