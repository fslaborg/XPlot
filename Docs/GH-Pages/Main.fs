namespace HtmlApp

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets
open Model
open View

module Site =

//    let ( => ) text url =
//        A [HRef url] -< [Text text]

//    let Links (ctx: Context<Action>) =
//        UL [
//            LI ["Home" => ctx.Link Home]
//            LI ["About" => ctx.Link About]
//        ]

//    let HomePage =
//        Skin.WithTemplate "HomePage" <| fun ctx ->
//            [
//                Div [Text "HOME"]
////                Div [new Controls.EntryPoint()]
////                Links ctx
//            ]
//
//    let AboutPage =
//        Skin.WithTemplate "AboutPage" <| fun ctx ->
//            [
//                Div [Text "ABOUT"]
////                Links ctx
//            ]

    let chartSitelet url id title demos =
        Sitelet.Content
            url
            (Chart id)
            <| View.chart title demos

    let dynamicChartSitelet url id title demos =
        Sitelet.Content
            url
            (Chart id)
            <| View.dynamicChart title demos

    let mapchartSitelet url id title demos =
        Sitelet.Content
            url
            (Chart id)
            <| View.mapchart title demos

    let Main =
        Sitelet.Sum [
            Sitelet.Content "/" Home View.home
            Sitelet.Content "/google-charts" GoogleCharts View.googleCharts
            Sitelet.Content "/highcharts" Highcharts View.highcharts
            chartSitelet
                "/chart/google-annotation-chart"
                1
                "Google Annotation Chart"
                [Demo.New "c5840517d75dcff6c83b" "Google Annotation Chart"]
            chartSitelet
                "/chart/google-area-chart"
                2
                "Google Area Chart"
                [Demo.New "a78621f0f95f4b411fa5" "Google Area Chart"]
            chartSitelet
                "/chart/google-bar-chart"
                3
                "Google Bar Chart"
                [Demo.New "4874aebfce1f4b588f5e" "Google Bar Chart"]
            chartSitelet
                "/chart/google-bubble-chart"
                4
                "Google Bubble Chart"
                [Demo.New "d07cbc8b0233ef94ebf8" "Google Bubble Chart"]
            chartSitelet
                "/chart/google-calendar-chart"
                5
                "Google Calendar Chart"
                [Demo.New "e83e6f4f6e5bc05e9933" "Google Calendar Chart"]
            chartSitelet
                "/chart/google-candlestick-chart"
                6
                "Google Candlestick Chart"
                [Demo.New "b740f58188f4cddfc0ba" "Google Candlestick Chart"]
            chartSitelet
                "/chart/google-column-chart"
                7
                "Google Column Chart"
                [Demo.New "b2135ec0e93d28295bbb" "Google Column Chart"]
            chartSitelet
                "/chart/google-combo-chart"
                8
                "Google Combo Chart"
                [Demo.New "0cb2f60010398f1be9ab" "Google Combo Chart"]
            chartSitelet
                "/chart/google-gauge-chart"
                9
                "Google Gauge Chart"
                [Demo.New "6fc88dd6024cf683a33f" "Google Gauge Chart"]
            chartSitelet
                "/chart/google-geo-chart"
                10
                "Google Geo Chart"
                [Demo.New "86f6a6dcf9ec4bf88930" "Google Geo Chart"]
            chartSitelet
                "/chart/google-histogram-chart"
                11
                "Google Histogram Chart"
                [Demo.New "9d202603aae1df40303b" "Google Histogram Chart"]
            chartSitelet
                "/chart/google-line-chart"
                12
                "Google Line Chart"
                [Demo.New "8a8e831364c2a965f646" "Google Line Chart"]
            chartSitelet
                "/chart/google-map-chart"
                13
                "Google Map Chart"
                [Demo.New "e723a85381063a9f9e16" "Google Map Chart"]
            chartSitelet
                "/chart/google-pie-chart"
                14
                "Google Pie Chart"
                [Demo.New "59d5f8a0ba8cf3ada86e" "Google Pie Chart"]
            chartSitelet
                "/chart/google-sankey-diagram"
                15
                "Google Sankey Diagram"
                [Demo.New "cead0cdd0e153a7c078e" "Google Sankey Diagram"]
            chartSitelet
                "/chart/google-scatter-chart"
                16
                "Google Scatter Chart"
                [Demo.New "a272c947396e3c67ddf4" "Google Scatter Chart"]
            chartSitelet
                "/chart/google-stepped-area-chart"
                17
                "Google Stepped Area"
                [Demo.New "734c913a859cadca6387" "Google Stepped Area"]
            chartSitelet
                "/chart/google-timeline-chart"
                18
                "Google Timeline Chart"
                [Demo.New "d23a9ff69ea5eb0d1b81" "Google Timeline Chart"]
            chartSitelet
                "/chart/google-table-chart"
                19
                "Google Table Chart"
                [Demo.New "d3db1c973285b612550e" "Google Table Chart"]
            chartSitelet
                "/chart/google-treemap-chart"
                20
                "Google Treemap Chart"
                [Demo.New "7a0f8caf46e0b4461cce" "Google Treemap Chart"]
        ]

[<Sealed>]
type Website() =
    interface IWebsite<Action> with
        member this.Sitelet = Site.Main
        member this.Actions =
            [
                yield Home
                yield GoogleCharts
                yield Highcharts
                for x in 1 .. 20 -> Chart x
            ]

[<assembly: Website(typeof<Website>)>]
do ()