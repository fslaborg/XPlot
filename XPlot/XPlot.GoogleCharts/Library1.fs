module XPlot.GoogleCharts

#if INTERACTIVE
#r """..\packages\Newtonsoft.Json.6.0.5\lib\net45\Newtonsoft.Json.dll"""
#r """..\packages\Google.DataTable.Net.Wrapper.3.1.0.0\lib\Google.DataTable.Net.Wrapper.dll"""
#endif

open Google.DataTable.Net.Wrapper
open Google.DataTable.Net.Wrapper.Extension
open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open System
open System.Diagnostics
open System.IO

type ChartGallery =
    | Area

    override __.ToString() =
        match FSharpValue.GetUnionFields(__, typeof<ChartGallery>) with
        | case, _ -> case.Name + "Chart"


type key = IConvertible
type value = IConvertible

type DataPoint =
    {
        X : key
        Y : value
    }

    static member New(x, y) = {X = x; Y = y}

type Series =
    {
        Name : string option
        DataPoints : seq<DataPoint>
    }

    static member New(dps, ?name) = {Name = name; DataPoints = dps}


let makeDataTable series =
    let dt = new DataTable()
    let firstSeries = Seq.head series
    let firstDpX = firstSeries.DataPoints |> Seq.head |> fun x -> x.X
    let columnType =
        firstDpX.GetTypeCode()
        |> function
        | TypeCode.Boolean -> ColumnType.Boolean
        | TypeCode.DateTime -> ColumnType.Datetime
        | TypeCode.String -> ColumnType.String
        | _ -> ColumnType.Number
    let firstColumn = Column(columnType)
    match firstSeries.Name with
    | None -> ()
    | Some name -> firstColumn.Label <- name
    dt.AddColumn firstColumn |> ignore
    
    series
    |> List.iter (fun x ->
        let column = Column(ColumnType.Number)
        match x.Name with
        | None -> ()
        | Some name -> column.Label <- name
        dt.AddColumn column |> ignore    
    )

    series
    |> List.map (fun x -> x.DataPoints |> Seq.toList)
    |> Seq.toList
    |> List.concat
    |> Seq.groupBy (fun dp -> dp.X)
    |> Seq.toList
    |> List.map (fun (key, dps) -> key, dps |> Seq.toList |> List.map (fun dp -> dp.Y))
    |> List.iter (fun (key, values) ->
        let row = dt.NewRow()
        row.AddCell(Cell(key)) |> ignore
        values
        |> List.iter (fun value -> Cell(value) |> row.AddCell |> ignore)
        dt.AddRow row |> ignore
    )
    dt

[<AutoOpen>]
module Configuration =

    type Animation() =

        [<DefaultValue>]
        val mutable duration : int

        [<DefaultValue>]
        val mutable easing : string

    type Gradient() =

        [<DefaultValue>]
        val mutable color1 : string

        [<DefaultValue>]
        val mutable color2 : string

        [<DefaultValue>]
        val mutable x1 : string

        [<DefaultValue>]
        val mutable y1 : string

        [<DefaultValue>]
        val mutable x2 : string

        [<DefaultValue>]
        val mutable y2 : string

        [<DefaultValue>]
        val mutable useObjectBoundingBoxUnits : bool

    type BoxStyle() =

        [<DefaultValue>]
        val mutable stroke : string

        [<DefaultValue>]
        val mutable strokeWidth : int

        [<DefaultValue>]
        val mutable rx : int

        [<DefaultValue>]
        val mutable ry : int

        [<DefaultValue>]
        val mutable gradient : Gradient

    type TextStyle() =

        [<DefaultValue>]
        val mutable fontName : string 

        [<DefaultValue>]
        val mutable fontSize : int

        [<DefaultValue>]
        val mutable bold : bool

        [<DefaultValue>]
        val mutable italic : bool

        [<DefaultValue>]
        val mutable color : string

        [<DefaultValue>]
        val mutable auraColor : string

        [<DefaultValue>]
        val mutable opacity : float

    type Annotations() =

        [<DefaultValue>]
        val mutable boxStyle : BoxStyle

        [<DefaultValue>]
        val mutable highContrast : bool

        [<DefaultValue>]
        val mutable textStyle : TextStyle

    type BackgroundColor() =

        [<DefaultValue>]
        val mutable stroke : string

        [<DefaultValue>]
        val mutable strokeWidth : int

        [<DefaultValue>]
        val mutable fill : string

    type ChartArea() =

        [<DefaultValue>]
        val mutable backgroundColor : BackgroundColor

        [<DefaultValue>]
        val mutable left : string

        [<DefaultValue>]
        val mutable top : string

        [<DefaultValue>]
        val mutable width : string

        [<DefaultValue>]
        val mutable height : string

    type Focused() =

        [<DefaultValue>]
        val mutable color : string

        [<DefaultValue>]
        val mutable opacity : float

    type Selected = Focused
 
    type Crosshair() =

        [<DefaultValue>]
        val mutable color : string

        [<DefaultValue>]
        val mutable focused : Focused

        [<DefaultValue>]
        val mutable opacity : float

        [<DefaultValue>]
        val mutable orientation : string

        [<DefaultValue>]
        val mutable selected : Selected

        [<DefaultValue>]
        val mutable trigger : string

    type Explorer() =

        [<DefaultValue>]
        val mutable actions : string []

        [<DefaultValue>]
        val mutable axis : string

        [<DefaultValue>]
        val mutable keepInBounds : bool

        [<DefaultValue>]
        val mutable maxZoomIn : float

        [<DefaultValue>]
        val mutable maxZoomOut : float

        [<DefaultValue>]
        val mutable zoomDelta : float

    type Gridlines() =

        [<DefaultValue>]
        val mutable color : string

        [<DefaultValue>]
        val mutable count : int

    type ViewWindow() =

        [<DefaultValue>]
        val mutable max : int

        [<DefaultValue>]
        val mutable min : int


    type Axis() =

        [<DefaultValue>]
        val mutable baseline : int

        [<DefaultValue>]
        val mutable baselineColor : string

        [<DefaultValue>]
        val mutable direction : int

        [<DefaultValue>]
        val mutable format : string

        [<DefaultValue>]
        val mutable gridlines : Gridlines

        [<DefaultValue>]
        val mutable minorGridlines : Gridlines

        [<DefaultValue>]
        val mutable logScale : bool

        [<DefaultValue>]
        val mutable textPosition : string

        [<DefaultValue>]
        val mutable textStyle : TextStyle

        [<DefaultValue>]
        val mutable ticks : obj []

        [<DefaultValue>]
        val mutable title : string

        [<DefaultValue>]
        val mutable titleTextStyle : TextStyle

        [<DefaultValue>]
        val mutable allowContainerBoundaryTextCufoff : bool

        [<DefaultValue>]
        val mutable slantedText : bool

        [<DefaultValue>]
        val mutable slantedTextAngle : int

        [<DefaultValue>]
        val mutable maxAlternation : int

        [<DefaultValue>]
        val mutable maxTextLines : int

        [<DefaultValue>]
        val mutable minTextSpacing : int

        [<DefaultValue>]
        val mutable showTextEvery : int

        [<DefaultValue>]
        val mutable maxValue : int

        [<DefaultValue>]
        val mutable minValue : int

        [<DefaultValue>]
        val mutable viewWindowMode : string

        [<DefaultValue>]
        val mutable viewWindow : ViewWindow








