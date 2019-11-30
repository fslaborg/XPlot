namespace XPlot.Plotly

type Colorbar() =
    let mutable _thicknessmode: _ option = None
    let mutable _thickness: float option = None
    let mutable _lenmode: _ option = None
    let mutable _len: float option = None
    let mutable _x: float option = None
    let mutable _xanchor: _ option = None
    let mutable _xpad: float option = None
    let mutable _y: float option = None
    let mutable _yanchor: _ option = None
    let mutable _ypad: float option = None
    let mutable _outlinecolor: string option = None
    let mutable _outlinewidth: float option = None
    let mutable _bordercolor: string option = None
    let mutable _borderwidth: float option = None
    let mutable _bgcolor: string option = None
    let mutable _tickmode: _ option = None
    let mutable _nticks: int option = None
    let mutable _tick0: float option = None
    let mutable _dtick: _ option = None
    let mutable _tickvals: _ option = None
    let mutable _ticktext: _ option = None
    let mutable _ticks: _ option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tickfont: Font option = None
    let mutable _tickangle: float option = None
    let mutable _tickformat: string option = None
    let mutable _tickprefix: string option = None
    let mutable _showtickprefix: _ option = None
    let mutable _ticksuffix: string option = None
    let mutable _showticksuffix: _ option = None
    let mutable _exponentformat: _ option = None
    let mutable _showexponent: _ option = None
    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _titleside: _ option = None
    //let mutable _role: string option = Some "object"
    let mutable _tickvalssrc: string option = None
    let mutable _ticktextsrc: string option = None

    /// Determines whether this color bar's thickness (i.e. the measure in the constant color direction) is set in units of plot *fraction* or in *pixels*. Use `thickness` to set the value.
    member __.thicknessmode
        with get () = Option.defaultValue Unchecked.defaultof<_> _thicknessmode
        and set value = _thicknessmode <- Some value

    /// Sets the thickness of the color bar This measure excludes the size of the padding, ticks and labels.
    member __.thickness
        with get () = Option.defaultValue 0.0 _thickness
        and set value = _thickness <- Some value

    /// Determines whether this color bar's length (i.e. the measure in the color variation direction) is set in units of plot *fraction* or in *pixels. Use `len` to set the value.
    member __.lenmode
        with get () = Option.defaultValue Unchecked.defaultof<_> _lenmode
        and set value = _lenmode <- Some value

    /// Sets the length of the color bar This measure excludes the padding of both ends. That is, the color bar length is this length minus the padding on both ends.
    member __.len
        with get () = Option.defaultValue 0.0 _len
        and set value = _len <- Some value

    /// Sets the x position of the color bar (in plot fraction).
    member __.x
        with get () = Option.defaultValue 0.0 _x
        and set value = _x <- Some value

    /// Sets this color bar's horizontal position anchor. This anchor binds the `x` position to the *left*, *center* or *right* of the color bar.
    member __.xanchor
        with get () = Option.defaultValue Unchecked.defaultof<_> _xanchor
        and set value = _xanchor <- Some value

    /// Sets the amount of padding (in px) along the x direction.
    member __.xpad
        with get () = Option.defaultValue 0.0 _xpad
        and set value = _xpad <- Some value

    /// Sets the y position of the color bar (in plot fraction).
    member __.y
        with get () = Option.defaultValue 0.0 _y
        and set value = _y <- Some value

    /// Sets this color bar's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the color bar.
    member __.yanchor
        with get () = Option.defaultValue Unchecked.defaultof<_> _yanchor
        and set value = _yanchor <- Some value

    /// Sets the amount of padding (in px) along the y direction.
    member __.ypad
        with get () = Option.defaultValue 0.0 _ypad
        and set value = _ypad <- Some value

    /// Sets the axis line color.
    member __.outlinecolor
        with get () = Option.defaultValue "" _outlinecolor
        and set value = _outlinecolor <- Some value

    /// Sets the width (in px) of the axis line.
    member __.outlinewidth
        with get () = Option.defaultValue 0.0 _outlinewidth
        and set value = _outlinewidth <- Some value

    /// Sets the axis line color.
    member __.bordercolor
        with get () = Option.defaultValue "" _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the width (in px) or the border enclosing this color bar.
    member __.borderwidth
        with get () = Option.defaultValue 0.0 _borderwidth
        and set value = _borderwidth <- Some value

    /// Sets the color of padded area.
    member __.bgcolor
        with get () = Option.defaultValue "" _bgcolor
        and set value = _bgcolor <- Some value

    /// Sets the tick mode for this axis. If *auto*, the number of ticks is set via `nticks`. If *linear*, the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` (*linear* is the default value if `tick0` and `dtick` are provided). If *array*, the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. (*array* is the default value if `tickvals` is provided).
    member __.tickmode
        with get () = Option.defaultValue Unchecked.defaultof<_> _tickmode
        and set value = _tickmode <- Some value

    /// Sets the number of ticks. Has an effect only if `tickmode` is set to *auto*.
    member __.nticks
        with get () = Option.defaultValue 0 _nticks
        and set value = _nticks <- Some value

    /// Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is *log*, then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2). If the axis `type` is *date*, then you must convert the date to unix time in milliseconds (the number of milliseconds since January 1st, 1970). For example, to set the starting tick to November 4th, 2013, set the range to 1380844800000.0.
    member __.tick0
        with get () = Option.defaultValue 0.0 _tick0
        and set value = _tick0 <- Some value

    /// Sets the step in-between ticks on this axis Use with `tick0`. If the axis `type` is *log*, then ticks are set every 10^(n*dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. If the axis `type` is *date*, then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0.
    member __.dtick
        with get () = Option.defaultValue Unchecked.defaultof<_> _dtick
        and set value = _dtick <- Some value

    /// Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
    member __.tickvals
        with get () = Option.defaultValue Unchecked.defaultof<_> _tickvals
        and set value = _tickvals <- Some value

    /// Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
    member __.ticktext
        with get () = Option.defaultValue Unchecked.defaultof<_> _ticktext
        and set value = _ticktext <- Some value

    /// Determines whether ticks are drawn or not. If **, this axis' ticks are not drawn. If *outside* (*inside*), this axis' are drawn outside (inside) the axis lines.
    member __.ticks
        with get () = Option.defaultValue Unchecked.defaultof<_> _ticks
        and set value = _ticks <- Some value

    /// Sets the tick length (in px).
    member __.ticklen
        with get () = Option.defaultValue 0.0 _ticklen
        and set value = _ticklen <- Some value

    /// Sets the tick width (in px).
    member __.tickwidth
        with get () = Option.defaultValue 0.0 _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the tick color.
    member __.tickcolor
        with get () = Option.defaultValue "" _tickcolor
        and set value = _tickcolor <- Some value

    /// Determines whether or not the tick labels are drawn.
    member __.showticklabels
        with get () = Option.defaultValue false _showticklabels
        and set value = _showticklabels <- Some value

    member __.tickfont
        with get () = Option.defaultValue (Font()) _tickfont
        and set value = _tickfont <- Some value

    /// Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.
    member __.tickangle
        with get () = Option.defaultValue 0.0 _tickangle
        and set value = _tickangle <- Some value

    /// Sets the tick label formatting rule using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
    member __.tickformat
        with get () = Option.defaultValue "" _tickformat
        and set value = _tickformat <- Some value

    /// Sets a tick label prefix.
    member __.tickprefix
        with get () = Option.defaultValue "" _tickprefix
        and set value = _tickprefix <- Some value

    /// If *all*, all tick labels are displayed with a prefix. If *first*, only the first tick is displayed with a prefix. If *last*, only the last tick is displayed with a suffix. If *none*, tick prefixes are hidden.
    member __.showtickprefix
        with get () = Option.defaultValue Unchecked.defaultof<_> _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Sets a tick label suffix.
    member __.ticksuffix
        with get () = Option.defaultValue "" _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Same as `showtickprefix` but for tick suffixes.
    member __.showticksuffix
        with get () = Option.defaultValue Unchecked.defaultof<_> _showticksuffix
        and set value = _showticksuffix <- Some value

    /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If *none*, it appears as 1,000,000,000. If *e*, 1e+9. If *E*, 1E+9. If *power*, 1x10^9 (with 9 in a super script). If *SI*, 1G. If *B*, 1B.
    member __.exponentformat
        with get () = Option.defaultValue Unchecked.defaultof<_> _exponentformat
        and set value = _exponentformat <- Some value

    /// If *all*, all exponents are shown besides their significands. If *first*, only the exponent of the first tick is shown. If *last*, only the exponent of the last tick is shown. If *none*, no exponents appear.
    member __.showexponent
        with get () = Option.defaultValue Unchecked.defaultof<_> _showexponent
        and set value = _showexponent <- Some value

    /// Sets the title of the color bar.
    member __.title
        with get () = Option.defaultValue "" _title
        and set value = _title <- Some value

    member __.titlefont
        with get () = Option.defaultValue (Font()) _titlefont
        and set value = _titlefont <- Some value

    /// Determines the location of the colorbar title with respect to the color bar.
    member __.titleside
        with get () = Option.defaultValue Unchecked.defaultof<_> _titleside
        and set value = _titleside <- Some value

    /// Sets the source reference on plot.ly for  tickvals .
    member __.tickvalssrc
        with get () = Option.defaultValue "" _tickvalssrc
        and set value = _tickvalssrc <- Some value

    /// Sets the source reference on plot.ly for  ticktext .
    member __.ticktextsrc
        with get () = Option.defaultValue "" _ticktextsrc
        and set value = _ticktextsrc <- Some value

    member __.ShouldSerializethicknessmode() =  _thicknessmode.IsSome
    member __.ShouldSerializethickness() =  _thickness.IsSome
    member __.ShouldSerializelenmode() =  _lenmode.IsSome
    member __.ShouldSerializelen() =  _len.IsSome
    member __.ShouldSerializex() =  _x.IsSome
    member __.ShouldSerializexanchor() =  _xanchor.IsSome
    member __.ShouldSerializexpad() =  _xpad.IsSome
    member __.ShouldSerializey() =  _y.IsSome
    member __.ShouldSerializeyanchor() =  _yanchor.IsSome
    member __.ShouldSerializeypad() =  _ypad.IsSome
    member __.ShouldSerializeoutlinecolor() =  _outlinecolor.IsSome
    member __.ShouldSerializeoutlinewidth() =  _outlinewidth.IsSome
    member __.ShouldSerializebordercolor() =  _bordercolor.IsSome
    member __.ShouldSerializeborderwidth() =  _borderwidth.IsSome
    member __.ShouldSerializebgcolor() =  _bgcolor.IsSome
    member __.ShouldSerializetickmode() =  _tickmode.IsSome
    member __.ShouldSerializenticks() =  _nticks.IsSome
    member __.ShouldSerializetick0() =  _tick0.IsSome
    member __.ShouldSerializedtick() =  _dtick.IsSome
    member __.ShouldSerializetickvals() =  _tickvals.IsSome
    member __.ShouldSerializeticktext() =  _ticktext.IsSome
    member __.ShouldSerializeticks() =  _ticks.IsSome
    member __.ShouldSerializeticklen() =  _ticklen.IsSome
    member __.ShouldSerializetickwidth() =  _tickwidth.IsSome
    member __.ShouldSerializetickcolor() =  _tickcolor.IsSome
    member __.ShouldSerializeshowticklabels() =  _showticklabels.IsSome
    member __.ShouldSerializetickfont() =  _tickfont.IsSome
    member __.ShouldSerializetickangle() =  _tickangle.IsSome
    member __.ShouldSerializetickformat() =  _tickformat.IsSome
    member __.ShouldSerializetickprefix() =  _tickprefix.IsSome
    member __.ShouldSerializeshowtickprefix() =  _showtickprefix.IsSome
    member __.ShouldSerializeticksuffix() =  _ticksuffix.IsSome
    member __.ShouldSerializeshowticksuffix() =  _showticksuffix.IsSome
    member __.ShouldSerializeexponentformat() =  _exponentformat.IsSome
    member __.ShouldSerializeshowexponent() =  _showexponent.IsSome
    member __.ShouldSerializetitle() =  _title.IsSome
    member __.ShouldSerializetitlefont() =  _titlefont.IsSome
    member __.ShouldSerializetitleside() =  _titleside.IsSome
    member __.ShouldSerializetickvalssrc() =  _tickvalssrc.IsSome
    member __.ShouldSerializeticktextsrc() =  _ticktextsrc.IsSome
