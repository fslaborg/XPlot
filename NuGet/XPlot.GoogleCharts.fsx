#I __SOURCE_DIRECTORY__
#r """../../packages/Google.DataTable.Net.Wrapper.3.1.2.0/lib/Google.DataTable.Net.Wrapper.dll"""
#r """../../packages/Newtonsoft.Json.6.0.6/lib/net45/Newtonsoft.Json.dll"""
#r """../../packages/XPlot.GoogleCharts.1.1.0/Lib/Net45/XPlot.GoogleCharts.dll"""

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

let subKeyPath = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
let keyName = "FsiAnyCPU.exe"
let localMachine = Registry.LocalMachine

try
    let keyExists =
        let subKey = localMachine.OpenSubKey(subKeyPath)
        subKey.GetValueNames()
        |> Array.exists (fun x -> x = keyName)

    match keyExists with
    | false ->
        let key = localMachine.CreateSubKey(subKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
        key.SetValue(keyName, 11001, RegistryValueKind.DWord)
        key.Close()
    | true -> ()
with _ -> printfn "Failed to instruct FSI to use the IE11 Standards mode."