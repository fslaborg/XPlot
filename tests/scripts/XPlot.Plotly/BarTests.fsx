#r @".\.\bin\Release\XPlot.Plotly.dll"
#load "Credentials.fsx"

// TESTED under CI now

open XPlot.Plotly

Plotly.Signin(Credentials.username, Credentials.key)

module BasicBarChart =

    let data =
        Data(
            [
                Bar(
                    x = ["giraffes"; "orangutans"; "monkeys"],
                    y = [20; 14; 23]
                )
            ]
        )

    let figure = Figure(data)

    let plotlyResponse = figure.Plot("Basic Bar Chart")

    figure.Show()

module GroupedBarChart =

    let trace1 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [20; 14; 23],
            name= "SF Zoo"            
        )

    let trace2 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [12; 18; 29],
            name = "LA Zoo"
        )

    let data = Data [trace1; trace2]

    let layout = Layout(barmode = "group")

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Grouped Bar Chart")

    figure.Show()

module StackedBarChart =

    let trace1 =
        Bar(
            x = ["giraffes"; "orangutans"; "monkeys"],
            y = [20; 14; 23],
            name = "SF Zoo"
        )

    let trace2 =
        Bar(
            x= ["giraffes"; "orangutans"; "monkeys"],
            y= [12; 18; 29],
            name = "LA Zoo"
        )

    let data = Data [trace1; trace2]

    let layout = Layout(barmode = "stack")
    
    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Stacked Bar Chart")

    figure.Show()

module ColoredStyledBarChart =
    
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

    let data = Data [trace1; trace2]

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
            bargap = 0.15,
            bargroupgap = 0.1
        )

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Colored and Styled Bar Chart")

    figure.Show()

module BarChartHoverText =

    let trace =
        Bar(
            x = ["Liam"; "Sophie"; "Jacob"; "Mia"; "William"; "Olivia"],
            y = [8.0; 8.0; 12.0; 12.0; 13.0; 20.0],
            text = ["4.17 below the mean"; "4.17 below the mean"; "0.17 below the mean"; "0.17 below the mean"; "0.83 above the mean"; "7.83 above the mean"],
            marker = Marker(color = "rgb(142, 124, 195)")
        )

    let data = Data [trace]

    let layout =
        Layout(
            title = "Number of graphs made this week",
            font = Font(family = "Raleway, sans-serif"),
            showlegend = false,
            xaxis= Xaxis(tickangle = -45.),
            yaxis=
                Yaxis(
                    zeroline = false,
                    gridwidth = 2.
                ),
            bargap = 0.05
        )

    let figure = Figure(data, layout)

    let plotlyResponse = figure.Plot("Bar Chart with Hover Text")

    figure.Show()

module CustomizingIndividualBarColors =

    let data =
        Data(
            [
                Bar(
                    x = [1; 2; 3; 4],
                    y = [5; 4; -3; 2],
                    marker = Marker(color = ["#447adb"; "#447adb"; "#db5a44"; "#447adb"])
                )
            ]
        )

    let figure = Figure data

    let plotlyResponse = figure.Plot("Customizing Individual Bar Colors")

    figure.Show()
