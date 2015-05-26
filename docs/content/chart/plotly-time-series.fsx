(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../../bin"

#load "../credentials.fsx"
#r "XPlot.Plotly.dll"
#r "XPlot.Plotly.WPF.dll"

open System
open XPlot.Plotly

Plotly.Signin MyCredentials.userAndKey

let x =
    [
        DateTime(2013, 10, 4);
        DateTime(2013, 11, 5);
        DateTime(2013, 12, 6)
    ]

(**
Plotly Time Series
==================

Time Series Plot with DateTime Objects
--------------------------------------
*)

let objData =
    Data(
        [
            Scatter(
                x = x,
                y = [1; 3; 6]
            )
        ]
    )

let objLayout = Layout(title = "Time Series Plot with datetime Objects")

Figure(objData, objLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/530.embed?width=640&height=480" ></iframe>
*)

(**
Date Strings
------------
*)

let stringData =
    Data(
        [
            Scatter(
                x = ["2013-10-04 22:23:00"; "2013-11-04 22:23:00"; "2013-12-04 22:23:00"],
                y = [1; 3; 6]
            )
        ]
    )

let stringLayout = Layout(title = "Date Strings")

Figure(stringData, stringLayout)

(**
<iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~TahaHachana/532.embed?width=640&height=480" ></iframe>
*)
