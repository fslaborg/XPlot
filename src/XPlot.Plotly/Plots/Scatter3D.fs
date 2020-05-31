namespace XPlot.Plotly

type Scatter3d() =
    inherit Trace()

    let mutable _type: string option = Some "scatter3d"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _z: _ option = None
    let mutable _text: _ option = None
    let mutable _mode: string option = None
    let mutable _surfaceaxis: _ option = None
    let mutable _surfacecolor: string option = None
    let mutable _projection: Projection option = None
    let mutable _line: Line option = None
    let mutable _marker: Marker option = None
    let mutable _textposition: _ option = None
    let mutable _textfont: Textfont option = None
    let mutable _error_x: Error_x option = None
    let mutable _error_y: Error_y option = None
    let mutable _error_z: Error_z option = None
    let mutable _scene: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _zsrc: string option = None
    let mutable _textsrc: string option = None
    let mutable _textpositionsrc: string option = None

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

    /// Sets the y coordinates.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the z coordinates.
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    /// If *-1*, the scatter points are not fill with a surface If *0*, *1*, *2*, the scatter points are filled with a Delaunay surface about the x, y, z respectively.
    member __.surfaceaxis
        with get () = Option.get _surfaceaxis
        and set value = _surfaceaxis <- Some value

    /// Sets the surface fill color.
    member __.surfacecolor
        with get () = Option.get _surfacecolor
        and set value = _surfacecolor <- Some value

    member __.projection
        with get () = Option.get _projection
        and set value = _projection <- Some value

    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
    member __.textposition
        with get () = Option.get _textposition
        and set value = _textposition <- Some value

    member __.textfont
        with get () = Option.get _textfont
        and set value = _textfont <- Some value

    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    member __.error_z
        with get () = Option.get _error_z
        and set value = _error_z <- Some value

    /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
    member __.scene
        with get () = Option.get _scene
        and set value = _scene <- Some value

    /// Sets the source reference on plot.ly for  x .
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the source reference on plot.ly for  y .
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Sets the source reference on plot.ly for  z .
    member __.zsrc
        with get () = Option.get _zsrc
        and set value = _zsrc <- Some value

    /// Sets the source reference on plot.ly for  text .
    member __.textsrc
        with get () = Option.get _textsrc
        and set value = _textsrc <- Some value

    /// Sets the source reference on plot.ly for  textposition .
    member __.textpositionsrc
        with get () = Option.get _textpositionsrc
        and set value = _textpositionsrc <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializemode() = not _mode.IsNone
    member __.ShouldSerializesurfaceaxis() = not _surfaceaxis.IsNone
    member __.ShouldSerializesurfacecolor() = not _surfacecolor.IsNone
    member __.ShouldSerializeprojection() = not _projection.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_z() = not _error_z.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializezsrc() = not _zsrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
    member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
