[<AutoOpen>]
module XPlot.Plotly.Graph

type Trace() = do ()

type ErrorY() =

    let mutable _type: string option = None
    let mutable _symmetric: bool option = None
    let mutable _array: seq<_> option = None
    let mutable _value: float option = None
    let mutable _arrayminus: seq<_> option = None
    let mutable _valueminus: float option = None
    let mutable _color: string option = None
    let mutable _thickness: float option = None
    let mutable _width: float option = None
    let mutable _opacity: float option = None
    let mutable _visible: bool option = None

    /// Specify how the 'value' or 'array' key in this error bar will be used to render the bars. Using 'data' will set error bar lengths to the actual numbers specified in 'array'.  Using 'percent' will set bar lengths to the percent of error associated with 'value'. Using 'constant' will set each error bar length to the single value specified in 'value'. Using 'sqrt' will set each error bar length to the square root of the x data at each point ('value' and 'array' do not apply).
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Toggle whether or not error bars are the same length in both directions (up and down). If not specified, the error bars will be symmetric.
    member __.symmetric
        with get () = Option.get _symmetric
        and set value = _symmetric <- Some value

    /// The array corresponding to the span of the error bars. Has only an effect if 'type' is set to 'data'. Values in the array are plotted relative to the 'y' coordinates. For example, with 'y'=[1,2] and 'array'=[1,2], the error bars will span from y= 0 to 2 and y= 0 to 4 if 'symmetric' is set to TRUE; and from y= 1 to 2 and y= 2 to 4 if 'symmetric' is set to FALSE and 'arrayminus' is empty.
    member __.array
        with get () = Option.get _array
        and set value = _array <- Some value

    /// The value or percentage determining the error bars' span, at all trace coordinates. Has an effect if 'type' is set to 'value' or 'percent'. If 'symmetric' is set to FALSE, this value corresponds to the span above the trace of coordinates. To specify multiple error bar lengths, you should set 'type' to 'data' and use the 'array' key instead.
    member __.value
        with get () = Option.get _value
        and set value = _value <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'array' but corresponding to the span of the error bars below the trace coordinates
    member __.arrayminus
        with get () = Option.get _arrayminus
        and set value = _arrayminus <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'value' but corresponding to the span of the error bars below the trace coordinates
    member __.valueminus
        with get () = Option.get _valueminus
        and set value = _valueminus <- Some value

    /// Sets the color of the error bars.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// Sets the line thickness of the y error bars.
    member __.thickness
        with get () = Option.get _thickness
        and set value = _thickness <- Some value

    /// Sets the width (in pixels) of the cross-bar at both ends of the error bars.
    member __.width
        with get () = Option.get _width
        and set value = _width <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializesymmetric() = not _symmetric.IsNone
    member __.ShouldSerializearray() = not _array.IsNone
    member __.ShouldSerializevalue() = not _value.IsNone
    member __.ShouldSerializearrayminus() = not _arrayminus.IsNone
    member __.ShouldSerializevalueminus() = not _valueminus.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializethickness() = not _thickness.IsNone
    member __.ShouldSerializewidth() = not _width.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone

type ErrorX() =

    let mutable _type: string option = None
    let mutable _symmetric: bool option = None
    let mutable _array: seq<_> option = None
    let mutable _value: float option = None
    let mutable _arrayminus: seq<_> option = None
    let mutable _valueminus: float option = None
    let mutable _color: string option = None
    let mutable _thickness: float option = None
    let mutable _width: float option = None
    let mutable _opacity: float option = None
    let mutable _copy_ystyle: string option = None
    let mutable _visible: bool option = None

    /// Specify how the 'value' or 'array' key in this error bar will be used to render the bars. Using 'data' will set error bar lengths to the actual numbers specified in 'array'.  Using 'percent' will set bar lengths to the percent of error associated with 'value'. Using 'constant' will set each error bar length to the single value specified in 'value'. Using 'sqrt' will set each error bar length to the square root of the x data at each point ('value' and 'array' do not apply).
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Toggle whether or not error bars are the same length in both directions (right and left). If not specified, the error bars will be symmetric.
    member __.symmetric
        with get () = Option.get _symmetric
        and set value = _symmetric <- Some value

    /// The array corresponding to the span of the error bars. Has only an effect if 'type' is set to 'data'. Values in the array are plotted relative to the 'x' coordinates. For example, with 'x'=[1,2] and 'array'=[1,2], the error bars will span from x= 0 to 2 and x= 0 to 4 if 'symmetric' is set to TRUE; and from x= 1 to 2 and x= 2 to 4 if 'symmetric' is set to FALSE and 'arrayminus' is empty.
    member __.array
        with get () = Option.get _array
        and set value = _array <- Some value

    /// The value or percentage determining the error bars' span, at all trace coordinates. Has an effect if 'type' is set to 'value' or 'percent'. If 'symmetric' is set to FALSE, this value corresponds to the span right of the trace of coordinates. To specify multiple error bar lengths, you should set 'type' to 'data' and use the 'array' key instead.
    member __.value
        with get () = Option.get _value
        and set value = _value <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'array' but corresponding to the span of the error bars left of the trace coordinates
    member __.arrayminus
        with get () = Option.get _arrayminus
        and set value = _arrayminus <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'value' but corresponding to the span of the error bars left of the trace coordinates
    member __.valueminus
        with get () = Option.get _valueminus
        and set value = _valueminus <- Some value

    /// Sets the color of the error bars.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// Sets the line thickness of the x error bars.
    member __.thickness
        with get () = Option.get _thickness
        and set value = _thickness <- Some value

    /// Sets the width (in pixels) of the cross-bar at both ends of the error bars.
    member __.width
        with get () = Option.get _width
        and set value = _width <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Toggle whether to set x error bar style to the same style (color, thickness, width, opacity) as y error bars set in 'yaxis'.
    member __.copy_ystyle
        with get () = Option.get _copy_ystyle
        and set value = _copy_ystyle <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializesymmetric() = not _symmetric.IsNone
    member __.ShouldSerializearray() = not _array.IsNone
    member __.ShouldSerializevalue() = not _value.IsNone
    member __.ShouldSerializearrayminus() = not _arrayminus.IsNone
    member __.ShouldSerializevalueminus() = not _valueminus.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializethickness() = not _thickness.IsNone
    member __.ShouldSerializewidth() = not _width.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializecopy_ystyle() = not _copy_ystyle.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone

type Line() =

    let mutable _color: obj option = None
    let mutable _width: obj option = None
    let mutable _dash: string option = None
    let mutable _opacity: float option = None
    let mutable _shape: string option = None
    let mutable _smoothing: float option = None
    let mutable _outliercolor: string option = None
    let mutable _outlierwidth: string option = None

    /// Sets the color of the line object. If linked within 'marker', sets the color of the marker's bordering line. If linked within, 'contours', sets the color of the contour lines.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// Sets the width (in pixels) of the line segments in question.
    member __.width
        with get () = Option.get _width
        and set value = _width <- Some value

    /// Sets the drawing style of the lines segments in this trace.
    member __.dash
        with get () = Option.get _dash
        and set value = _dash <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Choose the line shape between each coordinate pair in this trace. Applies only to scatter traces. The default value is 'linear'. If set to 'spline', then the lines are drawn using spline interpolation between the coordinate pairs. The remaining available values correspond to step-wise line shapes.
    member __.shape
        with get () = Option.get _shape
        and set value = _shape <- Some value

    /// Sets the amount of smoothing applied to the lines segments in this trace. Applies only to contour traces and scatter traces if 'shape' is set to 'spline'. The default value is 1. If 'smoothing' is set to 0, then no smoothing is applied. Set 'smoothing' to a value less (greater) than 1 for a less (more) pronounced line smoothing.
    member __.smoothing
        with get () = Option.get _smoothing
        and set value = _smoothing <- Some value

    /// For box plots only. Has an effect only if 'boxpoints' is set to 'suspectedoutliers'. Sets the color of the bordering line of the outlier points.
    member __.outliercolor
        with get () = Option.get _outliercolor
        and set value = _outliercolor <- Some value

    /// For box plots only. Has an effect only if 'boxpoints' is set to 'suspectedoutliers'. Sets the width in pixels of bordering line of the outlier points.
    member __.outlierwidth
        with get () = Option.get _outlierwidth
        and set value = _outlierwidth <- Some value

    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializewidth() = not _width.IsNone
    member __.ShouldSerializedash() = not _dash.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeshape() = not _shape.IsNone
    member __.ShouldSerializesmoothing() = not _smoothing.IsNone
    member __.ShouldSerializeoutliercolor() = not _outliercolor.IsNone
    member __.ShouldSerializeoutlierwidth() = not _outlierwidth.IsNone

type Marker() =

    let mutable _color: obj option = None
    let mutable _size: obj option = None
    let mutable _symbol: obj option = None
    let mutable _line: Line option = None
    let mutable _opacity: obj option = None
    let mutable _sizeref: float option = None
    let mutable _sizemode: string option = None
    let mutable _colorscale: string option = None
    let mutable _cauto: string option = None
    let mutable _cmin: float option = None
    let mutable _cmax: float option = None
    let mutable _outliercolor: string option = None
    let mutable _maxdisplayed: float option = None

    /// Sets the color of the face of the marker object. If 'color' is linked to an array of color strings, color values are mapped to individual marker points in the same order as in the data lists or arrays. To set the color of the marker's bordering line, use 'line' in 'marker'. The 'color' key can also accept array of numbers, where each number is then mapped to a color using the color scale set in 'colorscale'.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// Sets the size of the markers (in pixels). If 'size' is linked to an array of numbers, size values are mapped to individual marker points in the same order as in the 'x', 'y (or 'z') array. In this case, use 'size' in conjunction with 'sizeref' and 'sizemode' to fine-tune the map from the numbers linked to 'size' and the marker points' rendered sizes.
    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    /// The symbol that is drawn on the plot for each marker. Supported only in scatter traces. If 'symbol' is linked to an array, the symbol values are mapped to individual marker points in the same order as in the array linked to 'x', 'y' (or 'z').
    member __.symbol
        with get () = Option.get _symbol
        and set value = _symbol <- Some value

    /// Links a dictionary containing line parameters for the line segments associated with this marker. For example, the line segments around each marker point in a scatter trace or the line segments around each bar in a bar trace.
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets the opacity, or transparency also known as the alpha channel of colors) of the marker points. If the marker points' color is given in terms of 'rgba' color model, this does not need to be defined. If 'opacity' is linked to a list or an array of numbers, opacity values are mapped to individual marker points in the same order as in the 'x', 'y' (or 'z') array.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Sets the scale factor used to determine the rendered size of each marker point in this trace. Applies only to scatter traces that have their 'size' key in 'marker' linked to an array. If set, the value linked to 'sizeref' is used to divide each entry linked to 'size'. Specifically, setting 'sizeref' to less (greater) than 1, increases (decreases) the rendered marker sizes.
    member __.sizeref
        with get () = Option.get _sizeref
        and set value = _sizeref <- Some value

    /// Choose between marker size scaling options for the marker points in this trace. Applies only to scatter traces that have their 'size' key in 'marker' linked to an array. If 'diameter' ('area'), then the diameter (area) of the rendered marker points (in pixels) are proportional to the numbers linked to 'size'.For example, set 'sizemode' to 'area' for a more a smaller range of rendered marker sizes.
    member __.sizemode
        with get () = Option.get _sizemode
        and set value = _sizemode <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of color from 0-1, i.e. (c-cmin)/ (cmax-cmin), and the second element of pair corresponds to a color. Use with 'cauto', 'cmin' and 'cmax to fine-tune the map from 'color' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Toggle whether or not the default values of 'cmax' and 'cmax' can be overwritten.
    member __.cauto
        with get () = Option.get _cauto
        and set value = _cauto <- Some value

    /// Sets the minimum 'color' data value to be resolved by the color scale. Its default value is the minimum of the 'color' data values. This value will be used as the minimum in the color scale normalization. For more info see 'colorscale'. Has only an effect if 'color' is linked to an array nd 'colorscale' is set.
    member __.cmin
        with get () = Option.get _cmin
        and set value = _cmin <- Some value

    /// Sets the maximum 'color' data value to be resolved by the color scale. Its default value is the maximum of the 'color' data values. This value will be used as the maximum in the color scale normalization. For more info see 'colorscale'. Has only an effect if 'color' is linked to an array nd 'colorscale' is set.
    member __.cmax
        with get () = Option.get _cmax
        and set value = _cmax <- Some value

    /// For box plots only. Has an effect only if 'boxpoints' is set to 'suspectedoutliers'. Sets the face color of the outlier points.
    member __.outliercolor
        with get () = Option.get _outliercolor
        and set value = _outliercolor <- Some value

    /// Sets maximum number of displayed points for this trace. Applies only to scatter traces.
    member __.maxdisplayed
        with get () = Option.get _maxdisplayed
        and set value = _maxdisplayed <- Some value

    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializesymbol() = not _symbol.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializesizeref() = not _sizeref.IsNone
    member __.ShouldSerializesizemode() = not _sizemode.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializecauto() = not _cauto.IsNone
    member __.ShouldSerializecmin() = not _cmin.IsNone
    member __.ShouldSerializecmax() = not _cmax.IsNone
    member __.ShouldSerializeoutliercolor() = not _outliercolor.IsNone
    member __.ShouldSerializemaxdisplayed() = not _maxdisplayed.IsNone

type Font() =

    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None
    let mutable _outlinecolor: string option = None

    /// Sets the font family. If linked in the first level of the layout object,  set the color of the global font. The default font in Plotly is 'Open Sans, sans-serif'.
    member __.family
        with get () = Option.get _family
        and set value = _family <- Some value

    /// Sets the size of text font. If linked directly from 'layout', set the size of the global font.
    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    /// Sets the color of the text font. If linked directly from 'layout', set the color of the global font.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// For polar chart only. Sets the color of the text's outline.
    member __.outlinecolor
        with get () = Option.get _outlinecolor
        and set value = _outlinecolor <- Some value

    member __.ShouldSerializefamily() = not _family.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializeoutlinecolor() = not _outlinecolor.IsNone

type Stream() =

    let mutable _token: string option = None
    let mutable _maxpoints: float option = None

    /// The stream id number links a data trace on a plot with a stream. In other words, any data trace you create can reference a 'stream'. If you stream data to Plotly with the same stream id (token), Plotly knows update this data object with the incoming data stream.
    member __.token
        with get () = Option.get _token
        and set value = _token <- Some value

    /// Sets the maximum number of points to keep on the plots from an incoming stream. For example, if 'maxpoints' is set to 50, only the newest 50 points will be displayed on the plot.
    member __.maxpoints
        with get () = Option.get _maxpoints
        and set value = _maxpoints <- Some value

    member __.ShouldSerializetoken() = not _token.IsNone
    member __.ShouldSerializemaxpoints() = not _maxpoints.IsNone

