namespace XPlot.Plotly

open Graph
open Newtonsoft.Json
open System

module HTML =

    let template =
        """<head>
  <!-- Plotly.js -->
  <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
</head>

<body>
  
  <div id="[ID]" style="width: 900px; height: 500px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout);
  </script>
</body>"""

    let inlineTemplate =
        """<div id="[ID]" style="width: 900px; height: 500px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('[ID]', data, layout);
  </script>"""

open System.IO

type PlotlyChart() =
    let guid = Guid.NewGuid().ToString()

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
            HTML.template
                .Replace("[ID]", guid)
                .Replace("[DATA]", __.dataJson)
                .Replace("[LAYOUT]", __.layoutJson)
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" guid
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

    member __.GetInlineHtml() =
        HTML.inlineTemplate
            .Replace("[ID]", guid)
            .Replace("[DATA]", __.dataJson)
            .Replace("[LAYOUT]", __.layoutJson)

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
