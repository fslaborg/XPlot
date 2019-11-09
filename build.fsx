#r @"paket:
nuget Fake.Core.Target
nuget Fake.Core.Process
nuget Fake.Core.ReleaseNotes
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.DotNet.MSBuild
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.DotNet.Paket
nuget Fake.DotNet.FSFormatting
nuget Fake.DotNet.Fsi
nuget Fake.Tools.Git
nuget Fake.Api.GitHub //"

#if !FAKE
#load "./.fake/build.fsx/intellisense.fsx"
#r "netstandard" // Temp fix for https://github.com/dotnet/fsharp/issues/5216
#endif

open System
open System.IO
open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Tools

let project = "XPlot"
let summary = "Data visualization library for F#"
let solutionFile  = "XPlot.sln"
let configuration = "Release"
let gitHome = "https://github.com/fslaborg"
let gitName = project

let release = ReleaseNotes.load "RELEASE_NOTES.md"
let buildConfiguration = DotNet.Custom <| Environment.environVarOrDefault "configuration" configuration

// Generate assembly info files with the right version & up-to-date information
Target.create "AssemblyInfo" (fun _ ->
    let getAssemblyInfoAttributes projectName =
        [ AssemblyInfo.Title (projectName)
          AssemblyInfo.Product project
          AssemblyInfo.Description summary
          AssemblyInfo.Version release.AssemblyVersion
          AssemblyInfo.FileVersion release.AssemblyVersion ]

    let getProjectDetails projectPath =
        let projectName = Path.GetFileNameWithoutExtension(projectPath)
        (Path.GetDirectoryName(projectPath), getAssemblyInfoAttributes projectName)

    !! "src/**/*.fsproj"
    |> Seq.map getProjectDetails
    |> Seq.iter (fun (folderName, attributes) ->
        AssemblyInfoFile.createFSharp (folderName </> "AssemblyInfo.fs") attributes )
)

// --------------------------------------------------------------------------------------
// Clean build results

Target.create "Clean" (fun _ ->
    Shell.cleanDirs ["bin"; "temp"]
)

Target.create "CleanDocs" (fun _ ->
    Shell.cleanDirs ["docs/output"]
)

// --------------------------------------------------------------------------------------
// Build library & test project

Target.create "Build" (fun _ ->
    solutionFile 
    |> DotNet.build (fun p -> 
        { p with
            Configuration = buildConfiguration })
)

// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

// sooooon

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target.create "BuildPackages" (fun _ ->
    Paket.pack(fun p -> 
        { p with
            ToolType = ToolType.CreateLocalTool()
            OutputPath = "bin"
            Version = release.NugetVersion
            ReleaseNotes = release.Notes |> String.toLines })
)

Target.create "PublishPackages" (fun _ ->
    Paket.push(fun p ->
        { p with
            WorkingDir = "bin"
            ToolType = ToolType.CreateLocalTool()
            ApiKey = Environment.environVarOrDefault "NugetKey" "" })
)

// --------------------------------------------------------------------------------------
// Generate the documentation
Target.create "GenerateDocs" (fun _ ->
  let (exitCode, messages) = Fsi.exec (fun p -> { p with WorkingDirectory="docsrc/tools"; Define="RELEASE"; }) "generate.fsx" []
  if exitCode = 0 then () else 
    failwith (messages |> String.concat Environment.NewLine)
)

// --------------------------------------------------------------------------------------
// Release Scripts

Target.create "ReleaseDocs" (fun _ ->
    Git.Repository.clone "" (gitHome + "/" + gitName + ".git") "temp/gh-pages"
    Git.Branches.checkoutBranch "temp/gh-pages" "gh-pages"
    Shell.copyRecursive "docs/output" "temp/gh-pages" true |> printfn "%A"
    Git.CommandHelper.runSimpleGitCommand "temp/gh-pages" "add ." |> printfn "%s"
    let cmd = sprintf """commit -a -m "Update generated documentation for version %s""" release.NugetVersion
    Git.CommandHelper.runSimpleGitCommand "temp/gh-pages" cmd |> printfn "%s"
    Git.Branches.push "temp/gh-pages"
)

Target.create "Release" (fun _ ->
    Git.Staging.stageAll ""
    Git.Commit.exec "" (sprintf "Bump version to %s" release.NugetVersion)
    Git.Branches.push ""

    Git.Branches.tag "" release.NugetVersion
    Git.Branches.pushTag "" "upstream" release.NugetVersion
)

"Clean"
  ==> "AssemblyInfo"
  ==> "Build" 
  //==> "CleanDocs"
  //==> "GenerateDocs"
  ==> "BuildPackages"
  ==> "PublishPackages"
  ==> "Release"

Target.runOrDefaultWithArguments "Build"
