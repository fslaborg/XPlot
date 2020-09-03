# XPlot
[![Nuget Badge](https://buildstats.info/nuget/XPlot.Plotly)](https://www.nuget.org/packages/XPlot.Plotly/) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v1.4%20adopted-ff69b4.svg)](code-of-conduct.md)<a href="https://online.visualstudio.com/environments/new?name=🤘%20my-xplot&repo=fslaborg/xplot"><img src="https://img.shields.io/static/v1?style=flat-square&logo=microsoft&label=VS%20Online&message=Create&color=blue" alt="VS Online"></a>

![XPlot logo](misc/XPlot.png)

XPlot is splendid data visualization package for F# and .NET. Uses [Plotly](https://plot.ly/graphing-libraries/) and [Google Charts](https://developers.google.com/chart/) as "backends" to render fancy visualization.

## Try XPlot in your browser

Click this button to launch a Binder instance, where you can get plotting interactively!

The `fsharp/Docs/Plotting with Xplot` and `csharp/Docs/Plotting with Xplot` notebooks show many ways you can plot data.

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/dotnet/interactive/main?urlpath=lab)

## Contributing

This repository is governed by the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/).

We pledge to be overt in our openness, welcoming all people to contribute, and pledging in return to value them as whole human beings and to foster an atmosphere of kindness, cooperation, and understanding.

**No contribution is too small. We appreciate everything from spelling fixes to brand-new features.**

### Visual Studio Online quickstart

If you'd like to use Visual Studio online, just click this button to create a new online environment:

<a href="https://online.visualstudio.com/environments/new?name=my-xplot&repo=fslaborg/xplot"><img src="https://img.shields.io/static/v1?style=flat-square&logo=microsoft&label=VS%20Online&message=Create&color=blue" alt="VS Online"></a>

This will provision an environment with all necessary dependencies.

### Local development

To develop locally, first [download the latest .NET Core SDK](https://dotnet.microsoft.com/download).

Then, if you're on Unix, just run this from the command line:

    .\build.sh

If you're on Windows, run this from the command line:

    .\build.cmd

You can then open the project in the editing enviroment you prefer most. We recommend Visual Studio Code.

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