type Scatter() =
    inherit Trace()

    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _r: seq<float> option = None
    let mutable _t: _ option = None
    let mutable _mode: string option = None
    let mutable _name: string option = None
    let mutable _text: seq<string> option = None
    let mutable _error_y: ErrorY option = None
    let mutable _error_x: ErrorX option = None
    let mutable _marker: Marker option = None
    let mutable _line: Line option = None
    let mutable _textposition: string option = None
    let mutable _textfont: Font option = None
    let mutable _connectgaps: string option = None
    let mutable _fill: string option = None
    let mutable _fillcolor: string option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _type: string option = Some "scatter"

    /// Sets the x coordinates of the points of this scatter trace. If 'x' is linked to an array of strings, then the x coordinates are integers, 0, 1, 2, 3, ..., labeled on the x-axis by the array of strings linked to 'x'.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the y coordinates of the points of this scatter trace. If 'y' is linked to an array of strings, then the y coordinates are integers, 0, 1, 2, 3, ..., labeled on the y-axis by the array of strings linked to 'y'.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// For Polar charts only. Sets the radial coordinates of the points in this polar scatter trace about the origin.
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// For Polar charts only. Sets the angular coordinates of the points in this polar scatter trace. By default, the angular coordinates are in degrees (0 to 360) where the angles are measured clockwise about the right-hand side of the origin. To change this behavior, modify 'range' in 'angularaxis' or/and 'direction' in 'layout'. If 't' is linked to an array of strings, then the angular coordinates are 0, 360\N, 2*360/N, ... where N is the number of coordinates given labeled by the array of strings linked to 't'.
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    /// Plotting mode for this scatter trace. If the mode includes 'text' then the 'text' will appear at the (x,y) points, otherwise it will appear on hover.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// The text elements associated with each (x,y) pair in this scatter trace. If the scatter 'mode' does not include 'text' then elements linked to 'text' will appear on hover only. In contrast, if 'text' is included in 'mode', the elements in 'text' will be rendered on the plot at the locations specified in part by their corresponding (x,y) coordinate pair and the 'textposition' key.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Links a dictionary describing the vertical error bars (i.e. along the y-axis) that can be drawn from the (x,y) coordinates of this scatter trace.
    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    /// Links a dictionary describing the horizontal error bars (i.e. along the x-axis) that can be drawn from the (x,y) coordinates of this scatter trace.
    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    /// Links a dictionary containing marker style parameters for this scatter trace. Has an effect only if 'mode' contains 'markers'.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Links a dictionary containing line parameters for this scatter trace. Has an effect only if 'mode' contains 'lines'.
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets the position of the text elements in the 'text' key with respect to the data points. By default, the text elements are plotted directly at the (x,y) coordinates.
    member __.textposition
        with get () = Option.get _textposition
        and set value = _textposition <- Some value

    /// Links a dictionary describing the font style of this scatter trace's text elements. Has only an effect if 'mode' is set and includes 'text'.
    member __.textfont
        with get () = Option.get _textfont
        and set value = _textfont <- Some value

    /// Toggle whether or not missing data points (i.e. '' or NaN) linked to 'x' and/or 'y', are added in by Plotly using linear interpolation.
    member __.connectgaps
        with get () = Option.get _connectgaps
        and set value = _connectgaps <- Some value

    /// Use to make area-style charts. Determines which area to fill with a solid color.By default, the area will appear in a more-transparent shape of the line color (or of the marker color if 'mode' does not contains 'lines').
    member __.fill
        with get () = Option.get _fill
        and set value = _fill <- Some value

    /// Sets the color that will appear in the specified fill area (set in 'fill'). Has no effect if 'fill' is set to 'none'.
    member __.fillcolor
        with get () = Option.get _fillcolor
        and set value = _fillcolor <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Sets the x coordinates of the points of this scatter trace. If 'x' is linked to an array of strings, then the x coordinates are integers, 0, 1, 2, 3, ..., labeled on the x-axis by the array of strings linked to 'x'.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the y coordinates of the points of this scatter trace. If 'y' is linked to an array of strings, then the y coordinates are integers, 0, 1, 2, 3, ..., labeled on the y-axis by the array of strings linked to 'y'.
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializemode() = not _mode.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
    member __.ShouldSerializefill() = not _fill.IsNone
    member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Bar() =
    inherit Trace()

    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _name: string option = None
    let mutable _orientation: string option = None
    let mutable _text: seq<string> option = None
    let mutable _error_y: ErrorY option = None
    let mutable _error_x: ErrorX option = None
    let mutable _marker: Marker option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _r: seq<float> option = None
    let mutable _t: seq<_> option = None
    let mutable _type = Some "bar"

    /// Sets the x coordinates of the bars. If 'x' is linked to an array of strings, then the x coordinates are integers, 0, 1, 2, 3, ..., labeled on the x-axis by the array of strings linked to 'x'. If 'y' is not set, the bars are plotted horizontally, with their length determined by the array linked to 'x'.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the y coordinates of the bars. If 'y' is linked to an array of strings, then the y coordinates are integers, 0, 1, 2, 3, ..., labeled on the y-axis by the array of strings linked to 'y'. If 'x' is not set, the bars are plotted vertically, with their length determined by the array linked to 'y'.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Sets the orientation of the bars. If set to 'v', the length of each bar will run vertically. If set to 'h', the length of each bar will run horizontally
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// The text elements associated with each bar in this trace. The entries in 'text' will appear on hover only, in a text box located at the top of each bar.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Links a dictionary describing the vertical error bars (i.e. along the y-axis) that can be drawn from bar tops.
    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    /// Links a dictionary describing the horizontal error bars (i.e. along the x-axis) that can be drawn from bar tops.
    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    /// Links a dictionary containing marker style parameters for this bar trace, for example, the bars' fill color, border width and border color.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Sets the x coordinates of the bars. If 'x' is linked to an array of strings, then the x coordinates are integers, 0, 1, 2, 3, ..., labeled on the x-axis by the array of strings linked to 'x'. If 'y' is not set, the bars are plotted horizontally, with their length determined by the array linked to 'x'.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the y coordinates of the bars. If 'y' is linked to an array of strings, then the y coordinates are integers, 0, 1, 2, 3, ..., labeled on the y-axis by the array of strings linked to 'y'. If 'x' is not set, the bars are plotted vertically, with their length determined by the array linked to 'y'.
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// For Polar charts only. Sets the radial coordinates of the bars in this polar bar trace about the original; that is, the radial extent of each bar.
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// For Polar charts only. Sets the angular coordinates of the bars in this polar bar trace. By default, the angular coordinates are in degrees (0 to 360) where the angles are measured clockwise about the right-hand side of the origin. To change this behavior, modify 'range' in 'angularaxis' or/and 'direction' in 'layout'. If 't' is linked to an array of strings, then the angular coordinates are 0, 360\N, 2*360/N, ... where N is the number of coordinates given labeled by the array of strings linked to 't'.
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type XBins() =

    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: float option = None

    /// Sets the starting point on the x-axis for the first bin.
    member __.start
        with get () = Option.get _start
        and set value = _start <- Some value

    /// Sets the end point on the x-axis for the last bin.
    member __.``end``
        with get () = Option.get _end
        and set value = _end <- Some value

    /// Sets the size (i.e. their width) of each x-axis bin.
    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.ShouldSerializestart() = not _start.IsNone
    member __.ShouldSerializeend() = not _end.IsNone
    member __.ShouldSerializesize() = not _size.IsNone

type YBins() =

    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: float option = None

    /// Sets the starting point on the y-axis for the first bin.
    member __.start
        with get () = Option.get _start
        and set value = _start <- Some value

    /// Sets the end point on the y-axis for the last bin.
    member __.``end``
        with get () = Option.get _end
        and set value = _end <- Some value

    /// Sets the size (i.e. their width) of each y-axis bin.
    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    member __.ShouldSerializestart() = not _start.IsNone
    member __.ShouldSerializeend() = not _end.IsNone
    member __.ShouldSerializesize() = not _size.IsNone

type Histogram() =
    inherit Trace()

    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _histnorm: string option = None
    let mutable _histfunc: string option = None
    let mutable _name: string option = None
    let mutable _orientation: string option = None
    let mutable _autobinx: bool option = None
    let mutable _nbinsx: float option = None
    let mutable _xbins: XBins option = None
    let mutable _autobiny: string option = None
    let mutable _nbinsy: float option = None
    let mutable _ybins: YBins option = None
    let mutable _text: seq<string> option = None
    let mutable _error_y: ErrorY option = None
    let mutable _error_x: ErrorX option = None
    let mutable _marker: Marker option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _type = Some "histogram"

    /// Sets the data sample to be binned (done by Plotly) on the x-axis and plotted as vertical bars.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the data sample to be binned (done by Plotly) on the y-axis and plotted as horizontal bars.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin. If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by the size of the bin interval such that summing the area of all bins will yield 1.
    member __.histnorm
        with get () = Option.get _histnorm
        and set value = _histnorm <- Some value

    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    member __.histfunc
        with get () = Option.get _histfunc
        and set value = _histfunc <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Sets the orientation of the bars. If set to 'v', the length of each bar will run vertically. If set to 'h', the length of each bar will run horizontally
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// Toggle whether or not the x-axis bin parameters are picked automatically by Plotly. Once 'autobinx' is set to FALSE, the x-axis bins parameters can be declared in 'xbins' object.
    member __.autobinx
        with get () = Option.get _autobinx
        and set value = _autobinx <- Some value

    /// Specifies the number of x-axis bins. No need to set 'autobinx' to FALSE for 'nbinsx' to apply.
    member __.nbinsx
        with get () = Option.get _nbinsx
        and set value = _nbinsx <- Some value

    /// Links a dictionary defining the parameters of x-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobinx' is set to FALSE.
    member __.xbins
        with get () = Option.get _xbins
        and set value = _xbins <- Some value

    /// Toggle whether or not the y-axis bin parameters are picked automatically by Plotly. Once 'autobiny' is set to FALSE, the y-axis bins parameters can be declared in 'ybins' object.
    member __.autobiny
        with get () = Option.get _autobiny
        and set value = _autobiny <- Some value

    /// Specifies the number of y-axis bins. No need to set 'autobiny' to FALSE for 'nbinsy' to apply.
    member __.nbinsy
        with get () = Option.get _nbinsy
        and set value = _nbinsy <- Some value

    /// Links a dictionary defining the parameters of y-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobiny' is set to FALSE.
    member __.ybins
        with get () = Option.get _ybins
        and set value = _ybins <- Some value

    /// The text elements associated with each bar in this trace. The entries in 'text' will appear on hover only, in a text box located at the top of each bar.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Links a dictionary describing the vertical error bars (i.e. along the y-axis) that can be drawn from bar tops.
    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    /// Links a dictionary describing the horizontal error bars (i.e. along the x-axis) that can be drawn from bar tops.
    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    /// Links a dictionary containing marker style parameters for this bar trace, for example, the bars' fill color, border width and border color.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Sets the data sample to be binned (done by Plotly) on the x-axis and plotted as vertical bars.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the data sample to be binned (done by Plotly) on the y-axis and plotted as horizontal bars.
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializehistnorm() = not _histnorm.IsNone
    member __.ShouldSerializehistfunc() = not _histfunc.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializeautobinx() = not _autobinx.IsNone
    member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
    member __.ShouldSerializexbins() = not _xbins.IsNone
    member __.ShouldSerializeautobiny() = not _autobiny.IsNone
    member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
    member __.ShouldSerializeybins() = not _ybins.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Box() =
    inherit Trace()

    let mutable _y: _ option = None
    let mutable _x0: float option = None
    let mutable _x: _ option = None
    let mutable _name: string option = None
    let mutable _boxmean: string option = None
    let mutable _boxpoints: string option = None
    let mutable _jitter: float option = None
    let mutable _pointpos: float option = None
    let mutable _whiskerwidth: float option = None
    let mutable _fillcolor: string option = None
    let mutable _marker: Marker option = None
    let mutable _line: Line option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _type = Some "box"

    /// This array is used to define an individual box plot, or, a concatenation of multiple box plots. Statistics from these numbers define the bounds of the box, the length of the whiskers, etc. For details on defining multiple boxes with locations see 'x'. Each box spans from the first quartile to the third. The second quartile is marked by a line inside the box. By default, the whiskers are correspond to box' edges +/- 1.5 times the interquartile range. See also 'boxpoints' for more info
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// The location of this box. When 'y' defines a single box, 'x0' can be used to set where this box is centered on the x-axis. If many boxes are set to appear at the same 'x0' location, they will form a box group.
    member __.x0
        with get () = Option.get _x0
        and set value = _x0 <- Some value

    /// Usually, you do not need to set this value as plotly will handle box locations for you. However this allows you to have fine control over the location data for the box. Unlike making a bar, a box plot is made of many y values. Therefore, to give location data to the values you place in 'y', the length of 'x' must equal the length of 'y'. when making multiple box plots, you can concatenate the data sets for each box into a single 'y' array. then, the entries in 'x' define which box plot each entry in 'y' belongs to. When making a single box plot, you must set each entry in 'x' to the same value, see 'x0' for a more practical way to handle this case. If you don't include 'x', the box will simply be assigned a location.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Choose between add-on features for this box trace. If TRUE then the mean of the data linked to 'y' is shown as a dashed line in the box. If 'sd', then the standard deviation is also shown. If FALSE (the default), then no line are shown.
    member __.boxmean
        with get () = Option.get _boxmean
        and set value = _boxmean <- Some value

    /// Choose between boxpoints options for this box trace. If 'outliers' (the default), then only the points lying outside the box' whiskers (more info in 'y') are shown. If 'all', then all data points linked 'y' are shown. If 'suspectedoutliers', then outliers points are shown and points either less than 4*Q1-3*Q3 or greater than 4*Q3-3*Q1 are highlighted (with 'outliercolor' in Marker). If FALSE, then only the boxes are shown and the whiskers correspond to the minimum and maximum value linked to 'y'.
    member __.boxpoints
        with get () = Option.get _boxpoints
        and set value = _boxpoints <- Some value

    /// Sets the width of the jitter in the boxpoints scatter in this trace. Has an no effect if 'boxpoints' is set to FALSE. If 0, then the boxpoints are aligned vertically. If 1 then the boxpoints are placed in a random horizontal jitter of width equal to the width of the boxes.
    member __.jitter
        with get () = Option.get _jitter
        and set value = _jitter <- Some value

    /// Sets the horizontal position of the boxpoints in relation to the boxes in this trace. Has an no effect if 'boxpoints' is set to FALSE. If 0, then the boxpoints are placed over the center of each box. If 1 (-1), then the boxpoints are placed on the right (left) each box border. If 2 (-2), then the boxpoints are  placed 1 one box width to right (left) of each box. 
    member __.pointpos
        with get () = Option.get _pointpos
        and set value = _pointpos <- Some value

    /// Sets the width of the whisker of the box relative to the box' width (in normalized coordinates, e.g. if 'whiskerwidth' set 1, then the whiskers are as wide as the box.
    member __.whiskerwidth
        with get () = Option.get _whiskerwidth
        and set value = _whiskerwidth <- Some value

    /// Sets the color of the box interior.
    member __.fillcolor
        with get () = Option.get _fillcolor
        and set value = _fillcolor <- Some value

    /// Links a dictionary containing marker style parameters for this the boxpoints of box trace. Has an effect only 'boxpoints' is set to 'outliers', 'suspectedoutliers' or 'all'.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Links a dictionary containing line parameters for the border of this box trace (including the whiskers).
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Usually, you do not need to set this value as plotly will handle box locations for you. However this allows you to have fine control over the location data for the box. Unlike making a bar, a box plot is made of many y values. Therefore, to give location data to the values you place in 'y', the length of 'x' must equal the length of 'y'. when making multiple box plots, you can concatenate the data sets for each box into a single 'y' array. then, the entries in 'x' define which box plot each entry in 'y' belongs to. When making a single box plot, you must set each entry in 'x' to the same value, see 'x0' for a more practical way to handle this case. If you don't include 'x', the box will simply be assigned a location.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// This array is used to define an individual box plot, or, a concatenation of multiple box plots. Statistics from these numbers define the bounds of the box, the length of the whiskers, etc. For details on defining multiple boxes with locations see 'x'. Each box spans from the first quartile to the third. The second quartile is marked by a line inside the box. By default, the whiskers are correspond to box' edges +/- 1.5 times the interquartile range. See also 'boxpoints' for more info
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializex0() = not _x0.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeboxmean() = not _boxmean.IsNone
    member __.ShouldSerializeboxpoints() = not _boxpoints.IsNone
    member __.ShouldSerializejitter() = not _jitter.IsNone
    member __.ShouldSerializepointpos() = not _pointpos.IsNone
    member __.ShouldSerializewhiskerwidth() = not _whiskerwidth.IsNone
    member __.ShouldSerializefillcolor() = not _fillcolor.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Colorbar() =

    let mutable _title: string option = None
    let mutable _titleside: string option = None
    let mutable _titlefont: Font option = None
    let mutable _thickness: float option = None
    let mutable _thicknessmode: string option = None
    let mutable _len: float option = None
    let mutable _lenmode: string option = None
    let mutable _autotick: string option = None
    let mutable _nticks: float option = None
    let mutable _ticks: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tick0: float option = None
    let mutable _dtick: float option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _tickangle: float option = None
    let mutable _tickfont: Font option = None
    let mutable _showexponent: string option = None
    let mutable _exponentformat: string option = None
    let mutable _showtickprefix: string option = None
    let mutable _tickprefix: string option = None
    let mutable _showticksuffix: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _x: float option = None
    let mutable _y: float option = None
    let mutable _xanchor: string option = None
    let mutable _yanchor: string option = None
    let mutable _bgcolor: string option = None
    let mutable _outlinecolor: string option = None
    let mutable _outlinewidth: float option = None
    let mutable _bordercolor: string option = None
    let mutable _borderwidth: float option = None
    let mutable _xpad: float option = None
    let mutable _ypad: float option = None

    /// The title of the colorbar.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    /// Location of colorbar title with respect to the colorbar.
    member __.titleside
        with get () = Option.get _titleside
        and set value = _titleside <- Some value

    /// Links a dictionary describing the font settings of the colorbar title.
    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Sets the thickness of the line surrounding the colorbar.
    member __.thickness
        with get () = Option.get _thickness
        and set value = _thickness <- Some value

    /// Sets thickness unit mode.
    member __.thicknessmode
        with get () = Option.get _thicknessmode
        and set value = _thicknessmode <- Some value

    /// Sets the length of the colorbar.
    member __.len
        with get () = Option.get _len
        and set value = _len <- Some value

    /// Sets length unit mode.
    member __.lenmode
        with get () = Option.get _lenmode
        and set value = _lenmode <- Some value

    /// Toggle whether or not the colorbar ticks parameters are picked automatically by Plotly. Once 'autotick' is set to FALSE, the colorbar ticks parameters can be declared with 'ticks', 'tick0', 'dtick0' and other tick-related key in this colorbar object.
    member __.autotick
        with get () = Option.get _autotick
        and set value = _autotick <- Some value

    /// Sets the number of colorbar ticks. No need to set 'autoticks' to FALSE for 'nticks' to apply.
    member __.nticks
        with get () = Option.get _nticks
        and set value = _nticks <- Some value

    /// Sets the format of the ticks on this colorbar. For hidden ticks, link 'ticks' to an empty string.
    member __.ticks
        with get () = Option.get _ticks
        and set value = _ticks <- Some value

    /// Toggle whether or not the colorbar ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Sets the starting point of the ticks of this colorbar.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the distance between ticks on this colorbar.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the length of the tick lines on this colorbar.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the width of the tick lines on this colorbar.
    member __.tickwidth
        with get () = Option.get _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the color of the tick lines on this colorbar.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the angle in degrees of the ticks on this colorbar.
    member __.tickangle
        with get () = Option.get _tickangle
        and set value = _tickangle <- Some value

    /// Links a dictionary defining the parameters of the ticks' font.
    member __.tickfont
        with get () = Option.get _tickfont
        and set value = _tickfont <- Some value

    /// If set to 'all', ALL exponents will be shown appended to their significands. If set to 'first', the first tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'last', the last tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'none', no exponents will appear, only the significands.
    member __.showexponent
        with get () = Option.get _showexponent
        and set value = _showexponent <- Some value

    /// Sets how exponents show up. Here's how the number 1000000000 (1 billion) shows up in each. If set to 'none': 1,000,000,000. If set to 'e': 1e+9. If set to 'E': 1E+9. If set to 'power': 1x10^9 (where the 9 will appear super-scripted). If set to 'SI': 1G. If set to 'B': 1B (useful when referring to currency).
    member __.exponentformat
        with get () = Option.get _exponentformat
        and set value = _exponentformat <- Some value

    /// Same as 'showexponent' but for tick prefixes.
    member __.showtickprefix
        with get () = Option.get _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Tick prefix.
    member __.tickprefix
        with get () = Option.get _tickprefix
        and set value = _tickprefix <- Some value

    /// Same as 'showexponent' but for tick suffixes.
    member __.showticksuffix
        with get () = Option.get _showticksuffix
        and set value = _showticksuffix <- Some value

    /// Tick suffix.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Sets the 'x' position of this colorbar.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the 'y' position of this colorbar.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the horizontal position anchor of this colorbar. That is, bind the position set with the 'x' key to the 'left' or 'center' or 'right' of this colorbar.
    member __.xanchor
        with get () = Option.get _xanchor
        and set value = _xanchor <- Some value

    /// Sets the vertical position anchor of this colorbar. That is, bind the position set with the 'y' key to the 'bottom' or 'middle' or 'top' of this colorbar.
    member __.yanchor
        with get () = Option.get _yanchor
        and set value = _yanchor <- Some value

    /// Sets the background (bg) color of this colorbar.
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    /// The color of the outline surrounding this colorbar.
    member __.outlinecolor
        with get () = Option.get _outlinecolor
        and set value = _outlinecolor <- Some value

    /// Sets the width of the outline surrounding this colorbar.
    member __.outlinewidth
        with get () = Option.get _outlinewidth
        and set value = _outlinewidth <- Some value

    /// Sets the color of the enclosing boarder of this colorbar.
    member __.bordercolor
        with get () = Option.get _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the width of the boarder enclosing this colorbar
    member __.borderwidth
        with get () = Option.get _borderwidth
        and set value = _borderwidth <- Some value

    /// Sets the amount of space (padding) between the colorbar and the enclosing boarder in the x-direction.
    member __.xpad
        with get () = Option.get _xpad
        and set value = _xpad <- Some value

    /// Sets the amount of space (padding) between the colorbar and the enclosing boarder in the y-direction.
    member __.ypad
        with get () = Option.get _ypad
        and set value = _ypad <- Some value

    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitleside() = not _titleside.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializethickness() = not _thickness.IsNone
    member __.ShouldSerializethicknessmode() = not _thicknessmode.IsNone
    member __.ShouldSerializelen() = not _len.IsNone
    member __.ShouldSerializelenmode() = not _lenmode.IsNone
    member __.ShouldSerializeautotick() = not _autotick.IsNone
    member __.ShouldSerializenticks() = not _nticks.IsNone
    member __.ShouldSerializeticks() = not _ticks.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializetickangle() = not _tickangle.IsNone
    member __.ShouldSerializetickfont() = not _tickfont.IsNone
    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
    member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
    member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
    member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializexanchor() = not _xanchor.IsNone
    member __.ShouldSerializeyanchor() = not _yanchor.IsNone
    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializeoutlinecolor() = not _outlinecolor.IsNone
    member __.ShouldSerializeoutlinewidth() = not _outlinewidth.IsNone
    member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
    member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
    member __.ShouldSerializexpad() = not _xpad.IsNone
    member __.ShouldSerializeypad() = not _ypad.IsNone

