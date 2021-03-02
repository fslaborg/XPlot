#I "../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"

open Deedle
open XPlot.GoogleCharts
open System

let a = Series.ofObservations [ 1 => 10.0; 2 => 11.0; 3 => 12.0; ]
let b = Series.ofObservations [ 0 => 5.0; 1 => 6.0; 2 => 7.0; 3 => 8.0; ]

[a; b]
|> Chart.Line
|> Chart.Show

let a' = [(1, 10.0); (2, 11.0); (3, 12.0)]
let b' = [(0, 5.0); (1, 6.0); (2, 7.0); (3, 8.0)]

[a'; b']
|> Chart.Line
|> Chart.Show

let options = Options(displayAnnotations = true)

type Msg =
    {
        time: DateTime
        value: int
        title: string
        text: string
    }

    static member New(t, v, t', t'') =
        {
            time = t
            value = v
            title = t'
            text = t''
        }

let kepler =
    [
        DateTime(2314, 3, 15), 12400, "", ""
        DateTime(2314, 3, 16), 24045, "Lalibertines", "First encounter"
        DateTime(2314, 3, 17), 35022, "Lalibertines", "They are very tall"
        DateTime(2314, 3, 18), 12284, "Lalibertines", "Attack on our crew!"
        DateTime(2314, 3, 19), 8476, "Lalibertines", "Heavy casualties"
        DateTime(2314, 3, 20), 0, "Lalibertines", "All crew lost"
    ]
    |> List.map Msg.New
    |> Frame.ofRecords
    |> Frame.indexRowsDate "time"
    |> Frame.indexColsWith ["Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"]

let gliese =
    [
        DateTime(2314, 3, 15), 10645, "", ""
        DateTime(2314, 3, 16), 12374, "", ""
        DateTime(2314, 3, 17), 15766, "Gallantors", "First Encounter"
        DateTime(2314, 3, 18), 34334, "Gallantors", "Statement of shared principles"
        DateTime(2314, 3, 19), 66467, "Gallantors", "Mysteries revealed"
        DateTime(2314, 3, 20), 79463, "Gallantors", "Omniscience achieved"
    ]
    |> List.map Msg.New
    |> Frame.ofRecords
    |> Frame.indexRowsDate "time"        
    |> Frame.indexColsWith ["Gliese 163 mission"; "Gliese title"; "Gliese text"]
    
let chart1 =
    kepler
    |> Chart.Annotation
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"]
    |> Chart.Show

let chart2 =
    kepler.Join(gliese, kind = JoinKind.Outer)
    |> Chart.Annotation
    |> Chart.WithOptions options
    |> Chart.Show
