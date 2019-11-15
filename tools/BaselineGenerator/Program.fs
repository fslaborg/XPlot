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

module Bar =
    open Bar

    let generateBar () =
        let area = Path.Combine(plotlyPrelude, "bar" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(area) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(area + "bar-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(area + "bar-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(area + "bar-3.js", js)

        let js = PipeStyle.singleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(area + "single-series.js", js)

        let js = PipeStyle.multipleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(area + "multiple-series.js", js)

        let js = PipeStyle.yValuesJS |> Helpers.cleanJS
        File.WriteAllText(area + "y-values.js", js)

module BoxPlot =
    open BoxPlot

    let generateBoxPlots () =
        let area = Path.Combine(plotlyPrelude, "box" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(area) |> ignore

        let js = BasicBoxPlot.js |> Helpers.cleanJS
        File.WriteAllText(area + "basic-boxplot.js", js)

        let js = BoxPlotDisplaysUnderlyingData.js |> Helpers.cleanJS
        File.WriteAllText(area + "boxplot-displays-underlying-data.js", js)

        let js = GroupedBoxPlot.js |> Helpers.cleanJS
        File.WriteAllText(area + "grouped-boxplot.js", js)

module Bubble =
    open Bubble

    let generateBubble () =
        let area = Path.Combine(plotlyPrelude, "bubble" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(area) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-3.js", js)

        let js = Chart4.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-4.js", js)

        let js = Chart5.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-5.js", js)

        let js = Chart6.js |> Helpers.cleanJS
        File.WriteAllText(area + "bubble-6.js", js)

[<EntryPoint>]
let main _ =
    Directory.CreateDirectory(plotlyPrelude) |> ignore

    Area.generateArea ()
    Bar.generateBar ()
    BoxPlot.generateBoxPlots ()
    Bubble.generateBubble ()
    0 // return an integer exit code
