module HtmlApp.View

open HtmlApp.Model
open HtmlApp.Skin
open IntelliFactory.Html

let home =
    Skin.withHomeTemplate "XPlot" <| fun ctx ->
        [

        ]

let googleCharts =
    Skin.withGoogleTemplate "XPlot · Google Charts Support" <| fun ctx ->
        [
        ]


let highcharts =
    Skin.withHighchartsTemplate "XPlot · Highcharts Support" <| fun ctx ->
        [

        ]

type Demo =
    {
        Id : string
        Heading : string
    }

    static member New id heading =
        {
            Id = id
            Heading = heading
            
        }

let chart title (demos:Demo list) =
     Skin.withChartTemplate ("XPlot · " + title) <| fun ctx ->
        [
            for demo in demos do
                let demoId = demo.Id
                yield Div [Id demoId] -< [
                    H2 [Class "page-header demo-header"] -< [Text demo.Heading]
                    Div [Id "gist"] -< [
                        Script [Src <| "https://gist.github.com/TahaHachana/" + demoId + ".js"]
                    ]
                    IFrame [Src <| "../iframe/" + demoId + ".html"; Class "chart-iframe"]
                ]
        ]

let dynamicChart title (demos:Demo list) =
     Skin.withChartTemplate ("FsPlot · " + title) <| fun ctx ->
        [
            for demo in demos do
                let demoId = demo.Id
                yield Div [Id demoId] -< [
                    H2 [Class "page-header demo-header"] -< [Text demo.Heading]
                    Div [Id "gist"] -< [
                        Script [Src <| "https://gist.github.com/TahaHachana/" + demoId + ".js"]
                    ]
//                    IFrame [Src <| "../iframe/" + demoId + ".html"; Class "chart-iframe"]
                ]
        ]

let mapchart title (demos:Demo list) =
     Skin.withChartTemplate ("FsPlot · " + title) <| fun ctx ->
        [
            for demo in demos do
                let demoId = demo.Id
                yield Div [Id demoId] -< [
                    H2 [Class "page-header demo-header"] -< [Text demo.Heading]
                    Div [Id "gist"] -< [
                        Script [Src <| "https://gist.github.com/TahaHachana/" + demoId + ".js"]
                    ]
                    IFrame [Src <| "../iframe/" + demoId + ".html"; Class "map-chart-iframe"]
                ]
        ]

