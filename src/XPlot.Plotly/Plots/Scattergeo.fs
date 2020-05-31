namespace XPlot.Plotly

type Scattergeo() =
    inherit Trace()

    let mutable _type: string option = Some "scattergeo"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _lon: _ option = None
    let mutable _lat: _ option = None
    let mutable _locations: _ option = None
    let mutable _locationmode: _ option = None
    let mutable _mode: string option = None
    let mutable _text: string option = None
    let mutable _line: Line option = None
    let mutable _marker: Marker option = None
    let mutable _textfont: Textfont option = None
    let mutable _textposition: _ option = None
    let mutable _geo: string option = None
    let mutable _lonsrc: string option = None
    let mutable _latsrc: string option = None
    let mutable _locationssrc: string option = None
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

    /// Sets the longitude coordinates (in degrees East).
    member __.lon
        with get () = Option.get _lon
        and set value = _lon <- Some value

    /// Sets the latitude coordinates (in degrees North).
    member __.lat
        with get () = Option.get _lat
        and set value = _lat <- Some value

    /// Sets the coordinates via location IDs or names. Coordinates correspond to the centroid of each location given. See `locationmode` for more info.
    member __.locations
        with get () = Option.get _locations
        and set value = _locations <- Some value

    /// Determines the set of locations used to match entries in `locations` to regions on the map.
    member __.locationmode
        with get () = Option.get _locationmode
        and set value = _locationmode <- Some value

    /// Determines the drawing mode for this scatter trace. If the provided `mode` includes *text* then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points, then the default is *lines+markers*. Otherwise, *lines*.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    /// Sets text elements associated with each (lon,lat) pair. or item in `locations`. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (lon,lat) or `locations` coordinates.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    member __.textfont
        with get () = Option.get _textfont
        and set value = _textfont <- Some value

    /// Sets the positions of the `text` elements with respects to the (x,y) coordinates.
    member __.textposition
        with get () = Option.get _textposition
        and set value = _textposition <- Some value

    /// Sets a reference between this trace's geospatial coordinates and a geographic map. If *geo* (the default value), the geospatial coordinates refer to `layout.geo`. If *geo2*, the geospatial coordinates refer to `layout.geo2`, and so on.
    member __.geo
        with get () = Option.get _geo
        and set value = _geo <- Some value

    /// Sets the source reference on plot.ly for  lon .
    member __.lonsrc
        with get () = Option.get _lonsrc
        and set value = _lonsrc <- Some value

    /// Sets the source reference on plot.ly for  lat .
    member __.latsrc
        with get () = Option.get _latsrc
        and set value = _latsrc <- Some value

    /// Sets the source reference on plot.ly for  locations .
    member __.locationssrc
        with get () = Option.get _locationssrc
        and set value = _locationssrc <- Some value

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
    member __.ShouldSerializelon() = not _lon.IsNone
    member __.ShouldSerializelat() = not _lat.IsNone
    member __.ShouldSerializelocations() = not _locations.IsNone
    member __.ShouldSerializelocationmode() = not _locationmode.IsNone
    member __.ShouldSerializemode() = not _mode.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializegeo() = not _geo.IsNone
    member __.ShouldSerializelonsrc() = not _lonsrc.IsNone
    member __.ShouldSerializelatsrc() = not _latsrc.IsNone
    member __.ShouldSerializelocationssrc() = not _locationssrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
    member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
