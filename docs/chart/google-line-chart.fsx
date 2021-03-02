(*** condition: prepare ***)
#r "../../bin/XPlot.GoogleCharts/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0/XPlot.GoogleCharts.Deedle.dll"
#r "../../packages/Deedle/lib/netstandard2.0/Deedle.dll"
#r "../../packages/Google.DataTable.Net.Wrapper/lib/netstandard2.0/Google.DataTable.Net.Wrapper.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.GoogleCharts"
#r "nuget: XPlot.GoogleCharts.Deedle"
#endif // IPYNB

(**
Google Line Chart

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/zyzhu/XPlot/gh-pages?filepath=google-line-chart.ipynb)

This example shows how to create scatter (point) charts and line charts using the
`XPlot.GoogleCharts` library.

To create a line chart, use `Chart.Line`. To create a scatter (point) chart, use
`Chart.Scatter`. In both cases, you can also combine multiple charts in the same
chart area, simply by calling the functions with a list of lists (rather
than with just a plan list of key value pairs)

A simple line chart
-------------------

The following example calls `Chart.Line` with a list of key value pairs, created
using a simple F# list comprehension:
*)
open XPlot.GoogleCharts

let chart1 = Chart.Line [ for x in 0. .. 0.5 .. 6.3 -> x, sin x ]
(*** hide ***)
chart1.GetHtml()
(*** include-it-raw ***)

(**

A smooth function chart
-----------------------

By default, line charts use straight line segments between the points. You can add
smoothing by creating `Options` with `curveType="function"` as follows:

*)
let chart2 =
    [ for x in 0. .. 0.5 .. 6.3 -> x, sin x ]
    |> Chart.Line
    |> Chart.WithOptions(Options(curveType = "function"))
(*** hide ***)
chart2.GetHtml()
(*** include-it-raw ***)


(**
You can find more information about other options that you can specify in the documentation
[for the `Options` type](reference/xplot-googlecharts-configuration-options.html) in the API
reference. Another way to explore the available configuration options is to type dot right
after the value, i.e. `Options().` - and see what fields (lower-case, at the end of the list)
are available.
*)
(**
Combining line charts
---------------------

Finally, you can also pass multiple series of values to both point and line charts. This creates
a chart that shows multiple data sets using a different line or point color for each data set.
The following example plots sales and expenses of some non-existent company in a single line
chart with annotations:
*)
let sales = [("2013", 1000); ("2014", 1170); ("2015", 660); ("2016", 1030)]
let expenses = [("2013", 400); ("2014", 460); ("2015", 1120); ("2016", 540)]

let options =
  Options
    ( title = "Company Performance", curveType = "function",
      legend = Legend(position = "bottom") )

let chart3 =
    [sales; expenses]
    |> Chart.Line
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Sales"; "Expenses"]
(*** hide ***)
chart3.GetHtml()
(*** include-it-raw ***)
(**
Note that the two inputs are sequences of tuples with X (year) and Y (value) pairs. We then
create `Options` object to specify the title, smooth curve and also the legend of the chart.
Then we call `Chart.Line` followed by `Chart.WithOptions` and also `Chart.WithLabels` to
provide labels for the two series.
*)


(*
Create a line chart with two different Y-axes (the example above has two lines plotted by only a single Y-axis).
Plot values of different data types
Based off of this sample: https://developers.google.com/chart/interactive/docs/gallery/linechart#dual-y-charts
*)
open System

//Make up some fake data. Two sets of values for the same sequence of dates
let values1 = [1..7]
let values2 = [20.1..10.3..90.0] //using floats here to demonstrate that we can use a different data type on the second Y axis
let dates = [ for i in [6.0..(-1.0)..0.0] -> DateTime.Today.AddDays(-i) ]

let first = Deedle.Series(dates, values1)
let second = Deedle.Series(dates, values2)

let df = Deedle.Frame(["IntVals"; "FloatVals"], [first; second])

let dfOptions =
  Options
    ( title = "Value 1 & Value 2 by Date",
      legend = Legend(position = "bottom") ,
      series = [|Series("IntVals", targetAxisIndex = 0); Series("FloatVals", targetAxisIndex = 1)|],
      vAxes = [|Axis(title = "Foo"); Axis(title = "Bar")|])

let chart4 =
    df
    |> Chart.Line
    |> Chart.WithOptions dfOptions
(*** hide ***)
chart4.GetHtml()
(*** include-it-raw ***)
