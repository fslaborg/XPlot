namespace XPlot.Plotly

open Newtonsoft.Json
open HttpClient
open System.Windows
open System.Windows.Controls
//open System

//type value = IConvertible
//
//type Trace() =
//    let mutable xField : seq<string> option = None
//    let mutable yField : seq<value> option = None
//
//    member __.x
//        with get() = xField.Value
//        and set(value) = xField <- Some value
//
//    member __.y
//        with get() = yField.Value
//        and set(value: seq<value>) = yField <- Some value
//
//type Bar() =
//    inherit Trace()
//    
//    member __.``type`` = "bar"       
//
//
open Graph

type Data(traces:seq<Trace>) =

    member __.Json = JsonConvert.SerializeObject traces

type PlotlyResponse =
    {
        filename: string
        url: string
        error: string
        warning: string
        message: string
    }

type Credentials private () =

    static let mutable _username : string option = None
    static let mutable _key : string option = None

    static member username
        with get () = Option.get _username
        and set dir = _username <- Some dir

    static member key
        with get () = Option.get _key
        and set dir = _key <- Some dir

type Plotly private () =

    static member Signin(username, password) =
        Credentials.username <- username
        Credentials.key <- password
//
//type Font() =
//    let mutable _family : string option = None
//    let mutable _size : int option = None
//    let mutable _color : string option = None
//    let mutable _outlinecolor : string option = None
//
//    /// Sets the font family. If linked in the first level of the layout object, set the color of the global font. The default font in Plotly is 'Open Sans, sans-serif'.
//    member __.family
//        with get () = Option.get _family
//        and set dir = _family <- Some dir
//
//    /// Sets the size of text font. If linked directly from 'layout', set the size of the global font.
//    member __.size
//        with get () = Option.get _size
//        and set dir = _size <- Some dir
//
//    /// Sets the color of the text font. If linked directly from 'layout', set the color of the global font.
//    member __.color
//        with get () = Option.get _color
//        and set dir = _color <- Some dir
//
//    member __.outlinecolor
//        with get () = Option.get _outlinecolor
//        and set dir = _outlinecolor <- Some dir
//
//    member __.ShouldSerializefamily() = not _family.IsNone
//    member __.ShouldSerializesize() = not _size.IsNone
//    member __.ShouldSerializecolor() = not _color.IsNone
//    member __.ShouldSerializeoutlinecolor() = not _outlinecolor.IsNone
//  
//type XAxis()=
//
//    let mutable _title: string option = None
//    let mutable _titlefont: Font option = None
//    let mutable _range: float [] option = None
//    let mutable _domain: float [] option = None
//    let mutable _type: string option = None
//    let mutable _rangemode: string option = None
//    let mutable _autorange: string option = None
//    let mutable _showgrid: bool option = None
//    let mutable _zeroline: bool option = None
//    let mutable _showline: bool option = None
//    let mutable _autotick: bool option = None
//    let mutable _nticks: float option = None
//    let mutable _ticks: string option = None
//    let mutable _showticklabels: bool option = None
//    let mutable _tick0: float option = None
//    let mutable _dtick: float option = None
//    let mutable _ticklen: float option = None
//    let mutable _tickwidth: float option = None
//    let mutable _tickcolor: float option = None
//    let mutable _tickangle: float option = None
//    let mutable _tickfont: Font option = None
//    let mutable _exponentformat: string option = None
//    let mutable _showexponent: string option = None
//    let mutable _mirror: string option = None
//    let mutable _gridcolor: string option = None
//    let mutable _gridwidth: float option = None
//    let mutable _zerolinecolor: string option = None
//    let mutable _zerolinewidth: float option = None
//    let mutable _linecolor: string option = None
//    let mutable _linewidth: float option = None
//    let mutable _anchor: string  option = None
//    let mutable _overlaying: string option = None
//    let mutable _side: string option = None
//    let mutable _position: float option = None
//    let mutable _showbackground: bool option = None
//    let mutable _backgroundcolor: bool option = None
//    let mutable _showspikes: bool option = None
//    let mutable _spikesides: bool option = None
//    let mutable _spikethickness: float option = None
//
//    /// The x-axis title.
//    member __.title
//        with get () = Option.get _title
//        and set value = _title <- Some value
//
//    /// Links a dictionary describing the font settings of the x-axis title.
//    member __.titlefont
//        with get () = Option.get _titlefont
//        and set value = _titlefont <- Some value
//
//    /// Defines the start and end point of this x-axis.
//    member __.range
//        with get () = Option.get _range
//        and set value = _range <- Some value
//
//    /// Sets the domain of this x-axis; that is, the available space for this x-axis to live in. Domain coordinates are given in normalized coordinates with respect to the paper.
//    member __.domain
//        with get () = Option.get _domain
//        and set value = _domain <- Some value
//
//    /// Sets the format of this axis.
//    member __.``type``
//        with get () = Option.get _type
//        and set value = _type <- Some value
//
//    /// Choose between Plotly's automated axis generation modes: 'normal' (the default) sets the axis range in relation to the extrema in the data object, 'tozero' extends the axes to x=0 no matter the data plotted and 'nonnegative' sets a non-negative range no matter the data plotted.
//    member __.rangemode
//        with get () = Option.get _rangemode
//        and set value = _rangemode <- Some value
//
//    /// Toggle whether or not the range of this x-axis is automatically picked by Plotly. If 'range' is set, then 'autorange' is set to FALSE automatically. Otherwise, if 'autorange' is set to TRUE (the default behavior), the range of this x-axis can respond to adjustments made in the web GUI automatically. If 'autorange' is set to 'reversed', then this x-axis is drawn in reverse, e.g. in a 2D plot, from right to left instead of from left to right (the default behavior).
//    member __.autorange
//        with get () = Option.get _autorange
//        and set value = _autorange <- Some value
//
//    /// Toggle whether or not this axis features grid lines.
//    member __.showgrid
//        with get () = Option.get _showgrid
//        and set value = _showgrid <- Some value
//
//    /// Toggle whether or not an additional grid line (thicker than the other grid lines, by default) will appear on this axis along x=0.
//    member __.zeroline
//        with get () = Option.get _zeroline
//        and set value = _zeroline <- Some value
//
//    /// Toggle whether or not the line bounding this x-axis will be shown on the figure.
//    member __.showline
//        with get () = Option.get _showline
//        and set value = _showline <- Some value
//
//    /// Toggle whether or not the axis ticks parameters are picked automatically by Plotly. Once 'autotick' is set to FALSE, the axis ticks parameters can be declared with 'ticks', 'tick0', 'dtick0' and other tick-related key in this axis object.
//    member __.autotick
//        with get () = Option.get _autotick
//        and set value = _autotick <- Some value
//
//    /// Sets the number of axis ticks. No need to set 'autoticks' to FALSE for 'nticks' to apply.
//    member __.nticks
//        with get () = Option.get _nticks
//        and set value = _nticks <- Some value
//
//    /// Sets the format of the ticks on this axis. For hidden ticks, link 'ticks' to an empty string.
//    member __.ticks
//        with get () = Option.get _ticks
//        and set value = _ticks <- Some value
//
//    /// Toggle whether or not the axis ticks will feature tick labels.
//    member __.showticklabels
//        with get () = Option.get _showticklabels
//        and set value = _showticklabels <- Some value
//
//    /// Sets the starting point of the ticks of this axis.
//    member __.tick0
//        with get () = Option.get _tick0
//        and set value = _tick0 <- Some value
//
//    /// Sets the distance between ticks on this axis.
//    member __.dtick
//        with get () = Option.get _dtick
//        and set value = _dtick <- Some value
//
//    /// Sets the length of the tick lines on this axis.
//    member __.ticklen
//        with get () = Option.get _ticklen
//        and set value = _ticklen <- Some value
//
//    /// Sets the width of the tick lines on this axis.
//    member __.tickwidth
//        with get () = Option.get _tickwidth
//        and set value = _tickwidth <- Some value
//
//    /// Sets the color of the tick lines on this axis.
//    member __.tickcolor
//        with get () = Option.get _tickcolor
//        and set value = _tickcolor <- Some value
//
//    /// Sets the angle in degrees of the ticks on this axis.
//    member __.tickangle
//        with get () = Option.get _tickangle
//        and set value = _tickangle <- Some value
//
//    /// Links a dictionary defining the parameters of the ticks' font.
//    member __.tickfont
//        with get () = Option.get _tickfont
//        and set value = _tickfont <- Some value
//
//    /// Sets how exponents show up. Here's how the number 1000000000 (1 billion) shows up in each. If set to 'none': 1,000,000,000. If set to 'e': 1e+9. If set to 'E': 1E+9. If set to 'power': 1x10^9 (where the 9 will appear super-scripted). If set to 'SI': 1G. If set to 'B': 1B (useful when referring to currency).
//    member __.exponentformat
//        with get () = Option.get _exponentformat
//        and set value = _exponentformat <- Some value
//
//    /// If set to 'all', ALL exponents will be shown appended to their significands. If set to 'first', the first tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'last', the last tick's exponent will be appended to its significand, however no other exponents will appear--only the significands. If set to 'none', no exponents will appear, only the significands.
//    member __.showexponent
//        with get () = Option.get _showexponent
//        and set value = _showexponent <- Some value
//
//    /// Toggle the axis line and/or ticks across the plots or subplots. If TRUE, mirror the axis line across the primary subplot (i.e. the axis that this axis is anchored to). If 'ticks', mirror the axis line and the ticks. If 'all', mirror the axis line to all subplots containing this axis. If 'allticks', mirror the line and ticks to all subplots containing this axis. If FALSE, don't mirror the axis or the ticks.
//    member __.mirror
//        with get () = Option.get _mirror
//        and set value = _mirror <- Some value
//
//    /// Sets the axis grid color.
//    member __.gridcolor
//        with get () = Option.get _gridcolor
//        and set value = _gridcolor <- Some value
//
//    /// Sets the grid width (in pixels).
//    member __.gridwidth
//        with get () = Option.get _gridwidth
//        and set value = _gridwidth <- Some value
//
//    /// Sets the color of this axis' zeroline.
//    member __.zerolinecolor
//        with get () = Option.get _zerolinecolor
//        and set value = _zerolinecolor <- Some value
//
//    /// Sets the width of this axis' zeroline (in pixels).
//    member __.zerolinewidth
//        with get () = Option.get _zerolinewidth
//        and set value = _zerolinewidth <- Some value
//
//    /// Sets the axis line color.
//    member __.linecolor
//        with get () = Option.get _linecolor
//        and set value = _linecolor <- Some value
//
//    /// Sets the width of the axis line (in pixels).
//    member __.linewidth
//        with get () = Option.get _linewidth
//        and set value = _linewidth <- Some value
//
//    /// Choose whether the position of this x-axis will be anchored to a corresponding y-axis or will be 'free' to appear anywhere in the vertical space of this figure. Has no effect in 3D plots.
//    member __.anchor
//        with get () = Option.get _anchor
//        and set value = _anchor <- Some value
//
//    /// Choose to overlay the data bound to this x-axis on the same plotting area as a corresponding y-axis or choose not overlay other x-the other axis/axes of this figure.Has no effect in 3D plots.
//    member __.overlaying
//        with get () = Option.get _overlaying
//        and set value = _overlaying <- Some value
//
//    /// Sets whether this x-axis sits at the 'bottom' of the plot or at the 'top' of the plot.Has no effect in 3D plots.
//    member __.side
//        with get () = Option.get _side
//        and set value = _side <- Some value
//
//    /// Sets where this x-axis is positioned in the plotting space. For example if 'position' is set to 0.5, then this axis is placed at the exact center of the plotting space. Has an effect only if 'anchor' is set to 'free'.Has no effect in 3D plots.
//    member __.position
//        with get () = Option.get _position
//        and set value = _position <- Some value
//
//    /// Toggle whether or not this x-axis will have a background color. Has an effect only in 3D plots.
//    member __.showbackground
//        with get () = Option.get _showbackground
//        and set value = _showbackground <- Some value
//
//    /// Sets the background color of this x-axis. Has an effect only in 3D plots and if 'showbackground' is set to TRUE.
//    member __.backgroundcolor
//        with get () = Option.get _backgroundcolor
//        and set value = _backgroundcolor <- Some value
//
//    /// Toggle whether or not spikes will link up to this x-axis when hovering over data points. Has an effect only in 3D plots.
//    member __.showspikes
//        with get () = Option.get _showspikes
//        and set value = _showspikes <- Some value
//
//    /// Toggle whether or not the spikes will expand out to the x-axis bounds when hovering over data points. Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
//    member __.spikesides
//        with get () = Option.get _spikesides
//        and set value = _spikesides <- Some value
//
//    /// Sets the thickness (in pixels) of the x-axis spikes.Has an effect only in 3D plots and if 'showspikes' is set to TRUE.
//    member __.spikethickness
//        with get () = Option.get _spikethickness
//        and set value = _spikethickness <- Some value
//
//    member __.ShouldSerializetitle() = not _title.IsNone
//    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
//    member __.ShouldSerializerange() = not _range.IsNone
//    member __.ShouldSerializedomain() = not _domain.IsNone
//    member __.ShouldSerializetype() = not _type.IsNone
//    member __.ShouldSerializerangemode() = not _rangemode.IsNone
//    member __.ShouldSerializeautorange() = not _autorange.IsNone
//    member __.ShouldSerializeshowgrid() = not _showgrid.IsNone
//    member __.ShouldSerializezeroline() = not _zeroline.IsNone
//    member __.ShouldSerializeshowline() = not _showline.IsNone
//    member __.ShouldSerializeautotick() = not _autotick.IsNone
//    member __.ShouldSerializenticks() = not _nticks.IsNone
//    member __.ShouldSerializeticks() = not _ticks.IsNone
//    member __.ShouldSerializeshowticklabels() = not _showticklabels.IsNone
//    member __.ShouldSerializetick0() = not _tick0.IsNone
//    member __.ShouldSerializedtick() = not _dtick.IsNone
//    member __.ShouldSerializeticklen() = not _ticklen.IsNone
//    member __.ShouldSerializetickwidth() = not _tickwidth.IsNone
//    member __.ShouldSerializetickcolor() = not _tickcolor.IsNone
//    member __.ShouldSerializetickangle() = not _tickangle.IsNone
//    member __.ShouldSerializetickfont() = not _tickfont.IsNone
//    member __.ShouldSerializeexponentformat() = not _exponentformat.IsNone
//    member __.ShouldSerializeshowexponent() = not _showexponent.IsNone
//    member __.ShouldSerializemirror() = not _mirror.IsNone
//    member __.ShouldSerializegridcolor() = not _gridcolor.IsNone
//    member __.ShouldSerializegridwidth() = not _gridwidth.IsNone
//    member __.ShouldSerializezerolinecolor() = not _zerolinecolor.IsNone
//    member __.ShouldSerializezerolinewidth() = not _zerolinewidth.IsNone
//    member __.ShouldSerializelinecolor() = not _linecolor.IsNone
//    member __.ShouldSerializelinewidth() = not _linewidth.IsNone
//    member __.ShouldSerializeanchor() = not _anchor.IsNone
//    member __.ShouldSerializeoverlaying() = not _overlaying.IsNone
//    member __.ShouldSerializeside() = not _side.IsNone
//    member __.ShouldSerializeposition() = not _position.IsNone
//    member __.ShouldSerializeshowbackground() = not _showbackground.IsNone
//    member __.ShouldSerializebackgroundcolor() = not _backgroundcolor.IsNone
//    member __.ShouldSerializeshowspikes() = not _showspikes.IsNone
//    member __.ShouldSerializespikesides() = not _spikesides.IsNone
//    member __.ShouldSerializespikethickness() = not _spikethickness.IsNone
//
//
//        
//type Layout() =
//    let mutable _title : string option = None
//    let mutable _titlefont : Font option = None
//    let mutable _font : Font option = None
//    let mutable _showlegend : bool option = None
//    let mutable _autosize : bool option = None
//    let mutable _width : int option = None
//    let mutable _height : int option = None
//    let mutable _xaxis : XAxis option = None
//
//
//
//
//    /// The title of the figure.
//    member __.title
//        with get () = Option.get _title
//        and set dir = _title <- Some dir
//
//    /// Links a dictionary describing the font settings of the figure's title.
//    member __.titlefont
//        with get () = Option.get _titlefont
//        and set dir = _titlefont <- Some dir
//
//    /// Links a dictionary describing the global font settings for this figure (e.g. all axis titles and labels).
//    member __.font
//        with get () = Option.get _font
//        and set dir = _font <- Some dir
//
//    /// Toggle whether or not the legend will be shown in this figure.
//    member __.showlegend
//        with get () = Option.get _showlegend
//        and set dir = _showlegend <- Some dir
//
//    /// Toggle whether or not the dimensions of the figure are automatically picked by Plotly. Plotly picks figure's dimensions as a function of your machine's display resolution. Once 'autosize' is set to FALSE, the figure's dimensions can be set with 'width' and 'height'.
//    member __.autosize
//        with get () = Option.get _autosize
//        and set dir = _autosize <- Some dir
//
//    /// Sets the width in pixels of the figure you are generating.
//    member __.width
//        with get () = Option.get _width
//        and set dir = _width <- Some dir
//
//    /// Sets the height in pixels of the figure you are generating.
//    member __.height
//        with get () = Option.get _height
//        and set dir = _height <- Some dir
//    
//    /// Links a dictionary describing an x-axis (i.e. an horizontal axis). The first xaxis object can be entered into 'layout' by linking it to 'xaxis' OR 'xaxis1', both keys are identical to Plotly.  To create references other than x-axes, you need to define them in 'layout' using keys 'xaxis2', 'xaxis3' and so on. Note that in 3D plots, xaxis objects must be linked from a scene object.
//    member __.xaxis
//        with get () = Option.get _xaxis
//        and set dir = _xaxis <- Some dir
//
//    member __.ShouldSerializetitle() = not _title.IsNone
//    member __.ShouldSerializetitlefont() = not _titlefont.IsNone
//    member __.ShouldSerializefont() = not _font.IsNone
//    member __.ShouldSerializeshowlegend() = not _showlegend.IsNone
//    member __.ShouldSerializeautosize() = not _autosize.IsNone
//    member __.ShouldSerializewidth() = not _width.IsNone
//    member __.ShouldSerializeheight() = not _height.IsNone
//    member __.ShouldSerializexaxis() = not _xaxis.IsNone
//
//
//
//
//
type Kwargs() =
    
    let mutable _filename : string option = None
    let mutable _fileopt : string option = None
    let mutable _style : Trace option = None
    let mutable _traces : seq<int> option = None
    let mutable _layout : Layout option = None

    member __.filename
        with get () = Option.get _filename
        and set dir = _filename <- Some dir

    member __.fileopt
        with get () = Option.get _fileopt
        and set dir = _fileopt <- Some dir

    member __.style
        with get () = Option.get _style
        and set dir = _style <- Some dir

    member __.traces
        with get () = Option.get _traces
        and set dir = _traces <- Some dir

    member __.layout
        with get () = Option.get _layout
        and set dir = _layout <- Some dir

    member __.ShouldSerializefilename() = not _filename.IsNone
    member __.ShouldSerializefileopt() = not _fileopt.IsNone
    member __.ShouldSerializestyle() = not _style.IsNone
    member __.ShouldSerializetraces() = not _traces.IsNone
    member __.ShouldSerializelayout() = not _layout.IsNone

