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

