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
open XPlot.Plotly.Interactive.PowerShell.Commands

type KernelExtension() =
    static let mutable PlotlyUrl = "https://cdn.plot.ly/plotly-1.49.2.min"
    static let mutable RequireJsUrl = "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js"
    let getScriptElementWithRequire (script: string) =
        let newScript = StringBuilder()
        newScript.AppendLine("""<script type="text/javascript">""") |> ignore
        newScript.AppendLine($"""
var renderPlotly = function() {{
    var xplotRequire = require.config({{context:'xplot-3.0.1',paths:{{plotly:'%s{PlotlyUrl}'}}}}) || require;
    xplotRequire(['plotly'], function(Plotly) {{ """) |> ignore
        newScript.AppendLine(script) |> ignore
        newScript.AppendLine(@"});
};"
        ) |> ignore
        newScript.AppendLine(JavascriptUtilities.GetCodeForEnsureRequireJs(Uri(RequireJsUrl), "renderPlotly")) |> ignore
        newScript.AppendLine("</script>") |> ignore
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
        let addMethod = accelerator.GetMethod("Add", [| typeof<string>; typeof<Type> |])
        let addAccelerator (name, objectType) = addMethod.Invoke(null, [| name; objectType |]) |> ignore
        typeof<Trace>.Assembly.GetTypes()
        |> Array.filter typeof<Trace>.IsAssignableFrom
        |> Array.map (fun trace -> ($"Graph.{trace.Name}", trace))
        |> Array.append [| ("Layout", typeof<Layout.Layout>); ("Chart", typeof<Chart>) |]
        |> Array.iter addAccelerator

    let registerPowerShellModule () =
        // Add Modules directory that contains the helper modules.
        let psModulePath = Environment.GetEnvironmentVariable("PSModulePath")
        let psXPlotModulePath = Path.Join(Path.GetDirectoryName(typeof<NewPlotlyChartCommand>.Assembly.Location), "Modules")
        Environment.SetEnvironmentVariable("PSModulePath", $"{psXPlotModulePath}{Path.PathSeparator}{psModulePath}")

    let configurePowerShellKernel () =
        KernelInvocationContext.Current.DisplayAs("Configuring PowerShell Kernel for XPlot.Plotly integration.","text/markdown") |> ignore
        registerPowerShellAccelerators()
        registerPowerShellModule()

    /// Override the Plotly cdn url value used in all KernelExtensions.
    static member SetPlotlyUrl(url: string) = PlotlyUrl <- url

    /// Override the RequireJS cdn url value used in all KernelExtensions.
    static member SetRequireJsUrl(url: string) = RequireJsUrl <- url

    interface IKernelExtension with
        member _.OnLoadAsync kernel =
            registerPlotlyFormatters()
            let visitKernels (subKernel: Kernel) =
                match subKernel with
                | :? PowerShellKernel -> configurePowerShellKernel()
                | _ -> ()

            kernel.VisitSubkernelsAndSelf(Action<Kernel>(visitKernels))
            KernelInvocationContext.Current.DisplayAs("Installed support for XPlot.Plotly.","text/markdown") |> ignore
            Task.CompletedTask