type Heatmap() =
    inherit Trace()

    let mutable _z: _ option = None
    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _name: string option = None
    let mutable _zauto: string option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _colorscale: _ option = None
    let mutable _reversescale: string option = None
    let mutable _showscale: string option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _zsmooth: string option = None
    let mutable _opacity: float option = None
    let mutable _connectgaps: string option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _text: seq<string> option = None
    let mutable _visible: string option = None
    let mutable _x0: float option = None
    let mutable _dx: float option = None
    let mutable _y0: float option = None
    let mutable _dy: float option = None
    let mutable _xtype: string option = None
    let mutable _ytype: string option = None
    let mutable _type = Some "heatmap"

    /// Sets the data that describes the heatmap mapping. Say the dimensions of the 2d array linked to 'z' has n rows and m columns then the resulting heatmap will show n partitions along the y-axis and m partitions along the x-axis. Therefore, the i-th row/ j-th column cell in the 2d array linked to 'z' is mapped to the i-th partition of the y-axis (starting from the bottom of the plot) and the j-th partition of the x-axis (starting from the left of the plot). 
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets the horizontal coordinates referring to the columns of the 2d array linked to 'z'. If the 'z' is an array of strings, then the x-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'x' array should equal m.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the vertical coordinates referring to the rows of the 2d array linked to 'z'. If strings, the y-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'y' array should equal n.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Toggle whether or not the default values of 'zmax' and 'zmax' can be overwritten.
    member __.zauto
        with get () = Option.get _zauto
        and set value = _zauto <- Some value

    /// Sets the minimum 'z' data value to be resolved by the color scale. Its default value is the minimum of the 'z' data values. This value will be used as the minimum in the color scale normalization. For more info see 'colorscale'.
    member __.zmin
        with get () = Option.get _zmin
        and set value = _zmin <- Some value

    /// Sets the maximum 'z' data value to be resolved by the color scale. Its default value is the maximum of the 'z' data values. This value will be used as the maximum in the color scale normalization. For more info see 'colorscale'.
    member __.zmax
        with get () = Option.get _zmax
        and set value = _zmax <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of z from 0-1, i.e. (z-zmin)/ (zmax-zmin), and the second element of pair corresponds to a color. Use with 'zauto', 'zmin' and 'zmax to fine-tune the map from 'z' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Toggle whether or not the color scale will be reversed.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Toggle whether or not the color scale associated with this mapping will be shown alongside the figure.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

    /// Links a dictionary defining the parameters of the color bar associated with this trace (including its title, length and width).
    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Choose between algorithms ('best' or 'fast') to smooth data linked to 'z'. The default value is FALSE corresponding to no smoothing.
    member __.zsmooth
        with get () = Option.get _zsmooth
        and set value = _zsmooth <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Toggle whether or not missing data points (i.e. '' or NaN) linked to 'x' and/or 'y', are added in by Plotly using linear interpolation.
    member __.connectgaps
        with get () = Option.get _connectgaps
        and set value = _connectgaps <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// The value of 'text' must be a 2d array corresponding to the value associated with 'z'.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// The location of the first coordinate of the x-axis. Use with 'dx' an alternative to an 'x' array. Has no effect if 'x' is set.
    member __.x0
        with get () = Option.get _x0
        and set value = _x0 <- Some value

    /// Spacing between x-axis coordinates. Use with 'x0' an alternative to an 'x' array. Has no effect if 'x' is set.
    member __.dx
        with get () = Option.get _dx
        and set value = _dx <- Some value

    /// The location of the first coordinate of the y-axis. Use with 'dy' an alternative to an 'y' array. Has no effect if 'y' is set.
    member __.y0
        with get () = Option.get _y0
        and set value = _y0 <- Some value

    /// Spacing between y-axis coordinates. Use with 'y0' an alternative to an 'y' array. Has no effect if 'y' is set.
    member __.dy
        with get () = Option.get _dy
        and set value = _dy <- Some value

    /// If set to 'scaled' and 'x' is linked to an array, then the horizontal labels are scaled to an array of integers of unit step starting from 0.
    member __.xtype
        with get () = Option.get _xtype
        and set value = _xtype <- Some value

    /// If set to 'scaled' and 'y' is linked to an array, then the vertical labels are scaled to an array of integers of unit step starting from 0.
    member __.ytype
        with get () = Option.get _ytype
        and set value = _ytype <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializex0() = not _x0.IsNone
    member __.ShouldSerializedx() = not _dx.IsNone
    member __.ShouldSerializey0() = not _y0.IsNone
    member __.ShouldSerializedy() = not _dy.IsNone
    member __.ShouldSerializextype() = not _xtype.IsNone
    member __.ShouldSerializeytype() = not _ytype.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Contours() =

    let mutable _showlines: string option = None
    let mutable _start: float option = None
    let mutable _end: float option = None
    let mutable _size: float option = None
    let mutable _coloring: string option = None

    /// Toggle whether or not the contour lines appear on the plot.
    member __.showlines
        with get () = Option.get _showlines
        and set value = _showlines <- Some value

    /// Sets the value of the first contour level.
    member __.start
        with get () = Option.get _start
        and set value = _start <- Some value

    /// Sets the value of the last contour level.
    member __.``end``
        with get () = Option.get _end
        and set value = _end <- Some value

    /// Sets the size of each contour level.
    member __.size
        with get () = Option.get _size
        and set value = _size <- Some value

    /// Choose the coloring method for this contour trace. The default value is 'fill' where coloring is done evenly between each contour line. 'heatmap' colors on a grid point-by-grid point basis. 'lines' colors only the contour lines, each with respect to the color scale. 'none' prints all contour lines with the same color; choose their color in a Line object at the trace level if desired.
    member __.coloring
        with get () = Option.get _coloring
        and set value = _coloring <- Some value

    member __.ShouldSerializeshowlines() = not _showlines.IsNone
    member __.ShouldSerializestart() = not _start.IsNone
    member __.ShouldSerializeend() = not _end.IsNone
    member __.ShouldSerializesize() = not _size.IsNone
    member __.ShouldSerializecoloring() = not _coloring.IsNone

