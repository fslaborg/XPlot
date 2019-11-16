#r @"../../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"

// TESTED under CI now


open XPlot.Plotly

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Column
|> Chart.Show

// single series
sales
|> Chart.Column
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Column
|> Chart.Show

// Basic bar chart
module Chart1 =

    let data =
        [
            Bar(
                x = ["giraffes"; "orangutans"; "monkeys"],
                y = [20; 14; 23]
            )
        ]

    data
    |> Chart.Plot
    |> Chart.Show

// Grouped bar chart
module Chart2 =

    let trace1 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [20; 14; 23],
            name = "SF Zoo"
        )

    let trace2 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [12; 18; 29],
            name = "LA Zoo"
        )

    let data = [trace1; trace2]

    let layout = Layout(barmode = "group")
    
    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Stacked bar chart
module Chart3 =

    let trace1 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [20; 14; 23],
            name = "SF Zoo"
        )

    let trace2 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [12; 18; 29],
            name = "LA Zoo"
        )

    let data = [trace1; trace2]

    let layout = Layout(barmode = "stack")

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Bar chart with hover text
module Chart4 =

    let trace1 =
        Bar(
            x = ["Product A"; "Product B"; "Product C"],
            y = [20; 14; 23],
            text = ["27% market share"; "24% market share"; "19% market share"],
            marker =
                Marker(
                    color = "rgb(158,202,225)",
                    opacity = 0.6,
                    line =
                        Line(
                            color = "rbg(8,48,107)",
                            width = 1.5
                        )
                )
        )

    let data = [trace1]

    let layout = Layout(title = "January 2013 Sales Report")

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Bar chart with direct labels
module Chart5 =

    let xValue = ["Product A"; "Product B"; "Product C"]

    let yValue = [20.; 14.; 23.]

    let trace1 =
        Bar(
            x = xValue,
            y = yValue,
            text = ["27% market share"; "24% market share"; "19% market share"],
            marker =
                Marker(
                    color = "rgb(158;202;225)",
                    opacity = 0.6,
                    line =
                        Line(
                            color = "rbg(8;48;107)",
                            width = 1.5
                        )
                )
        )

    let data = [trace1]

    let layout = Layout(title = "January 2013 Sales Report")

    let annotations =
        xValue
        |> List.mapi (fun i _ ->
            Annotation(
                x = xValue.[i],
                y = yValue.[i],
                text = string yValue.[i],
                xanchor = "center",
                yanchor = "bottom",
                showarrow = false
            )
        )

    layout.annotations <- annotations
            
    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Grouped bar chart with direct labels
