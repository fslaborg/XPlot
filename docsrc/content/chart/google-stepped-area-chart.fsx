(*** hide ***)
#I "../../../bin/XPlot.GoogleCharts/netstandard2.0"
#r "XPlot.GoogleCharts.dll"
open XPlot.GoogleCharts

(**
Google Stepped Area Chart
=========================
*)
(*** define-output:steparea ***) 
let data =
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

let options =
    Options(
        title = "The decline of 'The 39 Steps'",
        vAxis = Axis(title = "Accumulated Rating"),
        isStacked = true
    )

data
|> Chart.SteppedArea
|> Chart.WithOptions options
|> Chart.WithLabels ["Rotten Tomatoes"; "IMDB"]
(*** include-it:steparea ***)
