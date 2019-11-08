# XPlot [![Nuget Badge](https://buildstats.info/nuget/XPlot.Plotly)](https://www.nuget.org/packages/XPlot.Plotly/) [![Build Status](https://dev.azure.com/xplot/xplot/_apis/build/status/fslaborg.XPlot?branchName=master)](https://dev.azure.com/xplot/xplot/_build/latest?definitionId=1&branchName=master)

![XPlot logo](misc/XPlot.png)

A splendid data visualization package for F# and .NET. Uses various JavaScript charting libraries as "backends".

## Documentation

http://fslaborg.github.io/XPlot/

## NuGet

* [Plotly](http://www.nuget.org/packages/XPlot.Plotly/)
* [Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts/)
* [Deedle Helpers for Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts.Deedle/)

## Building

Unix:

    .\build.sh

Windows:

    .\build.cmd

## Release

    .\build target NuGet
    set APIKEY=...
    ..\FsLab\.nuget\NuGet.exe push bin\*.nupkg  %APIKEY% -Source https://www.nuget.org

## Contact

* Maintainers are [@zyzhu](http://github.com/zyzhu), [@cartermp](http://github.com/cartermp) and backup maintainer [@dsyme](http://github.com/dsyme) 
