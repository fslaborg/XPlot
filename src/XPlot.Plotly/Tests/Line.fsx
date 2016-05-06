#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly

// Basic line plot
module Chart1 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17]
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [16; 5; 11; 9]
        )

    let data = [trace1; trace2]

    data
    |> Plotly.Plot
    |> Plotly.Show

// Line and scatter plot
module Chart2 =

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

    let data = [ trace1; trace2; trace3 ]

    let layout = Layout(title ="Line and Scatter Plot")

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Adding names to line and scatter plot
module Chart3 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers",
            name = "Scatter"
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines",
            name = "Lines"
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers",
            name = "Scatter + Lines"
        )

    let data = [ trace1; trace2; trace3 ]

    let layout = Layout(title ="Adding Names to Line and Scatter Plot")

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Line and scatter styling
module Chart4 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers",
            marker =
                Marker(
                    color = "rgb(219, 64, 82)",
                    size = 12.
                )
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines",
            line =
                Line(
                    color = "rgb(55, 128, 191)",
                    width = 3.
                )
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers",
            marker =
                Marker(
                    color = "rgb(128, 0, 128)",
                    size = 8.
                ),
            line =
                Line(
                    color = "rgb(128, 0, 128)",
                    width = 1.
                )
        )

    let data = [trace1; trace2; trace3]

    let layout = Layout(title = "Line and Scatter Styling")

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Colored and styled scatter plots
module Chart5 =

    let trace1 =
        Scatter(
            x = [52698; 43117],
            y = [53; 31],
            mode = "markers",
            name = "North America",
            text = ["United States"; "Canada"],
            marker =
                Marker(
                    color = "rgb(164, 194, 244)",
                    size = 12.,
                    line =
                        Line(
                            color = "white",
                            width = 0.5
                        )
                )
        )

    let trace2 =
        Scatter(
            x = [39317; 37236; 35650; 30066; 29570; 27159; 23557; 21046; 18007],
            y = [33; 20; 13; 19; 27; 19; 49; 44; 38],
            mode = "markers",
            name = "Europe",
            text = ["Germany"; "Britain"; "France"; "Spain"; "Italy"; "Czech Rep."; "Greece"; "Poland"],
            marker =
                Marker(
                    color = "rgb(255, 217, 102)",
                    size = 12.
                )
        )

    let trace3 =
        Scatter(
            x = [42952; 37037; 33106; 17478; 9813; 5253; 4692; 3899],
            y = [23; 42; 54; 89; 14; 99; 93; 70],
            mode = "markers",
            name = "Asia/Pacific",
            text = ["Australia"; "Japan"; "South Korea"; "Malaysia"; "China"; "Indonesia"; "Philippines"; "India"],
            marker =
                Marker(
                    color = "rgb(234, 153, 153)",
                    size = 12.
                )
        )

    let trace4 =
        Scatter(
            x = [19097; 18601; 15595; 13546; 12026; 7434; 5419],
            y = [43; 47; 56; 80; 86; 93; 80],
            mode = "markers",
            name = "Latin America",
            text = ["Chile"; "Argentina"; "Mexico"; "Venezuela"; "Venezuela"; "El Salvador"; "Bolivia"],
            marker =
                Marker(
                    color = "rgb(142; 124; 195)",
                    size = 12.
                )
        )

    let data = [trace1; trace2; trace3; trace4]

    let layout =
        Layout(
            title = "Quarter 1 Growth",
            xaxis =
                Xaxis(
                    title = "GDP per Capita",
                    showgrid = false,
                    zeroline = false
                ),
            yaxis =
                Yaxis(
                    title = "Percent",
                    showline = false
                )
        )

    (data, layout)
    |> Plotly.Plot
    |> Plotly.Show

