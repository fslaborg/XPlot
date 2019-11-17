// Learn more about F# at http://fsharp.org

open System
open System.Text
open System.IO
open MathNet.Numerics
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

let generateBasicLinearSpacedData () =
    let size = 100
    let xSamples = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
    let ySamples = Generate.LinearSpaced(size, -2. * Math.PI, 2. * Math.PI)
    let zSamples = Array2D.create size size 0.0

    let xSB = StringBuilder()
    let ySB = StringBuilder()
    let zSB = StringBuilder()

    for (x, y) in (xSamples, ySamples) ||> Array.zip do
        xSB.Append(x) |> ignore
        xSB.Append(',') |> ignore

        ySB.Append(y) |> ignore
        ySB.Append(',') |> ignore
    
    for i in 0 .. size-1 do
        for j in 0 .. size-1 do
            let r2 = xSamples.[i] ** 2.0 + ySamples.[j] ** 2.0
            zSamples.[i,j] <- sin xSamples.[i] * cos ySamples.[j] * sin r2 / log(r2 + 1.0)
            zSB.Append(zSamples.[i, j]) |> ignore
            zSB.Append(',') |> ignore
        zSB.Append('|') |> ignore

    let lines = [ xSB.ToString().TrimEnd(','); ySB.ToString().TrimEnd(','); zSB.ToString().TrimEnd(',') ]

    File.WriteAllLines(dataPrelude + "basic-linear-spaced-data.txt", lines)

let generatelargerLinearSpacedData () =
    let size = 2000
    let t = Generate.LinearSpaced(size, -1., 1.2)

    let sample =
        Normal.Samples(0.0, 1.0)
        |> Seq.take size
        |> Seq.toArray

    let xSamples = sample |> Array.mapi (fun i x -> t.[i] ** 3. + 0.3 * x)
    let ySamples = sample |> Array.mapi (fun i x -> t.[i] ** 6. + 0.3 * x)

    let xSB = StringBuilder()
    let ySB = StringBuilder()

    for (x, y) in (xSamples, ySamples) ||> Array.zip do
        xSB.Append(x) |> ignore
        xSB.Append(',') |> ignore

        ySB.Append(y) |> ignore
        ySB.Append(',') |> ignore

    let lines = [ xSB.ToString().TrimEnd(','); ySB.ToString().TrimEnd(','); ]

    File.WriteAllLines(dataPrelude + "larger-linear-spaced-data.txt", lines)

[<EntryPoint>]
let main _ =
    generateNormalData ()
    generateUniformData ()
    generateBasicLinearSpacedData ()
    generatelargerLinearSpacedData ()
    0 // return an integer exit code
