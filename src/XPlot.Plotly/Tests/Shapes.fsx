#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly
open System

// Highlighting Time Series Regions with Rectangle Shapes
module Chart1 =
    let data =
        Scatter(
              x = ["2015-02-01"; "2015-02-02"; "2015-02-03"; "2015-02-04"; "2015-02-05";
                  "2015-02-06"; "2015-02-07"; "2015-02-08"; "2015-02-09"; "2015-02-10";
                  "2015-02-11"; "2015-02-12"; "2015-02-13"; "2015-02-14"; "2015-02-15";
                  "2015-02-16"; "2015-02-17"; "2015-02-18"; "2015-02-19"; "2015-02-20";
                  "2015-02-21"; "2015-02-22"; "2015-02-23"; "2015-02-24"; "2015-02-25";
                  "2015-02-26"; "2015-02-27"; "2015-02-28"],
              y = [-14; -17; -8; -4; -7; -10; -12; -14; -12; -7; -11; -7; -18; -14; -14;
                  -16; -13; -7; -8; -14; -8; -3; -9; -9; -4; -13; -9; -6],
              mode = "line",
              name = "temperature"
        )

    let layout =
        Layout(

            // to highlight the timestamp we use shapes and create a rectangular

            shapes = [
                // 1st highlight during Feb 4 - Feb 6
                Shape(
                    ``type`` = "rect",
                    // x-reference is assigned to the x-values
                    xref = "x",
                    // y-reference is assigned to the plot paper [0;1]
                    yref = "paper",
                    x0 = "2015-02-04",
                    y0 = 0,
                    x1 = "2015-02-06",
                    y1 = 1,
                    fillcolor = "#d3d3d3",
                    opacity = 0.2,
                    line = Line(width = 0)
                );

                // 2nd highlight during Feb 20 - Feb 23
                Shape(
                    ``type`` = "rect",
                    xref = "x",
                    yref = "paper",
                    x0 = "2015-02-20",
                    y0 = 0,
                    x1 = "2015-02-22",
                    y1 = 1,
                    fillcolor = "#d3d3d3",
                    opacity = 0.2,
                    line = Line(width = 0)
                )
            ],
            height = 500.,
            width = 500.
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

#r "../../../packages/MathNet.Numerics/lib/net40/MathNet.Numerics.dll"

open MathNet.Numerics
open MathNet.Numerics.Distributions

let normalArray mean stddev size =
    let normal = new Normal(mean, stddev)
    normal.Samples()
    |> Seq.take size
    |> Seq.toArray

// Highlighting Clusters of Scatter Points with Circle Shapes
module Chart2 =

    let x0 = normalArray 2. 0.45 300
    let y0 = normalArray 2. 0.45 300

    let x1 = normalArray 6. 0.4 200
    let y1 = normalArray 6. 0.4 200

    let x2 = normalArray 4. 0.3 200
    let y2 = normalArray 4. 0.3 200

    let data =
        [
            Scatter(
                x = x0,
                y = y0,
                mode = "markers"
            )
            Scatter(
                x = x1,
                y = y1,
                mode = "markers"
            )
            Scatter(
                x = x2,
                y = y2,
                mode = "markers"
            )
            Scatter(
                x = x1,
                y = y0,
                mode = "markers"
            )
        ]

    let layout =
        Layout(
            shapes =
                [
                    Shape(
                        ``type`` = "circle",
                        xref = "x",
                        yref = "y",
                        x0 = Array.min x0,
                        y0 = Array.min y0,
                        x1 = Array.max x0,
                        y1 = Array.max y0,
                        opacity = 0.2,
                        fillcolor = "blue",
                        line = Line(color = "blue")
                    )
                    Shape(
                        ``type`` = "circle",
                        xref = "x",
                        yref = "y",
                        x0 = Array.min x1,
                        y0 = Array.min y1,
                        x1 = Array.max x1,
                        y1 = Array.max y1 ,
                        opacity = 0.2,
                        fillcolor = "orange",
                        line = Line(color = "orange")
                    )
                    Shape(
                        ``type`` = "circle",
                        xref = "x",
                        yref = "y",
                        x0 = Array.min x2,
                        y0 = Array.min y2,
                        x1 = Array.max x2,
                        y1 = Array.max y2,
                        opacity = 0.2,
                        fillcolor = "green",
                        line = Line(color = "green")
                    )
                    Shape(
                        ``type`` = "circle",
                        xref = "x",
                        yref = "y",
                        x0 = Array.min x1,
                        y0 = Array.min y0,
                        x1 = Array.max x1,
                        y1 = Array.max y0,
                        opacity = 0.2,
                        fillcolor = "red",
                        line = Line(color = "red")
                    )
            ],
            height = 400.,
            width = 480.,
            showlegend = false
    )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Vertical and Horizontal Lines Positioned Relative to the Axes
module Chart3 =

    let trace1 =
        Scatter(
            x = [2.; 3.5; 6.],
            y = [1.; 1.5; 1.],
            text = ["Vertical Line"; "Horizontal Dashed Line"; "Diagonal dotted Line"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Vertical and Horizontal Lines Positioned Relative to the Axes",
            xaxis = Xaxis(range = [0; 7]),
            yaxis = Yaxis(range = [0.; 2.5]),
//            width = 500.,
//            height = 500.,
            shapes =
                [
                    //line vertical
                    Shape(
                        ``type`` = "line",
                        x0 = 1,
                        y0 = 0,
                        x1 = 1,
                        y1 = 2,
                        line =
                            Line(
                                color = "rgb(55, 128, 191)",
                                width = 3
                            )
                    )
                    //Line Horizontal
                    Shape(
                        ``type`` = "line",
                        x0 = 2,
                        y0 = 2,
                        x1 = 5,
                        y1 = 2,
                        line =
                            Line(
                                color = "rgb(50, 171, 96)",
                                width = 4,
                                dash = "dashdot"
                            )
                    )
                    //Line Diagonal
                    Shape(
                        ``type`` = "line",
                        x0 = 4,
                        y0 = 0,
                        x1 = 6,
                        y1 = 2,
                        line =
                            Line(
                                color = "rgb(128, 0, 128)",
                                width = 4,
                                dash = "dot"
                            )
                    )
            ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Circle
module Chart4 =
    let trace1 =
        Scatter(
            x = [1.5; 3.5],
            y = [0.75; 2.5],
            text = ["Unfilled Circle"; "Filled Circle"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Circles",
            xaxis =
                Xaxis(
                    range = [0.; 4.5],
                    zeroline = false
                ),
            yaxis = Yaxis(range = [0.; 4.5]),
//            width = 500.,
//            height = 500.,
            shapes = [
                // Unfilled Circle
                Shape(
                    ``type`` = "circle",
                    xref = "x",
                    yref = "y",
                    x0 = 1,
                    y0 = 1,
                    x1 = 3,
                    y1 = 3,
                    line = Line(color = "rgba(50, 171, 96, 1)")
                )
                // Filled Circle
                Shape(
                    ``type`` = "circle",
                    xref = "x",
                    yref = "y",
                    fillcolor = "rgba(50, 171, 96, 0.7)",
                    x0 = 3,
                    y0 = 3,
                    x1 = 4,
                    y1 = 4,
                    line = Line(color = "rgba(50, 171, 96, 1)")
                )
            ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Rectangle Positioned Relative to the Plot and to the Axes
module chart4 =
    let trace1 =
        Scatter(
            x = [1.5; 3.],
            y = [2.5; 2.5],
            text = ["Rectangle reference to the plot"; "Rectangle reference to the axes"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Rectangles Positioned Relative to the Plot and to the Axes",
            xaxis =
                Xaxis(
                    range = [0; 4],
                    showgrid = false
                ),
            yaxis = Yaxis(range = [0; 4]),
//            width = 800.,
//            height = 600.,
            shapes =
                [
                    //Rectangle reference to the axes
                    Shape(
                        ``type`` = "rect",
                        xref = "x",
                        yref = "y",
                        x0 = 2.5,
                        y0 = 0,
                        x1 = 3.5,
                        y1 = 2,
                        line =
                            Line(
                                color = "rgb(55, 128, 191)",
                                width = 3
                            ),
                        fillcolor = "rgba(55, 128, 191, 0.6)"
                    )
                    //Rectangle reference to the Plot
                    Shape(
                        ``type`` = "rect",
                        xref = "paper",
                        yref = "paper",
                        x0 = 0.25,
                        y0 = 0,
                        x1 = 0.5,
                        y1 = 0.5,
                        line =
                            Line(
                            color = "rgb(50, 171, 96)",
                            width = 3
                            ),
                        fillcolor = "rgba(50, 171, 96, 0.6)"
                    )
                ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Rectangle Positioned Relative to the Axe
module Chart5 =
    let trace1 =
        Scatter(
            x = [1.5; 4.5],
            y = [0.75; 0.75],
            text = ["Unfilled Rectangle"; "Filled Rectangle"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Rectangle Positioned Relative to the Axes",
            xaxis =
                Xaxis(
                    range = [0; 7],
                    showgrid = false
                ),
            yaxis = Yaxis(range = [0.; 3.5]),
//            width = 500.,
//            height = 500.,
            shapes =
                [
                    //Unfilled Rectangle
                    Shape(
                        ``type`` = "rect",
                        x0 = 1,
                        y0 = 1,
                        x1 = 2,
                        y1 = 3,
                        line = Line(color = "rgba(128, 0, 128, 1)")
                    )
                    //Filled Rectangle
                    Shape(
                        ``type`` = "rect",
                        x0 = 3,
                        y0 = 1,
                        x1 = 6,
                        y1 = 2,
                        line =
                            Line(
                                color = "rgba(128; 0; 128; 1)",
                                width = 2
                            ),
                        fillcolor = "rgba(128, 0, 128, 0.7)"
                    )
                ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Lines Positioned Realtive to the Plot and to the Axis
module Chart6 =
    let trace1 =
        Scatter(
            x = [2; 6],
            y = [1; 1],
            text = ["Line positioned relative to the plot"; "Line positioned relative to the axes"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Lines Positioned Relative to the Plot & to the Axes",
            xaxis = Xaxis(range = [0; 8]),
            yaxis = Yaxis(range = [0; 2]),
//            width = 500,
//            height = 500.,
            shapes =
                [
                    // Line reference to the axes
                    Shape(
                        ``type`` = "line",
                        xref = "x",
                        yref = "y",
                        x0 = 4,
                        y0 = 0,
                        x1 = 8,
                        y1 = 1,
                        line =
                            Line(
                                color = "rgb(55, 128, 191)",
                                width = 3
                            )
                    )
                    // Line reference to the plot
                    Shape(
                        ``type`` = "line",
                        xref = "paper",
                        yref = "paper",
                        x0 = 0,
                        y0 = 0,
                        x1 = 0.5,
                        y1 = 0.5,
                        line =
                            Line(
                                color = "rgb(50, 171, 96)",
                                width = 3
                            )
                    )
                ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Basic Arbitrary SVG Paths
module Chart7 =
    let trace1 =
        Scatter(
            x = [2; 1; 8; 8],
            y = [0.25; 9.; 2.; 6.],
            text = ["filled triangle"; "filled Polygon"; "Quadratic Bezier Curves"; "Cubic Bezier Curves"],
            mode = "text"
        )

    let layout =
        Layout(
            title = "Basic Arbitrary SVG Paths",
            xaxis =
                Xaxis(
                    range = [0; 9],
                    zeroline = false
                ),
            yaxis =
                Yaxis(
                    range = [0; 11],
                    showgrid = false
                ),
//            width = 500.,
//            height = 500.,
            shapes =
                [
                    // Quadratic Bezier Curves
                    Shape(
                        ``type`` = "path",
                        path = "M 4,4 Q 6,0 8,4",
                        line = Line(color = "rgb(93, 164, 214)")
                    )
                    // Cubic Bezier Curves
                    Shape(
                        ``type`` = "path",
                        path = "M 1,4 C 2,8 6,4 8,8",
                        line = Line(color = "rgb(207, 114, 255)")
                    )
                    // Filled Triangle
                    Shape(
                        ``type`` = "path",
                        path = "M 1 1 L 1 3 L 4 1 Z",
                        fillcolor = "rgba(44, 160, 101, 0.5)",
                        line = Line(color = "rgb(44, 160, 101)")
                    )
                    // Filled Polygon
                    Shape(
                        ``type`` = "path",
                        path = "M 3,7 L2,8 L2,9 L3,10, L4,10 L5,9 L5,8 L4,7 Z",
                        fillcolor = "rgba(255, 140, 184, 0.5)",
                        line = Line(color = "rgb(255, 140, 184)")
                    )
                ]
        )

    trace1
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Venn Diagram with Circle Shapes
module Chart8 =
    let trace1 =
        Scatter(
            x = [1.; 1.75; 2.5],
            y = [1; 1; 1],
            mode = "text",
            text = ["A"; "A+B"; "B"],
            textfont =
                Textfont(
                    color = "black",
                    size = 18.,
                    family = "Arial"
                )
        )

    let layout =
        Layout(
            title = "Venn Diagram with Circle Shapes",
            xaxis =
                Xaxis(
                    showticklabels = false,
                    autotick = false,
                    showgrid = false,
                    zeroline = false
                ),
            yaxis =
                Yaxis(
                    showticklabels = false,
                    autotick = false,
                    showgrid = false,
                    zeroline = false
                ),
            shapes =
                [
                    Shape(
                        opacity = 0.3,
                        xref = "x",
                        yref = "y",
                        fillcolor = "blue",
                        x0 = 0,
                        y0 = 0,
                        x1 = 2,
                        y1 = 2,
                        ``type`` = "circle",
                        line = Line(color = "blue")
                    )
                    Shape(
                        opacity = 0.3,
                        xref = "x",
                        yref = "y",
                        fillcolor = "gray",
                        x0 = 1.5,
                        y0 = 0,
                        x1 = 3.5,
                        y1 = 2,
                        ``type`` = "circle",
                        line = Line(color = "gray")
                    )
                ],
            margin =
                Margin(
                    l = 20.,
                    r = 20.,
                    b = 100.
                )
//            height = 500.,
//            width = 500.
        )

    trace1
    |> Chart.Plot
    |> Chart.WithLayout layout
    |> Chart.Show
