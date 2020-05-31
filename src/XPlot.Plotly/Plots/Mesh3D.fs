namespace XPlot.Plotly

type Mesh3d() =
    inherit Trace()

    let mutable _type: string option = Some "mesh3d"
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
    let mutable _i: _ option = None
    let mutable _j: _ option = None
    let mutable _k: _ option = None
    let mutable _delaunayaxis: _ option = None
    let mutable _alphahull: float option = None
    let mutable _intensity: _ option = None
    let mutable _color: string option = None
    let mutable _vertexcolor: _ option = None
    let mutable _facecolor: _ option = None
    let mutable _flatshading: bool option = None
    let mutable _contour: Contour option = None
    let mutable _colorscale: _ option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _lighting: Lighting option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _scene: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _zsrc: string option = None
    let mutable _isrc: string option = None
    let mutable _jsrc: string option = None
    let mutable _ksrc: string option = None
    let mutable _intensitysrc: string option = None
    let mutable _vertexcolorsrc: string option = None
    let mutable _facecolorsrc: string option = None

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

    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    member __.i
        with get () = Option.get _i
        and set value = _i <- Some value

    member __.j
        with get () = Option.get _j
        and set value = _j <- Some value

    member __.k
        with get () = Option.get _k
        and set value = _k <- Some value

    member __.delaunayaxis
        with get () = Option.get _delaunayaxis
        and set value = _delaunayaxis <- Some value

    member __.alphahull
        with get () = Option.get _alphahull
        and set value = _alphahull <- Some value

    member __.intensity
        with get () = Option.get _intensity
        and set value = _intensity <- Some value

    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    member __.vertexcolor
        with get () = Option.get _vertexcolor
        and set value = _vertexcolor <- Some value

    member __.facecolor
        with get () = Option.get _facecolor
        and set value = _facecolor <- Some value

    member __.flatshading
        with get () = Option.get _flatshading
        and set value = _flatshading <- Some value

    member __.contour
        with get () = Option.get _contour
        and set value = _contour <- Some value

    /// Sets the colorscale.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Reverses the colorscale.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Determines whether or not a colorbar is displayed for this trace.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

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

    /// Sets the source reference on plot.ly for  i .
    member __.isrc
        with get () = Option.get _isrc
        and set value = _isrc <- Some value

    /// Sets the source reference on plot.ly for  j .
    member __.jsrc
        with get () = Option.get _jsrc
        and set value = _jsrc <- Some value

    /// Sets the source reference on plot.ly for  k .
    member __.ksrc
        with get () = Option.get _ksrc
        and set value = _ksrc <- Some value

    /// Sets the source reference on plot.ly for  intensity .
    member __.intensitysrc
        with get () = Option.get _intensitysrc
        and set value = _intensitysrc <- Some value

    /// Sets the source reference on plot.ly for  vertexcolor .
    member __.vertexcolorsrc
        with get () = Option.get _vertexcolorsrc
        and set value = _vertexcolorsrc <- Some value

    /// Sets the source reference on plot.ly for  facecolor .
    member __.facecolorsrc
        with get () = Option.get _facecolorsrc
        and set value = _facecolorsrc <- Some value

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
    member __.ShouldSerializei() = not _i.IsNone
    member __.ShouldSerializej() = not _j.IsNone
    member __.ShouldSerializek() = not _k.IsNone
    member __.ShouldSerializedelaunayaxis() = not _delaunayaxis.IsNone
    member __.ShouldSerializealphahull() = not _alphahull.IsNone
    member __.ShouldSerializeintensity() = not _intensity.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializevertexcolor() = not _vertexcolor.IsNone
    member __.ShouldSerializefacecolor() = not _facecolor.IsNone
    member __.ShouldSerializeflatshading() = not _flatshading.IsNone
    member __.ShouldSerializecontour() = not _contour.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializelighting() = not _lighting.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializezsrc() = not _zsrc.IsNone
    member __.ShouldSerializeisrc() = not _isrc.IsNone
    member __.ShouldSerializejsrc() = not _jsrc.IsNone
    member __.ShouldSerializeksrc() = not _ksrc.IsNone
    member __.ShouldSerializeintensitysrc() = not _intensitysrc.IsNone
    member __.ShouldSerializevertexcolorsrc() = not _vertexcolorsrc.IsNone
    member __.ShouldSerializefacecolorsrc() = not _facecolorsrc.IsNone
