namespace XPlot.Plotly

type Project() =
    let mutable _x: bool option = None
    let mutable _y: bool option = None
    let mutable _z: bool option = None

    /// Sets whether or not the dynamic contours are projected along the x axis.
    member __.x
        with get () = Option.defaultValue false _x
        and set value = _x <- Some value

    /// Sets whether or not the dynamic contours are projected along the y axis.
    member __.y
        with get () = Option.defaultValue false _y
        and set value = _y <- Some value

    /// Sets whether or not the dynamic contours are projected along the z axis.
    member __.z
        with get () = Option.defaultValue false _z
        and set value = _z <- Some value

    member __.ShouldSerializex() = _x.IsSome
    member __.ShouldSerializey() = _y.IsSome
    member __.ShouldSerializez() = _z.IsSome