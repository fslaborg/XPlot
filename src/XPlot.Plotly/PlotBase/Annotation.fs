namespace XPlot.Plotly

type Annotation() =

    let mutable _text: string option = None
    let mutable _textangle: float option = None
    let mutable _font: Font option = None
    let mutable _opacity: float option = None
    let mutable _align: _ option = None
    let mutable _bgcolor: string option = None
    let mutable _bordercolor: string option = None
    let mutable _borderpad: float option = None
    let mutable _borderwidth: float option = None
    let mutable _showarrow: bool option = None
    let mutable _arrowcolor: string option = None
    let mutable _arrowhead: int option = None
    let mutable _arrowsize: float option = None
    let mutable _arrowwidth: float option = None
    let mutable _ax: float option = None
    let mutable _ay: float option = None
    let mutable _xref: _ option = None
    let mutable _x: _ option = None
    let mutable _xanchor: _ option = None
    let mutable _yref: _ option = None
    let mutable _y: _ option = None
    let mutable _yanchor: _ option = None

    /// Sets the text associated with this annotation. Plotly uses a subset of HTML tags to do things like newline (<br>), bold (<b></b>), italics (<i></i>), hyperlinks (<a href='...'></a>). Tags <em>, <sup>, <sub> <span> are also supported.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Sets the angle at which the `text` is drawn with respect to the horizontal.
    member __.textangle
        with get () = Option.get _textangle
        and set value = _textangle <- Some value

    member __.font
        with get () = Option.get _font
        and set value = _font <- Some value

    /// Sets the opacity of the annotation (text + arrow).
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Sets the vertical alignment of the `text` with respect to the set `x` and `y` position. Has only an effect if `text` spans more two or more lines (i.e. `text` contains one or more <br> HTML tags).
    member __.align
        with get () = Option.get _align
        and set value = _align <- Some value

    /// Sets the background color of the annotation.
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    /// Sets the color of the border enclosing the annotation `text`.
    member __.bordercolor
        with get () = Option.get _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the padding (in px) between the `text` and the enclosing border.
    member __.borderpad
        with get () = Option.get _borderpad
        and set value = _borderpad <- Some value

    /// Sets the width (in px) of the border enclosing the annotation `text`.
    member __.borderwidth
        with get () = Option.get _borderwidth
        and set value = _borderwidth <- Some value

    /// Determines whether or not the annotation is drawn with an arrow. If *true*, `text` is placed near the arrow's tail. If *false*, `text` lines up with the `x` and `y` provided.
    member __.showarrow
        with get () = Option.get _showarrow
        and set value = _showarrow <- Some value

    /// Sets the color of the annotation arrow.
    member __.arrowcolor
        with get () = Option.get _arrowcolor
        and set value = _arrowcolor <- Some value

    /// Sets the annotation arrow head style.
    member __.arrowhead
        with get () = Option.get _arrowhead
        and set value = _arrowhead <- Some value

    /// Sets the size (in px) of annotation arrow head.
    member __.arrowsize
        with get () = Option.get _arrowsize
        and set value = _arrowsize <- Some value

    /// Sets the width (in px) of annotation arrow.
    member __.arrowwidth
        with get () = Option.get _arrowwidth
        and set value = _arrowwidth <- Some value

    /// Sets the x component of the arrow tail about the arrow head. A positive (negative) component corresponds to an arrow pointing from right to left (left to right)
    member __.ax
        with get () = Option.get _ax
        and set value = _ax <- Some value

    /// Sets the y component of the arrow tail about the arrow head. A positive (negative) component corresponds to an arrow pointing from bottom to top (top to bottom)
    member __.ay
        with get () = Option.get _ay
        and set value = _ay <- Some value

    /// Sets the annotation's x coordinate axis. If set to an x axis id (e.g. *x* or *x2*), the `x` position refers to an x coordinate If set to *paper*, the `x` position refers to the distance from the left side of the plotting area in normalized coordinates where 0 (1) corresponds to the left (right) side.
    member __.xref
        with get () = Option.get _xref
        and set value = _xref <- Some value

    /// Sets the annotation's x position. Note that dates and categories are converted to numbers.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the annotation's horizontal position anchor This anchor binds the `x` position to the *left*, *center* or *right* of the annotation. For example, if `x` is set to 1, `xref` to *paper* and `xanchor` to *right* then the right-most portion of the annotation lines up with the right-most edge of the plotting area. If *auto*, the anchor is equivalent to *center* for data-referenced annotations whereas for paper-referenced, the anchor picked corresponds to the closest side.
    member __.xanchor
        with get () = Option.get _xanchor
        and set value = _xanchor <- Some value

    /// Sets the annotation's y coordinate axis. If set to an y axis id (e.g. *y* or *y2*), the `y` position refers to an y coordinate If set to *paper*, the `y` position refers to the distance from the bottom of the plotting area in normalized coordinates where 0 (1) corresponds to the bottom (top).
    member __.yref
        with get () = Option.get _yref
        and set value = _yref <- Some value

    /// Sets the annotation's y position. Note that dates and categories are converted to numbers.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the annotation's vertical position anchor This anchor binds the `y` position to the *top*, *middle* or *bottom* of the annotation. For example, if `y` is set to 1, `yref` to *paper* and `yanchor` to *top* then the top-most portion of the annotation lines up with the top-most edge of the plotting area. If *auto*, the anchor is equivalent to *middle* for data-referenced annotations whereas for paper-referenced, the anchor picked corresponds to the closest side.
    member __.yanchor
        with get () = Option.get _yanchor
        and set value = _yanchor <- Some value

    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializetextangle() = not _textangle.IsNone
    member __.ShouldSerializefont() = not _font.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializealign() = not _align.IsNone
    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
    member __.ShouldSerializeborderpad() = not _borderpad.IsNone
    member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
    member __.ShouldSerializeshowarrow() = not _showarrow.IsNone
    member __.ShouldSerializearrowcolor() = not _arrowcolor.IsNone
    member __.ShouldSerializearrowhead() = not _arrowhead.IsNone
    member __.ShouldSerializearrowsize() = not _arrowsize.IsNone
    member __.ShouldSerializearrowwidth() = not _arrowwidth.IsNone
    member __.ShouldSerializeax() = not _ax.IsNone
    member __.ShouldSerializeay() = not _ay.IsNone
    member __.ShouldSerializexref() = not _xref.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializexanchor() = not _xanchor.IsNone
    member __.ShouldSerializeyref() = not _yref.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializeyanchor() = not _yanchor.IsNone
