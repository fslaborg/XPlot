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
nuget Fake.DotNet.NuGet
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
open Fake.DotNet.NuGet
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
let devBuildSuffix = "-preview-" + BuildServer.buildVersion
let pkgDir = "pkg"

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
    !! "**/**/bin/" |> Shell.cleanDirs    
    ["pkg"; "temp"] |> Shell.cleanDirs
)

Target.create "CleanDocs" (fun _ ->
    ["docs/output"] |> Shell.cleanDirs
)

// --------------------------------------------------------------------------------------
// Build everything

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
// Build and publish NuGet package

Target.create "BuildDevPackages" (fun _ ->
    Paket.pack(fun p -> 
        { p with
            ToolType = ToolType.CreateLocalTool()
            OutputPath = pkgDir
            Version = release.NugetVersion + devBuildSuffix
            ReleaseNotes = release.Notes |> String.toLines })
)

Target.create "BuildReleasePackages" (fun _ ->
    Paket.pack(fun p -> 
        { p with
            ToolType = ToolType.CreateLocalTool()
            OutputPath = pkgDir
            Version = release.NugetVersion
            ReleaseNotes = release.Notes |> String.toLines })
)

Target.create "PublishDevPackages" (fun _ ->
    let token =
        match Environment.environVarOrDefault "mapped-gh-token" "" with
        | s when not (String.IsNullOrWhiteSpace s) -> s
        | _ -> failwith "GitHub packages env var doesn't exist. Create a new one and set it up!"

    for nupkg in !! (pkgDir + "/*.nupkg") do
        let setNugetPushParams (defaults: NuGet.NuGetPushParams) =
            { defaults with
                Source = Some "https://nuget.pkg.github.com/fslaborg/index.json"
                ApiKey = Some token }

        let setParams (defaults: DotNet.NuGetPushOptions) =
            { defaults with
                PushParams = setNugetPushParams defaults.PushParams }

        DotNet.nugetPush setParams nupkg
)

Target.create "PublishReleasePackages" (fun _ ->
    Paket.push(fun p ->
        { p with
            WorkingDir = "pkg"
            ToolType = ToolType.CreateLocalTool()
            ApiKey = Environment.environVarOrDefault "NuGet-key" "" })
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

Target.create "DevBuild" ignore

"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "BuildDevPackages"
  ==> "DevBuild"

"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "BuildDevPackages"
  ==> "DevBuild"
  ==> "PublishDevPackages"

"Clean"
  ==> "AssemblyInfo"
  ==> "Build"
  ==> "BuildReleasePackages"
  ==> "PublishReleasePackages"
  ==> "Release"

Target.runOrDefaultWithArguments "DevBuild"
