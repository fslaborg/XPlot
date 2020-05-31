namespace XPlot.Plotly

type Scattergl() =
    inherit Trace()

    let mutable _type: string option = Some "scattergl"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _x: _ option = None
    let mutable _x0: _ option = None
    let mutable _dx: float option = None
    let mutable _y: _ option = None
    let mutable _y0: _ option = None
    let mutable _dy: float option = None
    let mutable _text: string option = None
    let mutable _mode: string option = None
    let mutable _line: Line option = None
    let mutable _marker: Marker option = None
    let mutable _fill: _ option = None
    let mutable _fillcolor: string option = None
    let mutable _error_x: Error_x option = None
    let mutable _error_y: Error_y option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _textsrc: string option = None

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

    /// Sets the x coordinates.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Alternate to `x`. Builds a linear space of x coordinates. Use with `dx` where `x0` is the starting coordinate and `dx` the step.
    member __.x0
        with get () = Option.get _x0
        and set value = _x0 <- Some value

    /// Sets the x coordinate step. See `x0` for more info.
    member __.dx
        with get () = Option.get _dx
        and set value = _dx <- Some value

    /// Sets the y coordinates.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Alternate to `y`. Builds a linear space of y coordinates. Use with `dy` where `y0` is the starting coordinate and `dy` the step.
    member __.y0
        with get () = Option.get _y0
        and set value = _y0 <- Some value

    /// Sets the y coordinate step. See `y0` for more info.
    member __.dy
        with get () = Option.get _dy
        and set value = _dy <- Some value

    /// Sets text elements associated with each (x,y) pair to appear on hover. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y) coordinates.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Determines the drawing mode for this scatter trace.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets the area to fill with a solid color. Use with `fillcolor`.
    member __.fill
        with get () = Option.get _fill
        and set value = _fill <- Some value

    /// Sets the fill color.
    member __.fillcolor
        with get () = Option.get _fillcolor
        and set value = _fillcolor <- Some value

    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Sets the source reference on plot.ly for  x .
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the source reference on plot.ly for  y .
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Sets the source reference on plot.ly for  text .
    member __.textsrc
        with get () = Option.get _textsrc
        and set value = _textsrc <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializex0() = not _x0.IsNone
    member __.ShouldSerializedx() = not _dx.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializey0() = not _y0.IsNone
    member __.ShouldSerializedy() = not _dy.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializemode() = not _mode.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializefill() = not _fill.IsNone
    member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
