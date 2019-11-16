open System.IO
open BaselineGenerator

let plotlyPrelude = Path.Combine("..", "..", "tests", "TestData", "XPlot.Plotly", "js" + string Path.DirectorySeparatorChar)

module Area =
    open Area

    let generateArea () =
        let path = Path.Combine(plotlyPrelude, "area" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "area-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "area-2.js", js)

        let js = PipeStyle.singleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(path + "single-series.js", js)

        let js = PipeStyle.multipleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(path + "multiple-series.js", js)

        let js = PipeStyle.yValuesJS |> Helpers.cleanJS
        File.WriteAllText(path + "y-values.js", js)

module Bar =
    open Bar

    let generateBar () =
        let path = Path.Combine(plotlyPrelude, "bar" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "bar-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "bar-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(path + "bar-3.js", js)

        let js = PipeStyle.singleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(path + "single-series.js", js)

        let js = PipeStyle.multipleSeriesJS |> Helpers.cleanJS
        File.WriteAllText(path + "multiple-series.js", js)

        let js = PipeStyle.yValuesJS |> Helpers.cleanJS
        File.WriteAllText(path + "y-values.js", js)

module BoxPlot =
    open BoxPlot

    let generateBoxPlots () =
        let path = Path.Combine(plotlyPrelude, "box" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = BasicBoxPlot.js |> Helpers.cleanJS
        File.WriteAllText(path + "basic-boxplot.js", js)

        let js = BoxPlotDisplaysUnderlyingData.js |> Helpers.cleanJS
        File.WriteAllText(path + "boxplot-displays-underlying-data.js", js)

        let js = GroupedBoxPlot.js |> Helpers.cleanJS
        File.WriteAllText(path + "grouped-boxplot.js", js)

module Bubble =
    open Bubble

    let generateBubble () =
        let path = Path.Combine(plotlyPrelude, "bubble" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-3.js", js)

        let js = Chart4.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-4.js", js)

        let js = Chart5.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-5.js", js)

        let js = Chart6.js |> Helpers.cleanJS
        File.WriteAllText(path + "bubble-6.js", js)

module Chart =
    open Chart

    let generateChart () =
        let path = Path.Combine(plotlyPrelude, "chart" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-3.js", js)

module Column =
    open Column

    let generateColumn () =
        let path = Path.Combine(plotlyPrelude, "column" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-3.js", js)

        let js = Chart4.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-4.js", js)

        let js = Chart5.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-5.js", js)

        let js = Chart6.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-6.js", js)

        let js = Chart7.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-7.js", js)

        let js = Chart8.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-8.js", js)

        let js = Chart9.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-9.js", js)

        let js = Chart10.js |> Helpers.cleanJS
        File.WriteAllText(path + "column-10.js", js)

module Contour =
    open Contour

    let generateContour () =
        let path = Path.Combine(plotlyPrelude, "contour" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = BasicContourPlot.js |> Helpers.cleanJS
        File.WriteAllText(path + "contour-1.js", js)

module ThreeDPlots =
    open ThreeDPlots

    let generate3DPlots () =
        let path = Path.Combine(plotlyPrelude, "3D" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = ThreeDRandomWalk.js |> Helpers.cleanJS
        File.WriteAllText(path + "3D-1.js", js)

        let js = ThreeDScatterPlot.js |> Helpers.cleanJS
        File.WriteAllText(path + "3D-2.js", js)

        let js = Topographical3DSurfacePlot.js |> Helpers.cleanJS
        File.WriteAllText(path + "3D-3.js", js)

module ErrorBars =
    open ErrorBars

    let generateErrorbars () =
        let errorbars = Path.Combine(plotlyPrelude, "errorbars" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(errorbars) |> ignore

        let js = BasicSymmetricErrorBars.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-1.js", js)

        let js = BarChartErrorBars.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-2.js", js)

        let js = HorizontalErrorBars.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-3.js", js)

        let js = AsymmetricErrorBars.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-4.js", js)

        let js = ErrorBarsPercentageYValue.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-5.js", js)

        let js = AsymmetricErrorBarsConstantOffset.js |> Helpers.cleanJS
        File.WriteAllText(errorbars + "eb-6.js", js)

module Gauge =
    open Gauge

    let generateGauge () =
        let path = Path.Combine(plotlyPrelude, "gauge" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = CircularGauge.js |> Helpers.cleanJS
        File.WriteAllText(path + "gauge.js", js)

module Heatmaps =
    open Heatmaps

    let generateHeatmaps () =
        let path = Path.Combine(plotlyPrelude, "heatmaps" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore

        let js = BasicHeatmap.js |> Helpers.cleanJS
        File.WriteAllText(path + "basic-heatmap.js", js)

        let js = HeatmapCategoricalAxisLabels.js |> Helpers.cleanJS
        File.WriteAllText(path + "categorical-axis-labels-heatmap.js", js)

        let js = CustomColorscale.js |> Helpers.cleanJS
        File.WriteAllText(path + "custom-colorscale.js", js)

        let js = EarthColorscale.js |> Helpers.cleanJS
        File.WriteAllText(path + "earth-colorscale.js", js)

        let js = YIGnBuColorscale.js |> Helpers.cleanJS
        File.WriteAllText(path + "yignbu-colorscale.js", js)

module Line =
    open Line

    let generateLine () =
        let path = Path.Combine(plotlyPrelude, "line" + string Path.DirectorySeparatorChar)
        Directory.CreateDirectory(path) |> ignore
        
        let js = Line1.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-1.js", js)

        let js = Line2.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-2.js", js)

        let js = Line3.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-3.js", js)

        let js = Chart1.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-1.js", js)

        let js = Chart2.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-2.js", js)

        let js = Chart3.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-3.js", js)

        let js = Chart4.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-4.js", js)

        let js = Chart5.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-5.js", js)

        let js = Chart6.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-6.js", js)

        let js = Chart7.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-7.js", js)

        let js = Chart8.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-8.js", js)

        let js = Chart9.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-9.js", js)

        let js = Chart10.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-10.js", js)

        let js = Chart11.js |> Helpers.cleanJS
        File.WriteAllText(path + "chart-11.js", js)

        let js = LineScatter1.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-scatter-1.js", js)

        let js = LineScatter2.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-scatter-2.js", js)

        let js = LineScatter3.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-scatter-3.js", js)

        let js = LineScatter4.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-scatter-4.js", js)

        let js = LineScatter5.js |> Helpers.cleanJS
        File.WriteAllText(path + "line-scatter-5.js", js)

[<EntryPoint>]
let main _ =
    Directory.CreateDirectory(plotlyPrelude) |> ignore

    Area.generateArea ()
    Bar.generateBar ()
    BoxPlot.generateBoxPlots ()
    Bubble.generateBubble ()
    Chart.generateChart ()
    Column.generateColumn ()
    Contour.generateContour ()
    ThreeDPlots.generate3DPlots ()
    ErrorBars.generateErrorbars ()
    Gauge.generateGauge ()
    Heatmaps.generateHeatmaps ()
    Line.generateLine ()
    
    0 // return an integer exit code
