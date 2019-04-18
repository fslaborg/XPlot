#r @"../../../bin/XPlot.Plotly/net45/XPlot.Plotly.dll"

open XPlot.Plotly

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

// y values only
sales
|> List.map snd
|> Chart.Scatter
|> Chart.Show

// single series
sales
|> Chart.Scatter
|> Chart.Show

// multiple series
[sales; expenses]
|> Chart.Scatter
|> Chart.Show

// Line and scatter plot
module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers"
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines"
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers"
        )

    [trace1; trace2; trace3]
    |> Chart.Plot
    |> Chart.Show

// Data labels hover
module Chart2 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [1; 6; 3; 6; 1],
            mode = "markers",
            name = "Team A",
            text = ["A-1"; "A-2"; "A-3"; "A-4"; "A-5"],
            marker = Marker (size = 12.)
        )

    let trace2 =
        Scatter(
            x = [1.5; 2.5; 3.5; 4.5; 5.5],
            y = [4; 1; 7; 1; 4],
            mode = "markers",
            name = "Team B",
            text = ["B-a"; "B-b"; "B-c"; "B-d"; "B-e"],
            marker = Marker (size = 12.)
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            xaxis = Xaxis(range = [0.75; 5.25]),
            yaxis = Yaxis(range = [0.; 8.]),
            title = "Data Labels Hover"
        )

    (data, layout)
    |> Chart.Plot
    |> Chart.Show

// Data labels on the plot
module Chart3 =
    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [1; 6; 3; 6; 1],
            mode = "markers+text",
            name = "Team A",
            text = ["A-1"; "A-2"; "A-3"; "A-4"; "A-5"],
            textposition = "top center",
            textfont = Textfont(family = "Raleway; sans-serif"),
            marker = Marker(size = 12.)
        )

    let trace2 =
        Scatter(
            x = [1.5; 2.5; 3.5; 4.5; 5.5],
            y = [4; 1; 7; 1; 4],
            mode = "markers+text",
            name = "Team B",
            text = ["B-a"; "B-b"; "B-c"; "B-d"; "B-e"],
            textfont = Textfont(family = "Times New Roman"),
            textposition = "bottom center",
            marker = Marker(size = 12.)
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            xaxis = Xaxis(range = [ 0.75; 5.25 ]),
            yaxis = Yaxis(range = [0.; 8.]),
            legend =
                Legend(
                    y = 0.5,
                    font =
                        Font(
                            family = "Arial; sans-serif",
                            color = "grey"
                        )
                ),
            title ="Data Labels on the Plot"
        )

    (data, layout)
    |> Plotly.Plot
    |> Chart.Show

// Scatter plot with a color dimension
module Chart4 =

    let trace1 =
        Scatter(
            y = [5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5],
            mode = "markers",
            marker =
                Marker(
                    size = 40.,
                    color = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15; 16; 17; 18; 19; 20; 21; 22; 23; 24; 25; 26; 27; 28; 29; 30; 31; 32; 33; 34; 35; 36; 37; 38; 39]
                )
        )

    let data = [trace1]

    let layout = Layout(title = "Scatter Plot with a Color Dimension")

    (data, layout)
    |> Chart.Plot
    |> Chart.Show

// Categorical dot plot
module Chart5 =

    let country = ["Switzerland (2011)"; "Chile (2013)"; "Japan (2014)"; "United States (2012)"; "Slovenia (2014)"; "Canada (2011)"; "Poland (2010)"; "Estonia (2015)"; "Luxembourg (2013)"; "Portugal (2011)"]

    let votingPop = [40.; 45.7; 52.; 53.6; 54.1; 54.2; 54.5; 54.7; 55.1; 56.6]

    let regVoters = [49.1; 42.; 52.7; 84.3; 51.7; 61.1; 55.3; 64.2; 91.1; 58.9]

    let trace1 =
        Scatter(
            x = votingPop,
            y = country,
            mode = "markers",
            name = "Percent of estimated voting age population",
            marker =
                Marker(
                    color = "rgba(156; 165; 196; 0.95)",
                    line =
                        Line(
                            color = "rgba(156; 165; 196; 1.0)",
                            width = 1.
                       ),
                    symbol = "circle",
                    size = 16.
            )
        )

    let trace2 =
        Scatter(
            x = regVoters,
            y = country,
            mode = "markers",
            name = "Percent of estimated registered voters",
            marker =
                Marker(
                    color = "rgba(204; 204; 204; 0.95)",
                    line =
                        Line(
                            color = "rgba(217; 217; 217; 1.0)",
                            width = 1.
                       ),
                    symbol = "circle",
                    size = 16.
            )
        )

    let data = [trace1; trace2];

    let layout =
        Layout(
            title = "Votes cast for ten lowest voting age population in OECD countries",
            xaxis =
                Xaxis(
                    showgrid = false,
                    showline = true,
                    linecolor = "rgb(102, 102, 102)",
                    titlefont = Font(color = "rgb(204, 204, 204)"),
                    tickfont = Font(color = "rgb(102, 102, 102)"),
                    tickmode = "auto",
                    dtick = 10,
                    ticks = "outside",
                    tickcolor = "rgb(102, 102, 102)"
                ),
            margin =
                Margin(
                    l = 140.,
                    r = 40.,
                    b = 50.,
                    t = 80.
                ),
            legend =
                Legend(
                    font = Font(size = 10.),
                    yanchor = "middle",
                    xanchor = "right"
                ),
            width = 600.,
            height = 600.,
            paper_bgcolor = "rgb(254, 247, 234)",
            plot_bgcolor = "rgb(254, 247, 234)",
            hovermode = "closest"
        )

    (data, layout)
    |> Chart.Plot
    |> Chart.Show


// Multiple y axes plot
module Chart6 =

    let trace1 = Scatter(x = [1; 2; 3; 4], y = [10; 15; 13; 17])

    let trace2 = Scatter(x = [2; 3; 4; 5], y = [160; 52; 114; 92], yaxis = "y2")
    
    let layout = 
      Layout (
        yaxis = Yaxis(title="Axis 1"),
        yaxis2 = Yaxis(title="Axis 2", overlaying="y", side="right")
    )
    
    Chart.Plot ([trace1; trace2], layout)
    |> Chart.Show




// ====================
// Pipeline stype tests
// ====================

[8., 12.; 4., 5.5; 11., 14.; 4., 5.; 3., 3.5; 6.5, 7.]
|> Chart.Scatter
|> Chart.Show

let rnd = new System.Random(0)
let data = [for i in 1 .. 1000 -> (rnd.Next(10),rnd.Next(10))]

data
|> Chart.Scatter
|> Chart.Show

[12.; 5.5; 14.; 5.; 3.5; 7.]
|> Chart.Scatter
|> Chart.Show
