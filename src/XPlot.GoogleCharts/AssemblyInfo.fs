namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.GoogleCharts")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("Data visualization library for F#")>]
[<assembly: AssemblyVersionAttribute("1.2.1")>]
[<assembly: AssemblyFileVersionAttribute("1.2.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2.1"
