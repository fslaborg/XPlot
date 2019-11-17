// Learn more about F# at http://fsharp.org

open System.Text
open System.IO
open MathNet.Numerics.Distributions

let dataPrelude = Path.Combine("..", "..", "tests", "TestData", "XPlot.Plotly", "numerical-data" + string Path.DirectorySeparatorChar)

let generateNormalData () =
    let xSamples = Normal.Samples(0.0, 1.0) |> Seq.take 2000
    let ySamples = xSamples |> Seq.map (fun x -> x + 0.1)

    let xSB = StringBuilder()
    let ySB = StringBuilder()

    for (x, y) in (xSamples, ySamples) ||> Seq.zip do
        xSB.Append(x) |> ignore
        xSB.Append(',') |> ignore

        ySB.Append(y) |> ignore
        ySB.Append(',') |> ignore

    let lines = [ xSB.ToString().TrimEnd(','); ySB.ToString().TrimEnd(',') ]

    File.WriteAllLines(dataPrelude + "normal-data.txt", lines)

let generateUniformData () =
    let xSamples = ContinuousUniform.Samples(0.0, 1.0) |> Seq.take 2000
    let ySamples = xSamples |> Seq.map (fun x -> x + 0.1)

    let xSB = StringBuilder()
    let ySB = StringBuilder()

    for (x, y) in (xSamples, ySamples) ||> Seq.zip do
        xSB.Append(x) |> ignore
        xSB.Append(',') |> ignore

        ySB.Append(y) |> ignore
        ySB.Append(',') |> ignore

    let lines = [ xSB.ToString().TrimEnd(','); ySB.ToString().TrimEnd(',') ]

    File.WriteAllLines(dataPrelude + "continuous-uniform-data.txt", lines)

[<EntryPoint>]
let main _ =
    generateNormalData ()
    generateUniformData ()
    0 // return an integer exit code
