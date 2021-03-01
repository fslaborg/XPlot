(**
Your First XPlot Chart
======================

In this tutorial we will walk through creating a chart in the browser,
from an F# script running in [Visual Studio Code](https://code.visualstudio.com/).

We assume that:

- VS Code is already installed,
- F# is already installed ([see fsharp.org under "Use"](http://fsharp.org/)), and
- VS Code extensions [Ionide FSharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp)
and [Ionide Paket](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-paket) are installed.

First, create a new F# script file: `Script.fsx`.

Copy-paste the following code into the editor:

*)

#r "nuget: XPlot.Plotly"

open XPlot.Plotly

[ 1 .. 10 ] |> Chart.Line |> Chart.Show


(**
Select all of the code you pasted in and press `Alt`+`Enter` to execute it.

That's it! You should see a chart popping up in your browser.

Notes

- you will need an internet connection for the chart to render, as the code relies on Plotly.

*)
(*** hide ***)
[ 1 .. 10 ]
|> Chart.Line
|> fun x -> x.GetHtml()
(*** include-it-raw ***)
