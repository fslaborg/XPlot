module LogPlotTests

open System.IO
open Expecto
open LogPlots
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "logplots")

[<Tests>]
let testArea =
    testList "LogPlots" [
        test "LogarithmicAxes generated JS did not regress" {
            let la = Path.Combine(baselineDir, "logarithmic-axes.js")
            let expectedJS = File.ReadAllText(la)
            let actualJS = LogarithmicAxes.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LogarithmicAxes"
        }
    ]