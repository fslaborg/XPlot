#I __SOURCE_DIRECTORY__
#r """../../packages/Google.DataTable.Net.Wrapper/lib/Google.DataTable.Net.Wrapper.dll"""
#r """../../packages/Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"""
#r """../../packages/XPlot.GoogleCharts/Lib/Net45/XPlot.GoogleCharts.dll"""

open XPlot.GoogleCharts

// warm up data and options serialization
[1, 1]
|> Chart.Area
|> fun chart -> chart.Html
|> ignore