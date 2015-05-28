(*** hide ***)
#I "../../../bin"
#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Plotly Bar Charts
=================

Basic Bar Chart
---------------
*)
let basicData =
    Data(
        [
            Bar(
                x = ["giraffes"; "orangutans"; "monkeys"],
                y = [20; 14; 23]
            )
        ]
    )

Figure(basicData)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/130.embed?width=640&height=480" ></iframe>
*)

(**
Grouped Bar Chart
-----------------
*)

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

let data2 = Data [groupedTrace1; groupedTrace2]

let groupedLayout = Layout(barmode = "group")

Figure(data2, groupedLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/145.embed?width=640&height=480" ></iframe>
*)

(**
Stacked Bar Chart
-----------------
*)

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

let stackedData = Data [stackedTrace1; stackedTrace2]

let stackedLayout = Layout(barmode = "stack")
    
Figure(stackedData, stackedLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/146.embed?width=640&height=480" ></iframe>
*)

(**
Colored and Styled Bar Chart
----------------------------
*)

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

let styledData = Data [styledTrace1; styledTrace2]

let styledLayout =
    Layout(
        title = "US Export of Plastic Scrap",
        xaxis =
            XAxis(
                tickfont =
                    Font(
                        size = 14.,
                        color = "rgb(107, 107, 107)"
                    )
            ),
        yaxis =
            YAxis(
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

Figure(styledData, styledLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/147.embed?width=640&height=480" ></iframe>
*)

(**
Bar Chart with Hover Text
-------------------------
*)

let hoverTrace =
    Bar(
        x = ["Liam"; "Sophie"; "Jacob"; "Mia"; "William"; "Olivia"],
        y = [8.0; 8.0; 12.0; 12.0; 13.0; 20.0],
        text =
            ["4.17 below the mean"; "4.17 below the mean"; "0.17 below the mean";
            "0.17 below the mean"; "0.83 above the mean"; "7.83 above the mean"],
        marker = Marker(color = "rgb(142, 124, 195)")
    )

let hoverData = Data [hoverTrace]

let hoverLayout =
    Layout(
        title = "Number of graphs made this week",
        font = Font(family = "Raleway, sans-serif"),
        showlegend = false,
        xaxis= XAxis(tickangle = -45.),
        yaxis=
            YAxis(
                zeroline = false,
                gridwidth = 2.
            ),
        bargap = 0.05
    )

Figure(hoverData, hoverLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/148.embed?width=640&height=480" ></iframe>
*)

(**
Customizing Individual Bar Colors
---------------------------------
*)

let customData =
    Data(
        [
            Bar(
                x = [1; 2; 3; 4],
                y = [5; 4; -3; 2],
                marker = Marker(color = ["#447adb"; "#447adb"; "#db5a44"; "#447adb"])
            )
        ]
    )

Figure(customData)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/149.embed?width=640&height=480" ></iframe>
*)