type Contour() =
    inherit Trace()

    let mutable _z: _ option = None
    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _name: string option = None
    let mutable _zauto: string option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _autocontour: string option = None
    let mutable _ncontours: float option = None
    let mutable _contours: Contours option = None
    let mutable _line: Line option = None
    let mutable _colorscale: string option = None
    let mutable _reversescale: string option = None
    let mutable _showscale: bool option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _connectgaps: string option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _x0: float option = None
    let mutable _dx: float option = None
    let mutable _y0: float option = None
    let mutable _dy: float option = None
    let mutable _xtype: string option = None
    let mutable _ytype: string option = None
    let mutable _type = Some "contour"

    /// Sets the data that describes the contour map mapping. Say the dimensions of the 2d array linked to 'z' has n rows and m columns then the resulting contour map will show n partitions along the y-axis and m partitions along the x-axis. Therefore, the i-th row/ j-th column cell in the 2d array linked to 'z' is mapped to the i-th partition of the y-axis (starting from the bottom of the plot) and the j-th partition of the x-axis (starting from the left of the plot). 
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets the horizontal coordinates referring to the columns of the 2d array linked to 'z'. If the 'z' is an array of strings, then the x-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'x' array should equal m.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the vertical coordinates referring to the rows of the 2d array linked to 'z'. If strings, the y-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'y' array should equal n.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Toggle whether or not the default values of 'zmax' and 'zmax' can be overwritten.
    member __.zauto
        with get () = Option.get _zauto
        and set value = _zauto <- Some value

    /// Sets the minimum 'z' data value to be resolved by the color scale. Its default value is the minimum of the 'z' data values. This value will be used as the minimum in the color scale normalization. For more info see 'colorscale'.
    member __.zmin
        with get () = Option.get _zmin
        and set value = _zmin <- Some value

    /// Sets the maximum 'z' data value to be resolved by the color scale. Its default value is the maximum of the 'z' data values. This value will be used as the maximum in the color scale normalization. For more info see 'colorscale'.
    member __.zmax
        with get () = Option.get _zmax
        and set value = _zmax <- Some value

    /// Toggle whether or not the contour parameters are picked automatically by Plotly. If FALSE, declare the contours parameters in 'contours'.
    member __.autocontour
        with get () = Option.get _autocontour
        and set value = _autocontour <- Some value

    /// Specifies the number of contours lines in the contour plot. No need to set 'autocontour' to False for 'ncontours' to apply.
    member __.ncontours
        with get () = Option.get _ncontours
        and set value = _ncontours <- Some value

    /// Links a dictionary defining the parameters of the contours of this trace.
    member __.contours
        with get () = Option.get _contours
        and set value = _contours <- Some value

    /// Links a dictionary containing line parameters for contour lines of this contour trace (including line width, dash, color and smoothing level). Has no an effect if 'showlines' is set to FALSE in 'contours'.
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of z from 0-1, i.e. (z-zmin)/ (zmax-zmin), and the second element of pair corresponds to a color. Use with 'zauto', 'zmin' and 'zmax to fine-tune the map from 'z' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Toggle whether or not the color scale will be reversed.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Toggle whether or not the color scale associated with this mapping will be shown alongside the figure.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

    /// Links a dictionary defining the parameters of the color bar associated with this trace (including its title, length and width).
    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Toggle whether or not missing data points (i.e. '' or NaN) linked to 'x' and/or 'y', are added in by Plotly using linear interpolation.
    member __.connectgaps
        with get () = Option.get _connectgaps
        and set value = _connectgaps <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// The location of the first coordinate of the x-axis. Use with 'dx' an alternative to an 'x' array. Has no effect if 'x' is set.
    member __.x0
        with get () = Option.get _x0
        and set value = _x0 <- Some value

    /// Spacing between x-axis coordinates. Use with 'x0' an alternative to an 'x' array. Has no effect if 'x' is set.
    member __.dx
        with get () = Option.get _dx
        and set value = _dx <- Some value

    /// The location of the first coordinate of the y-axis. Use with 'dy' an alternative to an 'y' array. Has no effect if 'y' is set.
    member __.y0
        with get () = Option.get _y0
        and set value = _y0 <- Some value

    /// Spacing between y-axis coordinates. Use with 'y0' an alternative to an 'y' array. Has no effect if 'y' is set.
    member __.dy
        with get () = Option.get _dy
        and set value = _dy <- Some value

    /// If set to 'scaled' and 'x' is linked to an array, then the horizontal labels are scaled to an array of integers of unit step starting from 0.
    member __.xtype
        with get () = Option.get _xtype
        and set value = _xtype <- Some value

    /// If set to 'scaled' and 'y' is linked to an array, then the vertical labels are scaled to an array of integers of unit step starting from 0.
    member __.ytype
        with get () = Option.get _ytype
        and set value = _ytype <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializeautocontour() = not _autocontour.IsNone
    member __.ShouldSerializencontours() = not _ncontours.IsNone
    member __.ShouldSerializecontours() = not _contours.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializeconnectgaps() = not _connectgaps.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializex0() = not _x0.IsNone
    member __.ShouldSerializedx() = not _dx.IsNone
    member __.ShouldSerializey0() = not _y0.IsNone
    member __.ShouldSerializedy() = not _dy.IsNone
    member __.ShouldSerializextype() = not _xtype.IsNone
    member __.ShouldSerializeytype() = not _ytype.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Histogram2d() =
    inherit Trace()

    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _histnorm: string option = None
    let mutable _histfunc: string option = None
    let mutable _name: string option = None
    let mutable _autobinx: bool option = None
    let mutable _nbinsx: float option = None
    let mutable _xbins: XBins option = None
    let mutable _autobiny: bool option = None
    let mutable _nbinsy: float option = None
    let mutable _ybins: YBins option = None
    let mutable _colorscale: _ option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _zauto: string option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _zsmooth: string option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _type = Some "histogram2d"

    /// Sets the data sample to be binned on the x-axis and whose distribution (computed by Plotly) will correspond to the x-coordinates of this 2D histogram trace.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the data sample to be binned on the y-axis and whose distribution (computed by Plotly) will correspond to the y-coordinates of this 2D histogram trace.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin. If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by the size of the bin interval such that summing the area of all bins will yield 1.
    member __.histnorm
        with get () = Option.get _histnorm
        and set value = _histnorm <- Some value

    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    member __.histfunc
        with get () = Option.get _histfunc
        and set value = _histfunc <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Toggle whether or not the x-axis bin parameters are picked automatically by Plotly. Once 'autobinx' is set to FALSE, the x-axis bins parameters can be declared in 'xbins' object.
    member __.autobinx
        with get () = Option.get _autobinx
        and set value = _autobinx <- Some value

    /// Specifies the number of x-axis bins. No need to set 'autobinx' to FALSE for 'nbinsx' to apply.
    member __.nbinsx
        with get () = Option.get _nbinsx
        and set value = _nbinsx <- Some value

    /// Links a dictionary defining the parameters of x-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobinx' is set to FALSE.
    member __.xbins
        with get () = Option.get _xbins
        and set value = _xbins <- Some value

    /// Toggle whether or not the y-axis bin parameters are picked automatically by Plotly. Once 'autobiny' is set to FALSE, the y-axis bins parameters can be declared in 'ybins' object.
    member __.autobiny
        with get () = Option.get _autobiny
        and set value = _autobiny <- Some value

    /// Specifies the number of y-axis bins. No need to set 'autobiny' to FALSE for 'nbinsy' to apply.
    member __.nbinsy
        with get () = Option.get _nbinsy
        and set value = _nbinsy <- Some value

    /// Links a dictionary defining the parameters of y-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobiny' is set to FALSE.
    member __.ybins
        with get () = Option.get _ybins
        and set value = _ybins <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of z from 0-1, i.e. (z-zmin)/ (zmax-zmin), and the second element of pair corresponds to a color. Use with 'zauto', 'zmin' and 'zmax to fine-tune the map from 'z' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Toggle whether or not the color scale will be reversed.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Toggle whether or not the color scale associated with this mapping will be shown alongside the figure.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

    /// Links a dictionary defining the parameters of the color bar associated with this trace (including its title, length and width).
    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Toggle whether or not the default values of 'zmax' and 'zmax' can be overwritten.
    member __.zauto
        with get () = Option.get _zauto
        and set value = _zauto <- Some value

    /// Sets the minimum 'z' data value to be resolved by the color scale. Its default value is the minimum of the 'z' data values. This value will be used as the minimum in the color scale normalization. For more info see 'colorscale'.
    member __.zmin
        with get () = Option.get _zmin
        and set value = _zmin <- Some value

    /// Sets the maximum 'z' data value to be resolved by the color scale. Its default value is the maximum of the 'z' data values. This value will be used as the maximum in the color scale normalization. For more info see 'colorscale'.
    member __.zmax
        with get () = Option.get _zmax
        and set value = _zmax <- Some value

    /// Choose between algorithms ('best' or 'fast') to smooth data linked to 'z'. The default value is FALSE corresponding to no smoothing.
    member __.zsmooth
        with get () = Option.get _zsmooth
        and set value = _zsmooth <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Sets the data sample to be binned on the x-axis and whose distribution (computed by Plotly) will correspond to the x-coordinates of this 2D histogram trace.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the data sample to be binned on the y-axis and whose distribution (computed by Plotly) will correspond to the y-coordinates of this 2D histogram trace.
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializehistnorm() = not _histnorm.IsNone
    member __.ShouldSerializehistfunc() = not _histfunc.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeautobinx() = not _autobinx.IsNone
    member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
    member __.ShouldSerializexbins() = not _xbins.IsNone
    member __.ShouldSerializeautobiny() = not _autobiny.IsNone
    member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
    member __.ShouldSerializeybins() = not _ybins.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializezsmooth() = not _zsmooth.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Histogram2dContour() =
    inherit Trace()

    let mutable _x: _ option = None
    let mutable _y: _ option = None
    let mutable _histnorm: string option = None
    let mutable _histfunc: string option = None
    let mutable _name: string option = None
    let mutable _autobinx: string option = None
    let mutable _nbinsx: float option = None
    let mutable _xbins: XBins option = None
    let mutable _autobiny: string option = None
    let mutable _nbinsy: float option = None
    let mutable _ybins: YBins option = None
    let mutable _autocontour: string option = None
    let mutable _ncontours: float option = None
    let mutable _contours: Contours option = None
    let mutable _line: Line option = None
    let mutable _colorscale: string option = None
    let mutable _reversescale: bool option = None
    let mutable _showscale: bool option = None
    let mutable _colorbar: Colorbar option = None
    let mutable _zauto: string option = None
    let mutable _zmin: float option = None
    let mutable _zmax: float option = None
    let mutable _opacity: float option = None
    let mutable _xaxis: string option = None
    let mutable _yaxis: string option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _xsrc: string option = None
    let mutable _ysrc: string option = None
    let mutable _type = Some "histogram2dcontour"

    /// Sets the data sample to be binned on the x-axis and whose distribution (computed by Plotly) will correspond to the x-coordinates of this 2D histogram trace.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the data sample to be binned on the y-axis and whose distribution (computed by Plotly) will correspond to the y-coordinates of this 2D histogram trace.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the type of normalization for this histogram trace. By default ('histnorm' set to '') the height of each bar displays the frequency of occurrence, i.e., the number of times this value was found in the corresponding bin. If set to 'percent', the height of each bar displays the percentage of total occurrences found within the corresponding bin. If set to 'probability', the height of each bar displays the probability that an event will fall into the corresponding bin. If set to 'density', the height of each bar is equal to the number of occurrences in a bin divided by the size of the bin interval such that summing the area of all bins will yield the total number of occurrences. If set to 'probability density', the height of each bar is equal to the number of probability that an event will fall into the corresponding bin divided by the size of the bin interval such that summing the area of all bins will yield 1.
    member __.histnorm
        with get () = Option.get _histnorm
        and set value = _histnorm <- Some value

    /// Sets the binning function used for this histogram trace. The default value is 'count' where the histogram values are computed by counting the number of values lying inside each bin. With 'histfunc' set to 'sum', 'avg', 'min' or 'max', the histogram values are computed using the sum, the average, the minimum or the 'maximum' of the values lying inside each bin respectively.
    member __.histfunc
        with get () = Option.get _histfunc
        and set value = _histfunc <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Toggle whether or not the x-axis bin parameters are picked automatically by Plotly. Once 'autobinx' is set to FALSE, the x-axis bins parameters can be declared in 'xbins' object.
    member __.autobinx
        with get () = Option.get _autobinx
        and set value = _autobinx <- Some value

    /// Specifies the number of x-axis bins. No need to set 'autobinx' to FALSE for 'nbinsx' to apply.
    member __.nbinsx
        with get () = Option.get _nbinsx
        and set value = _nbinsx <- Some value

    /// Links a dictionary defining the parameters of x-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobinx' is set to FALSE.
    member __.xbins
        with get () = Option.get _xbins
        and set value = _xbins <- Some value

    /// Toggle whether or not the y-axis bin parameters are picked automatically by Plotly. Once 'autobiny' is set to FALSE, the y-axis bins parameters can be declared in 'ybins' object.
    member __.autobiny
        with get () = Option.get _autobiny
        and set value = _autobiny <- Some value

    /// Specifies the number of y-axis bins. No need to set 'autobiny' to FALSE for 'nbinsy' to apply.
    member __.nbinsy
        with get () = Option.get _nbinsy
        and set value = _nbinsy <- Some value

    /// Links a dictionary defining the parameters of y-axis bins of this trace, for example, the bin width and the bins' starting and  ending value. Has an effect only if 'autobiny' is set to FALSE.
    member __.ybins
        with get () = Option.get _ybins
        and set value = _ybins <- Some value

    /// Toggle whether or not the contour parameters are picked automatically by Plotly. If FALSE, declare the contours parameters in 'contours'.
    member __.autocontour
        with get () = Option.get _autocontour
        and set value = _autocontour <- Some value

    /// Specifies the number of contours lines in the contour plot. No need to set 'autocontour' to False for 'ncontours' to apply.
    member __.ncontours
        with get () = Option.get _ncontours
        and set value = _ncontours <- Some value

    /// Links a dictionary defining the parameters of the contours of this trace.
    member __.contours
        with get () = Option.get _contours
        and set value = _contours <- Some value

    /// Links a dictionary containing line parameters for contour lines of this contour trace (including line width, dash, color and smoothing level). Has no an effect if 'showlines' is set to FALSE in 'contours'.
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of z from 0-1, i.e. (z-zmin)/ (zmax-zmin), and the second element of pair corresponds to a color. Use with 'zauto', 'zmin' and 'zmax to fine-tune the map from 'z' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// Toggle whether or not the color scale will be reversed.
    member __.reversescale
        with get () = Option.get _reversescale
        and set value = _reversescale <- Some value

    /// Toggle whether or not the color scale associated with this mapping will be shown alongside the figure.
    member __.showscale
        with get () = Option.get _showscale
        and set value = _showscale <- Some value

    /// Links a dictionary defining the parameters of the color bar associated with this trace (including its title, length and width).
    member __.colorbar
        with get () = Option.get _colorbar
        and set value = _colorbar <- Some value

    /// Toggle whether or not the default values of 'zmax' and 'zmax' can be overwritten.
    member __.zauto
        with get () = Option.get _zauto
        and set value = _zauto <- Some value

    /// Sets the minimum 'z' data value to be resolved by the color scale. Its default value is the minimum of the 'z' data values. This value will be used as the minimum in the color scale normalization. For more info see 'colorscale'.
    member __.zmin
        with get () = Option.get _zmin
        and set value = _zmin <- Some value

    /// Sets the maximum 'z' data value to be resolved by the color scale. Its default value is the maximum of the 'z' data values. This value will be used as the maximum in the color scale normalization. For more info see 'colorscale'.
    member __.zmax
        with get () = Option.get _zmax
        and set value = _zmax <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// This key determines which x-axis the x-coordinates of this trace will reference in the figure.  Values 'x1' and 'x' reference to 'xaxis' in 'layout', 'x2' references to 'xaxis2' in 'layout', and so on. Note that 'x1' will always refer to 'xaxis' or 'xaxis1' in 'layout', they are the same.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// This key determines which y-axis the y-coordinates of this trace will reference in the figure.  Values 'y1' and 'y' reference to 'yaxis' in 'layout', 'y2' references to 'yaxis2' in 'layout', and so on. Note that 'y1' will always refer to 'yaxis' or 'yaxis1' in 'layout', they are the same.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Sets the data sample to be binned on the x-axis and whose distribution (computed by Plotly) will correspond to the x-coordinates of this 2D histogram trace.
    member __.xsrc
        with get () = Option.get _xsrc
        and set value = _xsrc <- Some value

    /// Sets the data sample to be binned on the y-axis and whose distribution (computed by Plotly) will correspond to the y-coordinates of this 2D histogram trace.
    member __.ysrc
        with get () = Option.get _ysrc
        and set value = _ysrc <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializehistnorm() = not _histnorm.IsNone
    member __.ShouldSerializehistfunc() = not _histfunc.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializeautobinx() = not _autobinx.IsNone
    member __.ShouldSerializenbinsx() = not _nbinsx.IsNone
    member __.ShouldSerializexbins() = not _xbins.IsNone
    member __.ShouldSerializeautobiny() = not _autobiny.IsNone
    member __.ShouldSerializenbinsy() = not _nbinsy.IsNone
    member __.ShouldSerializeybins() = not _ybins.IsNone
    member __.ShouldSerializeautocontour() = not _autocontour.IsNone
    member __.ShouldSerializencontours() = not _ncontours.IsNone
    member __.ShouldSerializecontours() = not _contours.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializereversescale() = not _reversescale.IsNone
    member __.ShouldSerializeshowscale() = not _showscale.IsNone
    member __.ShouldSerializecolorbar() = not _colorbar.IsNone
    member __.ShouldSerializezauto() = not _zauto.IsNone
    member __.ShouldSerializezmin() = not _zmin.IsNone
    member __.ShouldSerializezmax() = not _zmax.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializexsrc() = not _xsrc.IsNone
    member __.ShouldSerializeysrc() = not _ysrc.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type AngularAxis() =

    let mutable _range: float [] option = None
    let mutable _domain: float [] option = None
    let mutable _showline: bool option = None
    let mutable _showticklabels: bool option = None
    let mutable _tickorientation: string option = None
    let mutable _tickcolor: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _endpadding: float option = None
    let mutable _visible: string option = None

    /// Defines the start and end point of this angular-axis. By default, 'range' is set to [0,360]. Has no effect if 't' is linked to an array of strings.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Polar chart subplots are not supported yet. This key has currently no effect.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Toggle whether or not the line bounding this angular-axis will be shown on the figure. If 'showline' is set to TRUE, the bounding line starts from the origin and extends to the edge of radial axis.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Toggle whether or not the angular axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Choose the orientation (from the paper's perspective) of the radial axis tick labels.
    member __.tickorientation
        with get () = Option.get _tickorientation
        and set value = _tickorientation <- Some value

    /// Sets the color of the tick lines on this angular axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the length of the tick lines on this angular axis.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// more info coming soon
    member __.endpadding
        with get () = Option.get _endpadding
        and set value = _endpadding <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializeendpadding() = not _endpadding.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone

type RadialAxis() =

    let mutable _range: float [] option = None
    let mutable _domain: float [] option = None
    let mutable _orientation: float option = None
    let mutable _showline: bool option = None
    let mutable _showticklabels: bool option = None
    let mutable _tickorientation: string option = None
    let mutable _ticklen: float option = None
    let mutable _tickcolor: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _endpadding: float option = None
    let mutable _visible: string option = None

    /// Defines the start and end point of this radial-axis.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Polar chart subplots are not supported yet. This key has currently no effect.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the orientation (an angle with respect to the origin) of the radial axis.
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// Toggle whether or not the line bounding this radial-axis will be shown on the figure.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Toggle whether or not the radial axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Choose the orientation (from the paper perspective) of the radial axis tick labels.
    member __.tickorientation
        with get () = Option.get _tickorientation
        and set value = _tickorientation <- Some value

    /// Sets the length of the tick lines on this radial axis.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the color of the tick lines on this radial axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the length of the tick lines on this radial axis.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// more info coming soon
    member __.endpadding
        with get () = Option.get _endpadding
        and set value = _endpadding <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetickorientation() = not _tickorientation.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializeendpadding() = not _endpadding.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone

type Area() =
    inherit Trace()

    let mutable _r: seq<float> option = None
    let mutable _t: seq<_> option = None
    let mutable _name: string option = None
    let mutable _marker: Marker option = None
    let mutable _showlegend: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _angularaxis: AngularAxis option = None
    let mutable _radialaxis: RadialAxis option = None
    let mutable _type = Some "area"

    /// Sets the radial coordinates of the circle sectors in this polar area trace about the origin; that is, the radial extent of each circle sector.
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// Sets the angular coordinates of the circle sectors in this polar area trace. There are as many sectors as coordinates linked to 't' and 'r'. Each sector is drawn about the coordinates linked to 't', where they spanned symmetrically in both the positive and negative angular directions. The angular extent of each sector is equal to the angular range (360 degree by default) divided by the number of sectors. Note that the sectors are drawn in order; coordinates at the end of the array may overlay the coordinates at the start. By default, the angular coordinates are in degrees (0 to 360) where the angles are measured clockwise about the right-hand side of the origin. To change this behavior, modify 'range' in 'angularaxis' or/and 'direction' in 'layout'. If 't' is linked to an array of strings, then the angular coordinates are 0, 360\N, 2*360/N, ... where N is the number of coordinates given labeled by the array of strings linked to 't'.
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    /// The label associated with this trace. This name will appear in the legend, on hover and in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Links a dictionary containing marker style of the area sectors of this trace, for example the sector fill color and sector boundary line width and sector boundary color.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Toggle whether or not this trace will be labeled in the legend.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Polar chart subplots are not supported yet. Info coming soon
    member __.angularaxis
        with get () = Option.get _angularaxis
        and set value = _angularaxis <- Some value

    /// Polar chart subplots are not supported yet. Info coming soon
    member __.radialaxis
        with get () = Option.get _radialaxis
        and set value = _radialaxis <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializeangularaxis() = not _angularaxis.IsNone
    member __.ShouldSerializeradialaxis() = not _radialaxis.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Error_z() =

    let mutable _type: string option = None
    let mutable _symmetric: string option = None
    let mutable _array: seq<_> option = None
    let mutable _value: float option = None
    let mutable _arrayminus: seq<_> option = None
    let mutable _valueminus: float option = None
    let mutable _color: string option = None
    let mutable _thickness: float option = None
    let mutable _width: float option = None
    let mutable _opacity: float option = None
    let mutable _visible: string option = None

    /// Specify how the 'value' or 'array' key in this error bar will be used to render the bars. Using 'data' will set error bar lengths to the actual numbers specified in 'array'.  Using 'percent' will set bar lengths to the percent of error associated with 'value'. Using 'constant' will set each error bar length to the single value specified in 'value'. Using 'sqrt' will set each error bar length to the square root of the x data at each point ('value' and 'array' do not apply).
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Toggle whether or not error bars are the same length in both directions (positive z and negative z). If not specified, the error bars will be symmetric.
    member __.symmetric
        with get () = Option.get _symmetric
        and set value = _symmetric <- Some value

    /// The array corresponding to the span of the error bars. Has only an effect if 'type' is set to 'data'. Values in the array are plotted relative to the 'z' coordinates. For example, with 'z'=[1,2] and 'array'=[1,2], the error bars will span from z= 0 to 2 and z= 0 to 4 if 'symmetric' is set to TRUE; and from z= 1 to 2 and z= 2 to 4 if 'symmetric' is set to FALSE and 'arrayminus' is empty.
    member __.array
        with get () = Option.get _array
        and set value = _array <- Some value

    /// The value or percentage determining the error bars' span, at all trace coordinates. Has an effect if 'type' is set to 'value' or 'percent'. If 'symmetric' is set to FALSE, this value corresponds to the span above the trace of coordinates. To specify multiple error bar lengths, you should set 'type' to 'data' and use the 'array' key instead.
    member __.value
        with get () = Option.get _value
        and set value = _value <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'array' but corresponding to the span of the error bars below the trace coordinates
    member __.arrayminus
        with get () = Option.get _arrayminus
        and set value = _arrayminus <- Some value

    /// Has an effect only when 'symmetric' is set to FALSE. Same as 'value' but corresponding to the span of the error bars below the trace coordinates
    member __.valueminus
        with get () = Option.get _valueminus
        and set value = _valueminus <- Some value

    /// Sets the color of the error bars.
    member __.color
        with get () = Option.get _color
        and set value = _color <- Some value

    /// Sets the line thickness of the z error bars.
    member __.thickness
        with get () = Option.get _thickness
        and set value = _thickness <- Some value

    /// Sets the width (in pixels) of the cross-bar at both ends of the error bars.
    member __.width
        with get () = Option.get _width
        and set value = _width <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializesymmetric() = not _symmetric.IsNone
    member __.ShouldSerializearray() = not _array.IsNone
    member __.ShouldSerializevalue() = not _value.IsNone
    member __.ShouldSerializearrayminus() = not _arrayminus.IsNone
    member __.ShouldSerializevalueminus() = not _valueminus.IsNone
    member __.ShouldSerializecolor() = not _color.IsNone
    member __.ShouldSerializethickness() = not _thickness.IsNone
    member __.ShouldSerializewidth() = not _width.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone

