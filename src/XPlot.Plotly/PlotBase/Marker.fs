namespace XPlot.Plotly

type Marker() =
    let mutable _symbol: _ option = None
    let mutable _opacity: _ option = None
    let mutable _size: _ option = None
    let mutable _color: _ option = None
    let mutable _maxdisplayed: int option = None
    let mutable _sizeref: float option = None
    let mutable _sizemin: float option = None
    let mutable _sizemode: _ option = None
    let mutable _colorscale: _ option = None
    let mutable _cauto: bool option = None
    let mutable _cmax: float option = None
    let mutable _cmin: float option = None
    let mutable _autocolorscale: bool option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _line: Line option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _symbolsrc: string option = None
    let mutable _opacitysrc: string option = None
    let mutable _sizesrc: string option = None
    let mutable _colorsrc: string option = None
    let mutable _outliercolor: string option = None
    let mutable _colors: _ option = None
    let mutable _colorssrc: string option = None

    /// Sets the marker symbol type. Adding 100 is equivalent to appending *-open* to a symbol name. Adding 200 is equivalent to appending *-dot* to a symbol name. Adding 300 is equivalent to appending *-open-dot* or *dot-open* to a symbol name.
    member __.symbol
        with get () = Option.defaultValue Unchecked.defaultof<_> _symbol
        and set value = _symbol <- Some value

    /// Sets the marker opacity.
    member __.opacity
        with get () = Option.defaultValue Unchecked.defaultof<_> _opacity
        and set value = _opacity <- Some value

    /// Sets the marker size (in px).
    member __.size
        with get () = Option.defaultValue Unchecked.defaultof<_> _size
        and set value = _size <- Some value

    /// Sets the marker color.
    member __.color
        with get () = Option.defaultValue Unchecked.defaultof<_> _color
        and set value = _color <- Some value

    /// Sets a maximum number of points to be drawn on the graph. *0* corresponds to no limit.
    member __.maxdisplayed
        with get () = Option.defaultValue 0 _maxdisplayed
        and set value = _maxdisplayed <- Some value

    /// Has only an effect if `marker.size` is set to a numerical array. Sets the scale factor used to determine the rendered size of marker points. Use with `sizemin` and `sizemode`.
    member __.sizeref
        with get () = Option.defaultValue 0.0 _sizeref
        and set value = _sizeref <- Some value

    /// Has only an effect if `marker.size` is set to a numerical array. Sets the minimum size (in px) of the rendered marker points.
    member __.sizemin
        with get () = Option.defaultValue 0.0 _sizemin
        and set value = _sizemin <- Some value

    /// Has only an effect if `marker.size` is set to a numerical array. Sets the rule for which the data in `size` is converted to pixels.
    member __.sizemode
        with get () = Option.defaultValue Unchecked.defaultof<_> _sizemode
        and set value = _sizemode <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Sets the colorscale.
    member __.colorscale
        with get () = Option.defaultValue Unchecked.defaultof<_> _colorscale
        and set value = _colorscale <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Determines the whether or not the color domain is computed automatically.
    member __.cauto
        with get () = Option.defaultValue false _cauto
        and set value = _cauto <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Sets the upper bound of the color domain.
    member __.cmax
        with get () = Option.defaultValue 0.0 _cmax
        and set value = _cmax <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Sets the lower bound of the color domain.
    member __.cmin
        with get () = Option.defaultValue 0.0 _cmin
        and set value = _cmin <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Determines whether or not the colorscale is picked using values inside `marker.color`.
    member __.autocolorscale
        with get () = Option.defaultValue false _autocolorscale
        and set value = _autocolorscale <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Reverses the colorscale.
    member __.reversescale
        with get () = Option.defaultValue false _reversescale
        and set value = _reversescale <- Some value

    /// Has only an effect if `marker.color` is set to a numerical array. Determines whether or not a colorbar is displayed.
    member __.showscale
        with get () = Option.defaultValue false _showscale
        and set value = _showscale <- Some value

    member __.line
        with get () = Option.defaultValue (Line()) _line
        and set value = _line <- Some value

    member __.colorbar
        with get () = Option.defaultValue (Colorbar()) _colorbar
        and set value = _colorbar <- Some value

    /// Sets the source reference on plot.ly for  symbol .
    member __.symbolsrc
        with get () = Option.defaultValue "" _symbolsrc
        and set value = _symbolsrc <- Some value

    /// Sets the source reference on plot.ly for  opacity .
    member __.opacitysrc
        with get () = Option.defaultValue "" _opacitysrc
        and set value = _opacitysrc <- Some value

    /// Sets the source reference on plot.ly for  size .
    member __.sizesrc
        with get () = Option.defaultValue "" _sizesrc
        and set value = _sizesrc <- Some value

    /// Sets the source reference on plot.ly for  color .
    member __.colorsrc
        with get () = Option.defaultValue "" _colorsrc
        and set value = _colorsrc <- Some value

    /// Sets the color of the outlier sample points.
    member __.outliercolor
        with get () = Option.defaultValue "" _outliercolor
        and set value = _outliercolor <- Some value

    /// Sets the color of each sector of this pie chart. If not specified, the default trace color set is used to pick the sector colors.
    member __.colors
        with get () = Option.defaultValue Unchecked.defaultof<_> _colors
        and set value = _colors <- Some value

    /// Sets the source reference on plot.ly for  colors .
    member __.colorssrc
        with get () = Option.defaultValue "" _colorssrc
        and set value = _colorssrc <- Some value

    member __.ShouldSerializesymbol() =  _symbol.IsSome
    member __.ShouldSerializeopacity() =  _opacity.IsSome
    member __.ShouldSerializesize() =  _size.IsSome
    member __.ShouldSerializecolor() =  _color.IsSome
    member __.ShouldSerializemaxdisplayed() =  _maxdisplayed.IsSome
    member __.ShouldSerializesizeref() =  _sizeref.IsSome
    member __.ShouldSerializesizemin() =  _sizemin.IsSome
    member __.ShouldSerializesizemode() =  _sizemode.IsSome
    member __.ShouldSerializecolorscale() =  _colorscale.IsSome
    member __.ShouldSerializecauto() =  _cauto.IsSome
    member __.ShouldSerializecmax() =  _cmax.IsSome
    member __.ShouldSerializecmin() =  _cmin.IsSome
    member __.ShouldSerializeautocolorscale() =  _autocolorscale.IsSome
    member __.ShouldSerializereversescale() =  _reversescale.IsSome
    member __.ShouldSerializeshowscale() =  _showscale.IsSome
    member __.ShouldSerializeline() =  _line.IsSome
    member __.ShouldSerializecolorbar() =  _colorbar.IsSome
    member __.ShouldSerializesymbolsrc() =  _symbolsrc.IsSome
    member __.ShouldSerializeopacitysrc() =  _opacitysrc.IsSome
    member __.ShouldSerializesizesrc() =  _sizesrc.IsSome
    member __.ShouldSerializecolorsrc() =  _colorsrc.IsSome
    member __.ShouldSerializeoutliercolor() =  _outliercolor.IsSome
    member __.ShouldSerializecolors() =  _colors.IsSome
    member __.ShouldSerializecolorssrc() =  _colorssrc.IsSome
