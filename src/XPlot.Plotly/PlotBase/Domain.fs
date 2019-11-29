namespace XPlot.Plotly

type Domain() =
    let mutable _x: _ option = None
    let mutable _y: _ option = None

    /// Sets the horizontal domain of this pie trace (in plot fraction).
    member __.x
        with get () = Option.defaultValue Unchecked.defaultof<_> _x
        and set value = _x <- Some value

    /// Sets the vertical domain of this pie trace (in plot fraction).
    member __.y
        with get () = Option.defaultValue Unchecked.defaultof<_> _y
        and set value = _y <- Some value

    member __.ShouldSerializex() = _x.IsSome
    member __.ShouldSerializey() = _y.IsSome