type Scatter3d() =
    inherit Trace()

    let mutable _x: obj option = None
    let mutable _y: obj option = None
    let mutable _z: obj option = None
    let mutable _mode: string option = None
    let mutable _name: string option = None
    let mutable _text: seq<string> option = None
    let mutable _textfont: Font option = None
    let mutable _error_z: Error_z option = None
    let mutable _error_y: ErrorY option = None
    let mutable _error_x: ErrorX option = None
    let mutable _marker: Marker option = None
    let mutable _line: Line option = None
    let mutable _textposition: string option = None
    let mutable _scene: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _type = Some "scatter3d"

    /// Sets the x coordinates of the points of this 3D scatter trace. If 'x' is linked to an array of strings, then the x coordinates are integers, 0, 1, 2, 3, ..., labeled on the x-axis by the array of strings linked to 'x'.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the y coordinates of the points of this 3D scatter trace. If 'y' is linked to an array of strings, then the y coordinates are integers, 0, 1, 2, 3, ..., labeled on the y-axis by the array of strings linked to 'y'.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the z coordinates of the points of this scatter trace. If 'z' is linked to an array of strings, then the z coordinates are integers, 0, 1, 2, 3, ..., labeled on the z-axis by the array of strings linked to 'z'.
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Plotting mode for this 3D scatter trace. If the mode includes 'text' then the 'text' will appear at the (x,y) points, otherwise it will appear on hover.
    member __.mode
        with get () = Option.get _mode
        and set value = _mode <- Some value

    /// The label associated with this trace. This name will appear in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// The text elements associated with each (x,y,z) pair in this 3D scatter trace. If the scatter 'mode' does not include 'text' then elements linked to 'text' will appear on hover only. In contrast, if 'text' is included in 'mode', the elements in 'text' will be rendered on the plot at the locations specified in part by their corresponding (x,y,z) coordinate pair and the 'textposition' key.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Links a dictionary describing the font style of this scatter3d trace's text elements. Has only an effect if 'mode' is set and includes 'text'."
    member __.textfont
        with get () = Option.get _textfont
        and set value = _textfont <- Some value

    /// Links a dictionary describing the z-axis error bars that can be drawn from the (x,y,z) coordinates of this 3D scatter trace.
    member __.error_z
        with get () = Option.get _error_z
        and set value = _error_z <- Some value

    /// Links a dictionary describing the y-axis error bars that can be drawn from the (x,y,z) coordinates of this 3D scatter trace.
    member __.error_y
        with get () = Option.get _error_y
        and set value = _error_y <- Some value

    /// Links a dictionary describing the x-axis error bars that can be drawn from the (x,y,z) coordinates of this 3D scatter trace.
    member __.error_x
        with get () = Option.get _error_x
        and set value = _error_x <- Some value

    /// Links a dictionary containing marker style parameters for this 3D scatter trace. Has an effect only if 'mode' contains 'markers'.
    member __.marker
        with get () = Option.get _marker
        and set value = _marker <- Some value

    /// Links a dictionary containing line parameters for this 3D scatter trace. Has an effect only if 'mode' contains 'lines'.
    member __.line
        with get () = Option.get _line
        and set value = _line <- Some value

    /// Sets the position of the text elements in the 'text' key with respect to the data points. By default, the text elements are plotted directly at the (x,y,z) coordinates.
    member __.textposition
        with get () = Option.get _textposition
        and set value = _textposition <- Some value

    /// This key determines the scene on which this trace will be plotted in.
    member __.scene
        with get () = Option.get _scene
        and set value = _scene <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializemode() = not _mode.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializetextfont() = not _textfont.IsNone
    member __.ShouldSerializeerror_z() = not _error_z.IsNone
    member __.ShouldSerializeerror_y() = not _error_y.IsNone
    member __.ShouldSerializeerror_x() = not _error_x.IsNone
    member __.ShouldSerializemarker() = not _marker.IsNone
    member __.ShouldSerializeline() = not _line.IsNone
    member __.ShouldSerializetextposition() = not _textposition.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type Surface() =
    inherit Trace()
    let mutable _z: obj option = None
    let mutable _x: obj option = None
    let mutable _y: obj option = None
    let mutable _name: string option = None
    let mutable _colorscale: string option = None
    let mutable _scene: string option = None
    let mutable _stream: Stream option = None
    let mutable _visible: string option = None
    let mutable _type = Some "surface"

    /// Sets the surface coordinates. Say the dimensions of the 2d array linked to 'z' has n rows and m columns then the resulting contour will have n coordinates along the y-axis and m coordinates along the x-axis. Therefore, the i-th row/ j-th column cell in the 2d array linked to 'z' is mapped to the i-th partition of the y-axis and the j-th partition of the x-axis 
    member __.z
        with get () = Option.get _z
        and set value = _z <- Some value

    /// Sets the horizontal coordinates referring to the columns of the 2d array linked to 'z'. If the 'z' is an array of strings, then the x-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'x' array should equal m.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the vertical coordinates referring to the rows of the 2d array linked to 'z'. If strings, the y-labels are spaced evenly. If the dimensions of the 2d array linked to 'z' are (n x m), the length of the 'y' array should equal n.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// The label associated with this trace. This name will appear in the column header in the online spreadsheet.
    member __.name
        with get () = Option.get _name
        and set value = _name <- Some value

    /// Sets and/or defines the color scale for this trace. The string values are pre-defined color scales. For custom color scales, define an array of value-color pairs where, the first element of the pair corresponds to a normalized value of z from 0-1, i.e. (z-zmin)/ (zmax-zmin), and the second element of pair corresponds to a color. Use with 'zauto', 'zmin' and 'zmax to fine-tune the map from 'z' to rendered colors.
    member __.colorscale
        with get () = Option.get _colorscale
        and set value = _colorscale <- Some value

    /// This key determines the scene on which this trace will be plotted in.
    member __.scene
        with get () = Option.get _scene
        and set value = _scene <- Some value

    /// Links a dictionary that initializes this trace as a writable-stream, for use with the streaming API.
    member __.stream
        with get () = Option.get _stream
        and set value = _stream <- Some value

    /// Toggles whether or not this object will be visible on the rendered figure.
    member __.visible
        with get () = Option.get _visible
        and set value = _visible <- Some value

    /// Plotly identifier for this data's trace type. 
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    member __.ShouldSerializez() = not _z.IsNone
    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializename() = not _name.IsNone
    member __.ShouldSerializecolorscale() = not _colorscale.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializestream() = not _stream.IsNone
    member __.ShouldSerializevisible() = not _visible.IsNone
    member __.ShouldSerializetype() = not _type.IsNone

type XAxis() =

    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _range: float [] option = None
    let mutable _domain: float [] option = None
    let mutable _type: string option = None
    let mutable _rangemode: string option = None
    let mutable _autorange: bool option = None
    let mutable _showgrid: bool option = None
    let mutable _zeroline: bool option = None
    let mutable _showline: bool option = None
    let mutable _autotick: string option = None
    let mutable _nticks: float option = None
    let mutable _ticks: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tick0: float option = None
    let mutable _dtick: float option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _tickangle: float option = None
    let mutable _tickfont: Font option = None
    let mutable _exponentformat: string option = None
    let mutable _showexponent: string option = None
    let mutable _showtickprefix: string option = None
    let mutable _tickprefix: string option = None
    let mutable _showticksuffix: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _tickformat: string option = None
    let mutable _hoverformat: string option = None
    let mutable _mirror: string option = None
    let mutable _gridcolor: string option = None
    let mutable _gridwidth: float option = None
    let mutable _zerolinecolor: string option = None
    let mutable _zerolinewidth: float option = None
    let mutable _linecolor: string option = None
    let mutable _linewidth: float option = None
    let mutable _anchor: string option = None
    let mutable _overlaying: string option = None
    let mutable _side: string option = None
    let mutable _position: float option = None
    let mutable _showbackground: string option = None
    let mutable _backgroundcolor: string option = None
    let mutable _showspikes: string option = None
    let mutable _spikesides: string option = None
    let mutable _spikethickness: float option = None

    /// The x-axis title.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    /// Links a dictionary describing the font settings of the x-axis title.
    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Defines the start and end point of this x-axis.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Sets the domain of this x-axis; that is, the available space for this x-axis to live in. Domain coordinates are given in normalized coordinates with respect to the paper.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the format of this axis.
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Choose between Plotly's automated axis generation modes: 'normal' (the default) sets the axis range in relation to the extrema in the data object, 'tozero' extends the axes to x=0 no matter the data plotted and 'nonnegative' sets a non-negative range no matter the data plotted.
    member __.rangemode
        with get () = Option.get _rangemode
        and set value = _rangemode <- Some value

    /// Toggle whether or not the range of this x-axis is automatically picked by Plotly. If 'range' is set, then 'autorange' is set to FALSE automatically. Otherwise, if 'autorange' is set to TRUE (the default behavior), the range of this x-axis can respond to adjustments made in the web GUI automatically. If 'autorange' is set to 'reversed', then this x-axis is drawn in reverse, e.g. in a 2D plot, from right to left instead of from left to right (the default behavior).
    member __.autorange
        with get () = Option.get _autorange
        and set value = _autorange <- Some value

    /// Toggle whether or not this axis features grid lines.
    member __.showgrid
        with get () = Option.get _showgrid
        and set value = _showgrid <- Some value

    /// Toggle whether or not an additional grid line (thicker than the other grid lines, by default) will appear on this axis along x=0.
    member __.zeroline
        with get () = Option.get _zeroline
        and set value = _zeroline <- Some value

    /// Toggle whether or not the line bounding this x-axis will be shown on the figure.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Toggle whether or not the axis ticks parameters are picked automatically by Plotly. Once 'autotick' is set to FALSE, the axis ticks parameters can be declared with 'ticks', 'tick0', 'dtick0' and other tick-related key in this axis object.
    member __.autotick
        with get () = Option.get _autotick
        and set value = _autotick <- Some value

    /// Sets the number of axis ticks. No need to set 'autoticks' to FALSE for 'nticks' to apply.
    member __.nticks
        with get () = Option.get _nticks
        and set value = _nticks <- Some value

    /// Sets the format of the ticks on this axis. For hidden ticks, link 'ticks' to an empty string.
    member __.ticks
        with get () = Option.get _ticks
        and set value = _ticks <- Some value

    /// Toggle whether or not the axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Sets the starting point of the ticks of this axis.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the distance between ticks on this axis.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the length of the tick lines on this axis.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the width of the tick lines on this axis.
    member __.tickwidth
        with get () = Option.get _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the color of the tick lines on this axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the angle in degrees of the ticks on this axis.
    member __.tickangle
        with get () = Option.get _tickangle
        and set value = _tickangle <- Some value

    /// Links a dictionary defining the parameters of the ticks' font.
    member __.tickfont
        with get () = Option.get _tickfont
        and set value = _tickfont <- Some value

    /// Sets how exponents show up. Here's how the number 1000000000 (1 billion) shows up in each. If set to 'none': 1,000,000,000. If set to 'e': 1e+9. If set to 'E': 1E+9. If set to 'power': 1x10^9 (where the 9 will appear super-scripted). If set to 'SI': 1G. If set to 'B': 1B (useful when referring to currency).
    member __.exponentformat
        with get () = Option.get _exponentformat
        and set value = _exponentformat <- Some value

    /// If set to 'all', ALL exponents will be shown appended to their significands. If set to 'first', the first tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'last', the last tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'none', no exponents will appear, only the significands.
    member __.showexponent
        with get () = Option.get _showexponent
        and set value = _showexponent <- Some value

    /// Same as 'showexponent' but for tick prefixes.
    member __.showtickprefix
        with get () = Option.get _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Tick prefix.
    member __.tickprefix
        with get () = Option.get _tickprefix
        and set value = _tickprefix <- Some value

    /// Same as 'showexponent' but for tick suffixes.
    member __.showticksuffix
        with get () = Option.get _showticksuffix
        and set value = _showticksuffix <- Some value

    /// Tick suffix.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Custom tick datetime formatting.
    member __.tickformat
        with get () = Option.get _tickformat
        and set value = _tickformat <- Some value

    /// Custom hover datetime formatting.
    member __.hoverformat
        with get () = Option.get _hoverformat
        and set value = _hoverformat <- Some value

    /// Toggle the axis line and/or ticks across the plots or subplots. If TRUE, mirror the axis line across the primary subplot (i.e. the axis that this axis is anchored to). If 'ticks', mirror the axis line and the ticks. If 'all', mirror the axis line to all subplots containing this axis. If 'allticks', mirror the line and ticks to all subplots containing this axis. If FALSE, don't mirror the axis or the ticks.
    member __.mirror
        with get () = Option.get _mirror
        and set value = _mirror <- Some value

    /// Sets the axis grid color.
    member __.gridcolor
        with get () = Option.get _gridcolor
        and set value = _gridcolor <- Some value

    /// Sets the grid width (in pixels).
    member __.gridwidth
        with get () = Option.get _gridwidth
        and set value = _gridwidth <- Some value

    /// Sets the color of this axis' zeroline.
    member __.zerolinecolor
        with get () = Option.get _zerolinecolor
        and set value = _zerolinecolor <- Some value

    /// Sets the width of this axis' zeroline (in pixels).
    member __.zerolinewidth
        with get () = Option.get _zerolinewidth
        and set value = _zerolinewidth <- Some value

    /// Sets the axis line color.
    member __.linecolor
        with get () = Option.get _linecolor
        and set value = _linecolor <- Some value

    /// Sets the width of the axis line (in pixels).
    member __.linewidth
        with get () = Option.get _linewidth
        and set value = _linewidth <- Some value

    /// Choose whether the position of this x-axis will be anchored to a corresponding y-axis or will be 'free' to appear anywhere in the vertical space of this figure. Has no effect in 3D plots.
    member __.anchor
        with get () = Option.get _anchor
        and set value = _anchor <- Some value

    /// Choose to overlay the data bound to this x-axis on the same plotting area as a corresponding y-axis or choose not overlay other x-the other axis/axes of this figure.Has no effect in 3D plots.
    member __.overlaying
        with get () = Option.get _overlaying
        and set value = _overlaying <- Some value

    /// Sets whether this x-axis sits at the 'bottom' of the plot or at the 'top' of the plot.Has no effect in 3D plots.
    member __.side
        with get () = Option.get _side
        and set value = _side <- Some value

    /// Sets where this x-axis is positioned in the plotting space. For example if 'position' is set to 0.5, then this axis is placed at the exact center of the plotting space. Has an effect only if 'anchor' is set to 'free'.Has no effect in 3D plots.
    member __.position
        with get () = Option.get _position
        and set value = _position <- Some value

    /// Toggle whether or not this x-axis will have a background color. Has an effect only in 3D plots.
    member __.showbackground
        with get () = Option.get _showbackground
        and set value = _showbackground <- Some value

    /// Sets the background color of this x-axis. Has an effect only in 3D plots and if 'showbackground' is set to TRUE.
    member __.backgroundcolor
        with get () = Option.get _backgroundcolor
        and set value = _backgroundcolor <- Some value

    /// Toggle whether or not spikes will link up to this x-axis when hovering over data points. Has an effect only in 3D plots.
    member __.showspikes
        with get () = Option.get _showspikes
        and set value = _showspikes <- Some value

    /// Toggle whether or not the spikes will expand out to the x-axis bounds when hovering over data points. Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikesides
        with get () = Option.get _spikesides
        and set value = _spikesides <- Some value

    /// Sets the thickness (in pixels) of the x-axis spikes.Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikethickness
        with get () = Option.get _spikethickness
        and set value = _spikethickness <- Some value

    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializerangemode() = not _rangemode.IsNone
    member __.ShouldSerializeautorange() = not _autorange.IsNone
    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
    member __.ShouldSerializezeroline() = not _zeroline.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeautotick() = not _autotick.IsNone
    member __.ShouldSerializenticks() = not _nticks.IsNone
    member __.ShouldSerializeticks() = not _ticks.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializetickangle() = not _tickangle.IsNone
    member __.ShouldSerializetickfont() = not _tickfont.IsNone
    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
    member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
    member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
    member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializetickformat() = not _tickformat.IsNone
    member __.ShouldSerializehoverformat() = not _hoverformat.IsNone
    member __.ShouldSerializemirror() = not _mirror.IsNone
    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
    member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
    member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
    member __.ShouldSerializelinecolor() = not _linecolor.IsNone
    member __.ShouldSerializelinewidth() = not _linewidth.IsNone
    member __.ShouldSerializeanchor() = not _anchor.IsNone
    member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
    member __.ShouldSerializeside() = not _side.IsNone
    member __.ShouldSerializeposition() = not _position.IsNone
    member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
    member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
    member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
    member __.ShouldSerializespikesides() = not _spikesides.IsNone
    member __.ShouldSerializespikethickness() = not _spikethickness.IsNone

