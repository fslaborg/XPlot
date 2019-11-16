module LineTests

open System.IO
open Expecto
open Line
open Testing

let baselineDir = Path.Combine(__SOURCE_DIRECTORY__, "..", "TestData", "XPlot.Plotly", "js", "line")

[<Tests>]
let testLine =
    testList "Line" [
        test "Line1 generated JS did not regress" {
            let l1 = Path.Combine(baselineDir, "line-1.js")
            let expectedJS = File.ReadAllText(l1)
            let actualJS = Line1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Line1"
        }

        test "Line2 generated JS did not regress" {
            let l2 = Path.Combine(baselineDir, "line-2.js")
            let expectedJS = File.ReadAllText(l2)
            let actualJS = Line2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Line2"
        }

        test "Line3 generated JS did not regress" {
            let l3 = Path.Combine(baselineDir, "line-3.js")
            let expectedJS = File.ReadAllText(l3)
            let actualJS = Line3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Line3"
        }
    ]

[<Tests>]
let tesLineCharts =
    testList "Line charts" [
        test "Chart1 generated JS did not regress" {
            let c1 = Path.Combine(baselineDir, "chart-1.js")
            let expectedJS = File.ReadAllText(c1)
            let actualJS = Chart1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart1"
        }

        test "Chart2 generated JS did not regress" {
            let c2 = Path.Combine(baselineDir, "chart-2.js")
            let expectedJS = File.ReadAllText(c2)
            let actualJS = Chart2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Column2"
        }

        test "Chart3 generated JS did not regress" {
            let c3 = Path.Combine(baselineDir, "chart-3.js")
            let expectedJS = File.ReadAllText(c3)
            let actualJS = Chart3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart3"
        }

        test "Chart4 generated JS did not regress" {
            let c4 = Path.Combine(baselineDir, "chart-4.js")
            let expectedJS = File.ReadAllText(c4)
            let actualJS = Chart4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart4"
        }

        test "Chart5 generated JS did not regress" {
            let c5 = Path.Combine(baselineDir, "chart-5.js")
            let expectedJS = File.ReadAllText(c5)
            let actualJS = Chart5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart5"
        }

        test "Chart6 generated JS did not regress" {
            let c6 = Path.Combine(baselineDir, "chart-6.js")
            let expectedJS = File.ReadAllText(c6)
            let actualJS = Chart6.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart6"
        }

        test "Chart7 generated JS did not regress" {
            let c7 = Path.Combine(baselineDir, "chart-7.js")
            let expectedJS = File.ReadAllText(c7)
            let actualJS = Chart7.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart7"
        }

        test "Chart8 generated JS did not regress" {
            let c8 = Path.Combine(baselineDir, "chart-8.js")
            let expectedJS = File.ReadAllText(c8)
            let actualJS = Chart8.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart8"
        }

        test "Chart9 generated JS did not regress" {
            let c9 = Path.Combine(baselineDir, "chart-9.js")
            let expectedJS = File.ReadAllText(c9)
            let actualJS = Chart9.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart9"
        }

        test "Chart10 generated JS did not regress" {
            let c10 = Path.Combine(baselineDir, "chart-10.js")
            let expectedJS = File.ReadAllText(c10)
            let actualJS = Chart10.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart10"
        }

        test "Chart11 generated JS did not regress" {
            let c10 = Path.Combine(baselineDir, "chart-11.js")
            let expectedJS = File.ReadAllText(c10)
            let actualJS = Chart11.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "Chart11"
        }
    ]

[<Tests>]
let testLineScatters =
    testList "Line scatters" [
        test "LineScatter1 generated JS did not regress" {
            let ls1 = Path.Combine(baselineDir, "line-scatter-1.js")
            let expectedJS = File.ReadAllText(ls1)
            let actualJS = LineScatter1.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineScatter1"
        }
        
        test "LineScatter2 generated JS did not regress" {
            let ls2 = Path.Combine(baselineDir, "line-scatter-2.js")
            let expectedJS = File.ReadAllText(ls2)
            let actualJS = LineScatter2.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineScatter2"
        }
        
        test "LineScatter3 generated JS did not regress" {
            let ls3 = Path.Combine(baselineDir, "line-scatter-3.js")
            let expectedJS = File.ReadAllText(ls3)
            let actualJS = LineScatter3.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineScatter1"
        }

        test "LineScatter4 generated JS did not regress" {
            let ls4 = Path.Combine(baselineDir, "line-scatter-4.js")
            let expectedJS = File.ReadAllText(ls4)
            let actualJS = LineScatter4.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineScatter4"
        }

        test "LineScatter5 generated JS did not regress" {
            let ls5 = Path.Combine(baselineDir, "line-scatter-5.js")
            let expectedJS = File.ReadAllText(ls5)
            let actualJS = LineScatter5.js |> Helpers.cleanJS

            Expect.equal expectedJS actualJS "LineScatter5"
        }
    ]