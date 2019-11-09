
#r @"../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"

open Newtonsoft.Json
open System
open System.Collections.Generic
open System.IO
open System.Net

let json =
    use client = new WebClient()
    client.Encoding <- System.Text.Encoding.UTF8
    client.DownloadString "https://plot.ly/plot-schema.json"

type Property =
    {
        typeName: string
        name: string
        ``type``: string
        description: string
        value : obj option
    }

let propertyFromString typeName x value =
    {
        typeName = typeName
        name = x
        ``type`` = "string"
        description = ""
        value = Some value
    }

let propertyFromObj typeName x (value: Dictionary<string, obj>) =
    {
        typeName = typeName
        name = x
        ``type`` = value.["valType"].ToString()
        description = try value.["description"].ToString() with _ -> ""
        value = None
    }

let jsonDict =
    JsonConvert.DeserializeObject(json, typeof<Dictionary<string, obj>>)
    :?> Dictionary<string, obj>

let traces =
    jsonDict.["traces"].ToString()
    |> fun x ->
        JsonConvert.DeserializeObject(x, typeof<Dictionary<string, obj>>)
        :?> Dictionary<string, obj>

let layout =
    jsonDict.["layout"].ToString()
    |> fun x ->
        JsonConvert.DeserializeObject(x, typeof<Dictionary<string, obj>>)
        :?> Dictionary<string, obj>

let rec getMembers typeName (properties: Dictionary<string, obj>) =
    [
        for p in properties do
            let x = p.Key
            printfn "%s" x
            let y = p.Value
            match y with
            | :? System.String -> yield propertyFromString typeName x ("\"" + string y + "\"")
            | :? System.Boolean -> yield propertyFromString typeName x y
            | _ ->
                let value =
                    JsonConvert.DeserializeObject(y.ToString(), typeof<Dictionary<string, obj>>)
                    :?> Dictionary<string, obj>
                match value.ContainsKey("valType") with
                | true -> yield propertyFromObj typeName x value
                | false ->
                    yield
                        {
                            typeName = typeName
                            name = x
                            ``type`` = x
                            description = ""
                            value = None
                        }
                    let typeName = x
                    let properties =
                        JsonConvert.DeserializeObject(y.ToString(), typeof<Dictionary<string, obj>>)
                        :?> Dictionary<string, obj>
                    yield! getMembers typeName properties   
    ]

let traceMembers =
    [
        for x in traces do 
            let typeName = x.Key
            let jObj = x.Value   
            let properties =
                jObj.ToString()
                |> fun x ->
                    JsonConvert.DeserializeObject(x, typeof<Dictionary<string, obj>>)
                    :?> Dictionary<string, obj>
                |> fun x -> x.["attributes"].ToString()
                |> fun x ->
                    JsonConvert.DeserializeObject(x, typeof<Dictionary<string, obj>>)
                    :?> Dictionary<string, obj>
            yield! getMembers typeName properties
    ]

let layoutMembers =
    [
        let typeName = "layout"
        let jObj = layout.["layoutAttributes"]
        let traces =
            jObj.ToString()
            |> fun x ->
                JsonConvert.DeserializeObject(x, typeof<Dictionary<string, obj>>)
                :?> Dictionary<string, obj>
        yield! getMembers typeName traces
    ]

let members =
    List.append traceMembers layoutMembers
    |> List.filter (fun x -> x.``type`` <> "_deprecated") 
    |> List.filter (fun x -> x.typeName <> "_deprecated")
    |> Seq.distinct
    |> Seq.toList

// All the types
members
|> Seq.map (fun x -> x.``type``)
|> Seq.distinct
|> Seq.toArray

//[|"string"; "enumerated"; "boolean"; "number"; "flaglist"; "stream";
//    "data_array"; "any"; "line"; "color"; "marker"; "colorscale"; "colorbar";
//    "integer"; "tickfont"; "angle"; "titlefont"; "textfont"; "error_y";
//    "error_x"; "axisid"; "xbins"; "ybins"; "insidetextfont"; "outsidetextfont";
//    "domain"; "info_array"; "contours"; "projection"; "x"; "y"; "z"; "error_z";
//    "sceneid"; "project"; "lighting"; "contour"; "geoid"; "font"; "margin";
//    "xaxis"; "yaxis"; "scene"; "camera"; "up"; "center"; "eye"; "aspectratio";
//    "zaxis"; "geo"; "rotation"; "lonaxis"; "lataxis"; "legend"; "annotations";
//    "items"; "annotation"; "shapes"; "shape"; "radialaxis"; "angularaxis"|]

let firstCharToUpper (str:string) =
    match str.Length with
    | 0 -> ""
    | 1 -> str.ToUpper()
    | _ -> 
        Char.ToUpper str.[0]
        |> fun x -> string x + str.Substring 1

let classes =
    members
    |> Seq.groupBy (fun x -> x.typeName)
    |> Seq.map (fun (key, members) ->
        let typeName' = firstCharToUpper key
        printfn "%s" typeName'
        let properties =
            members
            |> Seq.map (fun x ->
                let type' =
                    match x.``type`` with
                    | "string" | "flaglist" | "geoid" | "sceneid" | "axisid" | "color" -> "string"
                    | "boolean" -> "bool"
                    | "number" | "angle" -> "float"
                    | "integer" -> "int"
                    | "enumerated" | "data_array" | "any" | "info_array" | "colorscale" -> "_"
                    | t -> firstCharToUpper t
                {x with typeName = typeName'; ``type`` = type'} 
            )

        let fields =
            properties
            |> Seq.map (fun x ->
                match x.value with
                | None -> "    let mutable _" + x.name + ": " + x.``type`` + " option = None"
                | Some v -> "    let mutable _" + x.name + ": " + x.``type`` + " option = Some " + v.ToString())
            |> String.concat "\n"

        let members =
            properties
            |> Seq.map (fun x ->
                let name =
                    match x.name with
                    | "type" -> "``type``"
                    | "end" -> "``end``"
                    | name -> name
                [
                    if x.description <> "" then "    /// " + x.description
                    "    member __." + name
                    "        with get () = Option.get _" + x.name
                    "        and set value = _" + x.name + " <- Some value"
                ]
                |> String.concat "\n"
            )
            |> String.concat "\n\n"

        let shouldSerializeMembers =
            properties
            |> Seq.map (fun x -> "    member __.ShouldSerialize" + x.name + "() = not _" + x.name + ".IsNone")
            |> String.concat "\n"

        let graphObjClass =
            [
                "type " + typeName' + "() ="
                fields
                members
                shouldSerializeMembers
            ]
            |> String.concat "\n\n"
        graphObjClass)
    |> String.concat "\n\n"

let path = Path.Combine(__SOURCE_DIRECTORY__, "Graph.txt")

File.WriteAllText(path, classes)
