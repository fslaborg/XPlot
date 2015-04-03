module HtmlApp.View

open IntelliFactory.Html

let home =
    Skin.withHomeTemplate
        "XPlot · F# Data Visualization"
        <| fun _ -> []

let googleCharts =
    Skin.withGoogleTemplate
        "XPlot · Google Charts Support"
        <| fun _ -> []

let plotly =
    Skin.withPlotlyTemplate
        "XPlot · Plotly Support"
        <| fun _ -> []

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
     Skin.withChartTemplate
        ("XPlot · " + title)
        <| fun _ ->
            [
                for demo in demos do
                    let demoId = demo.Id
                    let code =
                        let dir = __SOURCE_DIRECTORY__
                        let path = dir + "/Code/" + demoId + ".txt"
                        System.IO.File.ReadAllText path
                    yield Div [Id demoId] -< [
                        H2 [Class "page-header demo-header"]
                        -< [Text demo.Heading]
                        Div [
                            Pre [
                                Code [Class "fsharp"]
                                -< [Text code]
                            ]
                        ]
                        IFrame [
                            Src <| "../iframe/" + demoId + ".html"
                            Class "chart-iframe"
                        ]
                    ]
            ]

type PlotlyDemo =
    {
        Id: string
        Heading: string
        PlotUrl: string
    }

    static member New id heading plotUrl =
        {
            Id = id
            Heading = heading
            PlotUrl = plotUrl
        }

open System.Text.RegularExpressions

let plotlyChart title (demos: PlotlyDemo list) =
     Skin.withChartTemplate
        ("XPlot · " + title)
        <| fun _ ->
            [
                for demo in demos do
                    let demoId = demo.Id
                    let code =
                        let dir = __SOURCE_DIRECTORY__
                        let path = dir + "/Code/" + demoId + ".txt"
                        System.IO.File.ReadAllText path
                    let plotId =
                        Regex("TahaHachana/(\d+)").Match(demo.PlotUrl)
                        |> fun x -> x.Groups.[1].Value
                    let plotScreenshot = demo.PlotUrl + ".png" //"https://plot.ly/~TahaHachana/" + plotId + ".png"
                    yield Div [Id demoId] -< [
                        H2 [Class "page-header demo-header"]
                        -< [Text demo.Heading]
                        Div [
                            Pre [
                                Code [Class "fsharp"]
                                -< [Text code]
                            ]
                        ]
                        IFrame [
                            Width "640"
                            Height "480"
                            FrameBorder "0"
                            NewAttribute "seamless" "seamless"
                            Scrolling "no"
                            Src <| demo.PlotUrl + ".embed?width=640&height=480"
//                            Class "chart-iframe"
                        ]

//                        Div [
//                            A [
//                                HRef demo.PlotUrl
//                                Target "_blank"
//                                Style "display: block; text-align: center;"
//                            ] -< [
//                                Img [
//                                    Src plotScreenshot
//                                    Style "max-width: 100%;"
//                                    NewAttribute "onerror" "this.onerror=null;this.src='https://plot.ly/404.png';"
//                                ]
//                            ]
//                            Script [
//                                Src "https://plot.ly/embed.js"
//                                HTML5.Data "plotly" <| "TahaHachana:" + plotId
//                            ]
//                        ]
                    ]
            ]

