namespace HtmlApp

open IntelliFactory.WebSharper.Sitelets
open Model
open View

module Site =

    let chartSitelet url id title demos =
        Sitelet.Content
            url
            (Chart id)
            <| View.chart title demos

    let plotlySitelet url id title demos =
        Sitelet.Content
            url
            (Chart id)
            <| View.plotlyChart title demos

    let Main =
        Sitelet.Sum
            [
                Sitelet.Content "/" Home View.home
                Sitelet.Content "/google-charts" GoogleCharts View.googleCharts
                Sitelet.Content "/plotly" Plotly View.plotly
                chartSitelet
                    "/chart/google-annotation-chart"
                    1
                    "Google Annotation Chart"
                    [Demo.New "GoogleAnnotation" "Google Annotation Chart"]
                chartSitelet
                    "/chart/google-area-chart"
                    2
                    "Google Area Chart"
                    [Demo.New "GoogleArea" "Google Area Chart"]
                chartSitelet
                    "/chart/google-bar-chart"
                    3
                    "Google Bar Chart"
                    [Demo.New "GoogleBar" "Google Bar Chart"]
                chartSitelet
                    "/chart/google-bubble-chart"
                    4
                    "Google Bubble Chart"
                    [Demo.New "GoogleBubble" "Google Bubble Chart"]
                chartSitelet
                    "/chart/google-calendar-chart"
                    5
                    "Google Calendar Chart"
                    [Demo.New "GoogleCalendar" "Google Calendar Chart"]
                chartSitelet
                    "/chart/google-candlestick-chart"
                    6
                    "Google Candlestick Chart"
                    [Demo.New "GoogleCandlestick" "Google Candlestick Chart"]
                chartSitelet
                    "/chart/google-column-chart"
                    7
                    "Google Column Chart"
                    [Demo.New "GoogleColumn" "Google Column Chart"]
                chartSitelet
                    "/chart/google-combo-chart"
                    8
                    "Google Combo Chart"
                    [Demo.New "GoogleCombo" "Google Combo Chart"]
                chartSitelet
                    "/chart/google-gauge-chart"
                    9
                    "Google Gauge Chart"
                    [Demo.New "GoogleGauge" "Google Gauge Chart"]
                chartSitelet
                    "/chart/google-geo-chart"
                    10
                    "Google Geo Chart"
                    [Demo.New "GoogleGeo" "Google Geo Chart"]
                chartSitelet
                    "/chart/google-histogram-chart"
                    11
                    "Google Histogram Chart"
                    [Demo.New "GoogleHistogram" "Google Histogram Chart"]
                chartSitelet
                    "/chart/google-line-chart"
                    12
                    "Google Line Chart"
                    [Demo.New "GoogleLine" "Google Line Chart"]
                chartSitelet
                    "/chart/google-map-chart"
                    13
                    "Google Map Chart"
                    [Demo.New "GoogleMap" "Google Map Chart"]
                chartSitelet
                    "/chart/google-pie-chart"
                    14
                    "Google Pie Chart"
                    [Demo.New "GooglePie" "Google Pie Chart"]
                chartSitelet
                    "/chart/google-sankey-diagram"
                    15
                    "Google Sankey Diagram"
                    [Demo.New "GoogleSankey" "Google Sankey Diagram"]
                chartSitelet
                    "/chart/google-scatter-chart"
                    16
                    "Google Scatter Chart"
                    [Demo.New "GoogleScatter" "Google Scatter Chart"]
                chartSitelet
                    "/chart/google-stepped-area-chart"
                    17
                    "Google Stepped Area Chart"
                    [Demo.New "GoogleSteppedArea" "Google Stepped Area Chart"]
                chartSitelet
                    "/chart/google-timeline-chart"
                    18
                    "Google Timeline Chart"
                    [Demo.New "GoogleTimeline" "Google Timeline Chart"]
                chartSitelet
                    "/chart/google-table-chart"
                    19
                    "Google Table Chart"
                    [Demo.New "GoogleTable" "Google Table Chart"]
                chartSitelet
                    "/chart/google-treemap-chart"
                    20
                    "Google Treemap Chart"
                    [Demo.New "GoogleTreemap" "Google Treemap Chart"]
                plotlySitelet
                    "/chart/plotly-bar-chart"
                    21
                    "Plotly Bar Chart"
                    [
                        PlotlyDemo.New "PlotlyBasicBarChart" "Basic Bar Chart" "https://plot.ly/~TahaHachana/130"
                    ]
            ]

[<Sealed>]
type Website() =
    interface IWebsite<Action> with
        member __.Sitelet = Site.Main
        member __.Actions =
            [
                yield Home
                yield GoogleCharts
                yield Plotly
                for x in 1 .. 21 -> Chart x
            ]

[<assembly: Website(typeof<Website>)>]
do ()