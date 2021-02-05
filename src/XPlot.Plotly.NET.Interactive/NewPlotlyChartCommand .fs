namespace XPlot.Plotly.NET.Interactive.PowerShell.Commands

open System.Collections.Generic
open XPlot.Plotly
open System.Management.Automation

[<Cmdlet(VerbsCommon.New, "PlotlyChart")>]
[<OutputType("XPlot.Plotly.Chart")>]
[<Alias("npc")>]
type NewPlotlyChartCommand() as this =
    inherit PSCmdlet()

    let mutable traces: List<'Traces> = null

    [<Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)>]
    member val Trace = Unchecked.defaultof<Trace[]> with get, set

    [<Parameter(Position = 1)>]
    member val Title = "" with get, set

    [<Parameter(Position = 1)>]
    member val Layout  = Unchecked.defaultof<Layout.Layout> with get, set

    override _.BeginProcessing() =
        traces <- List<'Traces>()

    override _.ProcessRecord() =
        traces.AddRange(this.Trace)

    override _.EndProcessing() =
        let nullCheck03 x = match x with null -> true | _ -> false
        let chart = Chart.Plot(traces)
        chart.WithTitle(this.Title)
        if this.Layout <> Unchecked.defaultof<Layout.Layout> then 
            chart.WithLayout(this.Layout)
        this.WriteObject(chart)