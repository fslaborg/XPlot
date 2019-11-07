(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Bar Charts
=================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-bar-charts.fsx)

Basic Bar Chart
---------------
*)

(*** define-output: chart1 ***)
let layout = Layout(title = "Basic Bar Chart")

let data = ["giraffes", 20; "orangutans", 14; "monkeys", 23]

data
|> Chart.Bar
|> Chart.WithLayout layout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart1 ***)

(**
Grouped Bar Chart
-----------------
*)

(*** define-output: chart2 ***)
let groupedTrace1 =
    Bar(
        x = ["giraffes"; "orangutans"; "monkeys"],
        y = [20; 14; 23],
        name= "SF Zoo"            
    )

let groupedTrace2 =
    Bar(
        x = ["giraffes"; "orangutans"; "monkeys"],
        y = [12; 18; 29],
        name = "LA Zoo"
    )

let groupedLayout = Layout(barmode = "group")

[groupedTrace1; groupedTrace2]
|> Chart.Plot
|> Chart.WithLayout groupedLayout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart2 ***)

(**
Stacked Bar Chart
-----------------
*)

(*** define-output: chart3 ***)
let stackedTrace1 =
    Bar(
        x = ["giraffes"; "orangutans"; "monkeys"],
        y = [20; 14; 23],
        name = "SF Zoo"
    )

let stackedTrace2 =
    Bar(
        x= ["giraffes"; "orangutans"; "monkeys"],
        y= [12; 18; 29],
        name = "LA Zoo"
    )

let stackedLayout = Layout(barmode = "stack")

[stackedTrace1; stackedTrace2]
|> Chart.Plot
|> Chart.WithLayout stackedLayout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart3 ***)

(**
Colored and Styled Bar Chart
----------------------------
*)

(*** define-output: chart4 ***)
let styledTrace1 =
    Bar(
        x =
            [1995; 1996; 1997; 1998; 1999; 2000; 2001; 2002; 2003; 2004; 2005; 2006;
             2007; 2008; 2009; 2010; 2011; 2012],
        y =
            [219; 146; 112; 127; 124; 180; 236; 207; 236; 263; 350; 430; 474; 526; 488;
            537; 500; 439],
        name = "Rest of world",
        marker = Marker(color = "rgb(55, 83, 109)")
    )

let styledTrace2 =
    Bar(
        x =
            [1995; 1996; 1997; 1998; 1999; 2000; 2001; 2002; 2003; 2004; 2005; 2006;
            2007; 2008; 2009; 2010; 2011; 2012],
        y =
            [16; 13; 10; 11; 28; 37; 43; 55; 56; 88; 105; 156; 270; 299; 340; 403; 549;
            499],        
        name = "China",
        marker = Marker(color = "rgb(26, 118, 255)")
    )

let styledLayout =
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

[styledTrace1; styledTrace2]
|> Chart.Plot
|> Chart.WithLayout styledLayout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart4 ***)

(**
Bar Chart with Hover Text
-------------------------
*)

(*** define-output: chart5 ***)
let hoverTrace =
    Bar(
        x = ["Liam"; "Sophie"; "Jacob"; "Mia"; "William"; "Olivia"],
        y = [8.0; 8.0; 12.0; 12.0; 13.0; 20.0],
        text =
            ["4.17 below the mean"; "4.17 below the mean"; "0.17 below the mean";
            "0.17 below the mean"; "0.83 above the mean"; "7.83 above the mean"],
        marker = Marker(color = "rgb(142, 124, 195)")
    )

let hoverLayout =
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

hoverTrace
|> Chart.Plot
|> Chart.WithLayout hoverLayout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart5 ***)

(**
Customizing Individual Bar Colors
---------------------------------
*)

(*** define-output: chart6 ***)
Bar(
    x = [1; 2; 3; 4],
    y = [5; 4; -3; 2],
    marker = Marker(color = ["#447adb"; "#447adb"; "#db5a44"; "#447adb"])
)
|> Chart.Plot
|> Chart.WithLayout hoverLayout
|> Chart.WithHeight 500
|> Chart.WithWidth 700
(*** include-it: chart6 ***)
