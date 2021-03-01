#I "../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"

open Deedle
open XPlot.GoogleCharts
    
type Marker =
    {
        x : string
        low : int
        opening : int
        closing : int
        high : int
    }

    static member New (x, l, o, c, h) =
        {
            x = x
            low = l
            opening = o
            closing = c
            high = h
        }

let chart1 =
    [
        "Mon", 20, 28, 38, 45
        "Tue", 31, 38, 55, 66
        "Wed", 50, 55, 77, 80
        "Thu", 77, 77, 66, 50
        "Fri", 68, 66, 22, 15        
    ]
    |> List.map Marker.New
    |> Frame.ofRecords
    |> Frame.indexRowsString "x"
    |> Chart.Candlestick
    |> Chart.Show     
