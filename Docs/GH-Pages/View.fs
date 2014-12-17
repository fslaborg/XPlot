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

let highcharts =
    Skin.withHighchartsTemplate
        "XPlot · Highcharts Support"
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