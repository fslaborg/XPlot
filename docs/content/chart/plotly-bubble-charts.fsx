(*** hide ***)
#I "../../../bin"
#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

(**
Plotly Bubble Charts
====================

Marker Size, Color, and Symbol as an Array
------------------------------------------
*)

let trace1 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [10; 11; 12; 13],
        mode = "markers",
        marker =
            Marker(
                color = ["hsl(0,100,40)"; "hsl(33,100,40)"; "hsl(66,100,40)"; "hsl(99,100,40)"],
                size = [12; 22; 32; 42],
                opacity = [0.6, 0.7, 0.8, 0.9]
            )
    )

let trace2 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [11; 12; 13; 14],
        mode = "markers",
        marker =
            Marker(
                color = "rgb(31, 119, 180)",
                size = 18,
                symbol = ["circle"; "square"; "diamond"; "cross"]
            )
    )

let trace3 =
    Scatter(
        x = [1; 2; 3; 4],
        y = [12; 13; 14; 15],
        mode = "markers",
        marker =
            Marker(
                size = 18,
                line =
                    Line(
                        color = ["rgb(120,120,120)"; "rgb(120,120,120)"; "red"; "rgb(120,120,120)"],
                        width = [2; 2; 6; 2]
                    )
            )
    )


let layout = Layout(showlegend = false)

Figure(Data.From [trace1; trace2; trace3], layout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/226.embed?width=640&height=480" ></iframe>
*)
