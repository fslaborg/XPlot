namespace XPlot.Plotly


type Candlestick() =
    inherit Trace()
    let mutable _type: string option = Some "candlestick"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _x: _ option = None
    let mutable _open: _ option = None
    let mutable _high: _ option = None
    let mutable _low: _ option = None
    let mutable _close: _ option = None
    let mutable _increasing: _ option = None
    let mutable _decreasing: _ option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None

    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Determines whether or not an item corresponding to this trace is shown in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
    member __.legendgroup
        with get () = Option.get _legendgroup
        and set value = _legendgroup <- Some value

    /// Sets the opacity of the trace.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    member __.uid
        with get () = Option.get _uid
        and set value = _uid <- Some value

    /// Determines which trace information appear on hover.
    member __.hoverinfo
        with get () = Option.get _hoverinfo
        and set value = _hoverinfo <- Some value

    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Sets the x values - usually time.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value
    
    /// Sets the open values.
    member __.``open``
        with get () = Option.get _open
        and set value = _open <- Some value

    /// Sets the high values.
    member __.high
        with get () = Option.get _high
        and set value = _high <- Some value

    /// Sets the low values.
    member __.low
        with get () = Option.get _low
        and set value = _low <- Some value

    /// Sets the close values.
    member __.close
        with get () = Option.get _close
        and set value = _close <- Some value

    /// Sets the increasing candles properties.
    member __.increasing
        with get () = Option.get _increasing
        and set value = _increasing <- Some value

    /// Sets the decreasing candles properties.
    member __.decreasing
        with get () = Option.get _decreasing
        and set value = _decreasing <- Some value

    /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializeopen() = not _open.IsNone
    member __.ShouldSerializehigh() = not _high.IsNone
    member __.ShouldSerializelow() = not _low.IsNone
    member __.ShouldSerializeclose() = not _close.IsNone
    member __.ShouldSerializeincreasing() = not _increasing.IsNone
    member __.ShouldSerializedecreasing() = not _decreasing.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
