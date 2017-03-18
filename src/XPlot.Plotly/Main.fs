namespace XPlot.Plotly

open Graph
open Newtonsoft.Json
open System
open System.IO

module Html =

    let pageTemplate =
        """<!DOCTYPE html>
<html>
    <head>
        <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
    </head>
    <body>
        [CHART]
    </body>
</html>"""

    let inlineTemplate =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"></div>
        <script>
            var data = [DATA];
            var layout = [LAYOUT];
            Plotly.newPlot('[ID]', data, layout);
        </script>"""

    let jsTemplate =
        """<script>
            var data = [DATA];
            var layout = [LAYOUT];
            Plotly.newPlot('[ID]', data, layout);
        </script>"""
    
    /// Display given html markup in default browser
    let showInBrowser html pageId=
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" pageId
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

type Options = Layout

type PlotlyChart() =

    [<DefaultValue>]
    val mutable private traces : seq<Trace>

    let serializeTraces names (traces:seq<Trace>) =
        match names with
        | None -> traces
        | Some names ->            
            traces
            |> Seq.mapi (fun i trace ->
                trace.name <- Seq.nth i names
                trace)
        |> JsonConvert.SerializeObject

    [<DefaultValue>]
    val mutable private layout : Layout option

    [<DefaultValue>]
    val mutable private labels : seq<string> option

    /// Returns the chart's full HTML source.
    member __.GetHtml() =
//        let tracesJson = serializeTraces __.labels __.traces
//        let layoutJson =
//            match __.layout with
//            | None -> "\"\""
//            | Some x -> JsonConvert.SerializeObject x
        let chartMarkup = __.GetInlineHtml()
//            Html.inlineTemplate
//                .Replace("[ID]", __.Id)
//                .Replace("[WIDTH]", string __.Width)
//                .Replace("[HEIGHT]", string __.Height)
//                .Replace("[DATA]", tracesJson)
//                .Replace("[LAYOUT]", layoutJson)
        Html.pageTemplate.Replace("[CHART]", chartMarkup)

    /// Inline markup that can be embedded in a HTML document.
    member __.GetInlineHtml() =
        let tracesJson = serializeTraces __.labels __.traces
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        Html.inlineTemplate
            .Replace("[ID]", __.Id)
            .Replace("[WIDTH]", string __.Width)
            .Replace("[HEIGHT]", string __.Height)
            .Replace("[DATA]", tracesJson)
            .Replace("[LAYOUT]", layoutJson)

    /// The chart's inline JavaScript code.
    member __.GetInlineJS() =
        let tracesJson = serializeTraces __.labels __.traces
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        Html.jsTemplate
            .Replace("[DATA]", tracesJson)
            .Replace("[LAYOUT]", layoutJson)

    /// The height of the chart container element.
    member val Height = 500 with get, set

    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString()
        with get, set

    member __.Plot(data:seq<#Trace>, ?Layout, ?Labels) =
        data
        |> Seq.map (fun trace -> trace :> Trace)
        |> fun traces -> __.traces <- traces
        __.layout <- Layout
        __.labels <- Labels

    member __.Show() =
//        let tracesJson = serializeTraces __.labels __.traces
//        let layoutJson =
//            match __.layout with
//            | None -> "\"\""
//            | Some x -> JsonConvert.SerializeObject x
//        let html =
//            let chartMarkup =
//                Html.inlineTemplate
//                    .Replace("[ID]", __.Id)
//                    .Replace("[WIDTH]", string __.Width)
//                    .Replace("[HEIGHT]", string __.Height)
//                    .Replace("[DATA]", tracesJson)
//                    .Replace("[LAYOUT]", layoutJson)
//            Html.pageTemplate.Replace("[CHART]", chartMarkup)
        let html = __.GetHtml()
        Html.showInBrowser html __.Id        

    /// The width of the chart container element.
    member val Width = 900 with get, set

    /// Sets the chart's height.
    member __.WithHeight height = __.Height <- height

    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    member __.WithLabel label = __.labels <- Some <| Seq.singleton label

    /// Sets the data series labels. Use this method if the
    /// chart's data is a series collection.
    member __.WithLabels(labels) = __.labels <- Some labels 

    /// Sets the chart's configuration options.
    member __.WithLayout(layoutObj) = __.layout <- Some layoutObj

    /// Display/hide the legend.
    member __.WithLegend enabled =
        match __.layout with
        | None ->
            let layout = Layout(showlegend = enabled)
            __.layout <- Some layout
        | Some layout -> layout.showlegend <- enabled

    /// Sets the chart's configuration options.
    member __.WithOptions options = __.WithLayout options

    /// Sets the chart's width and height.
    member __.WithSize (width, height) = 
        __.Height <- height
        __.Width <- width

    /// Sets the chart's title.
    member __.WithTitle title =
        match __.layout with
        | None ->
            let layout = Layout(title = title)
            __.layout <- Some layout
        | Some layout -> layout.title <- title

    /// Sets the chart's width.
    member __.WithWidth width = __.Width <- width

    /// Sets the chart's X-axis title.
    member __.WithXTitle xTitle =
        match __.layout with
        | None ->
            let layout = Layout(xaxis = Xaxis(title = xTitle))
            __.layout <- Some layout
        | Some layout ->
            try layout.xaxis.title <- xTitle
            with _ -> layout.xaxis <- Xaxis(title = xTitle)

    /// Sets the chart's Y-axis title.
    member __.WithYTitle yTitle =
        match __.layout with
        | None ->
            let layout = Layout(yaxis = Yaxis(title = yTitle))
            __.layout <- Some layout
        | Some layout ->
            try layout.yaxis.title <- yTitle
            with _ -> layout.yaxis <- Yaxis(title = yTitle)

type key = IConvertible
type value = IConvertible

type Chart =

    static member Plot(data) = 
        let chart = PlotlyChart()
        chart.Plot [data]
        chart

    static member Plot(data:seq<#Trace>) = 
        let chart = PlotlyChart()
        chart.Plot data
        chart

    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot([data], layout)
        chart

    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot(data, layout)
        chart

    /// Displays a chart in the default browser.
    static member Show(chart:PlotlyChart) = chart.Show()

    /// Combine charts together and display as a single page in default browser
    static member ShowAll(charts:seq<PlotlyChart>)=
        let html = charts |> Seq.map (fun c->c.GetInlineHtml()) |> Seq.reduce (+)
        let pageHtml = Html.pageTemplate.Replace("[CHART]", html)
        let combinedChartId = Guid.NewGuid().ToString()
        Html.showInBrowser pageHtml combinedChartId

    /// Sets the chart's height.
    static member WithHeight height (chart:PlotlyChart) =
        chart.WithHeight height
        chart

    /// Sets the chart's container div id.
    static member WithId id (chart:PlotlyChart) =
        chart.WithId id
        chart

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    static member WithLabel label (chart:PlotlyChart) =
        chart.WithLabel label
        chart

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    static member WithLabels labels (chart:PlotlyChart) =
        chart.WithLabels labels
        chart

    static member WithLayout layout (chart:PlotlyChart) =
        chart.WithLayout layout
        chart

    /// Display/hide the legend.
    static member WithLegend enabled (chart:PlotlyChart) =
        chart.WithLegend enabled
        chart

    /// Sets the chart's configuration options.
    static member WithOptions options (chart:PlotlyChart) =
        chart.WithOptions options
        chart

    /// Sets the chart's height.
    static member WithSize size (chart:PlotlyChart) =
        chart.WithSize size
        chart

    /// Sets the chart's title.
    static member WithTitle title (chart:PlotlyChart) =
        chart.WithTitle title
        chart

    /// Sets the chart's width.
    static member WithWidth width (chart:PlotlyChart) =
        chart.WithWidth width
        chart

    /// Sets the chart's X-axis title.
    static member WithXTitle xTitle (chart:PlotlyChart) =
        chart.WithXTitle xTitle
        chart

    /// Sets the chart's Y-axis title.
    static member WithYTitle yTitle (chart:PlotlyChart) =
        chart.WithYTitle yTitle
        chart

type Chart with

    static member Area(data:seq<#value>) =
        let x = Seq.mapi (fun i _ -> i) data
        let area = Scatter(x = x, y = data, fill = "tozeroy")
        Chart.Plot [area]

    static member Area(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let area = Scatter(x = x, y = y, fill = "tozeroy")
        Chart.Plot [area]

    static member Area(data:seq<#seq<#key * #value>>) =
        let areas =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                match i with
                | 0 -> Scatter(x = x, y = y, fill = "tozeroy")
                | _ -> Scatter(x = x, y = y, fill = "tonexty")
            )
        Chart.Plot areas

    static member Bar(data:seq<#value>) =
        let bar = Bar(x = data, orientation = "h")
        Chart.Plot [bar]

    static member Bar(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let bar = Bar(x = y, y = x, orientation = "h")
        Chart.Plot [bar]

    static member Bar(data:seq<#seq<#key * #value>>) =
        let bars =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Bar(x = y, y = x, orientation = "h")
            )
        Chart.Plot bars

    static member Bubble(data:seq<#key * #value * #value>) =
        let xs = data |> Seq.map (fun (x, _, _) -> x)
        let ys = data |> Seq.map (fun (_, y, _) -> y)
        let sizes = data |> Seq.map (fun (_, _, size) -> size)
        let trace =
            Scatter(
                x = xs,
                y = ys,
                mode = "markers",
                marker =
                    Marker (
                        size = sizes
                    )
            )
        Chart.Plot trace

    static member Column(data:seq<#value>) =
        let bar = Bar(y = data)
        Chart.Plot [bar]

    static member Column(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let bar = Bar(x = x, y = y)
        Chart.Plot [bar]

    static member Column(data:seq<#seq<#key * #value>>) =
        let bars =
            data
            |> Seq.mapi (fun i series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Bar(x = x, y = y)
            )
        Chart.Plot bars

    static member Line(data:seq<#value>) =
        let scatter = Scatter(y = data)
        Chart.Plot [scatter]

    static member Line(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let scatter = Scatter(x = x, y = y)
        Chart.Plot [scatter]

    static member Line(data:seq<#seq<#key * #value>>) =
        let scatters =
            data
            |> Seq.map (fun series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Scatter(x = x, y = y)
            )
        Chart.Plot scatters

    static member Pie(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let pie = Pie(labels = x, values = y)
        Chart.Plot [pie]

    static member Scatter(data:seq<#value>) =
        let scatter = Scatter(y = data, mode = "markers")
        Chart.Plot [scatter]

    static member Scatter(data:seq<#key * #value>) =
        let x = Seq.map fst data
        let y = Seq.map snd data
        let scatter = Scatter(x = x, y = y, mode = "markers")
        Chart.Plot [scatter]

    static member Scatter(data:seq<#seq<#key * #value>>) =
        let scatters =
            data
            |> Seq.map (fun series ->
                let x = Seq.map fst series
                let y = Seq.map snd series
                Scatter(x = x, y = y, mode = "markers")
            )
        Chart.Plot scatters

[<ObsoleteAttribute("Use the Chart type instead.")>]
type Plotly = Chart
