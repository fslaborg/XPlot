
open System.IO

let path = Path.Combine(__SOURCE_DIRECTORY__, "Graph.json")

let json = File.ReadAllText path

#r @"..\packages\Newtonsoft.Json.6.0.8\lib\net45\Newtonsoft.Json.dll"

type GraphObj =
    {
        key_type: string
        val_types: string
        required: string
        description: string
    }

open Newtonsoft.Json
open System.Collections.Generic

let graphObjs =
    JsonConvert.DeserializeObject(json, typeof<Dictionary<string, Dictionary<string, GraphObj>>>)
    :?> Dictionary<string, Dictionary<string, GraphObj>>

type Property =
    {
        name: string
        fieldName: string
        ``type``: string
        description: string
    }

open System

let firstCharToUpper (str:string) =
    match str.Length with
    | 0 -> ""
    | 1 -> str.ToUpper()
    | _ -> 
        Char.ToUpper str.[0]
        |> fun x -> string x + str.Substring 1

let classes =
    graphObjs
    |> Seq.map (fun graphObj ->
        let name = firstCharToUpper graphObj.Key
        let properties =
            graphObj.Value
            |> Seq.map (fun x ->
                let key = x.Key
                let graphObj = x.Value
                {
                    name = key
                    fieldName = "_" + key
                    ``type`` =
                        match graphObj.val_types with
                        | "number: x > 0" | "number: x >= 0" | "number" -> "float"
                        | x when x.StartsWith("a string") -> "string"
                        | x when x.StartsWith("number: x in [") -> "float"
                        | x when x.Contains("|") -> "string"
                        | "a boolean: TRUE | FALSE" -> "bool"
                        | "array of numbers" -> "seq<float>"
                        | "array of numbers, strings, datetimes" -> "seq<value>"
                        | "array of strings" -> "seq<string>"
                        | x -> x
                    description = graphObj.description
                }    
            )

        let fields =
            properties
            |> Seq.map (fun x -> "    let mutable " + x.fieldName + ": " + x.``type`` + " option = None")
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
                    "    /// " + x.description
                    "    member __." + name
                    "        with get () = Option.get " + x.fieldName
                    "        and set value = " + x.fieldName + " <- Some value"
                ]
                |> String.concat "\n"
            )
            |> String.concat "\n\n"

        let shouldSerializeMembers =
            properties
            |> Seq.map (fun x -> "    member __.ShouldSerialize" + x.name + "() = not " + x.fieldName + ".IsNone")
            |> String.concat "\n"

        let graphObjClass =
            [
                "type " + name + "() ="
                fields
                members
                shouldSerializeMembers
            ]
            |> String.concat "\n\n"
        graphObjClass)
    |> String.concat "\n\n"

let path' = Path.Combine(__SOURCE_DIRECTORY__, "Graph.txt")

File.WriteAllText(path', classes)

