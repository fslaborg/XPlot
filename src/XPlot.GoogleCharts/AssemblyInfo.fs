namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.GoogleCharts")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("Data visualization library for F#")>]
[<assembly: AssemblyVersionAttribute("1.4.0")>]
[<assembly: AssemblyFileVersionAttribute("1.4.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.4.0"
    let [<Literal>] InformationalVersion = "1.4.0"