type YAxis() =

    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _range: float [] option = None
    let mutable _domain: float [] option = None
    let mutable _type: string option = None
    let mutable _rangemode: string option = None
    let mutable _autorange: bool option = None
    let mutable _showgrid: bool option = None
    let mutable _zeroline: bool option = None
    let mutable _showline: bool option = None
    let mutable _autotick: string option = None
    let mutable _nticks: float option = None
    let mutable _ticks: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tick0: float option = None
    let mutable _dtick: float option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _tickangle: float option = None
    let mutable _tickfont: Font option = None
    let mutable _exponentformat: string option = None
    let mutable _showexponent: string option = None
    let mutable _showtickprefix: string option = None
    let mutable _tickprefix: string option = None
    let mutable _showticksuffix: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _tickformat: string option = None
    let mutable _hoverformat: string option = None
    let mutable _mirror: string option = None
    let mutable _gridcolor: string option = None
    let mutable _gridwidth: float option = None
    let mutable _zerolinecolor: string option = None
    let mutable _zerolinewidth: float option = None
    let mutable _linecolor: string option = None
    let mutable _linewidth: float option = None
    let mutable _anchor: string option = None
    let mutable _overlaying: string option = None
    let mutable _side: string option = None
    let mutable _position: float option = None
    let mutable _showbackground: string option = None
    let mutable _backgroundcolor: string option = None
    let mutable _showspikes: string option = None
    let mutable _spikesides: string option = None
    let mutable _spikethickness: float option = None

    /// The y-axis title.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    /// Links a dictionary describing the font settings of the y-axis title.
    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Defines the start and end point of this y-axis.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Sets the domain of this y-axis; that is, the available space for this y-axis to live in. Domain coordinates are given in normalized coordinates with respect to the paper.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the format of this axis.
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Choose between Plotly's automated axis generation modes: 'normal' (the default) sets the axis range in relation to the extrema in the data object, 'tozero' extends the axes to y=0 no matter the data plotted and 'nonnegative' sets a non-negative range no matter the data plotted.
    member __.rangemode
        with get () = Option.get _rangemode
        and set value = _rangemode <- Some value

    /// Toggle whether or not the range of this y-axis is automatically picked by Plotly. If 'range' is set, then 'autorange' is set to FALSE automatically. Otherwise, if 'autorange' is set to TRUE (the default behavior), the range of this y-axis can respond to adjustments made in the web GUI automatically. If 'autorange' is set to 'reversed', then this y-axis is drawn in reverse, e.g. in a 2D plot, from top to bottom instead of from bottom to top (the default behavior).
    member __.autorange
        with get () = Option.get _autorange
        and set value = _autorange <- Some value

    /// Toggle whether or not this axis features grid lines.
    member __.showgrid
        with get () = Option.get _showgrid
        and set value = _showgrid <- Some value

    /// Toggle whether or not an additional grid line (thicker than the other grid lines, by default) will appear on this axis along y=0.
    member __.zeroline
        with get () = Option.get _zeroline
        and set value = _zeroline <- Some value

    /// Toggle whether or not the line bounding this y-axis will be shown on the figure.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Toggle whether or not the axis ticks parameters are picked automatically by Plotly. Once 'autotick' is set to FALSE, the axis ticks parameters can be declared with 'ticks', 'tick0', 'dtick0' and other tick-related key in this axis object.
    member __.autotick
        with get () = Option.get _autotick
        and set value = _autotick <- Some value

    /// Sets the number of axis ticks. No need to set 'autoticks' to FALSE for 'nticks' to apply.
    member __.nticks
        with get () = Option.get _nticks
        and set value = _nticks <- Some value

    /// Sets the format of the ticks on this axis. For hidden ticks, link 'ticks' to an empty string.
    member __.ticks
        with get () = Option.get _ticks
        and set value = _ticks <- Some value

    /// Toggle whether or not the axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Sets the starting point of the ticks of this axis.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the distance between ticks on this axis.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the length of the tick lines on this axis.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the width of the tick lines on this axis.
    member __.tickwidth
        with get () = Option.get _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the color of the tick lines on this axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the angle in degrees of the ticks on this axis.
    member __.tickangle
        with get () = Option.get _tickangle
        and set value = _tickangle <- Some value

    /// Links a dictionary defining the parameters of the ticks' font.
    member __.tickfont
        with get () = Option.get _tickfont
        and set value = _tickfont <- Some value

    /// Sets how exponents show up. Here's how the number 1000000000 (1 billion) shows up in each. If set to 'none': 1,000,000,000. If set to 'e': 1e+9. If set to 'E': 1E+9. If set to 'power': 1x10^9 (where the 9 will appear super-scripted). If set to 'SI': 1G. If set to 'B': 1B (useful when referring to currency).
    member __.exponentformat
        with get () = Option.get _exponentformat
        and set value = _exponentformat <- Some value

    /// If set to 'all', ALL exponents will be shown appended to their significands. If set to 'first', the first tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'last', the last tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'none', no exponents will appear, only the significands.
    member __.showexponent
        with get () = Option.get _showexponent
        and set value = _showexponent <- Some value

    /// Same as 'showexponent' but for tick prefixes.
    member __.showtickprefix
        with get () = Option.get _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Tick prefix.
    member __.tickprefix
        with get () = Option.get _tickprefix
        and set value = _tickprefix <- Some value

    /// Same as 'showexponent' but for tick suffixes.
    member __.showticksuffix
        with get () = Option.get _showticksuffix
        and set value = _showticksuffix <- Some value

    /// Tick suffix.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Custom tick datetime formatting.
    member __.tickformat
        with get () = Option.get _tickformat
        and set value = _tickformat <- Some value

    /// Custom hover datetime formatting.
    member __.hoverformat
        with get () = Option.get _hoverformat
        and set value = _hoverformat <- Some value

    /// Toggle the axis line and/or ticks across the plots or subplots. If TRUE, mirror the axis line across the primary subplot (i.e. the axis that this axis is anchored to). If 'ticks', mirror the axis line and the ticks. If 'all', mirror the axis line to all subplots containing this axis. If 'allticks', mirror the line and ticks to all subplots containing this axis. If FALSE, don't mirror the axis or the ticks.
    member __.mirror
        with get () = Option.get _mirror
        and set value = _mirror <- Some value

    /// Sets the axis grid color.
    member __.gridcolor
        with get () = Option.get _gridcolor
        and set value = _gridcolor <- Some value

    /// Sets the grid width (in pixels).
    member __.gridwidth
        with get () = Option.get _gridwidth
        and set value = _gridwidth <- Some value

    /// Sets the color of this axis' zeroline.
    member __.zerolinecolor
        with get () = Option.get _zerolinecolor
        and set value = _zerolinecolor <- Some value

    /// Sets the width of this axis' zeroline (in pixels).
    member __.zerolinewidth
        with get () = Option.get _zerolinewidth
        and set value = _zerolinewidth <- Some value

    /// Sets the axis line color.
    member __.linecolor
        with get () = Option.get _linecolor
        and set value = _linecolor <- Some value

    /// Sets the width of the axis line (in pixels).
    member __.linewidth
        with get () = Option.get _linewidth
        and set value = _linewidth <- Some value

    /// Choose whether the position of this y-axis will be anchored to a corresponding x-axis or will be 'free' to appear anywhere in the horizontal space of this figure. Has no effect in 3D plots.
    member __.anchor
        with get () = Option.get _anchor
        and set value = _anchor <- Some value

    /// Choose to overlay the data bound to this y-axis on the same plotting area as a corresponding x-axis or choose not overlay other y-the other axis/axes of this figure.Has no effect in 3D plots.
    member __.overlaying
        with get () = Option.get _overlaying
        and set value = _overlaying <- Some value

    /// Sets whether this y-axis sits at the 'left' of the plot or at the 'right' of the plot.Has no effect in 3D plots.
    member __.side
        with get () = Option.get _side
        and set value = _side <- Some value

    /// Sets where this y-axis is positioned in the plotting space. For example if 'position' is set to 0.5, then this axis is placed at the exact center of the plotting space. Has an effect only if 'anchor' is set to 'free'.Has no effect in 3D plots.
    member __.position
        with get () = Option.get _position
        and set value = _position <- Some value

    /// Toggle whether or not this y-axis will have a background color. Has an effect only in 3D plots.
    member __.showbackground
        with get () = Option.get _showbackground
        and set value = _showbackground <- Some value

    /// Sets the background color of this y-axis. Has an effect only in 3D plots and if 'showbackground' is set to TRUE.
    member __.backgroundcolor
        with get () = Option.get _backgroundcolor
        and set value = _backgroundcolor <- Some value

    /// Toggle whether or not spikes will link up to this y-axis when hovering over data points. Has an effect only in 3D plots.
    member __.showspikes
        with get () = Option.get _showspikes
        and set value = _showspikes <- Some value

    /// Toggle whether or not the spikes will expand out to the y-axis bounds when hovering over data points. Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikesides
        with get () = Option.get _spikesides
        and set value = _spikesides <- Some value

    /// Sets the thickness (in pixels) of the y-axis spikes.Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikethickness
        with get () = Option.get _spikethickness
        and set value = _spikethickness <- Some value

    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializerangemode() = not _rangemode.IsNone
    member __.ShouldSerializeautorange() = not _autorange.IsNone
    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
    member __.ShouldSerializezeroline() = not _zeroline.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeautotick() = not _autotick.IsNone
    member __.ShouldSerializenticks() = not _nticks.IsNone
    member __.ShouldSerializeticks() = not _ticks.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializetickangle() = not _tickangle.IsNone
    member __.ShouldSerializetickfont() = not _tickfont.IsNone
    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
    member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
    member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
    member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializetickformat() = not _tickformat.IsNone
    member __.ShouldSerializehoverformat() = not _hoverformat.IsNone
    member __.ShouldSerializemirror() = not _mirror.IsNone
    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
    member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
    member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
    member __.ShouldSerializelinecolor() = not _linecolor.IsNone
    member __.ShouldSerializelinewidth() = not _linewidth.IsNone
    member __.ShouldSerializeanchor() = not _anchor.IsNone
    member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
    member __.ShouldSerializeside() = not _side.IsNone
    member __.ShouldSerializeposition() = not _position.IsNone
    member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
    member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
    member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
    member __.ShouldSerializespikesides() = not _spikesides.IsNone
    member __.ShouldSerializespikethickness() = not _spikethickness.IsNone

