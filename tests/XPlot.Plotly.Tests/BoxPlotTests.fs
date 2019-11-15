module BoxPlotTests

open System.IO
open Expecto
open BoxPlot
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "box")

[<Tests>]
let testArea =
    testList "Boxplot" [
        test "Basic boxplot generated JS did not regress" {
            let bb = Path.Combine(baselineDir, "basic-boxplot.js")
            let expectedJS = File.ReadAllText(bb)
            let actualJS = BasicBoxPlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Basic boxplot"
        }

        test "Boxplot with underlying data generated JS did not regress" {
            let underlying = Path.Combine(baselineDir, "boxplot-displays-underlying-data.js")
            let expectedJS = File.ReadAllText(underlying)
            let actualJS = BoxPlotDisplaysUnderlyingData.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Boxplot with underlying data"
        }

        test "BubbleCharts generated JS did not regress" {
            let bubbles = Path.Combine(baselineDir, "bubblecharts.js")
            let expectedJS = File.ReadAllText(bubbles)
            let actualJS = BubbleCharts.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Bubble charts"
        }

        test "Grouped boxplot generated JS did not regress" {
            let grouped = Path.Combine(baselineDir, "grouped-boxplot.js")
            let expectedJS = File.ReadAllText(grouped)
            let actualJS = GroupedBoxPlot.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Grouped boxplot"
        }
    ]
