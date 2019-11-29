namespace XPlot.Plotly

type Ybins() =
    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: _ option = None

    /// Sets the starting value for the y axis bins.
    member __.start
        with get () = Option.defaultValue 0.0 _start
        and set value = _start <- Some value

    /// Sets the end value for the y axis bins.
    member __.``end``
        with get () = Option.defaultValue 0.0 _end
        and set value = _end <- Some value

    /// Sets the step in-between value each y axis bin.
    member __.size
        with get () = Option.defaultValue Unchecked.defaultof<_> _size
        and set value = _size <- Some value

    member __.ShouldSerializestart() = not _start.IsNone
    member __.ShouldSerializeend() = not _end.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
