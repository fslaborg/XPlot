namespace XPlot.Plotly.Interactive.PowerShell.Commands

open System.Collections.Generic
open XPlot.Plotly
open System.Management.Automation

[<Cmdlet(VerbsCommon.New, "PlotlyChart")>]
[<OutputType("XPlot.Plotly.Chart")>]
[<Alias("npc")>]
type NewPlotlyChartCommand() =
    inherit PSCmdlet()
    [<DefaultValue>]
    [<AllowNull>]
    val mutable private _traces: List<Trace>

    [<Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)>]
    member val Trace:Trace[] = null with get, set

    [<Parameter(Position = 1)>]
    member val Title = "" with get, set

    [<Parameter(Position = 1)>]
    member val Layout = Unchecked.defaultof<Layout.Layout> with get, set

    override this.BeginProcessing() = 
        this._traces <- List<Trace>()

    override this.ProcessRecord() = 
        let traces = if isNull this.Trace then [||] else this.Trace
        this._traces.AddRange(traces)
        

    override this.EndProcessing() =
        let chart = Chart.Plot(this._traces)
        chart.WithTitle(this.Title)
        if this.Layout <> Unchecked.defaultof<Layout.Layout> then 
            chart.WithLayout(this.Layout)
        this.WriteObject(chart)