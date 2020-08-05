(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts
(**
Google Scatter Chart
====================

Creating scatter plots (or point charts) is easy. The following example generates 1000
points by multiplying two numbers for the X coordinate and two numbers for the Y coordinate:
*)
(*** define-output:point1 ***) 
let rnd = new System.Random() 
let next() = rnd.NextDouble() * rnd.NextDouble()
let points = [ for i in 0 .. 100 -> next(), next() ]

points |> Chart.Scatter 
(*** include-it:point1 ***)
