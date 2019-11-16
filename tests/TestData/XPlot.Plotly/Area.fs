namespace Area

open XPlot.Plotly

// Basic overlaid area chart
module Chart1 =
    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [0; 2; 3; 5],
            fill = "tozeroy"
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [3; 5; 1; 7],
            fill = "tonexty"
        )

    let js =
        let chart =
            [trace1; trace2]
            |> Chart.Plot

        chart.GetInlineJS()
        

// Overlaid Chart Without Boundary Lines
module Chart2 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [0; 2; 3; 5],
            fill = "tozeroy",
            mode = "none"
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [3; 5; 1; 7],
            fill = "tonexty",
            mode = "none"
        )

    let layout = Layout(title = "Overlaid Chart Without Boundary Lines")

    let js =
        let chart =
            [trace1; trace2]
            |> Chart.Plot
            |> Chart.WithLayout layout

        chart.GetInlineJS()

module PipeStyle =
    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

    let yValuesJS =
        let chart =
            sales
            |> List.map snd
            |> Chart.Area

        chart.GetInlineJS()

    let singleSeriesJS =
        let chart =
            sales
            |> Chart.Area
        
        chart.GetInlineJS()

    let multipleSeriesJS =
        let chart =
            [sales; expenses]
            |> Chart.Area
        
        chart.GetInlineJS()