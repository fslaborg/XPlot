namespace XPlot.Plotly

type Lonaxis() =

    let mutable _range: _ option = None
    let mutable _showgrid: bool option = None
    let mutable _tick0: float option = None
    let mutable _dtick: float option = None
    let mutable _gridcolor: string option = None
    let mutable _gridwidth: float option = None

    /// Sets the range of this axis (in degrees).
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Sets whether or not graticule are shown on the map.
    member __.showgrid
        with get () = Option.get _showgrid
        and set value = _showgrid <- Some value

    /// Sets the graticule's starting tick longitude/latitude.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the graticule's longitude/latitude tick step.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the graticule's stroke color.
    member __.gridcolor
        with get () = Option.get _gridcolor
        and set value = _gridcolor <- Some value

    /// Sets the graticule's stroke width (in px).
    member __.gridwidth
        with get () = Option.get _gridwidth
        and set value = _gridwidth <- Some value

    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
