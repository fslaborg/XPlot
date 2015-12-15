namespace XPlot.Plotly

open Graph
open Newtonsoft.Json

module HTML =
    let plotly_url = "https://cdn.plot.ly/plotly-latest.min.js"
    let plotly_reference = """<script src="[URL]"></script>""".Replace("[URL]", plotly_url)
    let file_template =
        """<head>
    [PLOTLY_REF]
</head>
<body>
    [CHART]
</body>"""
  
    let plotly_include = """<script type="text/javascript">
</script>
<script type="text/javascript">
    [PLOTLY_JS]
</script>"""
            
    let script_template = 
        """Plotly.plot("[ID]", [DATA], [LAYOUT], [CONFIG]).then(function() {
    $(".[ID].loading").remove()
})"""
                    
    let chart_template =
        """
<div id="[ID]" style="height: [HEIGHT]; width: [WIDTH];" class="plotly-graph-div"></div>
<script type="text/javascript">[SCRIPT]</script>"""

open System.IO

type PlotlyChart() =
    
    [<DefaultValue>]
    val mutable private chartHtml: string

    member __.ChartHtml () = __.chartHtml

    let div_id = System.Guid.NewGuid().ToString()
    let counter = ref 1

    member __.Plot(data:seq<#Trace>, ?Layout:Layout) =
        let dataJson = JsonConvert.SerializeObject data
        let layoutJson =
            match Layout with
            | None -> "\"\""
            | Some x -> JsonConvert.SerializeObject x
        let script = 
            HTML.script_template.Replace("[ID]", div_id) 
                                .Replace("[DATA]", dataJson)
                                .Replace("[LAYOUT]", layoutJson)
                                .Replace("[CONFIG]", "\"\"") 

        let html =
            HTML.chart_template.Replace("[SCRIPT]", script)
                               .Replace("[ID]", div_id) 
                               .Replace("[WIDTH]", "900px") //hardcode
                               .Replace("[HEIGHT]", "500px") //hardcode
        __.chartHtml <- html


    member __.Show() =
        let tempDir = Path.GetTempPath()
        let pid = System.Diagnostics.Process.GetCurrentProcess().Id
        let file = sprintf "show_%d_%d.html" pid counter.Value
        let path = Path.Combine(tempDir, file)
        let html = HTML.file_template.Replace("[PLOTLY_REF]", HTML.plotly_reference)
                                     .Replace("[CHART]",  __.chartHtml)
        File.WriteAllText(path, html)
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

    static member IShow(chart:PlotlyChart) = chart.ChartHtml()


    static member InitialiseNotebook () = 
        let wc = new System.Net.WebClient()
        let plotlyjs = wc.DownloadString(HTML.plotly_url)
        HTML.plotly_include.Replace("[PLOTLY_JS]", plotlyjs)

