namespace XPlot.Plotly

type Xbins() =
    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: _ option = None

    /// Sets the starting value for the x axis bins.
    member __.start
        with get () = Option.defaultValue 0.0 _start
        and set value = _start <- Some value

    /// Sets the end value for the x axis bins.
    member __.``end``
        with get () = Option.defaultValue 0.0 _end
        and set value = _end <- Some value

    /// Sets the step in-between value each x axis bin.
    member __.size
        with get () = Option.defaultValue Unchecked.defaultof<_> _size
        and set value = _size <- Some value

    member __.ShouldSerializestart() = _start.IsSome
    member __.ShouldSerializeend() = _end.IsSome
    member __.ShouldSerializesize() = _size.IsSome
