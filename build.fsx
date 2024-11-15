#r "nuget: Fun.Build, 1.1.2"
#r "nuget: Fake.IO.FileSystem, 6.0.0"
#r "nuget: Fake.Core.ReleaseNotes, 6.0.0"
#r "nuget: Fake.DotNet.AssemblyInfoFile, 6.0.0"

open System
open System.IO
open System.Xml.Linq
open Fun.Build
open Fake.Core
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.DotNet

let project = "XPlot"
let summary = "Data visualization library for F#"
let solutionFile = "XPlot.sln"

let gitHome = "https://github.com/fslaborg"
let gitName = project
let devBuildSuffix = BuildServer.buildVersion
let pkgDir = "pkg"

let release = ReleaseNotes.load "RELEASE_NOTES.md"
let buildConfiguration = Environment.environVarOrDefault "configuration" "Release"

// Generate assembly info files with the right version & up-to-date information
let AssemblyInfo =
    stage "AssemblyInfo" {
        run (fun ctx ->
            let getAssemblyInfoAttributes projectName =
                [ AssemblyInfo.Title(projectName)
                  AssemblyInfo.Product project
                  AssemblyInfo.Description summary
                  AssemblyInfo.Version release.AssemblyVersion
                  AssemblyInfo.FileVersion release.AssemblyVersion ]

            let getProjectDetails (projectPath: string) =
                let projectName = Path.GetFileNameWithoutExtension(projectPath)
                (Path.GetDirectoryName(projectPath), getAssemblyInfoAttributes projectName)

            !! "src/**/*.fsproj"
            |> Seq.map getProjectDetails
            |> Seq.iter (fun (folderName, attributes) ->
                AssemblyInfoFile.createFSharp (folderName </> "AssemblyInfo.fs") attributes))
    }

let Clean =
    stage "Clean" {
        run (fun ctx ->
            !! "**/**/bin/" |> Shell.cleanDirs
            [ "pkg"; "temp" ] |> Shell.cleanDirs
            [ "docs/output" ] |> Shell.cleanDirs)
    }

let Build =
    stage "Build" { run $"dotnet build -c %s{buildConfiguration} %s{solutionFile}" }

let CopyBinaries =
    stage "CopyBinaries" {
        run (fun ctx ->
            !! "src/**/*.??proj" -- "src/**/*.shproj"
            |> Seq.map (fun f ->
                ((System.IO.Path.GetDirectoryName f) </> "bin" </> buildConfiguration,
                 "bin" </> (System.IO.Path.GetFileNameWithoutExtension f)))
            |> Seq.iter (fun (fromDir, toDir) -> Shell.copyDir toDir fromDir (fun _ -> true))
            // Copy dll to release folder to avoid errors of missing external assemblies during generating API docs
            Shell.copyDir
                "src/XPlot.GoogleCharts.Deedle/bin/Release/netstandard2.0"
                "packages/Deedle/lib/netstandard2.0/"
                (fun _ -> true))
    }

let GenerateDocs =
    stage "GenerateDocs" {
        run (fun ctx -> Shell.cleanDir ".fsdocs")

        run
            "dotnet fsdocs build --clean --eval --properties Configuration=Release --parameters fsdocs-navbar-position fixed-left"
    }

let ReleaseDocs =
    let gitCloneUrl = gitHome + "/" + gitName + ".git"

    let commitMsg =
        "Update generated documentation for version %s{release.NugetVersion}"

    stage "ReleaseDocs" {
        run $"git clone %s{gitCloneUrl} \"temp/gh-pages\""

        stage "checkout gh-pages" {
            workingDir "temp/gh-pages"
            run "git checkout \"gh-pages\""
        }

        run (fun ctx -> Shell.copyRecursive "output" "temp/gh-pages" true |> printfn "%A")

        stage "add" {
            workingDir "temp/gh-pages"
            run "git add ."
            run $"git commit -a -m \"%s{commitMsg}\""
            run "git push"
        }
    }

let GenerateLocalDocs =
    let root = "file://" + (__SOURCE_DIRECTORY__ @@ "/output/")

    let cmd =
        @"build --clean --eval --properties Configuration=Release --parameters fsdocs-navbar-position fixed-left root """
        + root
        + @""""

    stage "GenerateLocalDocs" {
        run (fun ctx -> Shell.cleanDir ".fsdocs")
        run $"dotnet fsdocs %s{cmd}"
    }

let BuildPackages (isDev: bool) =
    let version = release.NugetVersion + (if isDev then devBuildSuffix else "")

    let xmlEncode (notEncodedText: string) =
        if String.IsNullOrWhiteSpace notEncodedText then
            ""
        else
            XText(notEncodedText).ToString().Replace("ß", "&szlig;")

    let releaseNotes = release.Notes |> String.toLines |> xmlEncode

    stage "BuildDevPackages" {
        run $"dotnet paket pack --version %s{version} --release-notes \"%s{releaseNotes}\" %s{pkgDir}"
    }

let RunPlotlyTests =
    stage "RunPlotlyTests" { run "dotnet ./tests/XPlot.Plotly.Tests/bin/Release/net8.0/XPlot.Plotly.Tests.dll" }

let PublishDevPackages =
    stage "PublishDevPackages" {
        run (fun ctx ->
            async {
                let token =
                    match Environment.environVarOrDefault "mapped-gh-token" "" with
                    | s when not (String.IsNullOrWhiteSpace s) -> s
                    | _ -> failwith "GitHub packages env var doesn't exist. Create a new one and set it up!"

                let mutable exitCode = 0

                for nupkg in !!(pkgDir + "/*.nupkg") do
                    let! result =
                        ctx.RunSensitiveCommand
                            $"dotnet nuget push --source \"https://nuget.pkg.github.com/fslaborg/index.json\" --api-key {token} {nupkg}"

                    exitCode <-
                        (match result with
                         | Ok _ -> 0
                         | Error _ -> 1)

                return exitCode
            })
    }

let PublishReleasePackages =
    let apiKey = Environment.environVarOrDefault "NuGet-key" ""

    stage "PublishReleasePackages" {
        workingDir (__SOURCE_DIRECTORY__ </> "pkg")
        runSensitive $"dotnet paket push --api-key {apiKey}"
    }

let Release =
    let commitMsg = $"Bump version to %s{release.NugetVersion}"

    stage "Release" {
        run "git add . --all"
        run $"git commit -m \"%s{commitMsg}\""
        run "git push"
        run $"git tag %s{release.NugetVersion}"
        run $"git push upstream %s{release.NugetVersion}"
    }

pipeline "DevBuild" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    CopyBinaries
    GenerateDocs
    BuildPackages true
    runIfOnlySpecified false
}

pipeline "CIBuild" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    CopyBinaries
    GenerateDocs
    BuildPackages true
    RunPlotlyTests
    runIfOnlySpecified true
}

pipeline "GenerateLocalDocs" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    CopyBinaries
    GenerateLocalDocs
    runIfOnlySpecified true
}

pipeline "ReleaseDocs" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    CopyBinaries
    GenerateDocs
    ReleaseDocs
    runIfOnlySpecified true
}

pipeline "PublishDevPackages" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    CopyBinaries
    GenerateDocs
    BuildPackages true
    PublishDevPackages
    runIfOnlySpecified true
}

pipeline "Release" {
    workingDir __SOURCE_DIRECTORY__
    Clean
    AssemblyInfo
    Build
    BuildPackages false
    PublishReleasePackages
    Release
    runIfOnlySpecified true
}

// This will collect command line help information for you
// You can run: dotnet fsi demo.fsx -- -h
tryPrintPipelineCommandHelp ()
