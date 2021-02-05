namespace XPlot.Plotly.NET.Interactive

open Microsoft.DotNet.Interactive
open System.Runtime.CompilerServices

[<Extension>]
type XplotExtensions =
    [<Extension>]
    static member inline UseXplot<'a when 'a :> Kernel>(kernel: 'a) : 'a =
        let extension = KernelExtension() :> IKernelExtension
        extension.OnLoadAsync(kernel) |> ignore
        kernel

