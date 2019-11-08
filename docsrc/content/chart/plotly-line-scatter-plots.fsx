(*** hide ***)
#I "../../../bin/XPlot.Plotly/netstandard2.0"
#r "XPlot.Plotly.dll"

open XPlot.Plotly

(**
Plotly Line and Scatter Plots
=============================

[Full source and data](https://github.com/fslaborg/XPlot/blob/master/docsrc/content/chart/plotly-line-scatter-plots.fsx)

Basic Line Plot
---------------
*)

(*** define-output: chart1 ***)
let trace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [10; 15; 13; 17]
    )

let trace2 =
    Scatter(
        x = [2; 3; 4; 5],
        y = [16; 5; 11; 9]
    )

[trace1; trace2]
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart1 ***)

(**
Line and Scatter Plot
---------------------
*)

(*** define-output: chart2 ***)       
let lineTrace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [10; 15; 13; 17],
        mode = "markers"
    )

let lineTrace2 =
    Scatter(
        x = [2; 3; 4; 5],
        y = [16; 5; 11; 9],
        mode = "lines"
    )

let lineTrace3 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [12; 9; 15; 12],
        mode = "lines+markers"
    )

[lineTrace1; lineTrace2; lineTrace3]
|> Chart.Plot
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart2 ***)

(**
Colored and Styled Scatter Plot
-------------------------------
*)

(*** define-output: chart3 ***)
let styledTrace1 =
    Scatter(
        x = [52698; 43117],
        y = [53; 31],
        mode = "markers",
        name = "North America",
        text = ["United States"; "Canada"],
        marker =
            Marker(
                color = "rgb(164, 194, 244)",
                size = 12,
                line =
                    Line(
                        color = "white",
                        width = 0.5
                    )
            )
    )

let styledTrace2 =
    Scatter(
        x = [39317; 37236; 35650; 30066; 29570; 27159; 23557; 21046; 18007],
        y = [33; 20; 13; 19; 27; 19; 49; 44; 38],
        mode = "markers",
        name = "Europe",
        text =
            ["Germany"; "Britain"; "France"; "Spain"; "Italy"; "Czech Rep."; "Greece";
             "Poland"],
        marker =
            Marker(
                color = "rgb(255, 217, 102)",
                size = 12,
                line=
                    Line(
                        color = "white",
                        width = 0.5
                    )
            )
    )

let styledTrace3 = 
    Scatter(
        x = [42952; 37037; 33106; 17478; 9813; 5253; 4692; 3899],
        y = [23; 42; 54; 89; 14; 99; 93; 70],
        mode = "markers",
        name = "Asia/Pacific",
        text =
            ["Australia"; "Japan"; "South Korea"; "Malaysia"; "China"; "Indonesia";
             "Philippines"; "India"],
        marker =
            Marker(
                color = "rgb(234, 153, 153)",
                size = 12,
                line =
                    Line(
                        color = "white",
                        width = 0.5
                    )
            )
    )

let styledTrace4 =
    Scatter(
        x = [19097; 18601; 15595; 13546; 12026; 7434; 5419],
        y = [43; 47; 56; 80; 86; 93; 80],
        mode = "markers",
        name = "Latin America",
        text =
            ["Chile"; "Argentina"; "Mexico"; "Venezuela"; "Venezuela"; "El Salvador";
             "Bolivia"],
        marker = 
            Marker(
                color = "rgb(142, 124, 195)",
                size = 12,
                line =
                    Line(
                        color = "white",
                        width = 0.5
                    )
            )
    )

let styledLayout =
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

[styledTrace1; styledTrace2; styledTrace3; styledTrace4]
|> Chart.Plot
|> Chart.WithLayout styledLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart3 ***)

(**
Line Shape Options for Interpolation
------------------------------------
*)

(*** define-output: chart4 ***)
let shapeTrace1 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [1; 3; 2; 3; 1],
        mode = "lines+markers",
        name = "'linear'",
        line = Line(shape = "linear")
    )

let shapeTrace2 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [6; 8; 7; 8; 6],
        mode = "lines+markers",
        name = "'spline'",
        text =
            ["tweak line smoothness<br>with 'smoothing' in line object";
             "tweak line smoothness<br>with 'smoothing' in line object";
             "tweak line smoothness<br>with 'smoothing' in line object";
             "tweak line smoothness<br>with 'smoothing' in line object";
             "tweak line smoothness<br>with 'smoothing' in line object";
             "tweak line smoothness<br>with 'smoothing' in line object"],
        line = Line(shape = "spline")
    )

let shapeTrace3 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [11; 13; 12; 13; 11],
        mode = "lines+markers",
        name = "'vhv'",
        line = Line(shape = "vhv")
    )

let shapeTrace4 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [16; 18; 17; 18; 16],
        mode = "lines+markers",
        name = "'hvh'",
        line = Line(shape = "hvh")
    )

let shapeTrace5 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [21; 23; 22; 23; 21],
        mode = "lines+markers",
        name = "'vh'",
        line = Line(shape = "vh")
    )

let shapeTrace6 =
    Scatter(
        x = [1; 2; 3; 4; 5],
        y = [26; 28; 27; 28; 26],
        mode = "lines+markers",
        name = "'hv'",
        line = Line(shape = "hv")
    )
        
let shapeLayout =
    Layout(
        legend =
            Legend(
                y = 0.5,
                traceorder = "reversed",
                font = Font(size = 16.),
                yref = "paper"
            )
    )

[shapeTrace1; shapeTrace2; shapeTrace3;
 shapeTrace4; shapeTrace5; shapeTrace6]
|> Chart.Plot
|> Chart.WithLayout shapeLayout
|> Chart.WithWidth 700
|> Chart.WithHeight 500
(*** include-it: chart4 ***)
