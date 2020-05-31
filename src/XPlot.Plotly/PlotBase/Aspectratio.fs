namespace XPlot.Plotly

type Aspectratio() =

    let mutable _x: float option = None
    let mutable _y: float option = None
    let mutable _z: float option = None

    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializez() = not _z.IsNone
