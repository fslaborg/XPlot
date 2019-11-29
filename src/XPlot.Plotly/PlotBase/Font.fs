namespace XPlot.Plotly

type Font() =
    let mutable _family: string option = None
    let mutable _size: float option = None
    let mutable _color: string option = None

    /// HTML font family - the typeface that will be applied by the web browser. The web browser will only be able to apply a font if it is available on the system which it operates. Provide multiple font families, separated by commas, to indicate the preference in which to apply fonts if they aren't available on the system. The plotly service (at https://plot.ly or on-premise) generates images on a server, where only a select number of fonts are installed and supported. These include *Arial*, *Balto*, *Courier New*, *Droid Sans*,, *Droid Serif*, *Droid Sans Mono*, *Gravitas One*, *Old Standard TT*, *Open Sans*, *Overpass*, *PT Sans Narrow*, *Raleway*, *Times New Roman*.
    member _.family
        with get () = Option.defaultValue "" _family
        and set value = _family <- Some value

    member _.size
        with get () = Option.defaultValue 0.0 _size
        and set value = _size <- Some value

    member _.color
        with get () = Option.defaultValue "" _color
        and set value = _color <- Some value

    member _.ShouldSerializefamily() = _family.IsSome
    member _.ShouldSerializesize() = _size.IsSome
    member _.ShouldSerializecolor() = _color.IsSome