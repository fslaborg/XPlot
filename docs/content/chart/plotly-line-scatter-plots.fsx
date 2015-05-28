(*** hide ***)
#I "../../../bin"
#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Plotly Line and Scatter Plots
=============================

Basic Line Plot
---------------
*)

let basicTrace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [10; 15; 13; 17]
    )

let basicTrace2 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [16; 5; 11; 9]
    )

Figure(Data.From [basicTrace1; basicTrace2])

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/173.embed?width=640&height=480" ></iframe>
*)

(**
Line and Scatter Plot
---------------------
*)
       
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

Figure(Data.From [lineTrace1; lineTrace2; lineTrace3])

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/177.embed?width=640&height=480" ></iframe>
*)

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
            XAxis(
                title = "GDP per Capita",
                showgrid = false,
                zeroline = false
            ),
        yaxis =
            YAxis(
                title = "Percent",
                showline = false
            )
    )

Figure(
    Data.From [styledTrace1; styledTrace2; styledTrace3; styledTrace4],
    styledLayout
)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/178.embed?width=640&height=480" ></iframe>
*)

(**
Line Shape Options for Interpolation
------------------------------------
*)

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

let data =
    Data([shapeTrace1; shapeTrace2; shapeTrace3;
          shapeTrace4; shapeTrace5; shapeTrace6]
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

Figure(data, shapeLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/179.embed?width=640&height=480" ></iframe>
*)