//
//    type Legend() =
//
//        [<DefaultValue>]
//        val mutable position : string
//
//        [<DefaultValue>]
//        val mutable alignment : string
//
//        [<DefaultValue>]
//        val mutable textStyle : TextStyle
//
//        [<DefaultValue>]
//        val mutable maxLines : int
//
//    type Axis() =
//
//        [<DefaultValue>]
//        val mutable minValue : int

    type Options() =

        [<DefaultValue>]
        val mutable aggregationTarget : string

        [<DefaultValue>]
        val mutable animation : Animation

        [<DefaultValue>]
        val mutable annotations : Annotations

        [<DefaultValue>]
        val mutable areaOpacity : float

        [<DefaultValue>]
        val mutable axisTitlesPosition : string
        
        [<DefaultValue>]
        val mutable backgroundColor : BackgroundColor
   
        [<DefaultValue>]
        val mutable chartArea : ChartArea
   
        [<DefaultValue>]
        val mutable colors : string []

        [<DefaultValue>]
        val mutable crosshair : Crosshair

        [<DefaultValue>]
        val mutable dataOpacity : float

        [<DefaultValue>]
        val mutable enableInteractivity : bool

        [<DefaultValue>]
        val mutable explorer : Explorer

        [<DefaultValue>]
        val mutable focusTarget : string

        [<DefaultValue>]
        val mutable fontSize : int

        [<DefaultValue>]
        val mutable fontName : string

        [<DefaultValue>]
        val mutable forceIFrame : bool

        [<DefaultValue>]
        val mutable hAxis : Axis

        [<DefaultValue>]
        val mutable height : int

    
//        [<DefaultValue>]
//        val mutable title : string
//
//        [<DefaultValue>]
//        val mutable legend : Legend
//
//        [<DefaultValue>]
//        val mutable vAxis : Axis


let jsTemplate =
    """<script type="text/javascript">
            google.setOnLoadCallback(drawChart);
            function drawChart() {
                var data = new google.visualization.DataTable({DATA});

                var options = {OPTIONS} 

                var chart = new google.visualization.{TYPE}(document.getElementById('chart_div'));
                chart.draw(data, options);
            }
        </script>"""


let coreTemplate =
    """<html>
    <head>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <script type="text/javascript">
            google.load("visualization", "1", {packages:["corechart"]})
        </script>
        {JS}
    </head>
    <body>
        <div id="chart_div" style="width: 900px;"></div>
</html>"""

type GoogleChart() as chart =
    
    [<DefaultValue>]
    val mutable private options : Options

    [<DefaultValue>]
    val mutable private data : seq<Series>

    [<DefaultValue>]
    val mutable private html : string

    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery
    
    let guid = Guid.NewGuid().ToString()
    let htmlFile = Path.GetTempPath() + guid + ".html"

    static member internal Create data options ``type`` =
        let gc = GoogleChart()
        gc.data <- data
        gc.options <- options
        gc.``type`` <- ``type``
        let dt = makeDataTable(data |> Seq.toList)
        let dataJson = dt.GetJson()
        let settings = JsonSerializerSettings()
        settings.NullValueHandling <- NullValueHandling.Ignore
        let optionsJson = JsonConvert.SerializeObject(options, settings)
        let js =
            jsTemplate.Replace("{DATA}", dataJson)
                .Replace("{OPTIONS}", optionsJson)
                .Replace("{TYPE}", gc.``type``.ToString())
        let html = coreTemplate.Replace("{JS}", js)
        gc.html <- html
        gc

    member __.Show() =
        File.WriteAllText(htmlFile, chart.html)
        Process.Start htmlFile
        |> ignore

type Chart =
    
    static member Area(data:seq<#key * #value>, options) =
        let data' =
            data
            |> Seq.map DataPoint.New
            |> Series.New

        GoogleChart.Create [data'] options Area

    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, options) =
        let data' =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map DataPoint.New
                |> Series.New)

        GoogleChart.Create data' options Area
        



