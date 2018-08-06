XPlot
=====

About
-----

Data visualization for F# using JavaScript charting libraries.

Documentation
-------------

http://fslaborg.github.io/XPlot/

NuGet
-----

* [Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts/)

* [Deedle Helpers for Google Charts](http://www.nuget.org/packages/XPlot.GoogleCharts.Deedle/)

* [Plotly](http://www.nuget.org/packages/XPlot.Plotly/)

Building
-------------

    .\build

Release
-------------

    .\build target NuGet
    set APIKEY=...
    ..\FsLab\.nuget\NuGet.exe push bin\*.nupkg  %APIKEY% -Source https://www.nuget.org

Contact
-------

http://fslaborg.github.io/#contact
