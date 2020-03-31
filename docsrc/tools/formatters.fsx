module Formatters

#load "../../packages/formatting/FSharp.Formatting/FSharp.Formatting.fsx"
#r "../../packages/formatting/FSharp.Compiler.Service/lib/netstandard2.0/FSharp.Compiler.Service.dll"
#r "../../packages/Deedle/lib/netstandard2.0/Deedle.dll"
#r "../../src/XPlot.GoogleCharts/bin/Release/netstandard2.0/XPlot.GoogleCharts.dll"
#r "../../src/XPlot.Plotly/bin/Release/netstandard2.0/XPlot.Plotly.dll"
#r "../../src/XPlot.D3/bin/Release/netstandard2.0/XPlot.D3.dll"

// --------------------------------------------------------------------------------------
// NOTE: Most of this file is the same as in FsLab (https://github.com/fslaborg/FsLab)
// --------------------------------------------------------------------------------------

open System.IO
open Deedle
open Deedle.Internal
open FSharp.Literate
open FSharp.Markdown
open XPlot

// --------------------------------------------------------------------------------------
// Implements Markdown formatters for common FsLab things - including Deedle series
// and frames, F# Charting charts, System.Image values and Math.NET matrices & vectors
// --------------------------------------------------------------------------------------

// How many columns and rows from frame should be rendered
let startColumnCount = 3
let endColumnCount = 3

let startRowCount = 8
let endRowCount = 4

// How many items from a series should be rendered
let startItemCount = 5
let endItemCount = 3

// How many columns and rows from a matrix should be rendered
let matrixStartColumnCount = 7
let matrixEndColumnCount = 2
let matrixStartRowCount = 10
let matrixEndRowCount = 4

// How many items from a vector should be rendered
let vectorStartItemCount = 7
let vectorEndItemCount = 2

// --------------------------------------------------------------------------------------
// Helper functions etc.
// --------------------------------------------------------------------------------------

/// Extract values from any series using reflection
let (|SeriesValues|_|) (value:obj) = 
  if value <> null then
    let iser = value.GetType().GetInterface("ISeries`1")
    if iser <> null then
      let keys = value.GetType().GetProperty("Keys").GetValue(value) :?> System.Collections.IEnumerable
      let vector = value.GetType().GetProperty("Vector").GetValue(value) :?> IVector
      Some(Seq.zip (Seq.cast<obj> keys) vector.ObjectSequence)
    else None
  else None

let (|Float|_|) (v:obj) = if v :? float then Some(v :?> float) else None
let (|Float32|_|) (v:obj) = if v :? float32 then Some(v :?> float32) else None

