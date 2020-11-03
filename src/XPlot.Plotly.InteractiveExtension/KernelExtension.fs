namespace XPlot.DotNet.Interactive.KernelExtensions

open System
open System.Text
open System.IO
open System.Threading.Tasks

open Microsoft.AspNetCore.Html
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Formatting
open Microsoft.DotNet.Interactive.Http
open XPlot.Plotly

open Giraffe.ViewEngine

type KernelExtension() =
    let getScriptElementWithRequire (script: string) =
        let newScript = StringBuilder()
        newScript.AppendLine("""<script type="text/javascript">""") |> ignore
        newScript.AppendLine("""
var renderPlotly = function() {
    var xplotRequire = require.config({context:'xplot-3.0.1',paths:{plotly:'https://cdn.plot.ly/plotly-1.49.2.min'}}) || require;
    xplotRequire(['plotly'], function(Plotly) {" """) |> ignore
        newScript.AppendLine(script) |> ignore
        newScript.AppendLine(@"});
};"
        ) |> ignore
        newScript.AppendLine(JavascriptUtilities.GetCodeForEnsureRequireJs(Uri("https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js"), "renderPlotly")) |> ignore
        newScript.ToString()

    let getHtml (chart: PlotlyChart) =
        let styleStr = sprintf "width: %dpx; height: %dpx;" chart.Width chart.Height
        let divElem =
            div [_style styleStr; _id chart.Id] [] |> RenderView.AsString.htmlDocument

        let js = chart.GetInlineJS().Replace("<script>", String.Empty).Replace("</script>", String.Empty)
        HtmlString(divElem + getScriptElementWithRequire js)

    let registerPlotlyFormatters () =
        Formatter.Register<PlotlyChart>(
            Action<_,_>(fun (chart: PlotlyChart) (writer: TextWriter) ->
                writer.Write(getHtml chart)),
            HtmlFormatter.MimeType)

    interface IKernelExtension with
        member _.OnLoadAsync _ =
            registerPlotlyFormatters()
            Task.CompletedTask

    