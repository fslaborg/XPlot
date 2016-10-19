module Formatters
#I "../../packages/FSharp.Formatting/lib/net40"
#r "FSharp.Literate.dll"
#r "FSharp.Markdown.dll"
#r "FSharp.CodeFormat.dll"
#r "RazorEngine.dll"
#r "../../packages/FAKE/tools/FakeLib.dll"
#r "../../packages/Deedle/lib/net40/Deedle.dll"
#r "../../bin/XPlot.GoogleCharts.dll"
#r "../../bin/XPlot.Plotly.dll"
#r "../../bin/XPlot.D3.dll"

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

open System.Windows.Forms

/// Extract values from any series using reflection
let (|SeriesValues|_|) (value:obj) = 
  let iser = value.GetType().GetInterface("ISeries`1")
  if iser <> null then
    let keys = value.GetType().GetProperty("Keys").GetValue(value) :?> System.Collections.IEnumerable
    let vector = value.GetType().GetProperty("Vector").GetValue(value) :?> IVector
    Some(Seq.zip (Seq.cast<obj> keys) vector.ObjectSequence)
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
  | Some(Float v) -> [ Paragraph [Literal (v.ToString(floatFormat)) ]] 
  | Some(Float32 v) -> [ Paragraph [Literal (v.ToString(floatFormat)) ]] 
  | Some v -> [ Paragraph [Literal (v.ToString()) ]] 
  | _ -> [ Paragraph [Literal def] ]

/// Format body of a single table cell
let td v = [ Paragraph [Literal v] ]

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
          if currentOutputKind = OutputKind.Html then [ InlineBlock html ] else [ InlineBlock latex ] }
  EmbedParagraphs(block)

let MathDisplay(latex) = Span [ LatexDisplayMath latex ]

/// Builds FSI evaluator that can render System.Image, F# Charts, series & frames
let createFsiEvaluator root output (floatFormat:string) =

  /// Counter for saving files
  let imageCounter = 
    let count = ref 0
    (fun () -> incr count; !count)

  let transformation (value:obj, typ:System.Type) =
    match value with 
    | :? System.Drawing.Image as img ->
        // Pretty print image - save the image to the "images" directory 
        // and return a DirectImage reference to the appropriate location
        let id = imageCounter().ToString()
        let file = "chart" + id + ".png"
        ensureDirectory (output @@ "images")
        img.Save(output @@ "images" @@ file, System.Drawing.Imaging.ImageFormat.Png) 
        Some [ Paragraph [DirectImage ("", (root + "/images/" + file, None))]  ]

    | :? GoogleCharts.GoogleChart as ch ->
        // Just return the inline HTML of a Google chart
        let ch = ch |> XPlot.GoogleCharts.Chart.WithSize(700, 400)
        Some [ InlineBlock <| ch.GetInlineHtml() ]

    | :? Plotly.PlotlyChart as chart ->
        // Just return the inline HTML for a Plotly chart
//        let name = 
//          match fig.Layout with
//          | Some ly -> ly.title
//          | None -> sprintf "XPlot Generated Chart %d" (imageCounter())
//        fig.Width <- 600
//        fig.Height <- 300
//        Some [ InlineBlock (fig.GetInlineHtml(name)) ]
        Some [ InlineBlock <| chart.GetInlineHtml() ]
    | :? D3.ForceLayoutChart as chart -> Some [ InlineBlock <| chart.GetHtml() ]

    | SeriesValues s ->
        // Pretty print series!
        let heads  = s |> mapSteps sitms fst (function Some k -> td (k.ToString()) | _ -> td " ... ")
        let row    = s |> mapSteps sitms snd (function Some v -> formatValue floatFormat "N/A" (OptionalValue.asOption v) | _ -> td " ... ")
        let aligns = s |> mapSteps sitms id (fun _ -> AlignDefault)
        [ InlineMultiformatBlock("<div class=\"deedleseries\">", "\\vspace{1em}")
          TableBlock(Some ((td "Keys")::heads), AlignDefault::aligns, [ (td "Values")::row ]) 
          InlineMultiformatBlock("</div>","\\vspace{1em}") ] |> Some

    | :? IFrame as f ->
      // Pretty print frame!
      {new IFrameOperation<_> with
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
          Some [ 
            InlineMultiformatBlock("<div class=\"deedleframe\">","\\vspace{1em}")
            TableBlock(Some ([]::heads), AlignDefault::aligns, rows) 
            InlineMultiformatBlock("</div>","\\vspace{1em}")
          ] }
      |> f.Apply

    | _ -> None 
    
  // Create FSI evaluator, register transformations & return
  let fsiEvaluator = FsiEvaluator() 
  fsiEvaluator.RegisterTransformation(transformation)
  fsiEvaluator