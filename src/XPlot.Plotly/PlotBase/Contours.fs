namespace XPlot.Plotly

type Contours() =
    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: float option = None
    let mutable _coloring: _ option = None
    let mutable _showlines: bool option = None
    let mutable _x: X option = None
    let mutable _y: Y option = None
    let mutable _z: Z option = None

    /// Sets the starting contour level value.
    member __.start
        with get () = Option.defaultValue 0.0 _start
        and set value = _start <- Some value

    /// Sets the end contour level value.
    member __.``end``
        with get () = Option.defaultValue 0.0 _end
        and set value = _end <- Some value

    /// Sets the step between each contour level.
    member __.size
        with get () = Option.defaultValue 0.0 _size
        and set value = _size <- Some value

    /// Determines the coloring method showing the contour values. If *fill*, coloring is done evenly between each contour level If *heatmap*, a heatmap gradient is coloring is applied between each contour level. If *lines*, coloring is done on the contour lines. If *none*, no coloring is applied on this trace.
    member __.coloring
        with get () = Option.defaultValue Unchecked.defaultof<_> _coloring
        and set value = _coloring <- Some value

    /// Determines whether or not the contour lines are drawn. Has only an effect if `contours.coloring` is set to *fill*.
    member __.showlines
        with get () = Option.defaultValue false _showlines
        and set value = _showlines <- Some value

    member __.x
        with get () = Option.defaultValue (X()) _x
        and set value = _x <- Some value

    member __.y
        with get () = Option.defaultValue (Y()) _y
        and set value = _y <- Some value

    member __.z
        with get () = Option.defaultValue (Z()) _z
        and set value = _z <- Some value

    member __.ShouldSerializestart() =  _start.IsSome
    member __.ShouldSerializeend() =  _end.IsSome
    member __.ShouldSerializesize() =  _size.IsSome
    member __.ShouldSerializecoloring() =  _coloring.IsSome
    member __.ShouldSerializeshowlines() =  _showlines.IsSome
    member __.ShouldSerializex() =  _x.IsSome
    member __.ShouldSerializey() =  _y.IsSome
    member __.ShouldSerializez() =  _z.IsSome
