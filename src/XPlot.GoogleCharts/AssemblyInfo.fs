namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.GoogleCharts")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("Data visualization library for F#")>]
[<assembly: AssemblyVersionAttribute("1.1.7")>]
[<assembly: AssemblyFileVersionAttribute("1.1.7")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.1.7"
