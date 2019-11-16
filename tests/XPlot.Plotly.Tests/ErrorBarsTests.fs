module ErrorBarsTests

open System.IO
open Expecto
open ErrorBars
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "errorbars")

[<Tests>]
let testArea =
    testList "ErrorBars" [
        test "BasicSymmetricErrorBars generated JS did not regress" {
            let c1 = Path.Combine(baselineDir, "eb-1.js")
            let expectedJS = File.ReadAllText(c1)
            let actualJS = BasicSymmetricErrorBars.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BasicSymmetricErrorBars"
        }

        test "BarChartErrorBars generated JS did not regress" {
            let c2 = Path.Combine(baselineDir, "eb-2.js")
            let expectedJS = File.ReadAllText(c2)
            let actualJS = BarChartErrorBars.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "BarChartErrorBars"
        }

        test "HorizontalErrorBars generated JS did not regress" {
            let c3 = Path.Combine(baselineDir, "eb-3.js")
            let expectedJS = File.ReadAllText(c3)
            let actualJS = HorizontalErrorBars.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "HorizontalErrorBars"
        }

        test "AsymmetricErrorBars generated JS did not regress" {
            let c4 = Path.Combine(baselineDir, "eb-4.js")
            let expectedJS = File.ReadAllText(c4)
            let actualJS = AsymmetricErrorBars.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "AsymmetricErrorBars"
        }

        test "ErrorBarsPercentageYValue generated JS did not regress" {
            let c5 = Path.Combine(baselineDir, "eb-5.js")
            let expectedJS = File.ReadAllText(c5)
            let actualJS = ErrorBarsPercentageYValue.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "ErrorBarsPercentageYValue"
        }

        test "AsymmetricErrorBarsConstantOffset generated JS did not regress" {
            let eb = Path.Combine(baselineDir, "eb-6.js")
            let expectedJS = File.ReadAllText(eb)
            let actualJS = AsymmetricErrorBarsConstantOffset.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "AsymmetricErrorBarsConstantOffset"
        }
    ]