module GaugeTests

open System.IO
open Expecto
open Gauge
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "gauge")

[<Tests>]
let testArea =
    testList "Gauges" [
        test "Circular Gauge generated JS did not regress" {
            let g = Path.Combine(baselineDir, "gauge.js")
            let expectedJS = File.ReadAllText(g)
            let actualJS = CircularGauge.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Circular Gauge"
        }
    ]