namespace XPlot.Plotly

type Margin() =

    let mutable _l: float option = None
    let mutable _r: float option = None
    let mutable _t: float option = None
    let mutable _b: float option = None
    let mutable _pad: float option = None
    let mutable _autoexpand: bool option = None

    /// Sets the left margin (in px).
    member __.l
        with get () = Option.get _l
        and set value = _l <- Some value

    /// Sets the right margin (in px).
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// Sets the top margin (in px).
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    /// Sets the bottom margin (in px).
    member __.b
        with get () = Option.get _b
        and set value = _b <- Some value

    /// Sets the amount of padding (in px) between the plotting area and the axis lines
    member __.pad
        with get () = Option.get _pad
        and set value = _pad <- Some value

    member __.autoexpand
        with get () = Option.get _autoexpand
        and set value = _autoexpand <- Some value

    member __.ShouldSerializel() = not _l.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializeb() = not _b.IsNone
    member __.ShouldSerializepad() = not _pad.IsNone
    member __.ShouldSerializeautoexpand() = not _autoexpand.IsNone
