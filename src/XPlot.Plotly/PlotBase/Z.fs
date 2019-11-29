namespace XPlot.Plotly

type Z() =
    let mutable _show: bool option = None
    let mutable _opacity: float option = None
    let mutable _scale: float option = None
    let mutable _project: Project option = None
    let mutable _color: string option = None
    let mutable _usecolormap: bool option = None
    let mutable _width: float option = None
    let mutable _highlight: bool option = None
    let mutable _highlightColor: string option = None
    let mutable _highlightWidth: float option = None

    /// Sets whether or not projections are shown along the z axis.
    member __.show
        with get () = Option.defaultValue false _show
        and set value = _show <- Some value

    /// Sets the projection color.
    member __.opacity
        with get () = Option.defaultValue 0.0 _opacity
        and set value = _opacity <- Some value

    /// Sets the scale factor determining the size of the projection marker points.
    member __.scale
        with get () = Option.defaultValue 0.0 _scale
        and set value = _scale <- Some value

    member __.project
        with get () = Option.defaultValue (Project()) _project
        and set value = _project <- Some value

    member __.color
        with get () = Option.defaultValue "" _color
        and set value = _color <- Some value

    member __.usecolormap
        with get () = Option.defaultValue false _usecolormap
        and set value = _usecolormap <- Some value

    member __.width
        with get () = Option.defaultValue 0.0 _width
        and set value = _width <- Some value

    member __.highlight
        with get () = Option.defaultValue false _highlight
        and set value = _highlight <- Some value

    member __.highlightColor
        with get () = Option.defaultValue "" _highlightColor
        and set value = _highlightColor <- Some value

    member __.highlightWidth
        with get () = Option.defaultValue 0.0 _highlightWidth
        and set value = _highlightWidth <- Some value

    member __.ShouldSerializeshow() =  _show.IsSome
    member __.ShouldSerializeopacity() =  _opacity.IsSome
    member __.ShouldSerializescale() =  _scale.IsSome
    member __.ShouldSerializeproject() =  _project.IsSome
    member __.ShouldSerializecolor() =  _color.IsSome
    member __.ShouldSerializeusecolormap() =  _usecolormap.IsSome
    member __.ShouldSerializewidth() =  _width.IsSome
    member __.ShouldSerializehighlight() =  _highlight.IsSome
    member __.ShouldSerializehighlightColor() =  _highlightColor.IsSome
    member __.ShouldSerializehighlightWidth() =  _highlightWidth.IsSome
