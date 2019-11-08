# XPlot [![Nuget Badge](https://buildstats.info/nuget/XPlot.Plotly)](https://www.nuget.org/packages/XPlot.Plotly/) [![Build Status](https://dev.azure.com/xplot/xplot/_apis/build/status/fslaborg.XPlot?branchName=master)](https://dev.azure.com/xplot/xplot/_build/latest?definitionId=1&branchName=master)

![XPlot logo](misc/XPlot.png)

XPlot is splendid data visualization package for F# and .NET. Uses [Plotly](https://plot.ly/graphing-libraries/) and [Google Charts](https://developers.google.com/chart/) as "backends" to render fancy visualization.

## Try XPlot in your browser

Click this button to launch a Binder instance, where you can get plotting interactively!

The `fsharp/Docs/Plotting with Xplot` and `csharp/Docs/Plotting with Xplot` notebooks show many ways you can plot data.

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/dotnet/try/master?urlpath=lab)

## Contributing

This project is accepting contributions from anyone who wants to improve XPlot.

**No contribution is too small. We appreciate everything from spelling fixes to brand-new features.**

Contributing is very easy. If you're on Unix, just run this from the command line:

    .\build.sh

If you're on Windows, run this from the command line:

    .\build.cmd

You can then open the project in any editing enviroment you prefer most.

## Documentation

http://fslaborg.github.io/XPlot/

## NuGet

* [Plotly](http://www.nuget.org/packages/XPlot.Plotly/)
* [Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts/)
* [Deedle Helpers for Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts.Deedle/)

## Release

    .\build target NuGet
    set APIKEY=...
    ..\FsLab\.nuget\NuGet.exe push bin\*.nupkg  %APIKEY% -Source https://www.nuget.org

## Contact

* Maintainers are [@zyzhu](http://github.com/zyzhu), [@cartermp](http://github.com/cartermp) and backup maintainer [@dsyme](http://github.com/dsyme) 
