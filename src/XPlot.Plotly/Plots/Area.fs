namespace XPlot.Plotly

type Area() =
    inherit Trace()

    let mutable _type: string option = Some "area"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _r: _ option = None
    let mutable _t: _ option = None
    let mutable _marker: Marker option = None
    let mutable _rsrc: string option = None
    let mutable _tsrc: string option = None

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

    /// For polar chart only.Sets the radial coordinates.
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// For polar chart only.Sets the angular coordinates.
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets the source reference on plot.ly for  r .
    member __.rsrc
        with get () = Option.get _rsrc
        and set value = _rsrc <- Some value

    /// Sets the source reference on plot.ly for  t .
    member __.tsrc
        with get () = Option.get _tsrc
        and set value = _tsrc <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializersrc() = not _rsrc.IsNone
    member __.ShouldSerializetsrc() = not _tsrc.IsNone
