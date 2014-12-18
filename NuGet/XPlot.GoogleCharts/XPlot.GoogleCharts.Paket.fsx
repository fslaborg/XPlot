#I __SOURCE_DIRECTORY__
#r """../../packages/Google.DataTable.Net.Wrapper/lib/Google.DataTable.Net.Wrapper.dll"""
#r """../../packages/Newtonsoft.Json/lib/net45/Newtonsoft.Json.dll"""
#r """../../packages/XPlot.GoogleCharts/Lib/Net45/XPlot.GoogleCharts.dll"""

open XPlot.GoogleCharts

// warm up data and options serialization
[1, 1]
|> Chart.Area
|> fun chart -> chart.Html
|> ignore

(*

Adds add a DWORD registry value to specify which
rendering mode and version of IE should be used by FSI.

**Problem**: WinForms and WPF browser controls default to IE7
standards mode.

**Solution**: Instruct FSI to use the IE11 Standards mode
and prevent Google Charts from falling back to VML.

*)

open Microsoft.Win32
open System.Diagnostics

type Architecture = ThirtyTwo | SixtyFour

let fsi =
    Process.GetProcessesByName "FsiAnyCPU"
    |> function
    | [||] -> ThirtyTwo
    | _ -> SixtyFour

let path =
    match fsi with
    | ThirtyTwo -> @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
    | SixtyFour -> @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"

let name =
    match fsi with
    | ThirtyTwo -> "Fsi.exe"
    | SixtyFour -> "FsiAnyCPU.exe"

let localMachine = Registry.LocalMachine

let addKey path name =
    let subKey = localMachine.OpenSubKey(path)
    subKey.GetValueNames()
    |> Array.exists (fun x -> x = name)
    |> function
    | false ->
        let key = localMachine.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)
        key.SetValue(name, 11001, RegistryValueKind.DWord)
        key.Close()
    | true -> ()

try addKey path name
with _ -> printfn "Failed to instruct FSI to use the IE11 Standards mode."