// Styling line plot
module Chart6 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "lines",
            name = "Red",
            line =
                Line(
                    color = "rgb(219, 64, 82)",
                    width = 3.
                )
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines",
            name = "Blue",
            line =
                Line(
                    color = "rgb(55, 128, 191)",
                    width = 1.
                )
        )

    let layout =
        Layout(
            width = 500.,
            height = 500.
        )

    let data = [trace1; trace2]

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Line shape options for interpolation
module Chart7 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [1; 3; 2; 3; 1],
            mode = "lines+markers",
            name = "linear",
            line = Line(shape = "linear")
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [6; 8; 7; 8; 6],
            mode = "lines+markers",
            name = "spline",
            text = ["""tweak line smoothness<br>with "smoothing" in line object"""; """tweak line smoothness<br>with "smoothing" in line object"""; """tweak line smoothness<br>with "smoothing" in line object"""; """tweak line smoothness<br>with "smoothing" in line object"""; """tweak line smoothness<br>with "smoothing" in line object"""; """tweak line smoothness<br>with "smoothing" in line object"""],
            line = Line(shape = "spline")
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [11; 13; 12; 13; 11],
            mode = "lines+markers",
            name = "vhv",
            line = Line(shape = "vhv")
        )

    let trace4 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [16; 18; 17; 18; 16],
            mode = "lines+markers",
            name = "hvh",
            line = Line(shape = "hvh")
        )

    let trace5 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [21; 23; 22; 23; 21],
            mode = "lines+markers",
            name = "vh",
            line = Line(shape = "vh")
        )

    let trace6 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [26; 28; 27; 28; 26],
            mode = "lines+markers",
            name = "hv",
            line = Line(shape = "hv")
        )

    let data = [trace1; trace2; trace3; trace4; trace5; trace6]

    let layout =
        Layout(
            legend =
                Legend(
                    y = 0.5,
                    traceorder = "reversed",
                    font = Font(size = 16.)
                )
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Graph and axes titles
module Chart8 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [10; 15; 13; 17],
            mode = "markers",
            name = "Scatter"
        )

    let trace2 =
        Scatter(
            x = [2; 3; 4; 5],
            y = [16; 5; 11; 9],
            mode = "lines",
            name = "Lines"
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4],
            y = [12; 9; 15; 12],
            mode = "lines+markers",
            name = "Scatter and Lines"
        )

    let data = [trace1; trace2; trace3]

    let layout =
        Layout(
            title = "Title of the Graph",
            xaxis = Xaxis(title = "x-axis title"),
            yaxis = Yaxis(title = "y-axis title")
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Line dash
module Chart9 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [1; 3; 2; 3; 1],
            mode = "lines",
            name = "Solid",
            line =
                Line(
                    dash = "solid",
                    width = 4.
                )
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [6; 8; 7; 8; 6],
            mode = "lines",
            name = "dashdot",
            line =
                Line(
                    dash = "dashdot",
                    width = 4.
                )
        )

    let trace3 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [11; 13; 12; 13; 11],
            mode = "lines",
            name = "Solid",
            line =
                Line(
                    dash = "solid",
                    width = 4.
                )
        )

    let trace4 =
        Scatter(
            x = [1; 2; 3; 4; 5],
            y = [16; 18; 17; 18; 16],
            mode = "lines",
            name = "dot",
            line =
                Line(
                    dash = "dot",
                    width = 4.
                )
        )

    let data = [trace1; trace2; trace3; trace4]

    let layout =
        Layout(
            title = "Line Dash",
            xaxis =
                Xaxis(
                    range = [0.75; 5.25],
                    autorange = false
                ),
            yaxis =
                Yaxis(
                    range = [0.; 18.5],
                    autorange = false
                ),
            legend =
                Legend(
                    y = 0.5,
                    traceorder = "reversed",
                    font = Font(size = 16.)
                )
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Connect gaps between dots
module Chart10 =

    let trace1 =
        Scatter(
            x = [1; 2; 3; 4; 5; 6; 7; 8],
            y = [box 10; box 15; box null; box 17; box 14; box 12; box 10; box null; box 15],
            mode = "lines+markers",
            connectgaps = true
        )

    let trace2 =
        Scatter(
            x = [1; 2; 3; 4; 5; 6; 7; 8],
            y = [box 16; box null; box 13; box 10; box 8; box null; box 11; box 12],
            mode = "lines",
            connectgaps = true
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            title = "Connect the Gaps Between Data",
            showlegend = false
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Labelling lines with annotations
module Chart11 =

    let xData =
        [
            [2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2013];
            [2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2013];
            [2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2013];
            [2001; 2002; 2003; 2004; 2005; 2006; 2007; 2008; 2009; 2010; 2011; 2013]
        ]

    let yData =
        [
            [74; 82; 80; 74; 73; 72; 74; 70; 70; 66; 66; 69];
            [45; 42; 50; 46; 36; 36; 34; 35; 32; 31; 31; 28];
            [13; 14; 20; 24; 20; 24; 24; 40; 35; 41; 43; 50];
            [18; 21; 18; 21; 16; 14; 13; 18; 17; 16; 19; 23]
        ]

    let colors = ["rgba(67,67,67,1)"; "rgba(115,115,115,1)"; "rgba(49,130,189, 1)"; "rgba(189,189,189,1)"]

    let lineSize = [2.; 2.; 4.; 2.]

    let labels = ["Television"; "Newspaper"; "Internet"; "Radio"]

    let data =
        [
            for x in 0 .. (xData.Length - 1) do
                let result =
                    Scatter(
                        x = xData.[x],
                        y = yData.[x],
                        mode = "lines",
                        line =
                            Line(
                                color = colors.[x],
                                width = lineSize.[x]
                            )
                    )
                let result2 =
                    Scatter(
                        x = [xData.[x].[0]; xData.[x].[11]],
                        y = [yData.[x].[0]; yData.[x].[11]],
                        mode = "markers",
                        marker =
                            Marker(
                                color = colors.[x],
                                size = 12.
                            )
                    )
                yield result
                yield result2
        ]

    let layout =
        Layout(
            showlegend = false,
            height = 600.,
            width = 600.,
            xaxis =
                Xaxis(
                    showline = true,
                    showgrid = false,
                    showticklabels = true,
                    linecolor = "rgb(204,204,204)",
                    linewidth = 2.,
//                    autotick = false,
                    ticks = "outside",
                    tickcolor = "rgb(204,204,204)",
                    tickwidth = 2.,
                    ticklen = 5.,
                    tickfont =
                        Font(
                            family = "Arial",
                            size = 12.,
                            color = "rgb(82, 82, 82)"
                    )
            ),
            yaxis =
                Yaxis(
                    showgrid = false,
                    zeroline = false,
                    showline = false,
                    showticklabels = false
                ),
            autosize = false,
            margin =
                Margin(
                    autoexpand = false,
                    l = 100.,
                    r = 20.,
                    t = 100.
                ),
            annotations =
                [
                    Annotation(
                        xref = "paper",
                        yref = "paper",
                        x = 0.0,
                        y = 1.05,
                        xanchor = "left",
                        yanchor = "bottom",
                        text = "Main Source for News",
                        font =
                            Font(
                                family = "Arial",
                                size = 30.,
                                color = "rgb(37,37,37)"
                            ),
                        showarrow = false
                    );
                    Annotation(
                        xref = "paper",
                        yref = "paper",
                        x = 0.5,
                        y = -0.1,
                        xanchor = "center",
                        yanchor = "top",
                        text = "Source = Pew Research Center & Storytelling with data",
                        showarrow = false,
                        font =
                            Font(
                                family = "Arial",
                                size = 12.,
                                color = "rgb(150,150,150)"
                            )
                    )
                ]
        )

    let annotations =
        [
            for x in 0 .. (xData.Length - 1) do
                let result =
                    Annotation(
                        xref = "paper",
                        x = 0.05,
                        y = float yData.[x].[0],
                        xanchor = "right",
                        yanchor = "middle",
                        text = labels.[x] + " " + string yData.[x].[0] + "%",
                        showarrow = false,
                        font =
                            Font(
                                family = "Arial",
                                size = 16.,
                                color = "black"
                            )
                    )
                let result2 =
                    Annotation(
                        xref = "paper",
                        x = 0.95,
                        y = float yData.[x].[11],
                        xanchor = "left",
                        yanchor = "middle",
                        text = string yData.[x].[11] + "%",
                        font =
                            Font(
                                family = "Arial",
                                size = 16.,
                                color = "black"
                            ),
                        showarrow = false
                    )
                yield result
                yield result2
        ]

    layout.annotations <- (Seq.append layout.annotations annotations)

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// ====================
// Pipeline style tests
// ====================

let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

[sales; expenses]
|> Plotly.Line
|> Plotly.Show

let chart1 =
    sales
    |> Plotly.Line
    |> Plotly.Show

let chart2 =
    [sales; expenses]
    |> Plotly.Line
    |> Plotly.Show

let a = [1, 10.0; 2, 11.0; 3, 12.0]
let b = [0, 5.0; 1, 6.0; 2, 7.0; 3, 8.0]

[a; b]
|> Plotly.Line
|> Plotly.Show
