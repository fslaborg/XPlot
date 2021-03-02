(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/MathNet.Numerics/lib/netstandard2.0/MathNet.Numerics.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.Plotly"
#r "nuget: MathNet.Numerics"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly Contour Plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=plotly-contour-plots.ipynb)

Basic Contour Plot
------------------
*)
open System
open MathNet.Numerics
open XPlot.Plotly

let size = 100

let x = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let y = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let z = Array2D.create size size 0.

for i in 0 .. 99 do
    for j in 0 .. 99 do
        let r2 = x.[i] ** 2. + y.[j] ** 2.
        z.[i,j] <- sin x.[i] * cos y.[j] * sin r2 / log(r2 + 1.)

let chart =
    Contour(
        z = z,
        x = x,
        y = y
    )
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart
#endif // IPYNB
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)
