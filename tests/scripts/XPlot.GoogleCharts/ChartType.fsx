#I "../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

let chart =
    ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    |> Chart.Line

let chart' =
    [
        ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
        ["2013", 798; "2014", 850; "2015", 760; "2016", 900]
    ]
    |> Chart.Line

let html = chart.GetHtml()

let inlineHtml = chart.GetInlineHtml()

let inlineJs = chart.GetInlineJS()

let height = chart.Height

let chartId = chart.Id

chart.Show()

let width = chart.Width

chart.WithHeight 400

chart.WithId "custom-id"
chart.Id

chart.WithLabel "Sales"
chart.Show()

chart'.WithLabels ["Sales"; "Expenses"]
chart'.Show()

chart.WithLegend false
chart.Show()

chart.WithLegend true
chart.Show()

let options = Options(title = "Company Performance")
chart.WithOptions options
chart.Show()

chart.WithSize(400, 400)
chart.Show()

chart.WithTitle "Company Performance"
chart.Show()

chart.WithWidth 400
chart.Show()

chart.WithXTitle "Year"
chart.WithYTitle "Total"
chart.Show()
