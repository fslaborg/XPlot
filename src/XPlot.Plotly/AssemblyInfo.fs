namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.Plotly")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("F# wrapper for Plotly.")>]
[<assembly: AssemblyVersionAttribute("1.0.1")>]
[<assembly: AssemblyFileVersionAttribute("1.0.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0.1"
