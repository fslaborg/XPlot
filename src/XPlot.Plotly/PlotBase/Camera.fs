namespace XPlot.Plotly

type Camera() =

    let mutable _up: Up option = None
    let mutable _center: Center option = None
    let mutable _eye: Eye option = None

    member __.up
        with get () = Option.get _up
        and set value = _up <- Some value

    member __.center
        with get () = Option.get _center
        and set value = _center <- Some value

    member __.eye
        with get () = Option.get _eye
        and set value = _eye <- Some value

    member __.ShouldSerializeup() = not _up.IsNone
    member __.ShouldSerializecenter() = not _center.IsNone
    member __.ShouldSerializeeye() = not _eye.IsNone

