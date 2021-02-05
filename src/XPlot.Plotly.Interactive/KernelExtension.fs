namespace XPlot.Plotly.Interactive

open System
open System.Text
open System.IO
open System.Threading.Tasks

open Microsoft.AspNetCore.Html
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting
open Microsoft.DotNet.Interactive.Http
open XPlot.Plotly

open System.Management.Automation

open Microsoft.DotNet.Interactive.PowerShell

open Giraffe.ViewEngine

type KernelExtension() =
    let getScriptElementWithRequire (script: string) =
        let newScript = StringBuilder()
        newScript.AppendLine("""<script type="text/javascript">""") |> ignore
        newScript.AppendLine("""
var renderPlotly = function() {
    var xplotRequire = require.config({context:'xplot-3.0.1',paths:{plotly:'https://cdn.plot.ly/plotly-1.49.2.min'}}) || require;
    xplotRequire(['plotly'], function(Plotly) { """) |> ignore
        newScript.AppendLine(script) |> ignore
        newScript.AppendLine(@"});
};"
        ) |> ignore
        newScript.AppendLine(JavascriptUtilities.GetCodeForEnsureRequireJs(Uri("https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js"), "renderPlotly")) |> ignore
        newScript.ToString()

    let getHtml (chart: PlotlyChart) =
        let styleStr = $"width: {chart.Width}px; height: {chart.Height}px;"
        let divElem =
            div [_style styleStr; _id chart.Id] [] |> RenderView.AsString.htmlDocument

        let js = chart.GetInlineJS().Replace("<script>", String.Empty).Replace("</script>", String.Empty)
        HtmlString(divElem + getScriptElementWithRequire js)

    let registerPlotlyFormatters () =
        Formatter.Register<PlotlyChart>(
            Action<_,_>(fun (chart: PlotlyChart) (writer: TextWriter) ->
                writer.Write(getHtml chart)),
            HtmlFormatter.MimeType)

    let registerPowerShellAccelerators () =
        // Register type accelerators for Plotly.
        let accelerator = typeof<PSObject>.Assembly.GetType("System.Management.Automation.TypeAccelerators")
        let addAccelerator = accelerator.GetMethod("Add", [| typeof<string>; typeof<Type> |])
        let traces =  typeof<Trace>.Assembly.GetTypes() |> Array.filter (fun (t:Type) -> typeof<Trace>.IsAssignableFrom(t))  
        for trace in traces do
            addAccelerator.Invoke(null, [|$"Graph.{trace.Name}"; trace |]) |>ignore
           
        // Add accelerators that exist in other namespaces.
        addAccelerator.Invoke(null, [| "Layout"; typeof<Layout.Layout> |]) |>ignore
        addAccelerator.Invoke(null, [| "Chart"; typeof<Chart> |]) |>ignore

    let registerPowerShellModule () = 
        ()
        

    let configurePowerShellKernel () = 
        KernelInvocationContext.Current.Display("Configuring PowerShell Kernel for XPlot.Plotly integration.","text/markdown") |> ignore
        registerPowerShellAccelerators()
        registerPowerShellModule()
              

    interface IKernelExtension with
        member _.OnLoadAsync kernel =
            registerPlotlyFormatters()
            let visitKernels (subKernel: Kernel) =
                match subKernel with
                | :? PowerShellKernel -> configurePowerShellKernel()
                | _ -> kernel |> ignore

            kernel.VisitSubkernelsAndSelf(Action<Kernel>(visitKernels),true)         
            KernelInvocationContext.Current.Display("Installed support for XPlot.Plotly.","text/markdown") |> ignore
            Task.CompletedTask 
            

    
