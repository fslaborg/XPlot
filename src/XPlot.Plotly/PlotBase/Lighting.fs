namespace XPlot.Plotly

type Lighting() =
    let mutable _ambient: float option = None
    let mutable _diffuse: float option = None
    let mutable _specular: float option = None
    let mutable _roughness: float option = None
    let mutable _fresnel: float option = None

    member __.ambient
        with get () = Option.defaultValue 0.0 _ambient
        and set value = _ambient <- Some value

    member __.diffuse
        with get () = Option.defaultValue 0.0 _diffuse
        and set value = _diffuse <- Some value

    member __.specular
        with get () = Option.defaultValue 0.0 _specular
        and set value = _specular <- Some value

    member __.roughness
        with get () = Option.defaultValue 0.0 _roughness
        and set value = _roughness <- Some value

    member __.fresnel
        with get () = Option.defaultValue 0.0 _fresnel
        and set value = _fresnel <- Some value

    member __.ShouldSerializeambient() =  _ambient.IsSome
    member __.ShouldSerializediffuse() =  _diffuse.IsSome
    member __.ShouldSerializespecular() =  _specular.IsSome
    member __.ShouldSerializeroughness() =  _roughness.IsSome
    member __.ShouldSerializefresnel() =  _fresnel.IsSome