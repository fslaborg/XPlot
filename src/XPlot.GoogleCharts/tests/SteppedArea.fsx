﻿#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let options =
    Options(
        title = "The decline of 'The 39 Steps'",
        vAxis = Axis(title = "Accumulated Rating"),
        isStacked = true
    )

let chart =
    [
        [
            "Alfred Hitchcock (1935)", 8.4
            "Ralph Thomas (1959)", 6.9
            "Don Sharp (1978)", 6.5
            "James Hawes (2008)", 4.4        
        ]
        [
            "Alfred Hitchcock (1935)", 7.9
            "Ralph Thomas (1959)", 6.5
            "Don Sharp (1978)", 6.4
            "James Hawes (2008)", 6.2        
        ]
    ]
    |> Chart.SteppedArea
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Rotten Tomatoes"; "IMDB"]
    |> Chart.Show
