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
                for x in 1 .. 4 -> Chart x
            ]

[<assembly: Website(typeof<Website>)>]
do ()