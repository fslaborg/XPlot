#I "bin/"
#r "bin/NewtonSoft.Json.dll"

#load "src/XPlot.D3/Configuration.fs"
#load "src/XPlot.D3/Main.fs"

open XPlot.D3
open System.Drawing

let edges = 
    [   "blog1", "content2"
        "content2", "content1"
        "content1", "blog1"]

edges
|> Chart.ForceLayout
|> Chart.WithHeight 1000
|> Chart.WithWidth 1000
|> Chart.WithGravity 2.5
|> Chart.WithEdgeOptions (fun e ->
{
    Stroke = Color.PowderBlue
    StrokeWidth = 2.0
    Distance = 250.0
}) 
|> Chart.Show
