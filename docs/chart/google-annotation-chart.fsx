(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Annotation Chart
[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-annotation-chart.ipynb)
*)

open XPlot.GoogleCharts
open System

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

let chart =
    [kepler; gliese]
    |> Chart.Annotation
    |> Chart.WithOptions options
    |> Chart.WithLabels
        [
            "Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"
            "Gliese 163 mission"; "Gliese title"; "Gliese text"
        ]
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
