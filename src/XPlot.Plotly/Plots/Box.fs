namespace XPlot.Plotly


type Box() =
    inherit Trace()

    let mutable _type: string option = Some "box"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _y: _ option = None
    let mutable _x: _ option = None
    let mutable _x0: _ option = None
    let mutable _y0: _ option = None
    let mutable _whiskerwidth: float option = None
    let mutable _boxpoints: _ option = None
    let mutable _boxmean: _ option = None
    let mutable _jitter: float option = None
    let mutable _pointpos: float option = None
    let mutable _orientation: _ option = None
    let mutable _marker: Marker option = None
    let mutable _line: Line option = None
    let mutable _fillcolor: string option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _ysrc: string option = None
    let mutable _xsrc: string option = None

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

    /// Sets the y sample data or coordinates. See overview for more info.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the x sample data or coordinates. See overview for more info.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the x coordinate of the box. See overview for more info.
    member __.x0
        with get () = Option.get _x0
        and set value = _x0 <- Some value

    /// Sets the y coordinate of the box. See overview for more info.
    member __.y0
        with get () = Option.get _y0
        and set value = _y0 <- Some value

    /// Sets the width of the whiskers relative to the box' width. For example, with 1, the whiskers are as wide as the box(es).
    member __.whiskerwidth
        with get () = Option.get _whiskerwidth
        and set value = _whiskerwidth <- Some value

    /// If *outliers*, only the sample points lying outside the whiskers are shown If *suspectedoutliers*, the outlier points are shown and points either less than 4*Q1-3*Q3 or greater than 4*Q3-3*Q1 are highlighted (see `outliercolor`) If *all*, all sample points are shown If *false*, only the box(es) are shown with no sample points
    member __.boxpoints
        with get () = Option.get _boxpoints
        and set value = _boxpoints <- Some value

    /// If *true*, the mean of the box(es)' underlying distribution is drawn as a dashed line inside the box(es). If *sd* the standard deviation is also drawn.
    member __.boxmean
        with get () = Option.get _boxmean
        and set value = _boxmean <- Some value

    /// Sets the amount of jitter in the sample points drawn. If *0*, the sample points align along the distribution axis. If *1*, the sample points are drawn in a random jitter of width equal to the width of the box(es).
    member __.jitter
        with get () = Option.get _jitter
        and set value = _jitter <- Some value

    /// Sets the position of the sample points in relation to the box(es). If *0*, the sample points are places over the center of the box(es). Positive (negative) values correspond to positions to the right (left) for vertical boxes and above (below) for horizontal boxes
    member __.pointpos
        with get () = Option.get _pointpos
        and set value = _pointpos <- Some value

    /// Sets the orientation of the box(es). If *v* (*h*), the distribution is visualized along the vertical (horizontal).
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets the fill color.
    member __.fillcolor
        with get () = Option.get _fillcolor
        and set value = _fillcolor <- Some value

    /// Sets a reference between this trace's x coordinates and a 2D cartesian x axis. If *x* (the default value), the x coordinates refer to `layout.xaxis`. If *x2*, the x coordinates refer to `layout.xaxis2`, and so on.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If *y* (the default value), the y coordinates refer to `layout.yaxis`. If *y2*, the y coordinates refer to `layout.xaxis2`, and so on.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Sets the source reference on plot.ly for  y .
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Sets the source reference on plot.ly for  x .
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializex0() = not _x0.IsNone
    member __.ShouldSerializey0() = not _y0.IsNone
    member __.ShouldSerializewhiskerwidth() = not _whiskerwidth.IsNone
    member __.ShouldSerializeboxpoints() = not _boxpoints.IsNone
    member __.ShouldSerializeboxmean() = not _boxmean.IsNone
    member __.ShouldSerializejitter() = not _jitter.IsNone
    member __.ShouldSerializepointpos() = not _pointpos.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
