(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: XPlot.GoogleCharts"
#endif // IPYNB

(**
Google Histogram Chart
======================
*)
open XPlot.GoogleCharts

let data =
    [
        "Acrocanthosaurus (top-spined lizard)", 12.2
        "Albertosaurus (Alberta lizard)", 9.1
        "Baryonyx (heavy claws)", 9.1
        "Ceratosaurus (horned lizard)", 6.1
        "Coelophysis (hollow form)", 2.7
        "Dromicelomimus (emu mimic)", 3.4
        "Mamenchisaurus (Mamenchi lizard)", 21.0
        "Megalosaurus (big lizard)", 7.9
        "Microvenator (small hunter)", 1.2
        "Oviraptor (egg robber)", 1.5
        "Sauronithoides (narrow-clawed lizard)", 2.0
        "Seismosaurus (tremor lizard)", 45.7
        "Supersaurus (super lizard)", 30.5
        "Ultrasaurus (ultra lizard)", 30.5
        "Velociraptor (swift robber)", 1.8
    ]

let options = Options(title = "Lengths of dinosaurs, in meters")

let chart =
    data
    |> Chart.Histogram
    |> Chart.WithOptions options
    |> Chart.WithLabel "Length"
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
