namespace XPlot.Plotly.Interactive.PowerShell.Commands

open XPlot.Plotly
open System.Management.Automation

[<Cmdlet(VerbsCommon.New, "PlotlyChart")>]
[<OutputType("XPlot.Plotly.Chart")>]
[<Alias("npc")>]
type NewPlotlyChartCommand() =
    inherit PSCmdlet()

    [<Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)>]
    member val Trace:Trace[] = null with get, set

    [<Parameter(Position = 1)>]
    member val Title = "" with get, set

    [<Parameter(Position = 1)>]
    member val Layout = Unchecked.defaultof<Layout.Layout> with get, set

    override _.BeginProcessing() = ()

    override _.ProcessRecord() = ()

    override this.EndProcessing() =
        let traces = if isNull this.Trace then [||] else this.Trace
        let chart = Chart.Plot(traces)
        chart.WithTitle(this.Title)
        if this.Layout <> Unchecked.defaultof<Layout.Layout> then 
            chart.WithLayout(this.Layout)
        this.WriteObject(chart)