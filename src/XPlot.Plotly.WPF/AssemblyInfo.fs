namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("XPlot.Plotly.WPF")>]
[<assembly: AssemblyProductAttribute("XPlot")>]
[<assembly: AssemblyDescriptionAttribute("Helpers for displaying charts created with the XPlot wrapper for Plotly in a WPF window.")>]
[<assembly: AssemblyVersionAttribute("1.0.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0.0"
