module PolarChartsTests

open System.IO
open Expecto
open PolarCharts
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "polar")

[<Tests>]
let testArea =
    testList "Polar charts" [
        test "PolarLine JS did not regress" {
            let pl = Path.Combine(baselineDir, "polar-line.js")
            let expectedJS = File.ReadAllText(pl)
            let actualJS = PolarLineChart.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "PolarLine"
        }
        
        test "PolarScatterChart JS did not regress" {
            let ps = Path.Combine(baselineDir, "polar-scatter.js")
            let expectedJS = File.ReadAllText(ps)
            let actualJS = PolarScatterChart.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "PolarScatterChart"
        }
        
        
        test "PolarAreaChart JS did not regress" {
            let pa = Path.Combine(baselineDir, "polar-area.js")
            let expectedJS = File.ReadAllText(pa)
            let actualJS = PolarAreaChart.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "PolarAreaChart"
        }
    ]