namespace XPlot.Plotly

type Textfont() =
    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    let mutable _familysrc: string option = None
    let mutable _sizesrc: string option = None
    let mutable _colorsrc: string option = None

    member __.family
        with get () = Option.defaultValue "" _family
        and set value = _family <- Some value

    member __.size
        with get () = Option.defaultValue 0.0 _size
        and set value = _size <- Some value

    member __.color
        with get () = Option.defaultValue "" _color
        and set value = _color <- Some value

    /// Sets the source reference on plot.ly for  family .
    member __.familysrc
        with get () = Option.defaultValue "" _familysrc
        and set value = _familysrc <- Some value

    /// Sets the source reference on plot.ly for  size .
    member __.sizesrc
        with get () = Option.defaultValue "" _sizesrc
        and set value = _sizesrc <- Some value

    /// Sets the source reference on plot.ly for  color .
    member __.colorsrc
        with get () = Option.defaultValue "" _colorsrc
        and set value = _colorsrc <- Some value

    member __.ShouldSerializefamily() =  _family.IsSome
    member __.ShouldSerializesize() =  _size.IsSome
    member __.ShouldSerializecolor() =  _color.IsSome
    member __.ShouldSerializefamilysrc() =  _familysrc.IsSome
    member __.ShouldSerializesizesrc() =  _sizesrc.IsSome
    member __.ShouldSerializecolorsrc() =  _colorsrc.IsSome