let inline (|PositiveInfinity|_|) (v: ^T) =
  if (^T : (static member IsPositiveInfinity: 'T -> bool) (v)) then Some PositiveInfinity else None
let inline (|NegativeInfinity|_|) (v: ^T) =
  if (^T : (static member IsNegativeInfinity: 'T -> bool) (v)) then Some NegativeInfinity else None
let inline (|NaN|_|) (v: ^T) =
  if (^T : (static member IsNaN: 'T -> bool) (v)) then Some NaN else None

/// Format value as a single-literal paragraph
let formatValue (floatFormat:string) def = function
  | Some(Float v) -> [ Paragraph([Literal(v.ToString(floatFormat), None)], None)] 
  | Some(Float32 v) -> [ Paragraph([Literal(v.ToString(floatFormat), None)], None)] 
  | Some v -> [ Paragraph([Literal(v.ToString(), None)], None)] 
  | _ -> [ Paragraph([Literal(def, None)], None)]

/// Format body of a single table cell
let td v = [ Paragraph([Literal(v, None)], None)]

/// Use 'f' to transform all values, then call 'g' with Some for 
/// values to show and None for "..." in the middle
let mapSteps (startCount, endCount) f g input = 
  input 
  |> Seq.map f |> Seq.startAndEnd startCount endCount
  |> Seq.map (function Choice1Of3 v | Choice3Of3 v -> g (Some v) | _ -> g None)
  |> List.ofSeq

// Tuples with the counts, for easy use later on
let fcols = startColumnCount, endColumnCount
let frows = startRowCount, endRowCount
let sitms = startItemCount, endItemCount
let mcols = matrixStartColumnCount, matrixEndColumnCount
let mrows = matrixStartRowCount, matrixEndRowCount
let vitms = vectorStartItemCount, vectorEndItemCount

/// Checks if the given directory exists. If not then this functions creates the directory.
let ensureDirectory dir =
    let di = new DirectoryInfo(dir)
    if not di.Exists then di.Create()

/// Combine two paths
let (@@) a b = Path.Combine(a, b)

// --------------------------------------------------------------------------------------
// Build FSI evaluator
// --------------------------------------------------------------------------------------

let mutable currentOutputKind = OutputKind.Html
let InlineMultiformatBlock(html, latex) =
    let block =
        { new MarkdownEmbedParagraphs with
            member x.Render() =
                if currentOutputKind = OutputKind.Html then
                    [ InlineBlock html ]
                else
                    [ InlineBlock latex ] }
    EmbedParagraphs(block, None)

let MathDisplay(latex) = Span([ LatexDisplayMath latex ], None)

/// Builds FSI evaluator that can render System.Image, F# Charts, series & frames
let createFsiEvaluator root output (floatFormat:string) =

  /// Counter for saving files
  let imageCounter = 
      let mutable count = 0
      fun () ->
          count <- count + 1
          count

  let transformation (value:obj, typ:System.Type) =
    match value with 
    | :? GoogleCharts.GoogleChart as ch ->
        // Just return the inline HTML of a Google chart
        let ch = ch |> XPlot.GoogleCharts.Chart.WithSize(700, 400)
        Some [ InlineBlock (ch.GetInlineHtml(), None) ]
    | :? Plotly.PlotlyChart as chart ->
        Some [ InlineBlock(chart.GetInlineHtml(), None) ]
    | :? D3.ForceLayoutChart as chart ->
      Some [ InlineBlock(chart.GetHtml(), None) ]
    | SeriesValues s ->
        // Pretty print series!
        let heads  = s |> mapSteps sitms fst (function Some k -> td (k.ToString()) | _ -> td " ... ")
        let row    = s |> mapSteps sitms snd (function Some v -> formatValue floatFormat "N/A" (OptionalValue.asOption v) | _ -> td " ... ")
        let aligns = s |> mapSteps sitms id (fun _ -> AlignDefault)
        [ InlineMultiformatBlock(("<div class=\"deedleseries\">", None), ("\\vspace{1em}", None))
          TableBlock(Some ((td "Keys")::heads), AlignDefault::aligns, [ (td "Values")::row ], None) 
          InlineMultiformatBlock(("</div>", None), ("\\vspace{1em}", None))] |> Some
    | :? IFrame as f ->
        // Pretty print frame!
        { new IFrameOperation<_> with
            member x.Invoke(f) = 
                let heads  = f.ColumnKeys |> mapSteps fcols id (function Some k -> td (k.ToString()) | _ -> td " ... ")
                let aligns = f.ColumnKeys |> mapSteps fcols id (fun _ -> AlignDefault)
                let rows = 
                  f.Rows |> Series.observationsAll |> mapSteps frows id (fun item ->
                    let def, k, data = 
                      match item with 
                      | Some(k, Some d) -> "N/A", k.ToString(), Series.observationsAll d |> Seq.map snd 
                      | Some(k, _) -> "N/A", k.ToString(), f.ColumnKeys |> Seq.map (fun _ -> None)
                      | None -> " ... ", " ... ", f.ColumnKeys |> Seq.map (fun _ -> None)
                    let row = data |> mapSteps fcols id (function Some v -> formatValue floatFormat def v | _ -> td " ... ")
                    (td k)::row )
                [ 
                  InlineMultiformatBlock(("<div class=\"deedleframe\">", None),("\\vspace{1em}", None))
                  TableBlock(Some ([]::heads), AlignDefault::aligns, rows, None) 
                  InlineMultiformatBlock(("</div>", None), ("\\vspace{1em}", None))
                ] |> Some }
        |> f.Apply
    | _ ->
        None 
    
  // Create FSI evaluator, register transformations & return
  let fsiEvaluator = FsiEvaluator() 
  fsiEvaluator.RegisterTransformation(transformation)
  fsiEvaluator