open System.Diagnostics
open System.IO
open System.Text.RegularExpressions

let nuget = Path.Combine(__SOURCE_DIRECTORY__, "nuget.exe")
let nuspec = Path.Combine(__SOURCE_DIRECTORY__, "XPlot.GoogleCharts.nuspec")

let nuspecText = File.ReadAllText nuspec

let package =
    Regex("<id>(.+?)</id>")
        .Match(nuspecText)
        .Groups
        .[1]
        .Value

let version =
    Regex("<version>(.+?)</version>")
        .Match(nuspecText)
        .Groups
        .[1]
        .Value

let nupkg =
    Path.Combine
        (
            System.Environment.CurrentDirectory,
            package + "." + version + ".nupkg"
        )

let packArgs = sprintf "pack %s" nuspec
let pushArgs = sprintf "push %s" nupkg

let startProcess args =
    let ``process`` = Process.Start(nuget, args)
    ``process``.WaitForExit()

startProcess packArgs

startProcess pushArgs