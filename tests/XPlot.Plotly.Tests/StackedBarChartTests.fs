module StackedBarChartTests

open System.IO
open Expecto
open StackedBarChart
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "stackedbarchart")

[<Tests>]
let testLine =
    testList "Stacked bar chart" [
        test "StackedBarChart1 generated JS did not regress" {
            let s = Path.Combine(baselineDir, "stacked-bar-chart-1.js")
            let expectedJS = File.ReadAllText(s)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "StackedBarChart1"
        }
    ]