#r @"../../../bin/XPlot.Plotly.dll"

open XPlot.Plotly

// Basic bar chart
module Chart1 =

    let data =
        [
            Bar(
                x = [20; 14; 23],
                y = ["giraffes"; "orangutans"; "monkeys"],
                orientation = "h"
            )
        ]

    data
    |> Plotly.Plot
    |> Plotly.Show

// Colored bar chart
module Chart2 =

    let trace1 =
        Bar(
            x = [20; 14; 23],
            y = ["giraffes"; "orangutans"; "monkeys"],
            name = "SF Zoo",
            orientation = "h",
            marker =
                Marker(
                    color = "rgba(55,128,191,0.6)"//,
//                    width = 1.
                )
        )

    let trace2 =
        Bar(
            x = [12; 18; 29],
            y = ["giraffes"; "orangutans"; "monkeys"],
            name = "LA Zoo",
            orientation = "h",
            marker =
                Marker(
                    color = "rgba(255,153,51,0.6)"//,
//                    width = 1
                )
        )

    let data = [trace1; trace2]

    let layout =
        Layout(
            title = "Colored Bar Chart",
            barmode = "stack"
        )

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Bar chart with line plot
module Chart3 =

    let xSavings =
        [1.3586; 2.2623000000000002; 4.9821999999999997; 6.5096999999999996;
            7.4812000000000003; 7.5133000000000001; 15.2148; 17.520499999999998
        ]

    let xNetworth = [93453.919999999998; 81666.570000000007; 69889.619999999995; 78381.529999999999; 141395.29999999999; 92969.020000000004; 66090.179999999993; 122379.3]

    let ySavings = ["Japan"; "United Kingdom"; "Canada"; "Netherlands"; "United States"; "Belgium"; "Sweden"; "Switzerland"]

    let yNetworth = ["Japan"; "United Kingdom"; "Canada"; "Netherlands"; "United States"; "Belgium"; "Sweden"; "Switzerland"]

    let trace1 =
        Bar(
            x = xSavings,
            y = ySavings,
            xaxis = "x1",
            yaxis = "y1",
            marker =
                Marker(
                    color = "rgba(50,171,96,0.6)",
                    line =
                        Line(
                            color = "rgba(50,171,96,1.0)",
                            width = 1.
                        )
                ),
            name = "Household savings; percentage of household disposable income",
            orientation = "h"
        )

    let trace2 =
        Scatter(
            x = xNetworth,
            y = yNetworth,
            xaxis = "x2",
            yaxis = "y1",
            mode = "lines+markers",
            line = Line(color = "rgb(128,0,128)"),
            name = "Household net worth; Million USD/capita"
        )

    let data = [trace1 :> Trace; trace2 :> Trace]

    let layout =
        Layout(
            title = "Household Savings & Net Worth for Eight OECD Countries",
            xaxis1 =
                Xaxis(
                    range = [0; 20],
                    domain = [0.; 0.5],
                    zeroline = false,
                    showline = false,
                    showticklabels = true,
                    showgrid = true
                ),
            xaxis2 =
                Xaxis(
                    range = [25000; 150000],
                    domain = [0.5; 1.],
                    zeroline = false,
                    showline = false,
                    showticklabels = true,
                    showgrid = true,
                    side = "top",
                    dtick = 25000
                ),
            legend =
                Legend(
                    x = 0.029,
                    y = 1.238,
                    font = Font(size = 10.)
                ),
            margin =
                Margin(
                    l = 100.,
                    r = 20.,
                    t = 200.,
                    b = 70.
                ),
            width = 700.,
            height = 600.,
            paper_bgcolor = "rgb(248,248,255)",
            plot_bgcolor = "rgb(248,248,255)",
            annotations = [
                Annotation(
                    xref = "paper",
                    yref = "paper",
                    x = -0.2,
                    y = -0.109,
                    text = "OECD " + "(2015) Household savings (indicator) " + "Household net worth (indicator). doi = " + "10.1787/cfc6f499-en (Accessed on 05 June 2015)",
                    showarrow = false,
                    font =
                        Font(
                            family = "Arial",
                            size = 10.,
                            color = "rgb(150,150,150)"
                        )
                )
            ]
        )

    let annotations =
        [
            for i in 0 .. xSavings.Length - 1 do
                let result =
                    Annotation(
                        xref = "x1",
                        yref = "y1",
                        x = xSavings.[i] + 2.3,
                        y = ySavings.[i],
                        text = string xSavings.[i] + "%",
                        font =
                            Font(
                                family = "Arial",
                                size = 12.,
                                color = "rgb(50, 171, 96)"
                            ),
                         showarrow = false;
                    )
                let result2 =
                    Annotation(
                        xref = "x2",
                        yref = "y1",
                        x = xNetworth.[i] - 20000.,
                        y = yNetworth.[i],
                        text = string xNetworth.[i] + " M",
                        font =
                            Font(
                                family = "Arial",
                                size = 12.,
                                color = "rgb(128, 0, 128)"
                            ),
                         showarrow = false
                    )
                yield result
                yield result2
        ]

    layout.annotations <- Seq.append layout.annotations annotations

    data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show

// ====================
// Pipeline style tests
// ====================

// Basic bar chart
module Chart1' =

    let data = ["giraffes", 20; "orangutans", 14; "monkeys", 23]

    data
    |> Plotly.Bar
    |> Plotly.Show

// Grouped bar chart
module Chart2' =

    let trace1 = ["giraffes", 20; "orangutans", 14; "monkeys", 23]
    let trace2 = ["giraffes", 12; "orangutans", 18; "monkeys", 29]

    let layout = Layout(barmode = "group")
    
    [trace1; trace2]
    |> Plotly.Bar
    |> Plotly.WithLayout layout
    |> Plotly.Show

// Stacked bar chart
module Chart3' =

    let trace1 = ["giraffes", 20; "orangutans", 14; "monkeys", 23]
    let trace2 = ["giraffes", 12; "orangutans", 18; "monkeys", 29]

    let layout = Layout(barmode = "stack")

    [trace1; trace2]
    |> Plotly.Bar
    |> Plotly.WithLabels ["SF Zoo"; "LA Zoo"]
    |> Plotly.WithLayout layout
    |> Plotly.Show
