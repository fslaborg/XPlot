#I __SOURCE_DIRECTORY__
#r """../../packages/Google.DataTable.Net.Wrapper.3.1.0.0/lib/Google.DataTable.Net.Wrapper.dll"""
#r """../../packages/Newtonsoft.Json.6.0.6/lib/net45/Newtonsoft.Json.dll"""
#r """../../packages/XPlot.GoogleCharts.1.0.1/Lib/Net45/XPlot.GoogleCharts.dll"""

open XPlot.GoogleCharts

// warm up data and options serialization
[1, 1]
|> Chart.Area
|> fun chart -> chart.Html
|> ignore