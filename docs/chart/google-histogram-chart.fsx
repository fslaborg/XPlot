(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Histogram Chart
======================
*)
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

(*** define-output:hist ***)  
let options = Options(title = "Lengths of dinosaurs, in meters")
 
data
|> Chart.Histogram
|> Chart.WithOptions options
|> Chart.WithLabel "Length"
(*** include-it:hist ***)