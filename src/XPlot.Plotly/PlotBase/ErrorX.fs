namespace XPlot.Plotly

type Error_x() =
    let mutable _visible: bool option = None
    let mutable _type: _ option = None
    let mutable _symmetric: bool option = None
    let mutable _array: _ option = None
    let mutable _arrayminus: _ option = None
    let mutable _value: float option = None
    let mutable _valueminus: float option = None
    let mutable _traceref: int option = None
    let mutable _tracerefminus: int option = None
    let mutable _copy_ystyle: bool option = None
    let mutable _copy_zstyle: bool option = None
    let mutable _color: string option = None
    let mutable _thickness: float option = None
    let mutable _width: float option = None
    let mutable _arraysrc: string option = None
    let mutable _arrayminussrc: string option = None

    /// Determines whether or not this set of error bars is visible.
    member __.visible
        with get () = Option.defaultValue false _visible
        and set value = _visible <- Some value

    /// Determines the rule used to generate the error bars. If *constant`, the bar lengths are of a constant value. Set this constant in `value`. If *percent*, the bar lengths correspond to a percentage of underlying data. Set this percentage in `value`. If *sqrt*, the bar lengths correspond to the sqaure of the underlying data. If *array*, the bar lengths are set with data set `array`.
    member __.``type``
        with get () = Option.defaultValue Unchecked.defaultof<_> _type
        and set value = _type <- Some value

    /// Determines whether or not the error bars have the same length in both direction (top/bottom for vertical bars, left/right for horizontal bars.
    member __.symmetric
        with get () = Option.defaultValue false _symmetric
        and set value = _symmetric <- Some value

    /// Sets the data corresponding the length of each error bar. Values are plotted relative to the underlying data.
    member __.array
        with get () = Option.defaultValue Unchecked.defaultof<_> _array
        and set value = _array <- Some value

    /// Sets the data corresponding the length of each error bar in the bottom (left) direction for vertical (horizontal) bars Values are plotted relative to the underlying data.
    member __.arrayminus
        with get () = Option.defaultValue Unchecked.defaultof<_> _arrayminus
        and set value = _arrayminus <- Some value

    /// Sets the value of either the percentage (if `type` is set to *percent*) or the constant (if `type` is set to *constant*) corresponding to the lengths of the error bars.
    member __.value
        with get () = Option.defaultValue 0.0 _value
        and set value = _value <- Some value

    /// Sets the value of either the percentage (if `type` is set to *percent*) or the constant (if `type` is set to *constant*) corresponding to the lengths of the error bars in the bottom (left) direction for vertical (horizontal) bars
    member __.valueminus
        with get () = Option.defaultValue 0.0 _valueminus
        and set value = _valueminus <- Some value

    member __.traceref
        with get () = Option.defaultValue 0 _traceref
        and set value = _traceref <- Some value

    member __.tracerefminus
        with get () = Option.defaultValue 0 _tracerefminus
        and set value = _tracerefminus <- Some value

    member __.copy_ystyle
        with get () = Option.defaultValue false _copy_ystyle
        and set value = _copy_ystyle <- Some value

    member __.copy_zstyle
        with get () = Option.defaultValue false _copy_zstyle
        and set value = _copy_zstyle <- Some value

    /// Sets the stoke color of the error bars.
    member __.color
        with get () = Option.defaultValue "" _color
        and set value = _color <- Some value

    /// Sets the thickness (in px) of the error bars.
    member __.thickness
        with get () = Option.defaultValue 0.0 _thickness
        and set value = _thickness <- Some value

    /// Sets the width (in px) of the cross-bar at both ends of the error bars.
    member __.width
        with get () = Option.defaultValue 0.0 _width
        and set value = _width <- Some value

    /// Sets the source reference on plot.ly for  array .
    member __.arraysrc
        with get () = Option.defaultValue "" _arraysrc
        and set value = _arraysrc <- Some value

    /// Sets the source reference on plot.ly for  arrayminus .
    member __.arrayminussrc
        with get () = Option.defaultValue "" _arrayminussrc
        and set value = _arrayminussrc <- Some value

    member __.ShouldSerializevisible() =  _visible.IsSome
    member __.ShouldSerializetype() =  _type.IsSome
    member __.ShouldSerializesymmetric() =  _symmetric.IsSome
    member __.ShouldSerializearray() =  _array.IsSome
    member __.ShouldSerializearrayminus() =  _arrayminus.IsSome
    member __.ShouldSerializevalue() =  _value.IsSome
    member __.ShouldSerializevalueminus() =  _valueminus.IsSome
    member __.ShouldSerializetraceref() =  _traceref.IsSome
    member __.ShouldSerializetracerefminus() =  _tracerefminus.IsSome
    member __.ShouldSerializecopy_ystyle() =  _copy_ystyle.IsSome
    member __.ShouldSerializecopy_zstyle() =  _copy_zstyle.IsSome
    member __.ShouldSerializecolor() =  _color.IsSome
    member __.ShouldSerializethickness() =  _thickness.IsSome
    member __.ShouldSerializewidth() =  _width.IsSome
    member __.ShouldSerializearraysrc() =  _arraysrc.IsSome
    member __.ShouldSerializearrayminussrc() =  _arrayminussrc.IsSome
