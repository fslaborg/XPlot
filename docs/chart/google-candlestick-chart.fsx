(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Candlestick Chart
========================
*)
let data =
    [
        "Mon", 20, 28, 38, 45
        "Tue", 31, 38, 55, 66
        "Wed", 50, 55, 77, 80
        "Thu", 77, 77, 66, 50
        "Fri", 68, 66, 22, 15        
    ]
        
(*** define-output:candle ***) 
Chart.Candlestick data
(*** include-it:candle ***)