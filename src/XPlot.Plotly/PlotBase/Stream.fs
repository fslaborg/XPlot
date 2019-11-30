namespace XPlot.Plotly

type Stream() =
    let mutable _token: string option = None
    let mutable _maxpoints: float option = None

    /// The stream id number links a data trace on a plot with a stream. See https://plot.ly/settings for more details.
    member __.token
        with get () = Option.defaultValue "" _token
        and set value = _token <- Some value

    /// Sets the maximum number of points to keep on the plots from an incoming stream. If `maxpoints` is set to *50*, only the newest 50 points will be displayed on the plot.
    member __.maxpoints
        with get () = Option.defaultValue 0.0 _maxpoints
        and set value = _maxpoints <- Some value

    member __.ShouldSerializetoken() = _token.IsSome
    member __.ShouldSerializemaxpoints() = _maxpoints.IsSome
