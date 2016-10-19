namespace XPlot.D3

open System.IO
open System
open System.Text
open Newtonsoft.Json
open XPlot.D3.Configuration

module HtmlGeneration =

    let jsTemplate = File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "jsTemplate.js"))
    let inlineTemplate =
        """
            <script type="text/javascript">
                {JS}
            </script>

            <div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>
        """

    let pageTemplate =
        """<!DOCTYPE html>
            <html>
                <head>
                    <meta charset="UTF-8">
                    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
                    <title>D3 Chart</title>
                </head>
                <body>
                    <div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>
                    <script src="http://d3js.org/d3.v3.min.js"></script>
                    <script type="text/javascript">
                        
                        {JS}
                    </script>
                </body>
            </html>"""

type ChartGallery =
    | ForceLayout


type public ForceLayoutChart() = 

    [<DefaultValue>]
    val mutable private nodes : seq<Node> 
    

    [<DefaultValue>]
    val mutable private edges : seq<Edge>
    
    // [<DefaultValue>]
    // val mutable private options : Options
    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery

    member val Options = defaultOptions with get, set
    member __.GetHtml() =
        
        let packages =
            match __.``type`` with
            | ForceLayout -> "forcelayoutchart"

        HtmlGeneration.pageTemplate
            .Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.GetInlineJS())
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))
    /// Displays a chart in the default browser.
    member __.Show() =
        let html = __.GetHtml()
        let tempPath = Path.GetTempPath()
        let file = sprintf "%s.html" __.Id
        let path = Path.Combine(tempPath, file)
        File.WriteAllText(path, html)
        System.Diagnostics.Process.Start(path) |> ignore

    member __.GetInlineHtml() =
        HtmlGeneration.inlineTemplate
            .Replace("{JS}", __.GetInlineJS())
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))
    
    let toHex (color:Color) = 
        String.Format("#{0:X2}{1:X2}{2:X2}", color.Red, color.Green, color.Blue)

    let toNodeStyle (nodeOptions:NodeOptions) =
            {
                FillHex = toHex nodeOptions.Fill
                StrokeHex = toHex nodeOptions.Stroke
                StrokeWidth = sprintf "%fpx" nodeOptions.StrokeWidth
                RadiusScale = nodeOptions.RadiusScale
            }
    let toEdgeStyle (edgeOptions:EdgeOptions) = 
        {
            StrokeHex = toHex edgeOptions.Stroke
            StrokeWidth = sprintf "%fpx" edgeOptions.StrokeWidth
            Distance = edgeOptions.Distance
        }

    member private __.links() = 
        let nodeIdxLkUp = 
            __.nodes
            |> Seq.mapi (fun i n -> n.Name, i )
            |> Map.ofSeq
        __.edges 
            |> Seq.map (fun e -> {source =  nodeIdxLkUp.[e.From.Name]; target =  nodeIdxLkUp.[e.To.Name] })


    /// The chart's inline JavaScript code.
    member __.GetInlineJS() =
        let nodesJson = __.nodes |> JsonConvert.SerializeObject   
        let nodeStylesJson = 
            __.nodes 
            |> Seq.map (__.Options.NodeOptions >> toNodeStyle) 
            |> Array.ofSeq 
            |> JsonConvert.SerializeObject
        let edgesJson = __.links() |> JsonConvert.SerializeObject
        let edgeStylesJson = 
            __.edges
            |> Seq.map(__.Options.EdgeOptions >> toEdgeStyle )
            |> Array.ofSeq
            |> JsonConvert.SerializeObject

        HtmlGeneration.jsTemplate.Replace("{NODES}", nodesJson)
            .Replace("{NODESTYLES}", nodeStylesJson )
            .Replace("{LINKS}", edgesJson)
            .Replace("{LINKSTYLES}", edgeStylesJson )
            .Replace("{GRAVITY}", (__.Options.Gravity.ToString()))
            .Replace("{CHARGE}", (__.Options.Charge.ToString()))

    member val Height = 500 with get, set


    member val Width = 900 with get, set

    member __.WithWidth width = __.Width <- width

    /// Sets the chart's height.
    member __.WithHeight height = __.Height <- height


    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString().Replace("-","")
        |> sprintf "d3%s"
        with get, set

    member __.WithGravity gravity = 
        __.Options <- {__.Options with Gravity = gravity}
    
    member __.WithCharge charge = 
        __.Options <- {__.Options with Charge = charge}

    member __.WithEdgeOptions edgeOptions =
        __.Options <- {__.Options with EdgeOptions = edgeOptions} 
    
    member __.WithNodeOptions nodeOptions = 
        __.Options <- {__.Options with NodeOptions = nodeOptions} 

    static member Create (nodes:seq<Node>) = 
        let ret = ForceLayoutChart()
        ret.nodes <- nodes
        ret.edges <- []
        ret

    static member Create (edgeMappings:seq<string * string>) = 
        let ret = ForceLayoutChart()
        ret.nodes <- 
            edgeMappings 
            |> Seq.map fst 
            |> Seq.append (edgeMappings |> Seq.map snd)
            |> Seq.distinct
            |> Seq.map (fun x -> {Name = x })
        let edges = edgeMappings |> Seq.map(fun e -> 
            {
                From = {Name = (fst e)}
                To = {Name = (snd e)}
            })
        ret.edges <- edges
        ret


type Chart =
    static member Create (nodes:seq<Node>) = 
        ForceLayoutChart.Create nodes
    
    static member Create (edges:seq<string * string>) = 
        ForceLayoutChart.Create edges

    static member WithNodeOptions nodeOptions (chart:ForceLayoutChart) =
        chart.WithNodeOptions nodeOptions
        chart

    static member WithEdgeOptions edgeOptions (chart:ForceLayoutChart) =
        chart.WithEdgeOptions edgeOptions
        chart  
    
    static member WithWidth width (chart:ForceLayoutChart) =
        chart.WithWidth width
        chart

    static member WithHeight height (chart:ForceLayoutChart) =
        chart.WithHeight height
        chart

    static member WithGravity gravity (chart:ForceLayoutChart) = 
        chart.WithGravity gravity
        chart
    
    static member WithCharge charge (chart:ForceLayoutChart) = 
        chart.WithCharge charge
        chart

    /// Displays a chart in the default browser.
    static member Show(chart : ForceLayoutChart) = chart.Show()

type public Chart with
    static member ForceLayout (nodes:seq<Node>) =
        Chart.Create nodes

    static member ForceLayout (edges:seq<string * string>) = 
        Chart.Create edges

    
        




    