module Chart6 =

    let trace1 =
        Bar(
            x = ["Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec"],
            y = [20; 14; 25; 16; 18; 22; 19; 15; 12; 16; 14; 17],
            name = "Primary Product",
            marker =
                Marker(
                    color = "rgb(49,130,189)",
                    opacity = 0.7
                )
        )

    let trace2 =
        Bar(
            x = ["Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec"],
            y = [19; 14; 22; 14; 16; 19; 15; 14; 10; 12; 12; 16],
            name = "Secondary Product",
            marker =
                Marker(
                    color = "rgb(204,204,204)",
                    opacity = 0.5
                )
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            title = "2013 Sales Report",
            xaxis = Xaxis(tickangle = -45.),
            barmode = "group"
        )

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Customizing individual bar colors
module Chart7 =

    let trace1 =
        Bar(
            x = ["Feature A"; "Feature B"; "Feature C"; "Feature D"; "Feature E"],
            y = [20; 14; 23; 25; 22],
            marker =
                Marker(
                    color = ["rgba(204,204,204,1)"; "rgba(222,45,38,0.8)"; "rgba(204,204,204,1)"; "rgba(204,204,204,1)"; "rgba(204,204,204,1)"]
                )
        )

    let data = [trace1]

    let layout = Layout(title = "Least Used Feature")

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Bar chart with hover text
module Chart8 =

    let trace1 =
        Bar(
            x = ["Liam"; "Sophie"; "Jacob"; "Mia"; "William"; "Olivia"],
            y = [8.0; 8.0; 12.0; 12.0; 13.0; 20.0],
            text = ["4.17 below the mean"; "4.17 below the mean"; "0.17 below the mean"; "0.17 below the mean"; "0.83 above the mean"; "7.83 above the mean"],
            marker = Marker(color = "rgb(142,124,195)")
        )

    let data = [trace1]

    let layout =
        Layout(
            title = "Number of Graphs Made this Week",
            font = Font(family = "Raleway; snas-serif"),
            showlegend = false,
            xaxis = Xaxis(tickangle = -45.),
            yaxis =
                Yaxis(
                    zeroline = false
//                    grigwidth = 2.
                ),
            bargap = 0.05
        )

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Colored and styled bar chart 
module Chart9 =

    let trace1 =
        Bar(
            x = [1995; 1996; 1997; 1998; 1999; 2000; 2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2012],
            y = [219; 146; 112; 127; 124; 180; 236; 207; 236; 263; 350; 430; 474; 526; 488; 537; 500; 439],
            name = "Rest of world",
            marker = Marker(color = "rgb(55, 83, 109)")
        )

    let trace2 =
        Bar(
            x = [1995; 1996; 1997; 1998; 1999; 2000; 2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2012],
            y = [16; 13; 10; 11; 28; 37; 43; 55; 56; 88; 105; 156; 270; 299; 340; 403; 549; 499],
            name = "China",
            marker = Marker(color = "rgb(26, 118, 255)")
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            title = "US Export of Plastic Scrap",
            xaxis =
                Xaxis(
                    tickfont =
                        Font(
                            size = 14.,
                            color = "rgb(107, 107, 107)"
                        )
                ),
            yaxis =
                Yaxis(
                    title = "USD (millions)",
                    titlefont =
                        Font(
                            size = 16.,
                            color = "rgb(107, 107, 107)"
                        ),
                    tickfont =
                        Font(
                            size = 14.,
                            color = "rgb(107, 107, 107)"
                        )
                ),
            legend =
                Legend(
                    x = 0.,
                    y = 1.0,
                    bgcolor = "rgba(255, 255, 255, 0)",
                    bordercolor = "rgba(255, 255, 255, 0)"
                ),
            barmode = "group",
            bargap = 0.15
//            bargroupgap = 0.1
        )

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// Waterfall bar chart
module Chart10 =

    let xData =
        [
            "Product Revenue";
            "Services Revenue";
            "Total Revenue";
            "Fixed Costs";
            "Variable Costs";
            "Total Costs";
            "Total"
        ]

    let yData = [400; 660; 660; 590; 400; 400; 340]

    let textList = ["$430K"; "$260K"; "$690K"; "$-120K"; "$-200K"; "$-320K"; "$370K"]

    let trace1 =
        Bar(
            x = xData,
            y = [0; 430; 0; 570; 370; 370; 0],
            marker = Marker(color = "rgba(1,1,1,0.0)")
        )

    let trace2 =
        Bar(
            x = xData,
            y = [430; 260; 690; 0; 0; 0; 0],
            marker = 
                Marker(
                    color = "rgba(55,128,191,0.7)",
                    line =
                        Line(
                            color = "rgba(55,128,191,1.0)",
                            width = 2.
                        )
                )
        )

    let trace3 =
        Bar(
            x = xData,
            y = [0; 0; 0; 120; 200; 320; 0],
            marker =
                Marker(
                    color = "rgba(219, 64, 82, 0.7)",
                    line =
                        Line(
                            color = "rgba(219, 64, 82, 1.0)",
                            width = 2.
                        )
                )
        )

    let trace4 =
        Bar(
            x = xData,
            y = [0; 0; 0; 0; 0; 0; 370],
            marker =
                Marker(
                    color = "rgba(50, 171, 96, 0.7)",
                    line =
                        Line(
                            color = "rgba(50,171,96,1.0)",
                            width = 2.
                        )
                )
        )

    let data = [trace1; trace2; trace3; trace4]

    let layout =
        Layout(
            title = "Annual Profit 2015",
            barmode = "stack",
            paper_bgcolor = "rgba(245,246,249,1)",
            plot_bgcolor = "rgba(245,246,249,1)",
            width = 600.,
            height = 600.,
            showlegend = false
        )

    let annotations =
        [0 .. 6]
        |> List.map (fun i ->
            Annotation(
                x = xData.[i],
                y = float yData.[i],
                text = textList.[i],
                font =
                    Font(
                        family = "Arial",
                        size = 14.,
                        color = "rgba(245,246,249,1)"
                    ),
                showarrow = false
            )
    )

    layout.annotations <- annotations

    data
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show

// ====================
// Pipeline style tests
// ====================

// Basic bar chart
module Chart1' =

    let data = ["giraffes", 20; "orangutans", 14; "monkeys", 23]

    data
    |> Chart.Column
    |> Chart.Show

// Grouped bar chart
module Chart2' =

    let trace1 = ["giraffes", 20; "orangutans", 14; "monkeys", 23]
    let trace2 = ["giraffes", 12; "orangutans", 18; "monkeys", 29]

    let layout = Layout(barmode = "group")
    
    [trace1; trace2]
    |> Chart.Column
    |> Chart.WithLayout layout
    |> Chart.Show

// Stacked bar chart
module Chart3' =

    let trace1 = ["giraffes", 20; "orangutans", 14; "monkeys", 23]
    let trace2 = ["giraffes", 12; "orangutans", 18; "monkeys", 29]

    let layout = Layout(barmode = "stack")

    [trace1; trace2]
    |> Chart.Column
    |> Chart.WithLabels ["SF Zoo"; "LA Zoo"]
    |> Chart.WithLayout layout
    |> Chart.Show

[20; 14; 23]
|> Chart.Column
|> Chart.Show
