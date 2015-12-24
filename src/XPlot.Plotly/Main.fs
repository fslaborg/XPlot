namespace XPlot.Plotly

open Graph
open Newtonsoft.Json
open System

module HTML =

    let doc =
        """<head>
  <!-- Plotly.js -->
  <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
</head>

<body>
  [CHART]
</body>"""

    let chart =
        """<div id="[ID]" style="width: [WIDTH]px; height: [HEIGHT]px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout);
  </script>"""

open System.IO

type PlotlyChart() =
    let guid = Guid.NewGuid().ToString()

    let mutable width = "900"

    let mutable height = "500"

    [<DefaultValue>]
    val mutable private dataJson: string

    [<DefaultValue>]
    val mutable private layout: Layout option

    member __.Plot(data:seq<#Trace>, ?Layout:Layout) =
        let dataJson = JsonConvert.SerializeObject data
        __.dataJson <- dataJson
        __.layout <- Layout

    member __.Show() =
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        let html =
            let chartMarkup =
                HTML.chart
                    .Replace("[ID]", guid)
                    .Replace("[WIDTH]", width)
                    .Replace("[HEIGHT]", height)
                    .Replace("[DATA]", __.dataJson)
                    .Replace("[LAYOUT]", layoutJson)
            HTML.doc.Replace("[CHART]", chartMarkup)
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

    member __.GetInlineHtml() =
        let layoutJson =
            match __.layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        HTML.chart
            .Replace("[ID]", guid)
            .Replace("[WIDTH]", width)
            .Replace("[HEIGHT]", height)
            .Replace("[DATA]", __.dataJson)
            .Replace("[LAYOUT]", layoutJson)

    member __.WithWidth(widthValue: int) = width <- string widthValue

    member __.WithHeight(heightValue: int) = height <- string heightValue

    member __.WithLayout(layoutObj) = __.layout <- Some layoutObj

type Plotly =

    static member Plot(data) = 
        let chart = PlotlyChart()
        chart.Plot data
        chart

    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot(data, layout)
        chart

    static member Show(chart:PlotlyChart) = chart.Show()

    static member WithWidth width (chart:PlotlyChart) =
        chart.WithWidth width
        chart

    static member WithHeight height (chart:PlotlyChart) =
        chart.WithHeight height
        chart

    static member WithLayout layout (chart:PlotlyChart) =
        chart.WithLayout layout
        chart

