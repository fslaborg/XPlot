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
                    "/chart/plotly-bar-charts"
                    21
                    "Plotly Bar Chart"
                    [
                        PlotlyDemo.New "PlotlyBasicBarChart" "Basic Bar Chart" "https://plot.ly/~TahaHachana/130"
                        PlotlyDemo.New "PlotlyGroupedBarChart" "Grouped Bar Chart" "https://plot.ly/~TahaHachana/145"
                        PlotlyDemo.New "PlotlyStackedBarChart" "Stacked Bar Chart" "https://plot.ly/~TahaHachana/146"
                        PlotlyDemo.New "PlotlyColoredStyledBarChart" "Colored and Styled Bar Chart" "https://plot.ly/~TahaHachana/147"
                        PlotlyDemo.New "PlotlyBarChartHoverText" "Bar Chart with Hover Text" "https://plot.ly/~TahaHachana/148"
                        PlotlyDemo.New "PlotlyCustomizingIndividualBarColors" "Customizing Individual Bar Colors" "https://plot.ly/~TahaHachana/149"
                    ]
                plotlySitelet
                    "/chart/plotly-line-scatter-plots"
                    22
                    "Plotly Line and Scatter Plots"
                    [
                        PlotlyDemo.New "PlotlyBasicLinePlot" "Basic Line Plot" "https://plot.ly/~TahaHachana/173"
                        PlotlyDemo.New "PlotlyLineScatterPlot" "Line and Scatter Plot" "https://plot.ly/~TahaHachana/177"
                        PlotlyDemo.New "PlotlyColoredStyledScatterPlot" "Colored and Styled Scatter Plot" "https://plot.ly/~TahaHachana/178"
                        PlotlyDemo.New "PlotlyLineShapeOptionsInterpolation" "Line Shape Options for Interpolation" "https://plot.ly/~TahaHachana/179"
                    ]
                plotlySitelet
                    "/chart/plotly-box-plots"
                    23
                    "Plotly Box Plots"
                    [
                        PlotlyDemo.New "PlotlyBasicBoxPlot" "Basic Box Plot" "https://plot.ly/~TahaHachana/206"
                        PlotlyDemo.New "PlotlyBoxPlotDisplaysUnderlyingData" "Box Plot That Displays the Underlying Data" "https://plot.ly/~TahaHachana/207"
                        PlotlyDemo.New "PlotlyGroupedBoxPlot" "Grouped Box Plot" "https://plot.ly/~TahaHachana/208"
                    ]
                plotlySitelet
                    "/chart/plotly-bubble-charts"
                    24
                    "Plotly Bubble Charts"
                    [
                        PlotlyDemo.New "PlotlyBubbleChart" "Marker Size, Color, and Symbol as an Array" "https://plot.ly/~TahaHachana/226"
                    ]
                plotlySitelet
                    "/chart/plotly-contour-plots"
                    25
                    "Plotly Contour Plots"
                    [
                        PlotlyDemo.New "PlotlyBasicContourPlot" "Basic Contour Plot" "https://plot.ly/~TahaHachana/268"
                        PlotlyDemo.New "2DHistogramContourPlotHistogramSubplots" "2D Histogram Contour Plot with Histogram Subplots" "https://plot.ly/~TahaHachana/269"
                    ]
                plotlySitelet
                    "/chart/plotly-area-plots"
                    26
                    "Plotly Area Plots"
                    [
                        PlotlyDemo.New "PlotlyBasicArea" "Basic Overlaid Area Chart" "https://plot.ly/~TahaHachana/289"
                    ]
                plotlySitelet
                    "/chart/plotly-error-bars"
                    27
                    "Plotly Error Bars"
                    [
                        PlotlyDemo.New "PlotlyBasicSymmetricErrorBars" "Basic Symmetric Error Bars" "https://plot.ly/~TahaHachana/312"
                        PlotlyDemo.New "PlotlyBarChartErrorBars" "Bar Chart with Error Bars" "https://plot.ly/~TahaHachana/319"
                        PlotlyDemo.New "PlotlyHorizontalErrorBars" "Horizontal Error Bars" "https://plot.ly/~TahaHachana/320"
                        PlotlyDemo.New "PlotlyAsymmetricErrorBars" "Asymmetric Error Bars" "https://plot.ly/~TahaHachana/321"
                        PlotlyDemo.New "PlotlyColoredStyledErrorBars" "Colored and Styled Error Bars" "https://plot.ly/~TahaHachana/323"
                        PlotlyDemo.New "PlotlyErrorBarsPercentageYValue" "Error Bars as a Percentage of the y-Value" "https://plot.ly/~TahaHachana/326"
                        PlotlyDemo.New "PlotlyAsymmetricErrorBarsConstantOffset" "Asymmetric Error Bars with a Constant Offset" "https://plot.ly/~TahaHachana/327"
                    ]
                plotlySitelet
                    "/chart/plotly-heatmaps"
                    28
                    "Plotly Heatmaps"
                    [
                        PlotlyDemo.New "PlotlyBasicHeatmap" "Basic Heatmap" "https://plot.ly/~TahaHachana/365"
                        PlotlyDemo.New "PlotlyHeatmapCategoricalAxisLabels" "Heatmap with Categorical Axis Labels" "https://plot.ly/~TahaHachana/369"
                        PlotlyDemo.New "PlotlyCustomColorscale" "Custom Colorscale" "https://plot.ly/~TahaHachana/370"
                        PlotlyDemo.New "PlotlyEarthColorscale" "Earth Colorscale" "https://plot.ly/~TahaHachana/371"
                        PlotlyDemo.New "PlotlyYIGnBuColorscale" "YIGnBu Colorscale" "https://plot.ly/~TahaHachana/372"
                    ]
                plotlySitelet
                    "/chart/plotly-histograms"
                    29
                    "Plotly Histograms"
                    [
                        PlotlyDemo.New "PlotlyBasicHistogram" "Basic Histogram" "https://plot.ly/~TahaHachana/388"
                        PlotlyDemo.New "PlotlyHorizontalHistogram" "Horizontal Histogram" "https://plot.ly/~TahaHachana/389"
                        PlotlyDemo.New "PlotlyOverlaidHistogram" "Overlaid Histogram" "https://plot.ly/~TahaHachana/390"
                        PlotlyDemo.New "PlotlyStackedHistograms" "Stacked Histograms" "https://plot.ly/~TahaHachana/394"
                        PlotlyDemo.New "PlotlyColoredStyledHistograms" "Colored and Styled Histograms" "https://plot.ly/~TahaHachana/395"
                    ]
                plotlySitelet
                    "/chart/plotly-2d-histograms"
                    30
                    "Plotly 2D Histograms"
                    [
                        PlotlyDemo.New "PlotlyHistogram2DBivariate" "2D Histogram of a Bivariate Normal Distribution" "https://plot.ly/~TahaHachana/411"
                        PlotlyDemo.New "Plotly2DHistogramBinningStyling" "2D Histogram Binning and Styling Options" "https://plot.ly/~TahaHachana/414"
                        PlotlyDemo.New "Plotly2DHistogramOverlaidScatter" "2D Histogram Overlaid with a Scatter Chart" "https://plot.ly/~TahaHachana/415"
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
                for x in 1 .. 30 -> Chart x
            ]

[<assembly: Website(typeof<Website>)>]
do ()