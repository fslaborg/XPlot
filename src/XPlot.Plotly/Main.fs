namespace XPlot.Plotly

open Graph
open Newtonsoft.Json

module HTML =

    let template =
        """<head>
  <!-- Plotly.js -->
  <script src="https://cdn.plot.ly/plotly-latest.min.js"></script>
</head>

<body>
  
  <div id="chart" style="width: 900px; height: 500px;"><!-- Plotly chart will be drawn inside this DIV --></div>
  <script>
    var data = [DATA];
    var layout = [LAYOUT];
    Plotly.newPlot('chart', data, layout);
  </script>
</body>"""

open System.IO

type PlotlyChart() =
    
    [<DefaultValue>]
    val mutable private chartHtml: string

    let counter = ref 1

    member __.Plot(data:seq<#Trace>, ?Layout:Layout) =
        let dataJson = JsonConvert.SerializeObject data
        let layoutJson =
            match Layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        let html =
            HTML.template.Replace("[DATA]", dataJson)
                .Replace("[LAYOUT]", layoutJson)
        __.chartHtml <- html

    member __.Show() =
        let tempDir = Path.GetTempPath()
        let pid = System.Diagnostics.Process.GetCurrentProcess().Id
        let file = sprintf "show_%d_%d.html" pid counter.Value
        let path = Path.Combine(tempDir, file)
        File.WriteAllText(path, __.chartHtml)
        System.Diagnostics.Process.Start(path) |> ignore
        incr counter

//    member __.GetInlineHtml(filename) =
//      let resp = __.Plot(filename)
//      """<iframe width="[WIDTH]" height="[HEIGHT]" frameborder="0" seamless="seamless" 
//           scrolling="no" src="[URL].embed?width=[WIDTH]&height=[HEIGHT]"></iframe>"""
//        .Replace("[WIDTH]", string width)
//        .Replace("[HEIGHT]", string height)
//        .Replace("[URL]", resp.Value.url)

type Plotly =

    static member Plot(data) =
        let chart = PlotlyChart()
        chart.Plot(data)
        chart
    
    static member Plot(data, layout) =
        let chart = PlotlyChart()
        chart.Plot(data, layout)
        chart

    static member Show(chart:PlotlyChart) = chart.Show()

module Test =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17]
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [16; 5; 11; 9]
        )

    let layout = Layout(title = "Test")

    ([trace1; trace2], layout)
    |> Plotly.Plot
    |> Plotly.Show
