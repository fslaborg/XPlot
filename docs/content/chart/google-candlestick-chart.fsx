(*** hide ***)
#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"
open XPlot.GoogleCharts

(**
Google Candlestick Chart
========================
*)
(*** define-output:candle ***) 
let data =
    [
        "Mon", 20, 28, 38, 45
        "Tue", 31, 38, 55, 66
        "Wed", 50, 55, 77, 80
        "Thu", 77, 77, 66, 50
        "Fri", 68, 66, 22, 15        
    ]
        
Chart.Candlestick data
(*** include-it:candle ***)