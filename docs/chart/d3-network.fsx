(*** condition: prepare ***)
#r "../../bin/XPlot.D3/netstandard2.0/XPlot.D3.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.D3"
#endif // IPYNB

(**
##D3 Network Example
*)
open XPlot.D3

let edges =
    [   "A", "B"
        "B", "C"
        "C", "A"
        "A", "D"
        "B", "E"]

let chart =
    edges
    |> Chart.ForceLayout
    |> Chart.WithHeight 300
    |> Chart.WithWidth 400
    |> Chart.WithGravity 0.5
    |> Chart.WithCharge -2000.0
    |> Chart.WithEdgeOptions (fun e ->
        let pr = e.From.Name, e.To.Name
        match pr with
        | "A","B" -> { defaultEdgeOptions with Distance = 200.0 }
        | "A","D" -> { defaultEdgeOptions with StrokeWidth = 4.5 }
        | _ -> {defaultEdgeOptions with Distance = 100.0})
    |> Chart.WithNodeOptions(fun n ->
        match n.Name with
        | "A" -> {defaultNodeOptions with Fill = {Red = 150uy; Green = 150uy; Blue=195uy}}
        | "B" -> {defaultNodeOptions with RadiusScale=1.5; Fill = {Red = 150uy; Green = 195uy; Blue=150uy}}
        | _ -> defaultNodeOptions)
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
