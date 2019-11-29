namespace XPlot.Plotly

type Trace() =
    let mutable _name: string option = None

    /// Sets the trace name. The trace name appear as the legend item and on hover.
    member _.name
        with get () = Option.defaultValue "" _name
        and set value = _name <- Some value

    member _.ShouldSerializename() = _name.IsSome