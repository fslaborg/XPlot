open System.IO
open BaselineGenerator

let plotlyPrelude = Path.Combine("..", "..", "tests", "TestData", "XPlot.Plotly", "js" + string Path.DirectorySeparatorChar)

module Area =
    open Area

    let generateArea () =
        let area = Path.Combine(plotlyPrelude, "area" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(area) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(area + "area-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(area + "area-2.js", js)

        let js = PipeStyle.singleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(area + "single-series.js", js)

        let js = PipeStyle.multipleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(area + "multiple-series.js", js)

        let js = PipeStyle.yValuesJS |> Helpers.cleanJS
        File.WriteAllText(area + "y-values.js", js)

[<EntryPoint>]
let main _ =
    Directory.CreateDirectory(plotlyPrelude) |> ignore

    Area.generateArea ()
    0 // return an integer exit code
