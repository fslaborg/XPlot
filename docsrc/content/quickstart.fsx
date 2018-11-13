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

## Step 1: Download the package XPlot.GoogleChart

Choose a folder where you want to work, and open it in VS Code.

Then use `Ctrl`+`Shift`+`P` to bring up the command palette and type the command `Paket: Init`.

This will create a file called `paket.dependencies`

Modify `paket.dependencies` so that it looks like this:

```
framework:net45
source https://www.nuget.org/api/v2
nuget XPlot.GoogleCharts
```

Bring up the command palette again with `Ctrl`+`Shift`+`P` and type `Paket: Install`.
This installs the package in your folder. You will see two things:

- a paket.lock file, 
- and a "packages" directory, with the following structure:

```
/packages/
    / Google.DataTable.Net.Wrapper/
        / lib
            / Google.DataTable.Net.Wrapper.dll
    / XPlot.GoogleCharts
        / lib
            /net45
                / XPlot.GoogleCharts.dll
```
                
Now you are ready to start creating a chart.

## Step 2: Creating a chart from a script

First, create a new F# script file: `Script.fsx`.

Copy-paste the following code into the editor:

*)

#I "./packages"
#r "Google.DataTable.Net.Wrapper/lib/Google.DataTable.Net.Wrapper.dll"
#r "XPlot.GoogleCharts/lib/net45/XPlot.GoogleCharts.dll"
#r "Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"

open XPlot.GoogleCharts

[ 1 .. 10 ] |> Chart.Line |> Chart.Show

(**
Select all of the code you pasted in and press `Alt`+`Enter` to execute it.

That's it! You should see a chart popping up in your browser.

Notes

- in the path `#r "XPlot.GoogleCharts/lib/net45/`, make sure "net45" is right, 
this is based on `paket.dependencies`, specifically the .NET 4.5 framework part (`framework:net45`).
- you will need an internet connection for the chart to render, as the code relies on Google-hosted services.

*)
