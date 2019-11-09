// Dodged Bar Chart
#load "../packages/FSLab.0.3.19/FsLab.fsx"

open System
open XPlot.Plotly

let trace1 =
        Bar(
            x = ["English"; "Reading"; "Math"],
            y = [20; 14; 23],
            name = "Students Passed",
            marker =
                Marker(
                    color = "rgb(34,139,34)",
                    opacity = 0.7
                )
        )

let trace2 =
        Bar(
            x = ["English"; "Reading"; "Math"],
            y = [12; 18; 29],
            name = "Students Failed",
            marker =
                Marker(
                    color = "rgb(49,130,189)",
                    opacity = 0.7
                )
        )

let data = [trace1; trace2]

let layout = Layout(
                title = "Number of Students who passed and failed subjects",
                xaxis =
                    Xaxis(
                        title = "Subjects"
                    ),
                yaxis =
                    Yaxis(
                        title = "Number of Students"
                    ),
                barmode = "group"
             )
    
data
    |> Plotly.Plot
    |> Plotly.WithLayout layout
    |> Plotly.Show