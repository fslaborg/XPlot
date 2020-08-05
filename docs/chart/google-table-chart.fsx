(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Table Chart
==================
*)
let salary =
    [
        "Mike", 10000
        "Jim", 8000
        "Alice", 12500
        "Bob", 7000
    ]
    |> List.map (fun (x, y) -> x, y :> value)
 
let fulltime =
    [
        "Mike", true
        "Jim", false
        "Alice", true
        "Bob", true
    ]
    |> List.map (fun (x, y) -> x, y :> value)

(*** define-output:table ***) 
[salary; fulltime]        
|> Chart.Table
|> Chart.WithOptions(Options(showRowNumber = true))
|> Chart.WithLabels ["Name"; "Salary"; "Full Time Employee"]
(*** include-it:table ***)
