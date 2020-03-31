// --------------------------------------------------------------------------------------
// Builds the documentation from `.fsx` and `.md` files in the 'docsrc/content' directory
// (the generated documentation is stored in the 'docs/output' directory)
// --------------------------------------------------------------------------------------

#load "formatters.fsx"

#I __SOURCE_DIRECTORY__
#I "../../packages/formatting/FSharp.Formatting/lib/netstandard2.0"
#r "FSharp.CodeFormat.dll"
#r "FSharp.Literate.dll"
#r "FSharp.Markdown.dll"
#r "FSharp.MetadataFormat.dll"
#r "FSharp.Formatting.Common.dll"
#r "Microsoft.AspNetCore.Razor.dll"
#r "Microsoft.AspNetCore.Razor.Runtime.dll"
#r "Microsoft.AspNetCore.Razor.Language.dll"
#r "RazorEngine.NetCore.dll"
#r "FSharp.Formatting.Razor.dll"

open System.Collections.Generic
open System.IO
open FSharp.Formatting.Razor

// --------------------------------------------------------------------------------------
// Helpers
// --------------------------------------------------------------------------------------
let subDirectories (dir: string) = Directory.EnumerateDirectories dir 

let rec copyRecursive dir1 dir2 =
    Directory.CreateDirectory dir2 |> ignore
    for subdir1 in Directory.EnumerateDirectories dir1 do
         let subdir2 = Path.Combine(dir2, Path.GetFileName subdir1)
         copyRecursive subdir1 subdir2
    for file in Directory.EnumerateFiles dir1 do
         File.Copy(file, file.Replace(dir1, dir2), true)

// Website location for the generated documentation
let website = "https://fslab.org/XPlot"

// Specify more information about your project
let info =
    [ "project-name", "XPlot"
      "project-author", "Taha Hachana; Tomas Petricek"
      "project-summary", "Data visualization library for F#"
      "project-github", "https://github.com/fslaborg/XPlot"
      "project-nuget", "http://www.nuget.org/packages?q=XPlot" ]

// --------------------------------------------------------------------------------------
// For typical project, no changes are needed below
// --------------------------------------------------------------------------------------

// Binaries for which to generate XML documentation
let binaries = 
    [ 
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.D3/bin/Release/netstandard2.0/XPlot.D3.dll"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.GoogleCharts/bin/Release/netstandard2.0/XPlot.GoogleCharts.dll"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.GoogleCharts.Deedle/bin/Release/netstandard2.0/XPlot.GoogleCharts.Deedle.dll"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.Plotly/bin/Release/netstandard2.0/XPlot.Plotly.dll"
    ]

let libDirs = 
    [ 
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.D3/bin/Release/netstandard2.0/"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.GoogleCharts/bin/Release/netstandard2.0/"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.GoogleCharts.Deedle/bin/Release/netstandard2.0/"
      __SOURCE_DIRECTORY__ + "/../../src/XPlot.Plotly/bin/Release/netstandard2.0/"
    ]

// When called from 'build.fsx', use the public project URL as <root>
// otherwise, use the current 'output' directory.
#if RELEASE
let root = website
#else
let root = "file://" + (__SOURCE_DIRECTORY__ @@ "../output")
#endif

let githubLink = "http://github.com/fsprojects/FSharp.Formatting"

Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__)

// Paths with template/source/output locations
let bin        = __SOURCE_DIRECTORY__ + "/../../bin"
let content    = __SOURCE_DIRECTORY__ + "/../content"
let output     = __SOURCE_DIRECTORY__ + "/../../docs/output"
let files      = __SOURCE_DIRECTORY__ + "/../files"
let templates  = __SOURCE_DIRECTORY__ + "/templates"
let formatting = __SOURCE_DIRECTORY__ + "/../../packages/formatting/FSharp.Formatting/"
let docTemplate = formatting + "/templates/docpage.cshtml"
let referenceOut = (output + "/reference")

// Where to look for *.csproj templates (in this order)
let layoutRootsAll = Dictionary<string, string list>()
layoutRootsAll.Add("en",[ templates; formatting + "templates"; formatting + "templates/reference" ])

subDirectories templates
|> Seq.iter (fun name ->
    if name.Length = 2 || name.Length = 3 then
        layoutRootsAll.Add(
                name, [templates + "/" + name
                       formatting + "templates"
                       formatting + "templates/reference" ]))

// Copy static files and CSS + JS from F# Formatting
let copyFiles () = copyRecursive files output

// Build API reference from XML comments
let buildReference () =
    printfn "building reference docs..."
    if Directory.Exists referenceOut then Directory.Delete(referenceOut, true)
    Directory.CreateDirectory referenceOut |> ignore
    RazorMetadataFormat.Generate
      ( binaries, output + "/" + "reference", layoutRootsAll.["en"],
        parameters = ("root", root)::info,
        sourceRepo = githubLink + "/" + "tree/master",
        sourceFolder = __SOURCE_DIRECTORY__ + "/" + ".." + "/" + "..",
        publicOnly = true, libDirs = libDirs)

// Build documentation from `fsx` and `md` files in `docs/content`
let buildDocumentation () =
    printfn "building docs..."
    let subdirs = [ content, docTemplate ]
    let fsiEvaluator = Formatters.createFsiEvaluator root output "#.####"
    for dir, template in subdirs do
        let sub = "." // Everything goes into the same output directory here
        let langSpecificPath(lang, path:string) =
            path.Split([|'/'; '\\'|], System.StringSplitOptions.RemoveEmptyEntries)
            |> Array.exists(fun i -> i = lang)
        let layoutRoots =
            let key = layoutRootsAll.Keys |> Seq.tryFind (fun i -> langSpecificPath(i, dir))
            match key with
            | Some lang -> layoutRootsAll.[lang]
            | None -> layoutRootsAll.["en"] // "en" is the default language
        RazorLiterate.ProcessDirectory
          ( dir, template, output + "/" + sub, replacements = ("root", root)::info,
            layoutRoots = layoutRoots,
            generateAnchors = true,
            processRecursive = false,
            includeSource = true,
            fsiEvaluator = fsiEvaluator
          )

// Generate
copyFiles()
buildDocumentation()
buildReference()