type Zaxis() =

    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _range: float [] option = None
    let mutable _domain: float [] option = None
    let mutable _type: string option = None
    let mutable _rangemode: string option = None
    let mutable _autorange: string option = None
    let mutable _showgrid: bool option = None
    let mutable _zeroline: bool option = None
    let mutable _showline: bool option = None
    let mutable _autotick: string option = None
    let mutable _nticks: float option = None
    let mutable _ticks: string option = None
    let mutable _showticklabels: bool option = None
    let mutable _tick0: float option = None
    let mutable _dtick: float option = None
    let mutable _ticklen: float option = None
    let mutable _tickwidth: float option = None
    let mutable _tickcolor: string option = None
    let mutable _tickangle: float option = None
    let mutable _tickfont: Font option = None
    let mutable _exponentformat: string option = None
    let mutable _showexponent: string option = None
    let mutable _showtickprefix: string option = None
    let mutable _tickprefix: string option = None
    let mutable _showticksuffix: string option = None
    let mutable _ticksuffix: string option = None
    let mutable _tickformat: string option = None
    let mutable _hoverformat: string option = None
    let mutable _mirror: string option = None
    let mutable _gridcolor: string option = None
    let mutable _gridwidth: float option = None
    let mutable _zerolinecolor: string option = None
    let mutable _zerolinewidth: float option = None
    let mutable _linecolor: string option = None
    let mutable _linewidth: float option = None
    let mutable _anchor: string option = None
    let mutable _overlaying: string option = None
    let mutable _side: string option = None
    let mutable _position: string option = None
    let mutable _showbackground: string option = None
    let mutable _backgroundcolor: string option = None
    let mutable _showspikes: string option = None
    let mutable _spikesides: string option = None
    let mutable _spikethickness: float option = None

    /// The z-axis title.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    /// Links a dictionary describing the font settings of the z-axis title.
    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Defines the start and end point of this z-axis.
    member __.range
        with get () = Option.get _range
        and set value = _range <- Some value

    /// Sets the domain of this z-axis; that is, the available space for this z-axis to live in. Domain coordinates are given in normalized coordinates with respect to the paper.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the format of this axis.
    member __.``type``
        with get () = Option.get _type
        and set value = _type <- Some value

    /// Choose between Plotly's automated axis generation modes: 'normal' (the default) sets the axis range in relation to the extrema in the data object, 'tozero' extends the axes to z=0 no matter the data plotted and 'nonnegative' sets a non-negative range no matter the data plotted.
    member __.rangemode
        with get () = Option.get _rangemode
        and set value = _rangemode <- Some value

    /// Toggle whether or not the range of this z-axis is automatically picked by Plotly. If 'range' is set, then 'autorange' is set to FALSE automatically. Otherwise, if 'autorange' is set to TRUE (the default behavior), the range of this z-axis can respond to adjustments made in the web GUI automatically. If 'autorange' is set to 'reversed', then this z-axis is drawn in reverse.
    member __.autorange
        with get () = Option.get _autorange
        and set value = _autorange <- Some value

    /// Toggle whether or not this axis features grid lines.
    member __.showgrid
        with get () = Option.get _showgrid
        and set value = _showgrid <- Some value

    /// Toggle whether or not an additional grid line (thicker than the other grid lines, by default) will appear on this axis along z=0.
    member __.zeroline
        with get () = Option.get _zeroline
        and set value = _zeroline <- Some value

    /// Toggle whether or not the line bounding this z-axis will be shown on the figure.
    member __.showline
        with get () = Option.get _showline
        and set value = _showline <- Some value

    /// Toggle whether or not the axis ticks parameters are picked automatically by Plotly. Once 'autotick' is set to FALSE, the axis ticks parameters can be declared with 'ticks', 'tick0', 'dtick0' and other tick-related key in this axis object.
    member __.autotick
        with get () = Option.get _autotick
        and set value = _autotick <- Some value

    /// Sets the number of axis ticks. No need to set 'autoticks' to FALSE for 'nticks' to apply.
    member __.nticks
        with get () = Option.get _nticks
        and set value = _nticks <- Some value

    /// Sets the format of the ticks on this axis. For hidden ticks, link 'ticks' to an empty string.
    member __.ticks
        with get () = Option.get _ticks
        and set value = _ticks <- Some value

    /// Toggle whether or not the axis ticks will feature tick labels.
    member __.showticklabels
        with get () = Option.get _showticklabels
        and set value = _showticklabels <- Some value

    /// Sets the starting point of the ticks of this axis.
    member __.tick0
        with get () = Option.get _tick0
        and set value = _tick0 <- Some value

    /// Sets the distance between ticks on this axis.
    member __.dtick
        with get () = Option.get _dtick
        and set value = _dtick <- Some value

    /// Sets the length of the tick lines on this axis.
    member __.ticklen
        with get () = Option.get _ticklen
        and set value = _ticklen <- Some value

    /// Sets the width of the tick lines on this axis.
    member __.tickwidth
        with get () = Option.get _tickwidth
        and set value = _tickwidth <- Some value

    /// Sets the color of the tick lines on this axis.
    member __.tickcolor
        with get () = Option.get _tickcolor
        and set value = _tickcolor <- Some value

    /// Sets the angle in degrees of the ticks on this axis.
    member __.tickangle
        with get () = Option.get _tickangle
        and set value = _tickangle <- Some value

    /// Links a dictionary defining the parameters of the ticks' font.
    member __.tickfont
        with get () = Option.get _tickfont
        and set value = _tickfont <- Some value

    /// Sets how exponents show up. Here's how the number 1000000000 (1 billion) shows up in each. If set to 'none': 1,000,000,000. If set to 'e': 1e+9. If set to 'E': 1E+9. If set to 'power': 1x10^9 (where the 9 will appear super-scripted). If set to 'SI': 1G. If set to 'B': 1B (useful when referring to currency).
    member __.exponentformat
        with get () = Option.get _exponentformat
        and set value = _exponentformat <- Some value

    /// If set to 'all', ALL exponents will be shown appended to their significands. If set to 'first', the first tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'last', the last tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'none', no exponents will appear, only the significands.
    member __.showexponent
        with get () = Option.get _showexponent
        and set value = _showexponent <- Some value

    /// Same as 'showexponent' but for tick prefixes.
    member __.showtickprefix
        with get () = Option.get _showtickprefix
        and set value = _showtickprefix <- Some value

    /// Tick prefix.
    member __.tickprefix
        with get () = Option.get _tickprefix
        and set value = _tickprefix <- Some value

    /// Same as 'showexponent' but for tick suffixes.
    member __.showticksuffix
        with get () = Option.get _showticksuffix
        and set value = _showticksuffix <- Some value

    /// Tick suffix.
    member __.ticksuffix
        with get () = Option.get _ticksuffix
        and set value = _ticksuffix <- Some value

    /// Custom tick datetime formatting.
    member __.tickformat
        with get () = Option.get _tickformat
        and set value = _tickformat <- Some value

    /// Custom hover datetime formatting.
    member __.hoverformat
        with get () = Option.get _hoverformat
        and set value = _hoverformat <- Some value

    /// Has no effect in 3D plots.
    member __.mirror
        with get () = Option.get _mirror
        and set value = _mirror <- Some value

    /// Sets the axis grid color.
    member __.gridcolor
        with get () = Option.get _gridcolor
        and set value = _gridcolor <- Some value

    /// Sets the grid width (in pixels).
    member __.gridwidth
        with get () = Option.get _gridwidth
        and set value = _gridwidth <- Some value

    /// Sets the color of this axis' zeroline.
    member __.zerolinecolor
        with get () = Option.get _zerolinecolor
        and set value = _zerolinecolor <- Some value

    /// Sets the width of this axis' zeroline (in pixels).
    member __.zerolinewidth
        with get () = Option.get _zerolinewidth
        and set value = _zerolinewidth <- Some value

    /// Sets the axis line color.
    member __.linecolor
        with get () = Option.get _linecolor
        and set value = _linecolor <- Some value

    /// Sets the width of the axis line (in pixels).
    member __.linewidth
        with get () = Option.get _linewidth
        and set value = _linewidth <- Some value

    /// Has no effect in 3D plots.
    member __.anchor
        with get () = Option.get _anchor
        and set value = _anchor <- Some value

    /// Has no effect in 3D plots.
    member __.overlaying
        with get () = Option.get _overlaying
        and set value = _overlaying <- Some value

    /// Has no effect in 3D plots.
    member __.side
        with get () = Option.get _side
        and set value = _side <- Some value

    /// Has no effect in 3D plots.
    member __.position
        with get () = Option.get _position
        and set value = _position <- Some value

    /// Toggle whether or not this z-axis will have a background color. Has an effect only in 3D plots.
    member __.showbackground
        with get () = Option.get _showbackground
        and set value = _showbackground <- Some value

    /// Sets the background color of this z-axis. Has an effect only in 3D plots and if 'showbackground' is set to TRUE.
    member __.backgroundcolor
        with get () = Option.get _backgroundcolor
        and set value = _backgroundcolor <- Some value

    /// Toggle whether or not spikes will link up to this z-axis when hovering over data points. Has an effect only in 3D plots.
    member __.showspikes
        with get () = Option.get _showspikes
        and set value = _showspikes <- Some value

    /// Toggle whether or not the spikes will expand out to the z-axis bounds when hovering over data points. Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikesides
        with get () = Option.get _spikesides
        and set value = _spikesides <- Some value

    /// Sets the thickness (in pixels) of the z-axis spikes.Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
    member __.spikethickness
        with get () = Option.get _spikethickness
        and set value = _spikethickness <- Some value

    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializerange() = not _range.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializetype() = not _type.IsNone
    member __.ShouldSerializerangemode() = not _rangemode.IsNone
    member __.ShouldSerializeautorange() = not _autorange.IsNone
    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
    member __.ShouldSerializezeroline() = not _zeroline.IsNone
    member __.ShouldSerializeshowline() = not _showline.IsNone
    member __.ShouldSerializeautotick() = not _autotick.IsNone
    member __.ShouldSerializenticks() = not _nticks.IsNone
    member __.ShouldSerializeticks() = not _ticks.IsNone
    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
    member __.ShouldSerializetick0() = not _tick0.IsNone
    member __.ShouldSerializedtick() = not _dtick.IsNone
    member __.ShouldSerializeticklen() = not _ticklen.IsNone
    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
    member __.ShouldSerializetickangle() = not _tickangle.IsNone
    member __.ShouldSerializetickfont() = not _tickfont.IsNone
    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
    member __.ShouldSerializeshowtickprefix() = not _showtickprefix.IsNone
    member __.ShouldSerializetickprefix() = not _tickprefix.IsNone
    member __.ShouldSerializeshowticksuffix() = not _showticksuffix.IsNone
    member __.ShouldSerializeticksuffix() = not _ticksuffix.IsNone
    member __.ShouldSerializetickformat() = not _tickformat.IsNone
    member __.ShouldSerializehoverformat() = not _hoverformat.IsNone
    member __.ShouldSerializemirror() = not _mirror.IsNone
    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
    member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
    member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
    member __.ShouldSerializelinecolor() = not _linecolor.IsNone
    member __.ShouldSerializelinewidth() = not _linewidth.IsNone
    member __.ShouldSerializeanchor() = not _anchor.IsNone
    member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
    member __.ShouldSerializeside() = not _side.IsNone
    member __.ShouldSerializeposition() = not _position.IsNone
    member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
    member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
    member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
    member __.ShouldSerializespikesides() = not _spikesides.IsNone
    member __.ShouldSerializespikethickness() = not _spikethickness.IsNone

type Scene() =

    let mutable _xaxis: XAxis option = None
    let mutable _yaxis: YAxis option = None
    let mutable _zaxis: Zaxis option = None
    let mutable _cameraposition: float [] [] option = None
    let mutable _domain: string option option = None
    let mutable _bgcolor: string option = None

    /// Links a dictionary describing an x-axis of a particular 3D scene.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// Links a dictionary describing an y-axis of a particular 3D scene.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Links a dictionary describing an z-axis of a particular 3D scene.
    member __.zaxis
        with get () = Option.get _zaxis
        and set value = _zaxis <- Some value

    /// Sets the camera position with respect to the scene. The first entry (a array of length 4) sets the angular position of the camera. The second entry (a array of length 3) sets the (x,y,z) translation of the camera. The third entry (a scalar) sets zoom of the camera.
    member __.cameraposition
        with get () = Option.get _cameraposition
        and set value = _cameraposition <- Some value

    /// Sets the x-y domain of this scene on the plotting surface.
    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// Sets the background (bg) color of this scene (i.e. of the plotting surface and the margins).
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializezaxis() = not _zaxis.IsNone
    member __.ShouldSerializecameraposition() = not _cameraposition.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone

type Legend() =

    let mutable _x: float option = None
    let mutable _y: float option = None
    let mutable _traceorder: string option = None
    let mutable _font: Font option = None
    let mutable _bgcolor: string option = None
    let mutable _bordercolor: string option = None
    let mutable _borderwidth: float option = None
    let mutable _xref: string option = None
    let mutable _yref: string option = None
    let mutable _xanchor: string option = None
    let mutable _yanchor: string option = None

    /// Sets the 'x' position of this legend. Use in conjunction with 'xref' and 'xanchor' to fine-tune the location of this legend.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the 'y' position of this legend. Use in conjunction with 'yref' and 'yanchor' to fine-tune the location of this legend.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Trace order is set by the order of trace in the data dictionary. The 'traceorder' key sets whether the legend labels are shown from first-to-last trace ('normal') or from last-to-first ('reversed').
    member __.traceorder
        with get () = Option.get _traceorder
        and set value = _traceorder <- Some value

    /// Links a dictionary describing the font settings within the legend.
    member __.font
        with get () = Option.get _font
        and set value = _font <- Some value

    /// Sets the background (bg) color of the legend.
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    /// Sets the enclosing border color for the legend.
    member __.bordercolor
        with get () = Option.get _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the width of the border enclosing for the legend.
    member __.borderwidth
        with get () = Option.get _borderwidth
        and set value = _borderwidth <- Some value

    /// Sets the x coordinate system which this object refers to. If you reference an axis, e.g., 'x2', the object will move with pan-and-zoom to stay fixed to this point. If you reference the 'paper', it remains fixed regardless of pan-and-zoom. In other words, if set to 'paper', the 'x' location refers to the distance from the left side of the plotting area in normalized coordinates where 0 is 'left' and 1 is 'right'. If set to refer to an xaxis' , e.g., 'x1', 'x2', 'x3', etc., the 'x' location will refer to the location in terms of this axis.
    member __.xref
        with get () = Option.get _xref
        and set value = _xref <- Some value

    /// Sets the y coordinate system which this object refers to. If you reference an axis, e.g., 'y2', the object will move with pan-and-zoom to stay fixed to this point. If you reference the 'paper', it remains fixed regardless of pan-and-zoom. In other words, if set to 'paper', the 'y' location refers to the distance from the left side of the plotting area in normalized coordinates where 0 is 'bottom' and 1 is 'top'. If set to refer to an yaxis' , e.g., 'y1', 'y2', 'y3', etc., the 'y' location will refer to the location in terms of this axis.
    member __.yref
        with get () = Option.get _yref
        and set value = _yref <- Some value

    /// Sets the horizontal position anchor of this legend. That is, bind the position set with the 'x' key to the 'left' or 'center' or 'right' of this legend. For example, if 'x' is set to 1, 'xref' to 'paper', and 'xanchor' to 'right', the right-most portion of this object will line up with the right-most edge of the plotting area.
    member __.xanchor
        with get () = Option.get _xanchor
        and set value = _xanchor <- Some value

    /// Sets the vertical position anchor of this legend. That is, bind the position set with the 'y' key to the 'bottom' or 'middle' or 'top' of this legend. For example, if 'y' is set to 1, 'yref' to 'paper', and 'yanchor' to 'top', the top-most portion of this object will line up with the top-most edge of the plotting area.
    member __.yanchor
        with get () = Option.get _yanchor
        and set value = _yanchor <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializetraceorder() = not _traceorder.IsNone
    member __.ShouldSerializefont() = not _font.IsNone
    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
    member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
    member __.ShouldSerializexref() = not _xref.IsNone
    member __.ShouldSerializeyref() = not _yref.IsNone
    member __.ShouldSerializexanchor() = not _xanchor.IsNone
    member __.ShouldSerializeyanchor() = not _yanchor.IsNone

type Annotation() =

    let mutable _x: float option = None
    let mutable _y: float option = None
    let mutable _xref: string option = None
    let mutable _yref: string option = None
    let mutable _text: string option = None
    let mutable _showarrow: bool option = None
    let mutable _font: Font option = None
    let mutable _xanchor: string option = None
    let mutable _yanchor: string option = None
    let mutable _align: string option = None
    let mutable _arrowhead: string option = None
    let mutable _arrowsize: float option = None
    let mutable _arrowwidth: float option = None
    let mutable _arrowcolor: string option = None
    let mutable _ax: float option = None
    let mutable _ay: float option = None
    let mutable _textangle: float option = None
    let mutable _bordercolor: string option = None
    let mutable _borderwidth: float option = None
    let mutable _borderpad: float option = None
    let mutable _bgcolor: string option = None
    let mutable _opacity: float option = None

    /// Sets the 'x' position of this annotation. Use in conjunction with 'xref' and 'xanchor' to fine-tune the location of this annotation.
    member __.x
        with get () = Option.get _x
        and set value = _x <- Some value

    /// Sets the 'y' position of this annotation. Use in conjunction with 'yref' and 'yanchor' to fine-tune the location of this annotation.
    member __.y
        with get () = Option.get _y
        and set value = _y <- Some value

    /// Sets the x coordinate system which this object refers to. If you reference an axis, e.g., 'x2', the object will move with pan-and-zoom to stay fixed to this point. If you reference the 'paper', it remains fixed regardless of pan-and-zoom. In other words, if set to 'paper', the 'x' location refers to the distance from the left side of the plotting area in normalized coordinates where 0 is 'left' and 1 is 'right'. If set to refer to an xaxis' , e.g., 'x1', 'x2', 'x3', etc., the 'x' location will refer to the location in terms of this axis.
    member __.xref
        with get () = Option.get _xref
        and set value = _xref <- Some value

    /// Sets the y coordinate system which this object refers to. If you reference an axis, e.g., 'y2', the object will move with pan-and-zoom to stay fixed to this point. If you reference the 'paper', it remains fixed regardless of pan-and-zoom. In other words, if set to 'paper', the 'y' location refers to the distance from the left side of the plotting area in normalized coordinates where 0 is 'bottom' and 1 is 'top'. If set to refer to an yaxis' , e.g., 'y1', 'y2', 'y3', etc., the 'y' location will refer to the location in terms of this axis.
    member __.yref
        with get () = Option.get _yref
        and set value = _yref <- Some value

    /// The text associated with this annotation. Plotly uses a subset of HTML tags to do things like newline (<br>), bold (<b></b>), italics (<i></i>), hyperlinks (<a href='...'></a>). Tags <em>, <sup>, <sub>, <span> are also supported.
    member __.text
        with get () = Option.get _text
        and set value = _text <- Some value

    /// Toggle whether or not the arrow associated with this annotation with be shown. If FALSE, then the text linked to 'text' lines up with the 'x', 'y' coordinates'. If TRUE (the default), then 'text' is placed near the arrow's tail.
    member __.showarrow
        with get () = Option.get _showarrow
        and set value = _showarrow <- Some value

    /// Links a dictionary describing the font settings within this annotation.
    member __.font
        with get () = Option.get _font
        and set value = _font <- Some value

    /// Sets the horizontal position anchor of this annotation. That is, bind the position set with the 'x' key to the 'left' or 'center' or 'right' of this annotation. For example, if 'x' is set to 1, 'xref' to 'paper', and 'xanchor' to 'right', the right-most portion of this object will line up with the right-most edge of the plotting area.
    member __.xanchor
        with get () = Option.get _xanchor
        and set value = _xanchor <- Some value

    /// Sets the vertical position anchor of this annotation. That is, bind the position set with the 'y' key to the 'bottom' or 'middle' or 'top' of this annotation. For example, if 'y' is set to 1, 'yref' to 'paper', and 'yanchor' to 'top', the top-most portion of this object will line up with the top-most edge of the plotting area.
    member __.yanchor
        with get () = Option.get _yanchor
        and set value = _yanchor <- Some value

    /// Sets the vertical alignment of the text in the annotation with respect to the set 'x', 'y' position. Has only an effect if the text linked to 'text' spans more two or more lines (using <br> HTML one or more tags).
    member __.align
        with get () = Option.get _align
        and set value = _align <- Some value

    /// Sets the arrowhead style. Has an effect only if 'showarrow' is set to True.
    member __.arrowhead
        with get () = Option.get _arrowhead
        and set value = _arrowhead <- Some value

    /// Scales the arrowhead's size. Has an effect only if 'showarrow' is set to TRUE.
    member __.arrowsize
        with get () = Option.get _arrowsize
        and set value = _arrowsize <- Some value

    /// Sets the arrowhead's width (in pixels). Has an effect only if 'showarrow' is set to TRUE.
    member __.arrowwidth
        with get () = Option.get _arrowwidth
        and set value = _arrowwidth <- Some value

    /// Sets the color of the arrowhead. Has an effect only if 'showarrow' is set to TRUE.
    member __.arrowcolor
        with get () = Option.get _arrowcolor
        and set value = _arrowcolor <- Some value

    /// Position of the annotation text relative to the arrowhead about the x-axis. Has an effect only if 'showarrow' is set to TRUE.
    member __.ax
        with get () = Option.get _ax
        and set value = _ax <- Some value

    /// Position of the annotation text relative to the arrowhead about the y-axis. Has an effect only if 'showarrow' is set to TRUE.
    member __.ay
        with get () = Option.get _ay
        and set value = _ay <- Some value

    /// Sets the angle of the text linked to 'text' with respect to the horizontal.
    member __.textangle
        with get () = Option.get _textangle
        and set value = _textangle <- Some value

    /// The color of the enclosing boarder of this annotation.
    member __.bordercolor
        with get () = Option.get _bordercolor
        and set value = _bordercolor <- Some value

    /// Sets the width of the boarder enclosing this annotation
    member __.borderwidth
        with get () = Option.get _borderwidth
        and set value = _borderwidth <- Some value

    /// The amount of space (padding) between the text and the enclosing boarder.
    member __.borderpad
        with get () = Option.get _borderpad
        and set value = _borderpad <- Some value

    /// Sets the background (bg) color of this annotation.
    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    /// Sets the opacity, or transparency, of the entire object, also known as the alpha channel of colors. If the object's color is given in terms of 'rgba' color model, 'opacity' is redundant.
    member __.opacity
        with get () = Option.get _opacity
        and set value = _opacity <- Some value

    member __.ShouldSerializex() = not _x.IsNone
    member __.ShouldSerializey() = not _y.IsNone
    member __.ShouldSerializexref() = not _xref.IsNone
    member __.ShouldSerializeyref() = not _yref.IsNone
    member __.ShouldSerializetext() = not _text.IsNone
    member __.ShouldSerializeshowarrow() = not _showarrow.IsNone
    member __.ShouldSerializefont() = not _font.IsNone
    member __.ShouldSerializexanchor() = not _xanchor.IsNone
    member __.ShouldSerializeyanchor() = not _yanchor.IsNone
    member __.ShouldSerializealign() = not _align.IsNone
    member __.ShouldSerializearrowhead() = not _arrowhead.IsNone
    member __.ShouldSerializearrowsize() = not _arrowsize.IsNone
    member __.ShouldSerializearrowwidth() = not _arrowwidth.IsNone
    member __.ShouldSerializearrowcolor() = not _arrowcolor.IsNone
    member __.ShouldSerializeax() = not _ax.IsNone
    member __.ShouldSerializeay() = not _ay.IsNone
    member __.ShouldSerializetextangle() = not _textangle.IsNone
    member __.ShouldSerializebordercolor() = not _bordercolor.IsNone
    member __.ShouldSerializeborderwidth() = not _borderwidth.IsNone
    member __.ShouldSerializeborderpad() = not _borderpad.IsNone
    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializeopacity() = not _opacity.IsNone

