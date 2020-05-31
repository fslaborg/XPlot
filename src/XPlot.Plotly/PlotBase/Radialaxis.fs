namespace XPlot.Plotly

type Radialaxis() =

    let mutable _range: _ option = None
    let mutable _domain: _ option = None
    let mutable _orientation: float option = None
    let mutable _showline: bool option = None
    let mutable _showticklabels: bool option = None
    let mutable _tickorientation: _ option = None
    let mutable _ticklen: float option = None
    let mutable _tickcolor: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _endpadding: float option = None
    let mutable _visible: bool option = None

    /// Defines the start and end point of this radial axis.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Polar chart subplots are not supported yet. This key has currently no effect.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the orientation (an angle with respect to the origin) of the radial axis.
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// Determines whether or not the line bounding this radial axis will be shown on the figure.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Determines whether or not the radial axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Sets the orientation (from the paper perspective) of the radial axis tick labels.
    member __.tickorientation
        with get () = Option.get _tickorientation
        and set value = _tickorientation <- Some value

    /// Sets the length of the tick lines on this radial axis.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the color of the tick lines on this radial axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the length of the tick lines on this radial axis.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    member __.endpadding
        with get () = Option.get _endpadding
        and set value = _endpadding <- Some value

    /// Determines whether or not this axis will be visible.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializeendpadding() = not _endpadding.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
