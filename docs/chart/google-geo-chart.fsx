﻿(*** condition: prepare ***)
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
Google Geo charts

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=google-geo-chart.ipynb)

This example shows how to create geo charts and line charts using the
`XPlot.GoogleCharts` library.

To create a geo chart, use the `Chart.Geo` function. As usual, you can specify additional
options of the chart using `Chart.WithOptions` including properties such as title, legend
and so on. More interestingly, this also lets you specify color axis (for filling countries
with a range of colors) and it lets you provide the `region` parameter for displaying only
a part of the world.

A simple geo chart
-------------------

The following example calls `Chart.Geo` with a list of key value pairs. Google Charts
automatically recognize country names and country codes, so the following readable code
works just fine:
*)
open XPlot.GoogleCharts

let pop =
  [ "Germany", 200; "United States", 300
    "Brazil", 400;  "Canada", 500
    "France", 600;  "RU", 700 ]

let chart =
    pop
    |> Chart.Geo
    |> Chart.WithLabel "Popularity"
(*** hide ***)
chart.GetHtml()
(*** include-it-raw ***)

(*** hide ***)

//(**
//
//A regional geo chart
//--------------------
//
//The following example is different in two ways:
//
// - It plots data for a specified region, which is specified using the `region` property of `Options`
// - It uses two different values - the first is used to determine the color of the circle and the second
//   one specifies its size.
//
//As before, we can specify the cities using just names. The `Chart.Geo` method is overloaded
//and takes a series of either two-element (as above) or three-element (as below) tuples:
//*)
//(*** define-output:geo2 ***)
//let data =
//  [ ("Rome", 2761477, 1285.31); ("Milan", 1324110, 181.76);
//    ("Naples", 959574, 117.27); ("Turin", 907563, 130.17);
//    ("Palermo", 655875, 158.9); ("Genoa", 607906, 243.60);
//    ("Bologna", 380181, 140.7); ("Florence", 371282, 102.41);
//    ("Anzio", 52192, 43.43);    ("Ciampino", 38262, 11.) ]
//
//let options =
//  Options
//    ( region = "IT", displayMode = "markers",
//      colorAxis = ColorAxis(colors = [|"green"; "blue"|]) )
//
//data
//|> Chart.Geo
//|> Chart.WithLabels ["Population"; "Area"]
//|> Chart.WithOptions options
//(*** include-output:geo2 ***)
