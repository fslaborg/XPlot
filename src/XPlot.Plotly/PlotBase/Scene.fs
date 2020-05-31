namespace XPlot.Plotly

type Scene() =

    let mutable _bgcolor: string option = None
    let mutable _camera: Camera option = None
    let mutable _domain: Domain option = None
    let mutable _aspectmode: _ option = None
    let mutable _aspectratio: Aspectratio option = None
    let mutable _xaxis: Xaxis option = None
    let mutable _yaxis: Yaxis option = None
    let mutable _zaxis: Zaxis option = None
    let mutable __isSubplotObj: bool option = Some true
    //let mutable _role: string option = Some "object"

    member __.bgcolor
        with get () = Option.get _bgcolor
        and set value = _bgcolor <- Some value

    member __.camera
        with get () = Option.get _camera
        and set value = _camera <- Some value

    member __.domain
        with get () = Option.get _domain
        and set value = _domain <- Some value

    /// If *cube*, this scene's axes are drawn as a cube, regardless of the axes' ranges. If *data*, this scene's axes are drawn in proportion with the axes' ranges. If *manual*, this scene's axes are drawn in proportion with the input of *aspectratio* (the default behavior if *aspectratio* is provided). If *auto*, this scene's axes are drawn using the results of *data* except when one axis is more than four times the size of the two others, where in that case the results of *cube* are used.
    member __.aspectmode
        with get () = Option.get _aspectmode
        and set value = _aspectmode <- Some value

    member __.aspectratio
        with get () = Option.get _aspectratio
        and set value = _aspectratio <- Some value

    member __.xaxis
        with get () = Option.get _xaxis
        and set value = _xaxis <- Some value

    member __.yaxis
        with get () = Option.get _yaxis
        and set value = _yaxis <- Some value

    member __.zaxis
        with get () = Option.get _zaxis
        and set value = _zaxis <- Some value

    member __._isSubplotObj
        with get () = Option.get __isSubplotObj
        and set value = __isSubplotObj <- Some value

    member __.ShouldSerializebgcolor() = not _bgcolor.IsNone
    member __.ShouldSerializecamera() = not _camera.IsNone
    member __.ShouldSerializedomain() = not _domain.IsNone
    member __.ShouldSerializeaspectmode() = not _aspectmode.IsNone
    member __.ShouldSerializeaspectratio() = not _aspectratio.IsNone
    member __.ShouldSerializexaxis() = not _xaxis.IsNone
    member __.ShouldSerializeyaxis() = not _yaxis.IsNone
    member __.ShouldSerializezaxis() = not _zaxis.IsNone
    member __.ShouldSerialize_isSubplotObj() = not __isSubplotObj.IsNone
