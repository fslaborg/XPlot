(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#I "../../../packages/MathNet.Numerics/lib/net40"
#r "XPlot.Plotly.dll"
#r "MathNet.Numerics.dll"

open System

open MathNet.Numerics
open MathNet.Numerics.Distributions

open XPlot.Plotly

let size = 100

let x = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let y = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
let z = Array2D.create size size 0.

for i in 0 .. 99 do
    for j in 0 .. 99 do
        let r2 = x.[i] ** 2. + y.[j] ** 2.
        z.[i,j] <- sin x.[i] * cos y.[j] * sin r2 / log(r2 + 1.)

(**
Plotly Contour Plots
====================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-contour-plots.fsx)

Basic Contour Plot
------------------
*)

(*** define-output: chart ***)
Contour(
    z = z,
    x = x,
    y = y
)
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart ***)
