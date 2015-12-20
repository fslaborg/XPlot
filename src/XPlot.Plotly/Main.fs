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
    val mutable private layoutJson: string

    member __.Plot(data:seq<#Trace>, ?Layout:Layout) =
        let dataJson = JsonConvert.SerializeObject data
        __.dataJson <- dataJson
        let layoutJson =
            match Layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        __.layoutJson <- layoutJson

    member __.Show() =
        let html =
            let chartMarkup =
                HTML.chart
                    .Replace("[ID]", guid)
                    .Replace("[WIDTH]", width)
                    .Replace("[HEIGHT]", height)
                    .Replace("[DATA]", __.dataJson)
                    .Replace("[LAYOUT]", __.layoutJson)
            HTML.doc.Replace("[CHART]", chartMarkup)
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

    member __.GetInlineHtml() =
        HTML.chart
            .Replace("[ID]", guid)
            .Replace("[WIDTH]", width)
            .Replace("[HEIGHT]", height)
            .Replace("[DATA]", __.dataJson)
            .Replace("[LAYOUT]", __.layoutJson)

    member __.WithWidth(widthValue: int) = width <- string widthValue

    member __.WithHeight(heightValue: int) = height <- string heightValue

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