//module ChartWindow =

//    open System
//    open System.Windows.Media.Imaging
//
//    let icon =
//        let uriString = @"pack://application:,,,/XPlot.Plotly;component/XPlot.ico"
//        let iconUri = Uri(uriString, UriKind.RelativeOrAbsolute)
//        BitmapFrame.Create(iconUri)
//
//    let show html =
//            let wnd = Window()
////            wnd.Icon <- icon
//            wnd.Height <- 600.
//            wnd.Width <- 1000.
//            wnd.Topmost <- true
//            wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
//            let browser = new WebBrowser()
//            browser.NavigateToString html
//            wnd.Content <- browser
//            wnd.Show()
//            wnd.Topmost <- false

type Figure(data:Data, ?Layout:Layout) =
    
    let mutable response = None
    let mutable origin = "plot"
    let mutable fileopt = "new"

    member __.Origin
        with get () = origin
        and set(value) = origin <- value

    member __.Fileopt
        with get () = fileopt
        and set(value) = fileopt <- value

    member __.Plot(filename) =
        let kwargs =
            Kwargs(
                filename = filename,
                fileopt = fileopt
            )
        match Layout with
        | None -> ()
        | Some x -> kwargs.layout <- x
        let body =
            [
                "un="
                Credentials.username
                "&key="
                Credentials.key
                "&origin="
                origin
                "&platform=f#&args="
                data.Json
                "&kwargs="
                JsonConvert.SerializeObject kwargs
            ] |> String.concat ""
        let request =  
            createRequest Post "https://plot.ly/clientresp"  
            |> withBody body
        let resp = request |> getResponse
        match resp.EntityBody with
        | None -> failwith "The response body was empty."
        | Some x ->
            let resp =
                JsonConvert.DeserializeObject(x, typeof<PlotlyResponse>)
                :?> PlotlyResponse
            match resp.error with
            | "" ->
                response <- Some resp
                response
            | msg -> failwith msg
//                printfn "%s" msg
//                None

    /// Displays the Figure in a window.
    member __.Show() =
        match response with
        | None -> printfn "Call the Plot member first."
        | Some resp ->
            let html =
                """<html><head></head><body><iframe width="100%" height="100%" frameborder="0" seamless="seamless" scrolling="no" src="""
                + "\""
                + resp.url
                + """.embed?width=900&height=500"></iframe></body></html>"""        
            ChartWindow.show html
//            let wnd = Window()
//    //        wnd.Icon <- icon
//            wnd.Height <- 600.
//            wnd.Width <- 1000.
//            wnd.Topmost <- true
//            wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
//            let browser = new WebBrowser()
//            let html =
//                """<html><head></head><body><iframe width="500" height="500" frameborder="0" seamless="seamless" scrolling="no" src="""
//                + "\""
//                + resp.url
//                + """.embed?width=500&height=500"></iframe></body></html>"""
//            browser.NavigateToString html
//            wnd.Content <- browser
//            wnd.Show()
//            wnd.Topmost <- false