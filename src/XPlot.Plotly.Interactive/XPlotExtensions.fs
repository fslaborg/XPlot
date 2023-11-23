namespace XPlot.Plotly.Interactive

open Microsoft.DotNet.Interactive
open System.Runtime.CompilerServices

[<Extension>]
type XplotExtensions =
    [<Extension>]
    static member inline UseXplot<'a when 'a :> Kernel>(kernel: 'a) : 'a =
        KernelExtension.Load(kernel) |> ignore
        kernel

