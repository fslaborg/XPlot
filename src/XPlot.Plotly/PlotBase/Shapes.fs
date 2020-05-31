namespace XPlot.Plotly

type Shapes() =

    let mutable _items: Items option = None

    member __.items
        with get () = Option.get _items
        and set value = _items <- Some value

    member __.ShouldSerializeitems() = not _items.IsNone