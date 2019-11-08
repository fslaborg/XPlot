(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts
(**
Google Line Chart
=================

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
(*** define-output:line1 ***) 
Chart.Line [ for x in 0. .. 0.5 .. 6.3 -> x, sin x ]
(*** include-it:line1 ***)
(**

A smooth function chart
-----------------------

By default, line charts use straight line segments between the points. You can add
smoothing by creating `Options` with `curveType="function"` as follows:

*)
(*** define-output:line2 ***) 
Chart.Line [ for x in 0. .. 0.5 .. 6.3 -> x, sin x ]
|> Chart.WithOptions(Options(curveType = "function"))
(*** include-it:line2 ***)

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
(*** define-output:combined1 ***) 
let sales = [("2013", 1000); ("2014", 1170); ("2015", 660); ("2016", 1030)]
let expenses = [("2013", 400); ("2014", 460); ("2015", 1120); ("2016", 540)]
 
let options =
  Options
    ( title = "Company Performance", curveType = "function",
      legend = Legend(position = "bottom") )
            
[sales; expenses]
|> Chart.Line
|> Chart.WithOptions options
|> Chart.WithLabels ["Sales"; "Expenses"]
(*** include-it:combined1 ***)
(**
Note that the two inputs are sequences of tuples with X (year) and Y (value) pairs. We then 
create `Options` object to specify the title, smooth curve and also the legend of the chart.
Then we call `Chart.Line` followed by `Chart.WithOptions` and also `Chart.WithLabels` to 
provide labels for the two series.
*)
