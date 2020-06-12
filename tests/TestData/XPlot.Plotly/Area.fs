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

module ChartStackedArea =
    // stacked area
    let trace1 =
        Scatter(
            x = ["2014"; "2015"; "2016"; "2017"; "2018"; "2019"; "2020"],
            y = [0.0; 0.9; 0.9; 0.9; 3.7; 5.4; 5.7],
            name = "M",
            fill = "tonexty",
            stackgroup = "one"
        )

    let trace2 =
        Scatter(
            x = ["2014"; "2015"; "2016"; "2017"; "2018"; "2019"; "2020"],
            y = [0.0; 0.7; 2.3; 3.3; 4.3; 4.3; 6.0],
            name = "W",
            fill = "tonexty",
            stackgroup = "one"
        )

    let layout = Layout(title = "Stacked Area")

    let js =
        let chart =
            [trace1; trace2]
            |> Chart.Plot
            |> Chart.WithLayout layout

        chart.GetInlineJS()
