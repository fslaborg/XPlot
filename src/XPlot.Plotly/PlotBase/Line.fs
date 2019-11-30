namespace XPlot.Plotly

type Line() =
    let mutable _color: _ option = None
    let mutable _width: _ option = None
    let mutable _shape: _ option = None
    let mutable _smoothing: float option = None
    let mutable _dash: string option = None
    let mutable _colorscale: _ option = None
    let mutable _cauto: bool option = None
    let mutable _cmax: float option = None
    let mutable _cmin: float option = None
    let mutable _autocolorscale: bool option = None
    let mutable _reversescale: bool option = None
    let mutable _colorsrc: string option = None
    let mutable _widthsrc: string option = None
    let mutable _outliercolor: string option = None
    let mutable _outlierwidth: float option = None

    /// Sets the line color.
    member __.color
        with get () = Option.defaultValue Unchecked.defaultof<_> _color
        and set value = _color <- Some value

    /// Sets the line width (in px).
    member __.width
        with get () = Option.defaultValue Unchecked.defaultof<_> _width
        and set value = _width <- Some value

    /// Determines the line shape. With *spline* the lines are drawn using spline interpolation. The other available values correspond to step-wise line shapes.
    member __.shape
        with get () = Option.defaultValue Unchecked.defaultof<_> _shape
        and set value = _shape <- Some value

    /// Has only an effect if `shape` is set to *spline* Sets the amount of smoothing. *0* corresponds to no smoothing (equivalent to a *linear* shape).
    member __.smoothing
        with get () = Option.defaultValue 0.0 _smoothing
        and set value = _smoothing <- Some value

    /// Sets the style of the lines. Set to a dash string type or a dash length in px.
    member __.dash
        with get () = Option.defaultValue "" _dash
        and set value = _dash <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the colorscale.
    member __.colorscale
        with get () = Option.defaultValue Unchecked.defaultof<_> _colorscale
        and set value = _colorscale <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Determines the whether or not the color domain is computed with respect to the input data.
    member __.cauto
        with get () = Option.defaultValue false _cauto
        and set value = _cauto <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the upper bound of the color domain.
    member __.cmax
        with get () = Option.defaultValue 0.0 _cmax
        and set value = _cmax <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Sets the lower bound of the color domain.
    member __.cmin
        with get () = Option.defaultValue 0.0 _cmin
        and set value = _cmin <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Determines whether or not the colorscale is picked using the sign of values inside `marker.line.color`.
    member __.autocolorscale
        with get () = Option.defaultValue false _autocolorscale
        and set value = _autocolorscale <- Some value

    /// Has only an effect if `marker.line.color` is set to a numerical array. Reverses the colorscale.
    member __.reversescale
        with get () = Option.defaultValue false _reversescale
        and set value = _reversescale <- Some value

    /// Sets the source reference on plot.ly for  color .
    member __.colorsrc
        with get () = Option.defaultValue "" _colorsrc
        and set value = _colorsrc <- Some value

    /// Sets the source reference on plot.ly for  width .
    member __.widthsrc
        with get () = Option.defaultValue "" _widthsrc
        and set value = _widthsrc <- Some value

    /// Sets the border line color of the outlier sample points. Defaults to marker.color
    member __.outliercolor
        with get () = Option.defaultValue "" _outliercolor
        and set value = _outliercolor <- Some value

    /// Sets the border line width (in px) of the outlier sample points.
    member __.outlierwidth
        with get () = Option.defaultValue 0.0 _outlierwidth
        and set value = _outlierwidth <- Some value

    member __.ShouldSerializecolor() =  _color.IsSome
    member __.ShouldSerializewidth() =  _width.IsSome
    member __.ShouldSerializeshape() =  _shape.IsSome
    member __.ShouldSerializesmoothing() =  _smoothing.IsSome
    member __.ShouldSerializedash() =  _dash.IsSome
    member __.ShouldSerializecolorscale() =  _colorscale.IsSome
    member __.ShouldSerializecauto() =  _cauto.IsSome
    member __.ShouldSerializecmax() =  _cmax.IsSome
    member __.ShouldSerializecmin() =  _cmin.IsSome
    member __.ShouldSerializeautocolorscale() =  _autocolorscale.IsSome
    member __.ShouldSerializereversescale() =  _reversescale.IsSome
    member __.ShouldSerializecolorsrc() =  _colorsrc.IsSome
    member __.ShouldSerializewidthsrc() =  _widthsrc.IsSome
    member __.ShouldSerializeoutliercolor() =  _outliercolor.IsSome
    member __.ShouldSerializeoutlierwidth() =  _outlierwidth.IsSome