type Margin() =

    let mutable _l: float option = None
    let mutable _r: float option = None
    let mutable _b: float option = None
    let mutable _t: float option = None
    let mutable _pad: float option = None
    let mutable _autoexpand: string option = None

    /// Sets the left margin size in pixels.
    member __.l
        with get () = Option.get _l
        and set value = _l <- Some value

    /// Sets the right margin size in pixels.
    member __.r
        with get () = Option.get _r
        and set value = _r <- Some value

    /// Sets the bottom margin size in pixels.
    member __.b
        with get () = Option.get _b
        and set value = _b <- Some value

    /// Sets the top margin size in pixels.
    member __.t
        with get () = Option.get _t
        and set value = _t <- Some value

    /// Sets the distance between edge of the plot and the bounding rectangle that encloses the plot (in pixels).
    member __.pad
        with get () = Option.get _pad
        and set value = _pad <- Some value

    /// more info coming soon
    member __.autoexpand
        with get () = Option.get _autoexpand
        and set value = _autoexpand <- Some value

    member __.ShouldSerializel() = not _l.IsNone
    member __.ShouldSerializer() = not _r.IsNone
    member __.ShouldSerializeb() = not _b.IsNone
    member __.ShouldSerializet() = not _t.IsNone
    member __.ShouldSerializepad() = not _pad.IsNone
    member __.ShouldSerializeautoexpand() = not _autoexpand.IsNone

type Layout() =

    let mutable _title: string option = None
    let mutable _titlefont: Font option = None
    let mutable _font: Font option = None
    let mutable _showlegend: bool option = None
    let mutable _autosize: bool option = None
    let mutable _width: float option = None
    let mutable _height: float option = None
    let mutable _xaxis: XAxis option = None
    let mutable _yaxis: YAxis option = None
    
    let mutable _xaxis2: XAxis option = None
    let mutable _yaxis2: YAxis option = None

    let mutable _legend: Legend option = None
    let mutable _annotations: Annotation [] option = None
    let mutable _margin: Margin option = None
    let mutable _paper_bgcolor: string option = None
    let mutable _plot_bgcolor: string option = None
    let mutable _hovermode: string option = None
    let mutable _dragmode: string option = None
    let mutable _separators: string option = None
    let mutable _barmode: string option = None
    let mutable _bargap: float option = None
    let mutable _bargroupgap: float option = None
    let mutable _barnorm: string option = None
    let mutable _boxmode: string option = None
    let mutable _boxgap: float option = None
    let mutable _boxgroupgap: float option = None
    let mutable _radialaxis: RadialAxis option = None
    let mutable _angularaxis: AngularAxis option = None
    let mutable _scene: Scene option = None
    let mutable _direction: string option = None
    let mutable _orientation: float option = None
    let mutable _hidesources: string option = None

    /// The title of the figure.
    member __.title
        with get () = Option.get _title
        and set value = _title <- Some value

    /// Links a dictionary describing the font settings of the figure's title.
    member __.titlefont
        with get () = Option.get _titlefont
        and set value = _titlefont <- Some value

    /// Links a dictionary describing the global font settings for this figure (e.g. all axis titles and labels).
    member __.font
        with get () = Option.get _font
        and set value = _font <- Some value

    /// Toggle whether or not the legend will be shown in this figure.
    member __.showlegend
        with get () = Option.get _showlegend
        and set value = _showlegend <- Some value

    /// Toggle whether or not the dimensions of the figure are automatically picked by Plotly. Plotly picks figure's dimensions as a function of your machine's display resolution. Once 'autosize' is set to FALSE, the figure's dimensions can be set with 'width' and 'height'.
    member __.autosize
        with get () = Option.get _autosize
        and set value = _autosize <- Some value

    /// Sets the width in pixels of the figure you are generating.
    member __.width
        with get () = Option.get _width
        and set value = _width <- Some value

    /// Sets the height in pixels of the figure you are generating.
    member __.height
        with get () = Option.get _height
        and set value = _height <- Some value

    /// Links a dictionary describing an x-axis (i.e. an horizontal axis). The first xaxis object can be entered into 'layout' by linking it to 'xaxis' OR 'xaxis1', both keys are identical to Plotly.  To create references other than x-axes, you need to define them in 'layout' using keys 'xaxis2', 'xaxis3' and so on. Note that in 3D plots, xaxis objects must be linked from a scene object.
    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    /// Links a dictionary describing an y-axis (i.e. an vertical axis). The first yaxis object can be entered into 'layout' by linking it to 'yaxis' OR 'yaxis1', both keys are identical to Plotly.  To create references other than y-axes, you need to define them in 'layout' using keys 'yaxis2', 'yaxis3' and so on. Note that in 3D plots, yaxis objects must be linked from a scene object.
    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    /// Links a dictionary describing an x-axis (i.e. an horizontal axis). The first xaxis object can be entered into 'layout' by linking it to 'xaxis' OR 'xaxis1', both keys are identical to Plotly.  To create references other than x-axes, you need to define them in 'layout' using keys 'xaxis2', 'xaxis3' and so on. Note that in 3D plots, xaxis objects must be linked from a scene object.
    member __.xaxis2
        with get () = Option.get _xaxis2
        and set value = _xaxis2 <- Some value

    /// Links a dictionary describing an y-axis (i.e. an vertical axis). The first yaxis object can be entered into 'layout' by linking it to 'yaxis' OR 'yaxis1', both keys are identical to Plotly.  To create references other than y-axes, you need to define them in 'layout' using keys 'yaxis2', 'yaxis3' and so on. Note that in 3D plots, yaxis objects must be linked from a scene object.
    member __.yaxis2
        with get () = Option.get _yaxis2
        and set value = _yaxis2 <- Some value

    /// Links a dictionary containing the legend parameters for this figure.
    member __.legend
        with get () = Option.get _legend
        and set value = _legend <- Some value

    /// Links an array that contains one or multiple annotation dictionaries.
    member __.annotations
        with get () = Option.get _annotations
        and set value = _annotations <- Some value

    /// Links a dictionary containing the margin parameters for this figure.
    member __.margin
        with get () = Option.get _margin
        and set value = _margin <- Some value

    /// Sets the color of the figure's paper (i.e. area representing the canvas of the figure).
    member __.paper_bgcolor
        with get () = Option.get _paper_bgcolor
        and set value = _paper_bgcolor <- Some value

    /// Sets the background color of the plot (i.e. the area laying inside this figure's axes.
    member __.plot_bgcolor
        with get () = Option.get _plot_bgcolor
        and set value = _plot_bgcolor <- Some value

    /// Sets this figure's behavior when a user hovers over it. When set to 'x', all data sharing the same 'x' coordinate will be shown on screen with corresponding trace labels. When set to 'y' all data sharing the same 'y' coordinates will be shown on the screen with corresponding trace labels. When set to 'closest', information about the data point closest to where the viewer is hovering will appear.
    member __.hovermode
        with get () = Option.get _hovermode
        and set value = _hovermode <- Some value

    /// Sets this figure's behavior when a user preforms a mouse 'drag' in the plot area. When set to 'zoom', a portion of the plot will be highlighted, when the viewer exits the drag, this highlighted section will be zoomed in on. When set to 'pan', data in the plot will move along with the viewers dragging motions. A user can always depress the 'shift' key to access the whatever functionality has not been set as the default. In 3D plots, the default drag mode is 'rotate' which rotates the scene.
    member __.dragmode
        with get () = Option.get _dragmode
        and set value = _dragmode <- Some value

    /// Sets the decimal (the first character) and thousands (the second character) separators to be displayed on this figure's tick labels and hover mode. This is meant for internationalization purposes. For example, if 'separator' is set to ', ', then decimals are separated by commas and thousands by spaces. One may have to set 'exponentformat' to 'none' in the corresponding axis object(s) to see the effects.
    member __.separators
        with get () = Option.get _separators
        and set value = _separators <- Some value

    /// For bar and histogram plots only. This sets how multiple bar objects are plotted together. In other words, this defines how bars at the same location appear on the plot. If set to 'stack' the bars are stacked on top of one another. If set to 'group', the bars are plotted next to one another, centered around the shared location. If set to 'overlay', the bars are simply plotted over one another, you may need to set the opacity to see this.
    member __.barmode
        with get () = Option.get _barmode
        and set value = _barmode <- Some value

    /// For bar and histogram plots only. Sets the gap between bars (or sets of bars) at different locations.
    member __.bargap
        with get () = Option.get _bargap
        and set value = _bargap <- Some value

    /// For bar and histogram plots only. Sets the gap between bars in the same group. That is, when multiple bar objects are plotted and share the same locations, this sets the distance between bars at each location.
    member __.bargroupgap
        with get () = Option.get _bargroupgap
        and set value = _bargroupgap <- Some value

    /// Sets the type of normalization for this bar trace. By default, 'barnorm' is set to '', which results in the height of each bar being displayed. If set to 'fraction', the value of each bar is divided by the sum of the values in the bar group. If set to 'percent', each bar's height is set to the fractional value * 100.
    member __.barnorm
        with get () = Option.get _barnorm
        and set value = _barnorm <- Some value

    /// For box plots only. Sets how groups of box plots appear. If set to 'overlay', a group of boxes will be plotted directly on top of one another at their specified location. If set to 'group', the boxes will be centered around their shared location, but they will not overlap.
    member __.boxmode
        with get () = Option.get _boxmode
        and set value = _boxmode <- Some value

    /// For box plots only. Sets the gap between boxes at different locations (i.e. x-labels). If there are multiple boxes at a single x-label, then this sets the gap between these sets of boxes.For example, if 0, then there is no gap between boxes. If 0.25, then this gap occupies 25% of the available space and the box width (or width of the set of boxes) occupies the remaining 75%.
    member __.boxgap
        with get () = Option.get _boxgap
        and set value = _boxgap <- Some value

    /// For box plots only. Sets the gap between boxes in the same group, where a group is the set of boxes with the same location (i.e. x-label). For example, if 0, then there is no gap between boxes. If 0.25, then this gap occupies 25% of the available space and the box width occupies the remaining 75%.
    member __.boxgroupgap
        with get () = Option.get _boxgroupgap
        and set value = _boxgroupgap <- Some value

    /// Links a dictionary describing the radial axis in a polar plot.
    member __.radialaxis
        with get () = Option.get _radialaxis
        and set value = _radialaxis <- Some value

    /// Links a dictionary describing the angular axis in a polar plot.
    member __.angularaxis
        with get () = Option.get _angularaxis
        and set value = _angularaxis <- Some value

    /// Links a dictionary describing a scene in a 3D plot. The first scene object can be entered into 'layout' by linking it to 'scene' OR 'scene1', both keys are identical to Plotly. Link subsequent scene objects using 'scene2', 'scene3', etc.
    member __.scene
        with get () = Option.get _scene
        and set value = _scene <- Some value

    /// For polar plots only. Sets the direction corresponding to positive angles.
    member __.direction
        with get () = Option.get _direction
        and set value = _direction <- Some value

    /// For polar plots only. Rotates the entire polar by the given angle.
    member __.orientation
        with get () = Option.get _orientation
        and set value = _orientation <- Some value

    /// Toggle whether or not an annotation citing the data source is placed at the bottom-right corner of the figure.This key has an effect only on graphs that have been generated from forked graphs from plot.ly.
    member __.hidesources
        with get () = Option.get _hidesources
        and set value = _hidesources <- Some value

    member __.ShouldSerializetitle() = not _title.IsNone
    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
    member __.ShouldSerializefont() = not _font.IsNone
    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
    member __.ShouldSerializeautosize() = not _autosize.IsNone
    member __.ShouldSerializewidth() = not _width.IsNone
    member __.ShouldSerializeheight() = not _height.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone

    member __.ShouldSerializexaxis2() = not _xaxis2.IsNone
    member __.ShouldSerializeyaxis2() = not _yaxis2.IsNone

    member __.ShouldSerializelegend() = not _legend.IsNone
    member __.ShouldSerializeannotations() = not _annotations.IsNone
    member __.ShouldSerializemargin() = not _margin.IsNone
    member __.ShouldSerializepaper_bgcolor() = not _paper_bgcolor.IsNone
    member __.ShouldSerializeplot_bgcolor() = not _plot_bgcolor.IsNone
    member __.ShouldSerializehovermode() = not _hovermode.IsNone
    member __.ShouldSerializedragmode() = not _dragmode.IsNone
    member __.ShouldSerializeseparators() = not _separators.IsNone
    member __.ShouldSerializebarmode() = not _barmode.IsNone
    member __.ShouldSerializebargap() = not _bargap.IsNone
    member __.ShouldSerializebargroupgap() = not _bargroupgap.IsNone
    member __.ShouldSerializebarnorm() = not _barnorm.IsNone
    member __.ShouldSerializeboxmode() = not _boxmode.IsNone
    member __.ShouldSerializeboxgap() = not _boxgap.IsNone
    member __.ShouldSerializeboxgroupgap() = not _boxgroupgap.IsNone
    member __.ShouldSerializeradialaxis() = not _radialaxis.IsNone
    member __.ShouldSerializeangularaxis() = not _angularaxis.IsNone
    member __.ShouldSerializescene() = not _scene.IsNone
    member __.ShouldSerializedirection() = not _direction.IsNone
    member __.ShouldSerializeorientation() = not _orientation.IsNone
    member __.ShouldSerializehidesources() = not _hidesources.IsNone

//type Figure() =
//
//    let mutable _data: Trace [] option = None
//    let mutable _layout: Layout option = None
//
//    /// An array of one or multiple trace dictionaries to be shown on one plotly figure.
//    member __.data
//        with get () = Option.get _data
//        and set value = _data <- Some value
//
//    /// A dictionary that contains the layout parameters (e.g. information about the axis, global settings and layout information related to the rendering of the figure).
//    member __.layout
//        with get () = Option.get _layout
//        and set value = _layout <- Some value
//
//    member __.ShouldSerializedata() = not _data.IsNone
//    member __.ShouldSerializelayout() = not _layout.IsNone
//
//type Data() = do ()
//
//type Annotations() = do ()
