module HtmlApp.Skin

open IntelliFactory.WebSharper.Sitelets
open Model

type Page =
    {
        Title : string
        Body : list<Content.HtmlElement>
    }

let MainTemplate =
    Content.Template<Page>("~/Home.html")
        .With("title", fun x -> x.Title)
        .With("body", fun x -> x.Body)

let googleTemplate =
    Content.Template<Page>("~/GoogleCharts.html")
        .With("title", fun x -> x.Title)
        .With("body", fun x -> x.Body)

let highchartsTemplate =
    Content.Template<Page>("~/Highcharts.html")
        .With("title", fun x -> x.Title)
        .With("body", fun x -> x.Body)

let chartTemplate =
    Content.Template<Page>("~/Chart.html")
        .With("title", fun x -> x.Title)
        .With("body", fun x -> x.Body)

let WithTemplate template title body : Content<Action> =
    Content.WithTemplate template <| fun context ->
        {
            Title = title
            Body = body context
        }

let withHomeTemplate title body = WithTemplate MainTemplate title body
let withGoogleTemplate title body  = WithTemplate googleTemplate title body
let withHighchartsTemplate title body  = WithTemplate highchartsTemplate title body
let withChartTemplate title body  = WithTemplate chartTemplate title body
