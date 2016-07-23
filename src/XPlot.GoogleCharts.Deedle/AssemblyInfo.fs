namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.GoogleCharts.Deedle")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("Data visualization library for F#")>]
[<assembly: AssemblyVersionAttribute("1.3.1")>]
[<assembly: AssemblyFileVersionAttribute("1.3.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.3.1"
    let [<Literal>] InformationalVersion = "1.3.1"
