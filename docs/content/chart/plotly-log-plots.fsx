(*** hide ***)
#I "../../../bin"
#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Plotly Log Plots
================

Logarithmic Axes
----------------
*)

let trace1 =
    Scatter(
        x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
        y = [8; 7; 6; 5; 4; 3; 2; 1; 0]
    )

let trace2 =
    Scatter(
        x = [0; 1; 2; 3; 4; 5; 6; 7; 8],
        y = [0; 1; 2; 3; 4; 5; 6; 7; 8]
    )

let data = Data([trace1; trace2])

let layout =
    Layout(
        title = "Logarithmic Axes",
        xaxis =
            XAxis(
                ``type`` = "log",
                autorange = true
            ),
        yaxis =
            YAxis(
                ``type`` = "log",
                autorange = true
            )
    )

Figure(Data.From [trace1; trace2], layout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/548.embed?width=640&height=480" ></iframe>
*)
