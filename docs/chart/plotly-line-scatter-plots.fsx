(*** condition: prepare ***)
#r "../../bin/XPlot.Plotly/netstandard2.0/XPlot.Plotly.dll"
#r "../../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
(*** condition: ipynb ***)
#if IPYNB
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
#r "nuget: XPlot.Plotly"
#r "nuget: XPlot.Plotly.Interactive"
#endif // IPYNB

(**
Plotly Line and Scatter Plots

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/fslaborg/XPlot/gh-pages?filepath=plotly-line-scatter-plots.ipynb)

Basic Line Plot
---------------
*)

open XPlot.Plotly

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

let chart1 =
    [trace1; trace2]
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart1
#endif // IPYNB
(*** hide ***)
chart1.GetHtml()
(*** include-it-raw ***)


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

let chart2 =
    [lineTrace1; lineTrace2; lineTrace3]
    |> Chart.Plot
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart2
#endif // IPYNB
(*** hide ***)
chart2.GetHtml()
(*** include-it-raw ***)

(**
Colored and Styled Scatter Plot
-------------------------------
*)

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

let chart3 =
    [styledTrace1; styledTrace2; styledTrace3; styledTrace4]
    |> Chart.Plot
    |> Chart.WithLayout styledLayout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart3
#endif // IPYNB
(*** hide ***)
chart3.GetHtml()
(*** include-it-raw ***)

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

let chart4 =
    [shapeTrace1; shapeTrace2; shapeTrace3;
     shapeTrace4; shapeTrace5; shapeTrace6]
    |> Chart.Plot
    |> Chart.WithLayout shapeLayout
    |> Chart.WithWidth 700
    |> Chart.WithHeight 500
(*** condition: ipynb ***)
#if IPYNB
chart4
#endif // IPYNB
(*** hide ***)
chart4.GetHtml()
(*** include-it-raw ***)
