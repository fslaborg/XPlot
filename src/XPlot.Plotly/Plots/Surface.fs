namespace XPlot.Plotly

type Surface() =
    inherit Trace()

    let mutable _type: string option = Some "surface"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _z: _ option = None
    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _text: _ option = None
    let mutable _zauto: bool option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _colorscale: _ option = None
    let mutable _autocolorscale: bool option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _contours: Contours option = None
    let mutable _hidesurface: bool option = None
    let mutable _lighting: Lighting option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _scene: string option = None
    let mutable _zsrc: string option = None
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

    /// Sets the z coordinates.
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets the x coordinates.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the y coordinates.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the text elements associated with each z value.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Determines the whether or not the color domain is computed with respect to the input data.
    member __.zauto
        with get () = Option.get _zauto
        and set value = _zauto <- Some value

    /// Sets the lower bound of color domain.
    member __.zmin
        with get () = Option.get _zmin
        and set value = _zmin <- Some value

    /// Sets the upper bound of color domain.
    member __.zmax
        with get () = Option.get _zmax
        and set value = _zmax <- Some value

    /// Sets the colorscale.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Determines whether or not the colorscale is picked using the sign of the input z values.
    member __.autocolorscale
        with get () = Option.get _autocolorscale
        and set value = _autocolorscale <- Some value

    /// Reverses the colorscale.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Determines whether or not a colorbar is displayed for this trace.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

    member __.contours
        with get () = Option.get _contours
        and set value = _contours <- Some value

    member __.hidesurface
        with get () = Option.get _hidesurface
        and set value = _hidesurface <- Some value

    member __.lighting
        with get () = Option.get _lighting
        and set value = _lighting <- Some value

    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Sets a reference between this trace's 3D coordinate system and a 3D scene. If *scene* (the default value), the (x,y,z) coordinates refer to `layout.scene`. If *scene2*, the (x,y,z) coordinates refer to `layout.scene2`, and so on.
    member __.scene
        with get () = Option.get _scene
        and set value = _scene <- Some value

    /// Sets the source reference on plot.ly for  z .
    member __.zsrc
        with get () = Option.get _zsrc
        and set value = _zsrc <- Some value

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
    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecontours() = not _contours.IsNone
    member __.ShouldSerializehidesurface() = not _hidesurface.IsNone
    member __.ShouldSerializelighting() = not _lighting.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializezsrc() = not _zsrc.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
