
module Program

open Expecto

[<EntryPoint>]
let main args =
    let config =
        { defaultConfig with
            verbosity = Logging.LogLevel.Verbose }
    let asmName  = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
    let fileName = sprintf "bin/TestResults-%s-%O.xml" asmName (System.Environment.OSVersion)
    let writeResults = TestResults.writeNUnitSummary fileName
    let config = config.appendSummaryHandler writeResults
    runTestsInAssembly config args