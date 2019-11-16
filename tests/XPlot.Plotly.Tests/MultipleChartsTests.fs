module MultipleChartsTests

open System.IO
open Expecto
open MultipleChartTypes
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "multiple-chart-types")

[<Tests>]
let testArea =
    testList "MultipleChartTypes" [
        test "ContourAndScatter generated JS did not regress" {
            let cas = Path.Combine(baselineDir, "contour-and-scatter.js")
            let expectedJS = File.ReadAllText(cas)
            let actualJS = ContourAndScatter.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "ContourAndScatter"
        }

        test "LineAndBarChart generated JS did not regress" {
            let lab = Path.Combine(baselineDir, "line-and-bar.js")
            let expectedJS = File.ReadAllText(lab)
            let actualJS = LineAndBarChart.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineAndBarChart"
        }
    ]