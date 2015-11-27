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

    let plotly_url = "https://cdn.plot.ly/plotly-latest.min.js"
    let plotly_include = """<script type="text/javascript">
    require=requirejs=define=undefined;
</script>
<script type="text/javascript">
    [PLOTLY_JS]
</script>"""
            

    let script_template = 
        """Plotly.plot("[ID]", [DATA], [LAYOUT], [CONFIG]).then(function() {
    $(".[ID].loading").remove()
})"""
                    

    let jupyter_template =
        """<div class="[ID] loading" style="color: rgb(50,50,50);">Drawing...</div>
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
        let html =
            HTML.template.Replace("[DATA]", dataJson)
                         .Replace("[LAYOUT]", layoutJson)
        __.chartHtml <- html

    member __.IPlot(data:seq<#Trace>, ?Layout:Layout) =
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
            HTML.jupyter_template.Replace("[SCRIPT]", script)
                                 .Replace("[ID]", div_id) //hardcode
                                 .Replace("[WIDTH]", "200") //hardcode
                                 .Replace("[HEIGHT]", "100") //hardcode
                               
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

    static member IPlot(data) =
        let chart = PlotlyChart()
        chart.IPlot(data)
        chart.ChartHtml()

    static member IPlot(data, layout) =
        let chart = PlotlyChart()
        chart.IPlot(data, layout)
        chart.ChartHtml()

    static member init_notebook_mode () = 
        let wc = new System.Net.WebClient()
        let plotlyjs = wc.DownloadString(HTML.plotly_url)
        HTML.plotly_include.Replace("[PLOTLY_JS]", plotlyjs)

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

    (*  IFsharp Notebook useage  *) 
    //Plotly.init_notebook_mode () |> Util.Html
    // ([trace1; trace2], layout) |> Plotly.IPlot |> Util.Html
