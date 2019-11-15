
module Program

open Expecto

[<EntryPoint>]
let main args =
    let config =
        { defaultConfig with
            verbosity = Logging.LogLevel.Verbose }
    let asmName  = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
    let fileName = sprintf "testResults/TestResults-%s.xml" asmName
    let name = sprintf "%s.%O" asmName (System.Environment.OSVersion)
    let writeResults = TestResults.writeNUnitSummary (fileName, name)
    let config = config.appendSummaryHandler writeResults
    runTestsInAssembly config args