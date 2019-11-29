namespace XPlot.Plotly

type Rotation() =
    let mutable _lon: float option = None
    let mutable _lat: float option = None
    let mutable _roll: float option = None

    /// Rotates the map along parallels (in degrees East).
    member __.lon
        with get () = Option.defaultValue 0.0 _lon
        and set value = _lon <- Some value

    /// Rotates the map along meridians (in degrees North).
    member __.lat
        with get () = Option.defaultValue 0.0 _lat
        and set value = _lat <- Some value

    /// Roll the map (in degrees) For example, a roll of *180* makes the map appear upside down.
    member __.roll
        with get () = Option.defaultValue 0.0 _roll
        and set value = _roll <- Some value

    member __.ShouldSerializelon() =  _lon.IsSome
    member __.ShouldSerializelat() =  _lat.IsSome
    member __.ShouldSerializeroll() =  _roll.IsSome


