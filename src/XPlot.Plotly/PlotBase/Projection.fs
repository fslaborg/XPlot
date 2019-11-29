namespace XPlot.Plotly

type Projection() =
    let mutable _x: X option = None
    let mutable _y: Y option = None
    let mutable _z: Z option = None
    let mutable _type: _ option = None
    let mutable _rotation: Rotation option = None
    let mutable _parallels: _ option = None
    let mutable _scale: float option = None

    member __.x
        with get () = Option.defaultValue (X()) _x
        and set value = _x <- Some value

    member __.y
        with get () = Option.defaultValue (Y()) _y
        and set value = _y <- Some value

    member __.z
        with get () = Option.defaultValue (Z()) _z
        and set value = _z <- Some value

    /// Sets the projection type.
    member __.``type``
        with get () = Option.defaultValue Unchecked.defaultof<_> _type
        and set value = _type <- Some value

    member __.rotation
        with get () = Option.defaultValue (Rotation()) _rotation
        and set value = _rotation <- Some value

    /// For conic projection types only. Sets the parallels (tangent, secant) where the cone intersects the sphere.
    member __.parallels
        with get () = Option.defaultValue Unchecked.defaultof<_> _parallels
        and set value = _parallels <- Some value

    /// Zooms in or out on the map view.
    member __.scale
        with get () = Option.defaultValue 0.0 _scale
        and set value = _scale <- Some value

    member __.ShouldSerializex() =  _x.IsSome
    member __.ShouldSerializey() =  _y.IsSome
    member __.ShouldSerializez() =  _z.IsSome
    member __.ShouldSerializetype() =  _type.IsSome
    member __.ShouldSerializerotation() =  _rotation.IsSome
    member __.ShouldSerializeparallels() =  _parallels.IsSome
    member __.ShouldSerializescale() =  _scale.IsSome
