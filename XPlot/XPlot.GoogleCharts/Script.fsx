#r """.\bin\Release\XPlot.GoogleCharts.dll"""

open XPlot.GoogleCharts

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

let options = Options()

options.areaOpacity <- 0.3
options.dataOpacity <- 1.0
options.enableInteractivity <- true
options.fontSize <- 14
options.height <- 500 
options.width <- 900
options.lineWidth <- 2

//options.title <- "Company Performance"
//options.legend <- Legend(position = "none")
//options.vAxis <- Axis(minValue = 0)

let chart = Chart.Area([sales; expenses], ["Sales"; "Expenses"], options)

chart.Show()
