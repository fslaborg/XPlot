(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"
#load "credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.GoogleCharts.dll"

(**
Introducing your project
========================

Say more

*)

open XPlot.GoogleCharts
open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Some more info
*)
