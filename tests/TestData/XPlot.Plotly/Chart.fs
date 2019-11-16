namespace Chart

open System
open XPlot.Plotly

module Chart1 =
    type Chartable = { XD:DateTime; YD:float }

    // Raw Data
    let tD1 =
        [|
            { XD = System.DateTime.Parse("5/13/2016"); YD = 4.0 }
            { XD = System.DateTime.Parse("5/12/2016"); YD = 6.0 }
            { XD = System.DateTime.Parse("5/9/2016");  YD = 1.5 }
            { XD = System.DateTime.Parse("5/20/2016"); YD = 8.0 }
        |]
    // Prediction Line
    let tD2 =
        [|
            { XD = System.DateTime.Parse("5/9/2016");  YD = 3.0 }
            { XD = System.DateTime.Parse("5/20/2016"); YD = 7.0 }
        |]
    // Upper Bound
    let tD3 =
        [|
            { XD = System.DateTime.Parse("5/9/2016");  YD = 4.0 }
            { XD = System.DateTime.Parse("5/20/2016"); YD = 7.0 }
        |]
    // Lower Bound
    let tD4 =
        [|
            { XD = System.DateTime.Parse("5/9/2016");  YD = 2.0 }
            { XD = System.DateTime.Parse("5/20/2016"); YD = 7.0 }
        |]

    let getXVal (data:Chartable array) =
        data
        |> Array.map(fun x -> x.XD.Date) 
        |> Array.sortBy(fun x -> x)

    let getYVal (data:Chartable array) =
        data
        |> Array.sortBy(fun y -> y.XD.Date)
        |> Array.map(fun y -> y.YD)

    let rawDataX = 
        tD1
        |> getXVal

    let rawDataY = 
        tD1
        |> getYVal

    let predLineX = 
        tD2
        |> getXVal

    let predLineY = 
        tD2
        |> getYVal

    let upErrX = 
        tD3
        |> getXVal

    let upErrY = 
        tD3
        |> getYVal

    let loErrX = 
        tD4
        |> getXVal

    let loErrY = 
        tD4
        |> getYVal

    let rawData =
        Scatter(
            x = rawDataX,
            y = rawDataY,
            mode = "lines+markers",
            name = "Raw Data"
        )
    let predictionLine =
        Scatter(
            x = predLineX,
            y = predLineY, 
            mode = "lines+markers",
            name = "Prediction Line"
        )
    let upperError =
        Scatter(
            x = upErrX,
            y = upErrY,
            fill = "tonexty", 
            fillcolor = "rgba(255, 153, 0, 0.3)", 
            mode = "text",
            name = "Upper Bound"
        )
    let lowerError =
        Scatter(
            x = loErrX,
            y = loErrY,
            fill = "tonexty", 
            fillcolor = "rgba(255, 153, 0, 0.3)",
            mode = "text", 
            name = "Lower Bound"
        )

    let js =
        let chart =
            [rawData; predictionLine; upperError; lowerError]
            |> Chart.Plot
        chart.GetInlineJS()

module Chart2 =
    let data = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]

    let options =
        Options(
            title = "Company Performance",
            height = 400.0,
            width = 400.0,
            showlegend = true)

    let js =
        let chart =
            data
            |> Chart.Line
            |> Chart.WithOptions options
            |> Chart.WithXTitle "Year"
            |> Chart.WithYTitle "Total"
        chart.GetInlineJS()

module Chart3 =
    let data =
        [
            ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
            ["2013", 798; "2014", 850; "2015", 760; "2016", 900]
        ]

    let js =
        let chart =
            data
            |> Chart.Line
            |> Chart.WithLabels ["Sales"; "Expenses"]
        chart.GetInlineJS()

