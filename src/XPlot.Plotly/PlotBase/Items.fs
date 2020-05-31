namespace XPlot.Plotly

type Items() =

    let mutable _annotation: Annotation option = None
    let mutable _shape: Shape option = None

    member __.annotation
        with get () = Option.get _annotation
        and set value = _annotation <- Some value

    member __.shape
        with get () = Option.get _shape
        and set value = _shape <- Some value

    member __.ShouldSerializeannotation() = not _annotation.IsNone
    member __.ShouldSerializeshape() = not _shape.IsNone