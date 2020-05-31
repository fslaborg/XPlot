namespace XPlot.Plotly

type Yaxis() =

    let mutable _autotick: bool option = None
    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _type: _ option = None
    let mutable _autorange: _ option = None
    let mutable _rangemode: _ option = None
    let mutable _range: _ option = None
    let mutable _fixedrange: bool option = None
    let mutable _tickmode: _ option = None
    let mutable _nticks: int option = None
    let mutable _tick0: float option = None
    let mutable _dtick: _ option = None
    let mutable _tickvals: _ option = None
    let mutable _ticktext: _ option = None
    let mutable _ticks: _ option = None
    let mutable _mirror: _ option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tickfont: Font option = None
    let mutable _tickangle: float option = None
    let mutable _tickprefix: string option = None
    let mutable _showtickprefix: _ option = None
    let mutable _ticksuffix: string option = None
    let mutable _showticksuffix: _ option = None
    let mutable _showexponent: _ option = None
    let mutable _exponentformat: _ option = None
    let mutable _tickformat: string option = None
    let mutable _hoverformat: string option = None
    let mutable _showline: bool option = None
    let mutable _linecolor: string option = None
    let mutable _linewidth: float option = None
    let mutable _showgrid: bool option = None
    let mutable _gridcolor: string option = None
    let mutable _gridwidth: float option = None
    let mutable _zeroline: bool option = None
    let mutable _zerolinecolor: string option = None
    let mutable _zerolinewidth: float option = None
    let mutable _anchor: _ option = None
    let mutable _side: _ option = None
    let mutable _overlaying: _ option = None
    let mutable _domain: _ option = None
    let mutable _position: float option = None
    let mutable __isSubplotObj: bool option = Some true
    let mutable _tickvalssrc: string option = None
    let mutable _ticktextsrc: string option = None
    let mutable _showspikes: bool option = None
    let mutable _spikesides: bool option = None
    let mutable _spikethickness: float option = None
    let mutable _spikecolor: string option = None
    let mutable _showbackground: bool option = None
    let mutable _backgroundcolor: string option = None
    let mutable _showaxeslabels: bool option = None

    member __.autotick
        with get () = Option.get _autotick
        and set value = _autotick <- Some value

    /// Sets the title of this axis.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Sets the axis type. By default, plotly attempts to determined the axis type by looking into the data of the traces that referenced the axis in question.
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Determines whether or not the range of this axis is computed in relation to the input data. See `rangemode` for more info. If `range` is provided, then `autorange` is set to *false*.
    member __.autorange
        with get () = Option.get _autorange
        and set value = _autorange <- Some value

    /// If *normal*, the range is computed in relation to the extrema of the input data. If *tozero*`, the range extends to 0, regardless of the input data If *nonnegative*, the range is non-negative, regardless of the input data.
    member __.rangemode
        with get () = Option.get _rangemode
        and set value = _rangemode <- Some value

    /// Sets the range of this axis. If the axis `type` is *log*, then you must take the log of your desired range (e.g. to set the range from 1 to 100, set the range from 0 to 2). If the axis `type` is *date*, then you must convert the date to unix time in milliseconds (the number of milliseconds since January 1st, 1970). For example, to set the date range from January 1st 1970 to November 4th, 2013, set the range from 0 to 1380844800000.0
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Determines whether or not this axis is zoom-able. If true, then zoom is disabled.
    member __.fixedrange
        with get () = Option.get _fixedrange
        and set value = _fixedrange <- Some value

    /// Sets the tick mode for this axis. If *auto*, the number of ticks is set via `nticks`. If *linear*, the placement of the ticks is determined by a starting position `tick0` and a tick step `dtick` (*linear* is the default value if `tick0` and `dtick` are provided). If *array*, the placement of the ticks is set via `tickvals` and the tick text is `ticktext`. (*array* is the default value if `tickvals` is provided).
    member __.tickmode
        with get () = Option.get _tickmode
        and set value = _tickmode <- Some value

    /// Sets the number of ticks. Has an effect only if `tickmode` is set to *auto*.
    member __.nticks
        with get () = Option.get _nticks
        and set value = _nticks <- Some value

    /// Sets the placement of the first tick on this axis. Use with `dtick`. If the axis `type` is *log*, then you must take the log of your starting tick (e.g. to set the starting tick to 100, set the `tick0` to 2). If the axis `type` is *date*, then you must convert the date to unix time in milliseconds (the number of milliseconds since January 1st, 1970). For example, to set the starting tick to November 4th, 2013, set the range to 1380844800000.0.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the step in-between ticks on this axis Use with `tick0`. If the axis `type` is *log*, then ticks are set every 10^(n*dtick) where n is the tick number. For example, to set a tick mark at 1, 10, 100, 1000, ... set dtick to 1. To set tick marks at 1, 100, 10000, ... set dtick to 2. To set tick marks at 1, 5, 25, 125, 625, 3125, ... set dtick to log_10(5), or 0.69897000433. If the axis `type` is *date*, then you must convert the time to milliseconds. For example, to set the interval between ticks to one day, set `dtick` to 86400000.0.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the values at which ticks on this axis appear. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
    member __.tickvals
        with get () = Option.get _tickvals
        and set value = _tickvals <- Some value

    /// Sets the text displayed at the ticks position via `tickvals`. Only has an effect if `tickmode` is set to *array*. Used with `ticktext`.
    member __.ticktext
        with get () = Option.get _ticktext
        and set value = _ticktext <- Some value

    /// Determines whether ticks are drawn or not. If **, this axis' ticks are not drawn. If *outside* (*inside*), this axis' are drawn outside (inside) the axis lines.
    member __.ticks
        with get () = Option.get _ticks
        and set value = _ticks <- Some value

    /// Determines if the axis lines or/and ticks are mirrored to the opposite side of the plotting area. If *true*, the axis lines are mirrored. If *ticks*, the axis lines and ticks are mirrored. If *false*, mirroring is disable. If *all*, axis lines are mirrored on all shared-axes subplots. If *allticks*, axis lines and ticks are mirrored on all shared-axes subplots.
    member __.mirror
        with get () = Option.get _mirror
        and set value = _mirror <- Some value

    /// Sets the tick length (in px).
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the tick width (in px).
    member __.tickwidth
        with get () = Option.get _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the tick color.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Determines whether or not the tick labels are drawn.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    member __.tickfont
        with get () = Option.get _tickfont
        and set value = _tickfont <- Some value

    /// Sets the angle of the tick labels with respect to the horizontal. For example, a `tickangle` of -90 draws the tick labels vertically.
    member __.tickangle
        with get () = Option.get _tickangle
        and set value = _tickangle <- Some value

    /// Sets a tick label prefix.
    member __.tickprefix
        with get () = Option.get _tickprefix
        and set value = _tickprefix <- Some value

    /// If *all*, all tick labels are displayed with a prefix. If *first*, only the first tick is displayed with a prefix. If *last*, only the last tick is displayed with a suffix. If *none*, tick prefixes are hidden.
    member __.showtickprefix
        with get () = Option.get _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Sets a tick label suffix.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Same as `showtickprefix` but for tick suffixes.
    member __.showticksuffix
        with get () = Option.get _showticksuffix
        and set value = _showticksuffix <- Some value

    /// If *all*, all exponents are shown besides their significands. If *first*, only the exponent of the first tick is shown. If *last*, only the exponent of the last tick is shown. If *none*, no exponents appear.
    member __.showexponent
        with get () = Option.get _showexponent
        and set value = _showexponent <- Some value

    /// Determines a formatting rule for the tick exponents. For example, consider the number 1,000,000,000. If *none*, it appears as 1,000,000,000. If *e*, 1e+9. If *E*, 1E+9. If *power*, 1x10^9 (with 9 in a super script). If *SI*, 1G. If *B*, 1B.
    member __.exponentformat
        with get () = Option.get _exponentformat
        and set value = _exponentformat <- Some value

    /// Sets the tick label formatting rule using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
    member __.tickformat
        with get () = Option.get _tickformat
        and set value = _tickformat <- Some value

    /// Sets the hover text formatting rule for data values on this axis, using the python/d3 number formatting language. See https://github.com/mbostock/d3/wiki/Formatting#numbers or https://docs.python.org/release/3.1.3/library/string.html#formatspec for more info.
    member __.hoverformat
        with get () = Option.get _hoverformat
        and set value = _hoverformat <- Some value

    /// Determines whether or not a line bounding this axis is drawn.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Sets the axis line color.
    member __.linecolor
        with get () = Option.get _linecolor
        and set value = _linecolor <- Some value

    /// Sets the width (in px) of the axis line.
    member __.linewidth
        with get () = Option.get _linewidth
        and set value = _linewidth <- Some value

    /// Determines whether or not grid lines are drawn. If *true*, the grid lines are drawn at every tick mark.
    member __.showgrid
        with get () = Option.get _showgrid
        and set value = _showgrid <- Some value

    /// Sets the color of the grid lines.
    member __.gridcolor
        with get () = Option.get _gridcolor
        and set value = _gridcolor <- Some value

    /// Sets the width (in px) of the grid lines.
    member __.gridwidth
        with get () = Option.get _gridwidth
        and set value = _gridwidth <- Some value

    /// Determines whether or not a line is drawn at along the 0 value of this axis. If *true*, the zero line is drawn on top of the grid lines.
    member __.zeroline
        with get () = Option.get _zeroline
        and set value = _zeroline <- Some value

    /// Sets the line color of the zero line.
    member __.zerolinecolor
        with get () = Option.get _zerolinecolor
        and set value = _zerolinecolor <- Some value

    /// Sets the width (in px) of the zero line.
    member __.zerolinewidth
        with get () = Option.get _zerolinewidth
        and set value = _zerolinewidth <- Some value

    /// If set to an opposite-letter axis id (e.g. `xaxis2`, `yaxis`), this axis is bound to the corresponding opposite-letter axis. If set to *free*, this axis' position is determined by `position`.
    member __.anchor
        with get () = Option.get _anchor
        and set value = _anchor <- Some value

    /// Determines whether a x (y) axis is positioned at the *bottom* (*left*) or *top* (*right*) of the plotting area.
    member __.side
        with get () = Option.get _side
        and set value = _side <- Some value

    /// If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis. If *false*, this axis does not overlay any same-letter axes.
    member __.overlaying
        with get () = Option.get _overlaying
        and set value = _overlaying <- Some value

    /// Sets the domain of this axis (in plot fraction).
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to *free*.
    member __.position
        with get () = Option.get _position
        and set value = _position <- Some value

    member __._isSubplotObj
        with get () = Option.get __isSubplotObj
        and set value = __isSubplotObj <- Some value

    /// Sets the source reference on plot.ly for  tickvals .
    member __.tickvalssrc
        with get () = Option.get _tickvalssrc
        and set value = _tickvalssrc <- Some value

    /// Sets the source reference on plot.ly for  ticktext .
    member __.ticktextsrc
        with get () = Option.get _ticktextsrc
        and set value = _ticktextsrc <- Some value

    /// Sets whether or not spikes starting from data points to this axis' wall are shown on hover.
    member __.showspikes
        with get () = Option.get _showspikes
        and set value = _showspikes <- Some value

    /// Sets whether or not spikes extending from the projection data points to this axis' wall boundaries are shown on hover.
    member __.spikesides
        with get () = Option.get _spikesides
        and set value = _spikesides <- Some value

    /// Sets the thickness (in px) of the spikes.
    member __.spikethickness
        with get () = Option.get _spikethickness
        and set value = _spikethickness <- Some value

    /// Sets the color of the spikes.
    member __.spikecolor
        with get () = Option.get _spikecolor
        and set value = _spikecolor <- Some value

    /// Sets whether or not this axis' wall has a background color.
    member __.showbackground
        with get () = Option.get _showbackground
        and set value = _showbackground <- Some value

    /// Sets the background color of this axis' wall.
    member __.backgroundcolor
        with get () = Option.get _backgroundcolor
        and set value = _backgroundcolor <- Some value

    /// Sets whether or not this axis is labeled
    member __.showaxeslabels
        with get () = Option.get _showaxeslabels
        and set value = _showaxeslabels <- Some value

    member __.ShouldSerializeautotick() = not _autotick.IsNone
    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializeautorange() = not _autorange.IsNone
    member __.ShouldSerializerangemode() = not _rangemode.IsNone
    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializefixedrange() = not _fixedrange.IsNone
    member __.ShouldSerializetickmode() = not _tickmode.IsNone
    member __.ShouldSerializenticks() = not _nticks.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializetickvals() = not _tickvals.IsNone
    member __.ShouldSerializeticktext() = not _ticktext.IsNone
    member __.ShouldSerializeticks() = not _ticks.IsNone
    member __.ShouldSerializemirror() = not _mirror.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetickfont() = not _tickfont.IsNone
    member __.ShouldSerializetickangle() = not _tickangle.IsNone
    member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
    member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
    member __.ShouldSerializetickformat() = not _tickformat.IsNone
    member __.ShouldSerializehoverformat() = not _hoverformat.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializelinecolor() = not _linecolor.IsNone
    member __.ShouldSerializelinewidth() = not _linewidth.IsNone
    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
    member __.ShouldSerializezeroline() = not _zeroline.IsNone
    member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
    member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
    member __.ShouldSerializeanchor() = not _anchor.IsNone
    member __.ShouldSerializeside() = not _side.IsNone
    member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializeposition() = not _position.IsNone
    member __.ShouldSerialize_isSubplotObj() = not __isSubplotObj.IsNone
    member __.ShouldSerializetickvalssrc() = not _tickvalssrc.IsNone
    member __.ShouldSerializeticktextsrc() = not _ticktextsrc.IsNone
    member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
    member __.ShouldSerializespikesides() = not _spikesides.IsNone
    member __.ShouldSerializespikethickness() = not _spikethickness.IsNone
    member __.ShouldSerializespikecolor() = not _spikecolor.IsNone
    member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
    member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
    member __.ShouldSerializeshowaxeslabels() = not _showaxeslabels.IsNone
