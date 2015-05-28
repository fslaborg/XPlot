(*** hide ***)
#I "../../../bin"
#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Plotly Area Plots
=================

Basic Overlaid Area Chart
-------------------------
*)

let trace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [0; 2; 3; 5],
        fill = "tozeroy"
    )

let trace2 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [3; 5; 1; 7],
        fill = "tonexty"
    )

let layout = Layout(title = "Basic Overlaid Area Chart")

Figure(Data.From [trace1; trace2], layout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/289.embed?width=640&height=480" ></iframe>
*)
