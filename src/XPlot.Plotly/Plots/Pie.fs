namespace XPlot.Plotly

type Pie() =
    inherit Trace()

    let mutable _type: string option = Some "pie"
    let mutable _visible: _ option = None
    let mutable _showlegend: bool option = None
    let mutable _legendgroup: string option = None
    let mutable _opacity: float option = None
    let mutable _uid: string option = None
    let mutable _hoverinfo: string option = None
    let mutable _stream: Stream option = None
    let mutable _labels: _ option = None
    let mutable _label0: float option = None
    let mutable _dlabel: float option = None
    let mutable _values: _ option = None
    let mutable _marker: Marker option = None
    let mutable _text: _ option = None
    let mutable _scalegroup: string option = None
    let mutable _textinfo: string option = None
    let mutable _textposition: _ option = None
    let mutable _textfont: Textfont option = None
    let mutable _insidetextfont: Insidetextfont option = None
    let mutable _outsidetextfont: Outsidetextfont option = None
    let mutable _domain: Domain option = None
    let mutable _hole: float option = None
    let mutable _sort: bool option = None
    let mutable _direction: _ option = None
    let mutable _rotation: float option = None
    let mutable _pull: float option = None
    let mutable _labelssrc: string option = None
    let mutable _valuessrc: string option = None
    let mutable _textsrc: string option = None
    let mutable _textpositionsrc: string option = None
    let mutable _pullsrc: string option = None

    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Determines whether or not this trace is visible. If *legendonly*, the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Determines whether or not an item corresponding to this trace is shown in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
    member __.legendgroup
        with get () = Option.get _legendgroup
        and set value = _legendgroup <- Some value

    /// Sets the opacity of the trace.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    member __.uid
        with get () = Option.get _uid
        and set value = _uid <- Some value

    /// Determines which trace information appear on hover.
    member __.hoverinfo
        with get () = Option.get _hoverinfo
        and set value = _hoverinfo <- Some value

    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Sets the sector labels.
    member __.labels
        with get () = Option.get _labels
        and set value = _labels <- Some value

    /// Alternate to `labels`. Builds a numeric set of labels. Use with `dlabel` where `label0` is the starting label and `dlabel` the step.
    member __.label0
        with get () = Option.get _label0
        and set value = _label0 <- Some value

    /// Sets the label step. See `label0` for more info.
    member __.dlabel
        with get () = Option.get _dlabel
        and set value = _dlabel <- Some value

    /// Sets the values of the sectors of this pie chart.
    member __.values
        with get () = Option.get _values
        and set value = _values <- Some value

    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets text elements associated with each sector.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// If there are multiple pies that should be sized according to their totals, link them by providing a non-empty group id here shared by every trace in the same group.
    member __.scalegroup
        with get () = Option.get _scalegroup
        and set value = _scalegroup <- Some value

    /// Determines which trace information appear on the graph.
    member __.textinfo
        with get () = Option.get _textinfo
        and set value = _textinfo <- Some value

    /// Specifies the location of the `textinfo`.
    member __.textposition
        with get () = Option.get _textposition
        and set value = _textposition <- Some value

    member __.textfont
        with get () = Option.get _textfont
        and set value = _textfont <- Some value

    member __.insidetextfont
        with get () = Option.get _insidetextfont
        and set value = _insidetextfont <- Some value

    member __.outsidetextfont
        with get () = Option.get _outsidetextfont
        and set value = _outsidetextfont <- Some value

    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the fraction of the radius to cut out of the pie. Use this to make a donut chart.
    member __.hole
        with get () = Option.get _hole
        and set value = _hole <- Some value

    /// Determines whether or not the sectors of reordered from largest to smallest.
    member __.sort
        with get () = Option.get _sort
        and set value = _sort <- Some value

    /// Specifies the direction at which succeeding sectors follow one another.
    member __.direction
        with get () = Option.get _direction
        and set value = _direction <- Some value

    /// Instead of the first slice starting at 12 o'clock, rotate to some other angle.
    member __.rotation
        with get () = Option.get _rotation
        and set value = _rotation <- Some value

    /// Sets the fraction of larger radius to pull the sectors out from the center. This can be a constant to pull all slices apart from each other equally or an array to highlight one or more slices.
    member __.pull
        with get () = Option.get _pull
        and set value = _pull <- Some value

    /// Sets the source reference on plot.ly for  labels .
    member __.labelssrc
        with get () = Option.get _labelssrc
        and set value = _labelssrc <- Some value

    /// Sets the source reference on plot.ly for  values .
    member __.valuessrc
        with get () = Option.get _valuessrc
        and set value = _valuessrc <- Some value

    /// Sets the source reference on plot.ly for  text .
    member __.textsrc
        with get () = Option.get _textsrc
        and set value = _textsrc <- Some value

    /// Sets the source reference on plot.ly for  textposition .
    member __.textpositionsrc
        with get () = Option.get _textpositionsrc
        and set value = _textpositionsrc <- Some value

    /// Sets the source reference on plot.ly for  pull .
    member __.pullsrc
        with get () = Option.get _pullsrc
        and set value = _pullsrc <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializelegendgroup() = not _legendgroup.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeuid() = not _uid.IsNone
    member __.ShouldSerializehoverinfo() = not _hoverinfo.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializelabels() = not _labels.IsNone
    member __.ShouldSerializelabel0() = not _label0.IsNone
    member __.ShouldSerializedlabel() = not _dlabel.IsNone
    member __.ShouldSerializevalues() = not _values.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializescalegroup() = not _scalegroup.IsNone
    member __.ShouldSerializetextinfo() = not _textinfo.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializeinsidetextfont() = not _insidetextfont.IsNone
    member __.ShouldSerializeoutsidetextfont() = not _outsidetextfont.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializehole() = not _hole.IsNone
    member __.ShouldSerializesort() = not _sort.IsNone
    member __.ShouldSerializedirection() = not _direction.IsNone
    member __.ShouldSerializerotation() = not _rotation.IsNone
    member __.ShouldSerializepull() = not _pull.IsNone
    member __.ShouldSerializelabelssrc() = not _labelssrc.IsNone
    member __.ShouldSerializevaluessrc() = not _valuessrc.IsNone
    member __.ShouldSerializetextsrc() = not _textsrc.IsNone
    member __.ShouldSerializetextpositionsrc() = not _textpositionsrc.IsNone
    member __.ShouldSerializepullsrc() = not _pullsrc.IsNone
