namespace XPlot.Plotly

type Choropleth() =
    inherit Trace()

    let mutable _type: string option = Some "choropleth"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _locations: _ option = None
    let mutable _locationmode: _ option = None
    let mutable _z: _ option = None
    let mutable _text: _ option = None
    let mutable _marker: Marker option = None
    let mutable _zauto: bool option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _colorscale: _ option = None
    let mutable _autocolorscale: bool option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _geo: string option = None
    let mutable _locationssrc: string option = None
    let mutable _zsrc: string option = None
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

    /// Sets the coordinates via location IDs or names. See `locationmode` for more info.
    member __.locations
        with get () = Option.get _locations
        and set value = _locations <- Some value

    /// Determines the set of locations used to match entries in `locations` to regions on the map.
    member __.locationmode
        with get () = Option.get _locationmode
        and set value = _locationmode <- Some value

    /// Sets the color values.
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets the text elements associated with each location.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

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

    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Sets a reference between this trace's geospatial coordinates and a geographic map. If *geo* (the default value), the geospatial coordinates refer to `layout.geo`. If *geo2*, the geospatial coordinates refer to `layout.geo2`, and so on.
    member __.geo
        with get () = Option.get _geo
        and set value = _geo <- Some value

    /// Sets the source reference on plot.ly for  locations .
    member __.locationssrc
        with get () = Option.get _locationssrc
        and set value = _locationssrc <- Some value

    /// Sets the source reference on plot.ly for  z .
    member __.zsrc
        with get () = Option.get _zsrc
        and set value = _zsrc <- Some value

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
    member __.ShouldSerializelocations() = not _locations.IsNone
    member __.ShouldSerializelocationmode() = not _locationmode.IsNone
    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializeautocolorscale() = not _autocolorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializegeo() = not _geo.IsNone
    member __.ShouldSerializelocationssrc() = not _locationssrc.IsNone
    member __.ShouldSerializezsrc() = not _zsrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
