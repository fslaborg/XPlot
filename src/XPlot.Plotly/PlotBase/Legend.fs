namespace XPlot.Plotly

type Legend() =

    let mutable _bgcolor: string option = None
    let mutable _bordercolor: string option = None
    let mutable _borderwidth: float option = None
    let mutable _font: Font option = None
    let mutable _traceorder: string option = None
    let mutable _orientation: string option = None
    let mutable _tracegroupgap: float option = None
    let mutable _x: float option = None
    let mutable _xanchor: _ option = None
    let mutable _y: float option = None
    let mutable _yanchor: _ option = None
    let mutable _yref: string option = None

    /// Sets the legend background color.
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    /// Sets the color of the border enclosing the legend.
    member __.bordercolor
        with get () = Option.get _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the width (in px) of the border enclosing the legend.
    member __.borderwidth
        with get () = Option.get _borderwidth
        and set value = _borderwidth <- Some value

    member __.font
        with get () = Option.get _font
        and set value = _font <- Some value

    /// Determines the order at which the legend items are displayed. If *normal*, the items are displayed top-to-bottom in the same order as the input data. If *reversed*, the items are displayed in the opposite order as *normal*. If *grouped*, the items are displayed in groups (when a trace `legendgroup` is provided). if *grouped+reversed*, the items are displayed in the opposite order as *grouped*.
    member __.traceorder
        with get () = Option.get _traceorder
        and set value = _traceorder <- Some value

    /// Set horizontal *h* or vertical *v* orientation of legend
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// Sets the amount of vertical space (in px) between legend groups.
    member __.tracegroupgap
        with get () = Option.get _tracegroupgap
        and set value = _tracegroupgap <- Some value

    /// Sets the x position (in normalized coordinates) of the legend.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the legend's horizontal position anchor. This anchor binds the `x` position to the *left*, *center* or *right* of the legend.
    member __.xanchor
        with get () = Option.get _xanchor
        and set value = _xanchor <- Some value

    /// Sets the y position (in normalized coordinates) of the legend.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the legend's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the legend.
    member __.yanchor
        with get () = Option.get _yanchor
        and set value = _yanchor <- Some value

    member __.yref
        with get () = Option.get _yref
        and set value = _yref <- Some value

    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
    member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
    member __.ShouldSerializefont() = not _font.IsNone
    member __.ShouldSerializetraceorder() = not _traceorder.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializetracegroupgap() = not _tracegroupgap.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializexanchor() = not _xanchor.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializeyanchor() = not _yanchor.IsNone
    member __.ShouldSerializeyref() = not _yref.IsNone
