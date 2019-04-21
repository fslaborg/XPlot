#I "../../../bin"
#r "XPlot.GoogleCharts.dll"

open System
open XPlot.GoogleCharts

let kepler =
    [
        DateTime(2314, 3, 15), 12400, "", ""
        DateTime(2314, 3, 16), 24045, "Lalibertines", "First encounter"
        DateTime(2314, 3, 17), 35022, "Lalibertines", "They are very tall"
        DateTime(2314, 3, 18), 12284, "Lalibertines", "Attack on our crew!"
        DateTime(2314, 3, 19), 8476, "Lalibertines", "Heavy casualties"
        DateTime(2314, 3, 20), 0, "Lalibertines", "All crew lost"
    ]

let gliese =
    [
        DateTime(2314, 3, 15), 10645, "", ""
        DateTime(2314, 3, 16), 12374, "", ""
        DateTime(2314, 3, 17), 15766, "Gallantors", "First Encounter"
        DateTime(2314, 3, 18), 34334, "Gallantors", "Statement of shared principles"
        DateTime(2314, 3, 19), 66467, "Gallantors", "Mysteries revealed"
        DateTime(2314, 3, 20), 79463, "Gallantors", "Omniscience achieved"
    ]

let options = Options(displayAnnotations = true)

let test1 =
    kepler
    |> Chart.Annotation
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"]
    |> Chart.Show

let test2 =
    [kepler; gliese]
    |> Chart.Annotation
    |> Chart.WithOptions options
    |> Chart.WithLabels
        [
            "Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"
            "Gliese 163 mission"; "Gliese title"; "Gliese text"            
        ]
    |> Chart.Show
