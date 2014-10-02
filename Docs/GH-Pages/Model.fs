module HtmlApp.Model


type Action =
    | Home
    | GoogleCharts
    | Highcharts
    | Chart of int //gistId //title * gistId

//and title = string

//and gistId = string
