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

//let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
//let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
//
//let data = [sales; expenses]
//let dt = data.ToGoogleDataTable()
//
//dt.Build().GetJson()


type ChartGallery =
    | Area

    override __.ToString() =
        match FSharpValue.GetUnionFields(__, typeof<ChartGallery>) with
        | case, _ -> case.Name + "Chart"

type key = IConvertible
type value = IConvertible

[<AutoOpen>]
module Data =

    type Datum =
        {
            X : key
            Y1 : value
            Y2 : value option
        }

        static member New(x, y) = {X = x; Y1 = y; Y2 = None}

        static member New(x, y1, y2) = {X = x; Y1 = y1; Y2 = Some y2}

    type Series =
        {
            Name : string option
            Datums : seq<Datum>
        }

        static member New name datums = {Name = name; Datums = datums}

        member __.WithName name = {__ with Name = name}

    let sales =
        ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
        |> List.map (fun (x, y) -> x, y, 10)
        |> List.map Datum.New
        
    let expenses =
        ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
        |> List.map (fun (x, y) -> x, y, 20)
        |> List.map Datum.New

    let salesSeries = Series.New (Some "Sales") sales
    let expensesSeries = Series.New (Some "Expenses") expenses

    let series = seq {yield salesSeries; yield expensesSeries}



//    let dt = new DataTable()
//    let labels =
//        [
//            for x in series -> x.Name
//        ]
//    let datum = Seq.head series |> fun x -> Seq.head x.Datums
//    let firstColumnType =
//        datum.X.GetTypeCode()
//        |> function
//        | TypeCode.Boolean -> ColumnType.Boolean
//        | TypeCode.DateTime -> ColumnType.Datetime
//        | TypeCode.String -> ColumnType.String
//        | _ -> ColumnType.Number
//        |> fun x -> dt.AddColumn(Column(x)) |> ignore
//
//    labels
//    |> Seq.zip [yield datum.Y1.GetTypeCode(); if datum.Y2.IsSome then yield datum.Y2.Value.GetTypeCode()]
//    |> Seq.iter (fun (typecode, label) ->
//        let columnType =
//            match typecode with
//            | TypeCode.Boolean -> ColumnType.Boolean
//            | TypeCode.DateTime -> ColumnType.Datetime
//            | TypeCode.String -> ColumnType.String
//            | _ -> ColumnType.Number
//        let column = Column(columnType)
//        if label.IsSome then column.Label <- label.Value
//        dt.AddColumn column |> ignore)

//    let inferColumnType isKey series =
//        series.Datums
//        |> Seq.head
//        |> fun datum ->
//            match isKey with
//            | false -> datum.Y
//            | true -> datum.X
//        |> fun x -> x.GetTypeCode()
//        |> function
//        | TypeCode.Boolean -> ColumnType.Boolean
//        | TypeCode.DateTime -> ColumnType.Datetime
//        | TypeCode.String -> ColumnType.String
//        | _ -> ColumnType.Number

//    let keyColumnType = inferColumnType true
//
//    let valueColumnType = inferColumnType false

    let makeDataTable (series:seq<Series>) =
        let dt = new DataTable()
    
//        let labels =
//            [
//                for x in series -> x.Name
//            ]
        let datum = Seq.head series |> fun x -> Seq.head x.Datums
        let firstColumnType =
            datum.X.GetTypeCode()
            |> function
            | TypeCode.Boolean -> ColumnType.Boolean
            | TypeCode.DateTime -> ColumnType.Datetime
            | TypeCode.String -> ColumnType.String
            | _ -> ColumnType.Number
            |> fun x -> dt.AddColumn(Column(x)) |> ignore

        [
            yield datum.Y1.GetTypeCode()
            yield datum.Y1.GetTypeCode()
            if datum.Y2.IsSome then yield datum.Y2.Value.GetTypeCode()
            if datum.Y2.IsSome then yield datum.Y2.Value.GetTypeCode()
        ]
        |> Seq.iter (fun typecode ->
            let columnType =
                match typecode with
                | TypeCode.Boolean -> ColumnType.Boolean
                | TypeCode.DateTime -> ColumnType.Datetime
                | TypeCode.String -> ColumnType.String
                | _ -> ColumnType.Number
            let column = Column(columnType)
//            if label.IsSome then column.Label <- label.Value
            dt.AddColumn column |> ignore)
//        dt.Columns
//        // keys column
//        let firstSeries = Seq.head series
//        let firstColumn = Column(keyColumnType firstSeries)
//        match firstSeries.Name with
//        | None -> ()
//        | Some name -> firstColumn.Label <- name
//        dt.AddColumn firstColumn |> ignore
    
//        // values columns        
//        series
//        |> Seq.iter (fun x ->
//            let column = Column(valueColumnType x)
//            match x.Name with
//            | None -> ()
//            | Some name -> column.Label <- name
//            dt.AddColumn column |> ignore    
//        )

        // table rows
        series
        |> Seq.map (fun x -> x.Datums)
        |> Seq.concat
        |> Seq.groupBy (fun datum -> datum.X)
        |> Seq.map (fun (key, dps) -> key, dps |> Seq.map (fun dp -> [yield dp.Y1; if dp.Y2.IsSome then yield dp.Y2.Value]))
        |> Seq.iter (fun (key, values) ->
            let row = dt.NewRow()
            row.AddCell(Cell(key)) |> ignore
            values
            |> Seq.iter (fun value ->
//                let row = dt.NewRow()
//                row.AddCell(Cell(key)) |> ignore
                value
                |> Seq.iter (fun v ->
//                    let row = dt.NewRow()
//                    row.AddCell(Cell(key)) |> ignore
                    Cell(v)
                    |> row.AddCell
                    |> ignore
                )
            )
            dt.AddRow row |> ignore

    //        dt.AddRow row |> ignore
        )
        dt

[<AutoOpen>]
module Configuration =

    type Animation() =
        
        let mutable durationField : int option = None
        let mutable easingField : string option = None

        member __.duration
            with get() = durationField.Value
            and set(value) = durationField <- Some value

        member __.easing
            with get() = easingField.Value
            and set(value) = easingField <- Some value

        member __.ShouldSerializeduration() = not durationField.IsNone
        member __.ShouldSerializeeasing() = not easingField.IsNone

    type Gradient() =

        let mutable color1Field : string option = None
        let mutable color2Field : string option = None
        let mutable x1Field : string option = None
        let mutable y1Field : string option = None
        let mutable x2Field : string option = None
        let mutable y2Field : string option = None
        let mutable useObjectBoundingBoxUnitsField : bool option = None

        member __.color1
            with get() = color1Field.Value
            and set(value) = color1Field <- Some value

        member __.color2
            with get() = color2Field.Value
            and set(value) = color2Field <- Some value

        member __.x1
            with get() = x1Field.Value
            and set(value) = x1Field <- Some value

        member __.y1
            with get() = y1Field.Value
            and set(value) = y1Field <- Some value

        member __.x2
            with get() = x1Field.Value
            and set(value) = x1Field <- Some value

        member __.y2
            with get() = y1Field.Value
            and set(value) = y1Field <- Some value

        member __.useObjectBoundingBoxUnits
            with get() = useObjectBoundingBoxUnitsField.Value
            and set(value) = useObjectBoundingBoxUnitsField <- Some value

        member __.ShouldSerializecolor1() = not color1Field.IsNone
        member __.ShouldSerializecolor2() = not color2Field.IsNone
        member __.ShouldSerializex1() = not x1Field.IsNone
        member __.ShouldSerializey1() = not y1Field.IsNone
        member __.ShouldSerializex2() = not x1Field.IsNone
        member __.ShouldSerializey2() = not y1Field.IsNone
        member __.ShouldSerializeuseObjectBoundingBoxUnits() = not useObjectBoundingBoxUnitsField.IsNone

    type BoxStyle() =

        let mutable strokeField : string option = None
        let mutable strokeWidthField : int option = None
        let mutable rxField : int option = None
        let mutable ryField : int option = None
        let mutable gradientField : Gradient option = None

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.strokeWidth
            with get() = strokeWidthField.Value
            and set(value) = strokeWidthField <- Some value

        member __.rx
            with get() = rxField.Value
            and set(value) = rxField <- Some value

        member __.ry
            with get() = ryField.Value
            and set(value) = ryField <- Some value

        member __.gradient
            with get() = gradientField.Value
            and set(value) = gradientField <- Some value

        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializestrokeWidth() = not strokeWidthField.IsNone
        member __.ShouldSerializerx() = not rxField.IsNone
        member __.ShouldSerializery() = not ryField.IsNone
        member __.ShouldSerializegradient() = not gradientField.IsNone

    type TextStyle() =

        let mutable fontNameField : string option = None
        let mutable fontSizeField : int option = None
        let mutable boldField : bool option = None
        let mutable italicField : bool option = None
        let mutable colorField : string option = None
        let mutable auraColorField : string option = None
        let mutable opacityField : float option = None

        member __.fontName
            with get() = fontNameField.Value
            and set(value) = fontNameField <- Some value

        member __.fontSize
            with get() = fontSizeField.Value
            and set(value) = fontSizeField <- Some value

        member __.bold
            with get() = boldField.Value
            and set(value) = boldField <- Some value

        member __.italic
            with get() = italicField.Value
            and set(value) = italicField <- Some value

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.auraColor
            with get() = auraColorField.Value
            and set(value) = auraColorField <- Some value

        member __.opacity
            with get() = opacityField.Value
            and set(value) = opacityField <- Some value

        member __.ShouldSerializefontName() = not fontNameField.IsNone
        member __.ShouldSerializefontSize() = not fontSizeField.IsNone
        member __.ShouldSerializebold() = not boldField.IsNone
        member __.ShouldSerializeitalic() = not italicField.IsNone
        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializeauraColor() = not auraColorField.IsNone
        member __.ShouldSerializeopacity() = not opacityField.IsNone

    type Annotations() =

        let mutable boxStyleField : BoxStyle option = None
        let mutable highContrastField : bool option = None
        let mutable textStyleField : TextStyle option = None

        member __.boxStyle
            with get() = boxStyleField.Value
            and set(value) = boxStyleField <- Some value

        member __.highContrast
            with get() = highContrastField.Value
            and set(value) = highContrastField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ShouldSerializeboxStyle() = not boxStyleField.IsNone
        member __.ShouldSerializehighContrast() = not highContrastField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone

    type BackgroundColor() =

        let mutable strokeField : string option = None
        let mutable strokeWidthField : int option = None
        let mutable fillField : string option = None

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.strokeWidth
            with get() = strokeWidthField.Value
            and set(value) = strokeWidthField <- Some value

        member __.fill
            with get() = fillField.Value
            and set(value) = fillField <- Some value

        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializestrokeWidth() = not strokeWidthField.IsNone
        member __.ShouldSerializefill() = not fillField.IsNone

    type ChartArea() =

        let mutable backgroundColorField : BackgroundColor option = None
        let mutable leftField : string option = None
        let mutable topField : string option = None
        let mutable widthField : string option = None
        let mutable heightField : string option = None

        member __.backgroundColor
            with get() = backgroundColorField.Value
            and set(value) = backgroundColorField <- Some value

        member __.left
            with get() = leftField.Value
            and set(value) = leftField <- Some value

        member __.top
            with get() = topField.Value
            and set(value) = topField <- Some value

        member __.width
            with get() = widthField.Value
            and set(value) = widthField <- Some value

        member __.height
            with get() = heightField.Value
            and set(value) = heightField <- Some value

        member __.ShouldSerializebackgroundColor() = not backgroundColorField.IsNone
        member __.ShouldSerializeleft() = not leftField.IsNone
        member __.ShouldSerializetop() = not topField.IsNone
        member __.ShouldSerializewidth() = not widthField.IsNone
        member __.ShouldSerializeheight() = not heightField.IsNone

    type Focused() =

        let mutable colorField : string option = None
        let mutable opacityField : float option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.opacity
            with get() = opacityField.Value
            and set(value) = opacityField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializeopacity() = not opacityField.IsNone

    type Selected = Focused
 
    type Crosshair() =

        let mutable colorField : string option = None
        let mutable focusedField : Focused option = None
        let mutable opacityField : float option = None
        let mutable orientationField : string option = None
        let mutable selectedField : Selected option = None
        let mutable triggerField : string option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.focused
            with get() = focusedField.Value
            and set(value) = focusedField <- Some value

        member __.opacity
            with get() = opacityField.Value
            and set(value) = opacityField <- Some value

        member __.orientation
            with get() = orientationField.Value
            and set(value) = orientationField <- Some value

        member __.selected
            with get() = selectedField.Value
            and set(value) = selectedField <- Some value

        member __.trigger
            with get() = triggerField.Value
            and set(value) = triggerField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializefocused() = not focusedField.IsNone
        member __.ShouldSerializeopacity() = not opacityField.IsNone
        member __.ShouldSerializeorientation() = not orientationField.IsNone
        member __.ShouldSerializeselected() = not selectedField.IsNone
        member __.ShouldSerializetrigger() = not triggerField.IsNone

    type Explorer() =

        let mutable actionsField : string [] option = None
        let mutable axisField : string option = None
        let mutable keepInBoundsField : bool option = None
        let mutable maxZoomInField : float option = None
        let mutable maxZoomOutField : float option = None
        let mutable zoomDeltaField : float option = None

        member __.actions
            with get() = actionsField.Value
            and set(value) = actionsField <- Some value

        member __.axis
            with get() = axisField.Value
            and set(value) = axisField <- Some value

        member __.keepInBounds
            with get() = keepInBoundsField.Value
            and set(value) = keepInBoundsField <- Some value

        member __.maxZoomIn
            with get() = maxZoomInField.Value
            and set(value) = maxZoomInField <- Some value

        member __.maxZoomOut
            with get() = maxZoomOutField.Value
            and set(value) = maxZoomOutField <- Some value

        member __.zoomDelta
            with get() = zoomDeltaField.Value
            and set(value) = zoomDeltaField <- Some value

        member __.ShouldSerializeactions() = not actionsField.IsNone
        member __.ShouldSerializeaxis() = not axisField.IsNone
        member __.ShouldSerializekeepInBounds() = not keepInBoundsField.IsNone
        member __.ShouldSerializemaxZoomIn() = not maxZoomInField.IsNone
        member __.ShouldSerializemaxZoomOut() = not maxZoomOutField.IsNone
        member __.ShouldSerializezoomDelta() = not zoomDeltaField.IsNone

    type Gridlines() =

        let mutable colorField : string option = None
        let mutable countField : int option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.count
            with get() = countField.Value
            and set(value) = countField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializecount() = not countField.IsNone

    type ViewWindow() =

        let mutable maxField : int option = None
        let mutable minField : int option = None

        member __.max
            with get() = maxField.Value
            and set(value) = maxField <- Some value

        member __.min
            with get() = minField.Value
            and set(value) = minField <- Some value

        member __.ShouldSerializemax() = not maxField.IsNone
        member __.ShouldSerializemin() = not minField.IsNone

    type Axis() =

        let mutable baselineField : int option = None
        let mutable baselineColorField : string option = None
        let mutable directionField : int option = None
        let mutable formatField : string option = None
        let mutable gridlinesField : Gridlines option = None
        let mutable minorGridlinesField : Gridlines option = None
        let mutable logScaleField : bool option = None
        let mutable textPositionField : string option = None
        let mutable textStyleField : TextStyle option = None
        let mutable ticksField : obj [] option = None
        let mutable titleField : string option = None
        let mutable titleTextStyleField : TextStyle option = None
        let mutable allowContainerBoundaryTextCufoffField : bool option = None
        let mutable slantedTextField : bool option = None
        let mutable slantedTextAngleField : int option = None
        let mutable maxAlternationField : int option = None
        let mutable maxTextLinesField : int option = None
        let mutable minTextSpacingField : int option = None
        let mutable showTextEveryField : int option = None
        let mutable maxValueField : int option = None
        let mutable minValueVal : int option = None
        let mutable viewWindowModeField : string option = None
        let mutable viewWindowField : ViewWindow option = None

        member __.baseline
            with get() = baselineField.Value
            and set(value) = baselineField <- Some value

        member __.baselineColor
            with get() = baselineColorField.Value
            and set(value) = baselineColorField <- Some value

        member __.direction
            with get() = directionField.Value
            and set(value) = directionField <- Some value

        member __.format
            with get() = formatField.Value
            and set(value) = formatField <- Some value

        member __.gridlines
            with get() = gridlinesField.Value
            and set(value) = gridlinesField <- Some value

        member __.minorGridlines
            with get() = minorGridlinesField.Value
            and set(value) = minorGridlinesField <- Some value

        member __.logScale
            with get() = logScaleField.Value
            and set(value) = logScaleField <- Some value

        member __.textPosition
            with get() = textPositionField.Value
            and set(value) = textPositionField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ticks
            with get() = ticksField.Value
            and set(value) = ticksField <- Some value

        member __.title
            with get() = titleField.Value
            and set(value) = titleField <- Some value

        member __.titleTextStyle
            with get() = titleTextStyleField.Value
            and set(value) = titleTextStyleField <- Some value

        member __.allowContainerBoundaryTextCufoff
            with get() = allowContainerBoundaryTextCufoffField.Value
            and set(value) = allowContainerBoundaryTextCufoffField <- Some value

        member __.slantedText
            with get() = slantedTextField.Value
            and set(value) = slantedTextField <- Some value

        member __.slantedTextAngle
            with get() = slantedTextAngleField.Value
            and set(value) = slantedTextAngleField <- Some value

        member __.maxAlternation
            with get() = maxAlternationField.Value
            and set(value) = maxAlternationField <- Some value

        member __.maxTextLines
            with get() = maxTextLinesField.Value
            and set(value) = maxTextLinesField <- Some value

        member __.minTextSpacing
            with get() = minTextSpacingField.Value
            and set(value) = minTextSpacingField <- Some value

        member __.showTextEvery
            with get() = showTextEveryField.Value
            and set(value) = showTextEveryField <- Some value

        member __.maxValue
            with get() = maxValueField.Value
            and set(value) = maxValueField <- Some value

        member __.minValue
            with get() = minValueVal.Value
            and set(value) = minValueVal <- Some value

        member __.viewWindowMode
            with get() = viewWindowModeField.Value
            and set(value) = viewWindowModeField <- Some value

        member __.viewWindow
            with get() = viewWindowField.Value
            and set(value) = viewWindowField <- Some value

        member __.ShouldSerializebaseline() = not baselineField.IsNone
        member __.ShouldSerializebaselineColor() = not baselineColorField.IsNone
        member __.ShouldSerializedirection() = not directionField.IsNone
        member __.ShouldSerializeformat() = not formatField.IsNone
        member __.ShouldSerializegridlines() = not gridlinesField.IsNone
        member __.ShouldSerializeminorGridlines() = not minorGridlinesField.IsNone
        member __.ShouldSerializelogScale() = not logScaleField.IsNone
        member __.ShouldSerializetextPosition() = not textPositionField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone
        member __.ShouldSerializeticks() = not ticksField.IsNone
        member __.ShouldSerializetitle() = not titleField.IsNone
        member __.ShouldSerializetitleTextStyle() = not titleTextStyleField.IsNone
        member __.ShouldSerializeallowContainerBoundaryTextCufoff() = not allowContainerBoundaryTextCufoffField.IsNone
        member __.ShouldSerializeslantedText() = not slantedTextField.IsNone
        member __.ShouldSerializeslantedTextAngle() = not slantedTextAngleField.IsNone
        member __.ShouldSerializemaxAlternation() = not maxAlternationField.IsNone
        member __.ShouldSerializemaxTextLines() = not maxTextLinesField.IsNone
        member __.ShouldSerializeminTextSpacing() = not minTextSpacingField.IsNone
        member __.ShouldSerializeshowTextEvery() = not showTextEveryField.IsNone
        member __.ShouldSerializemaxValue() = not maxValueField.IsNone
        member __.ShouldSerializeminValue() = not minValueVal.IsNone
        member __.ShouldSerializeviewWindowMode() = not viewWindowModeField.IsNone
        member __.ShouldSerializeviewWindow() = not viewWindowField.IsNone

    type Legend() =

        let mutable alignmentField : string option = None
        let mutable maxLinesField : int option = None
        let mutable positionField : string option = None
        let mutable textStyleField : TextStyle option = None

        member __.alignment
            with get() = alignmentField.Value
            and set(value) = alignmentField <- Some value

        member __.maxLines
            with get() = maxLinesField.Value
            and set(value) = maxLinesField <- Some value

        member __.position
            with get() = positionField.Value
            and set(value) = positionField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ShouldSerializealignment() = not alignmentField.IsNone
        member __.ShouldSerializemaxLines() = not maxLinesField.IsNone
        member __.ShouldSerializeposition() = not positionField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone

    type Series() =

        let mutable annotationsField : Annotations option = None
        let mutable colorField : string option = None
        let mutable targetAxisIndexField : int option = None
        let mutable pointShapeField : string option = None
        let mutable pointSizeField : int option = None
        let mutable lineWidthField : int option = None
        let mutable areaOpacityField : float option = None
        let mutable visibleInLegendField : bool option = None

        member __.annotations
            with get() = annotationsField.Value
            and set(value) = annotationsField <- Some value

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.targetAxisIndex
            with get() = targetAxisIndexField.Value
            and set(value) = targetAxisIndexField <- Some value

        member __.pointShape
            with get() = pointShapeField.Value
            and set(value) = pointShapeField <- Some value

        member __.pointSize
            with get() = pointSizeField.Value
            and set(value) = pointSizeField <- Some value

        member __.lineWidth
            with get() = lineWidthField.Value
            and set(value) = lineWidthField <- Some value

        member __.areaOpacity
            with get() = areaOpacityField.Value
            and set(value) = areaOpacityField <- Some value

        member __.visibleInLegend
            with get() = visibleInLegendField.Value
            and set(value) = visibleInLegendField <- Some value

        member __.ShouldSerializeannotations() = not annotationsField.IsNone
        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializetargetAxisIndex() = not targetAxisIndexField.IsNone
        member __.ShouldSerializepointShape() = not pointShapeField.IsNone
        member __.ShouldSerializepointSize() = not pointSizeField.IsNone
        member __.ShouldSerializelineWidth() = not lineWidthField.IsNone
        member __.ShouldSerializeareaOpacity() = not areaOpacityField.IsNone
        member __.ShouldSerializevisibleInLegend() = not visibleInLegendField.IsNone

    type Tooltip() =

        let mutable isHtmlField : bool option = None
        let mutable showColorCodeField : bool option = None
        let mutable textStyleField : TextStyle option = None
        let mutable triggerField : string option = None

        member __.isHtml
            with get() = isHtmlField.Value
            and set(value) = isHtmlField <- Some value

        member __.showColorCode
            with get() = showColorCodeField.Value
            and set(value) = showColorCodeField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.trigger
            with get() = triggerField.Value
            and set(value) = triggerField <- Some value

        member __.ShouldSerializeisHtml() = not isHtmlField.IsNone
        member __.ShouldSerializeshowColorCode() = not showColorCodeField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone
        member __.ShouldSerializetrigger() = not triggerField.IsNone

    type Options() =

        let mutable aggregationTargetField : string option = None
        let mutable animationField : Animation option = None
        let mutable annotationsField : Annotations option = None
        let mutable areaOpacityField : float option = None
        let mutable axisTitlesPositionField : string option = None
        let mutable backgroundColorField : BackgroundColor option = None
        let mutable chartAreaField : ChartArea option = None
        let mutable colorsField : string [] option = None
        let mutable crosshairField : Crosshair option = None
        let mutable dataOpacityField : float option = None
        let mutable enableInteractivityField : bool option = None
        let mutable explorerField : Explorer option = None
        let mutable focusTargetField : string option = None
        let mutable fontSizeField : int option = None
        let mutable fontNameField : string option = None
        let mutable forceIFrameField : bool option = None
        let mutable hAxisField : Axis option = None
        let mutable heightField : int option = Some 500
        let mutable interpolateNullsField : bool option = None
        let mutable isStackedField : bool option = None
        let mutable legendField : Legend option = Some <| Legend(position = "none")
        let mutable lineWidthField : int option = None
        let mutable orientationField : string option = None
        let mutable pointShapeField : string option = None
        let mutable pointSizeField : int option = None
        let mutable reverseCategoriesField : bool option = None
        let mutable selectionModeField : string option = None
        let mutable seriesField : Series [] option = None
        let mutable themeField : string option = None
        let mutable titleField : string option = None
        let mutable titlePositionField : string option = None
        let mutable titleTextStyleField : TextStyle option = None
        let mutable tooltipField : Tooltip option = None
        let mutable vAxesField : Axis [] option = None
        let mutable vAxisField : Axis option = None
        let mutable widthField : int option = Some 900

        member __.aggregationTarget
            with get() = aggregationTargetField.Value
            and set(value) = aggregationTargetField <- Some value

        member __.animation
            with get() = animationField.Value
            and set(value) = animationField <- Some value

        member __.annotations
            with get() = annotationsField.Value
            and set(value) = annotationsField <- Some value

        member __.areaOpacity
            with get() = areaOpacityField.Value
            and set(value) = areaOpacityField <- Some value

        member __.axisTitlesPosition
            with get() = axisTitlesPositionField.Value
            and set(value) = axisTitlesPositionField <- Some value

        member __.backgroundColor
            with get() = backgroundColorField.Value
            and set(value) = backgroundColorField <- Some value

        member __.chartArea
            with get() = chartAreaField.Value
            and set(value) = chartAreaField <- Some value

        member __.colors
            with get() = colorsField.Value
            and set(value) = colorsField <- Some value

        member __.crosshair
            with get() = crosshairField.Value
            and set(value) = crosshairField <- Some value

        member __.dataOpacity
            with get() = dataOpacityField.Value
            and set(value) = dataOpacityField <- Some value

        member __.enableInteractivity
            with get() = enableInteractivityField.Value
            and set(value) = enableInteractivityField <- Some value

        member __.explorer
            with get() = explorerField.Value
            and set(value) = explorerField <- Some value

        member __.focusTarget
            with get() = focusTargetField.Value
            and set(value) = focusTargetField <- Some value

        member __.fontSize
            with get() = fontSizeField.Value
            and set(value) = fontSizeField <- Some value

        member __.fontName
            with get() = fontNameField.Value
            and set(value) = fontNameField <- Some value

        member __.forceIFrame
            with get() = forceIFrameField.Value
            and set(value) = forceIFrameField <- Some value

        member __.hAxis
            with get() = hAxisField.Value
            and set(value) = hAxisField <- Some value

        member __.height
            with get() = heightField.Value
            and set(value) = heightField <- Some value

        member __.interpolateNulls
            with get() = interpolateNullsField.Value
            and set(value) = interpolateNullsField <- Some value

        member __.isStacked
            with get() = isStackedField.Value
            and set(value) = isStackedField <- Some value

        member __.legend
            with get() = legendField.Value
            and set(value) = legendField <- Some value

        member __.lineWidth
            with get() = lineWidthField.Value
            and set(value) = lineWidthField <- Some value

        member __.orientation
            with get() = orientationField.Value
            and set(value) = orientationField <- Some value

        member __.pointShape
            with get() = pointShapeField.Value
            and set(value) = pointShapeField <- Some value

        member __.pointSize
            with get() = pointSizeField.Value
            and set(value) = pointSizeField <- Some value

        member __.reverseCategories
            with get() = reverseCategoriesField.Value
            and set(value) = reverseCategoriesField <- Some value

        member __.selectionMode
            with get() = selectionModeField.Value
            and set(value) = selectionModeField <- Some value

        member __.series
            with get() = seriesField.Value
            and set(value) = seriesField <- Some value

        member __.theme
            with get() = themeField.Value
            and set(value) = themeField <- Some value

        member __.title
            with get() = titleField.Value
            and set(value) = titleField <- Some value

        member __.titlePosition
            with get() = titlePositionField.Value
            and set(value) = titlePositionField <- Some value

        member __.titleTextStyle
            with get() = titleTextStyleField.Value
            and set(value) = titleTextStyleField <- Some value

        member __.tooltip
            with get() = tooltipField.Value
            and set(value) = tooltipField <- Some value

        member __.vAxes
            with get() = vAxesField.Value
            and set(value) = vAxesField <- Some value

        member __.vAxis
            with get() = vAxisField.Value
            and set(value) = vAxisField <- Some value

        member __.width
            with get() = widthField.Value
            and set(value) = widthField <- Some value

        member __.ShouldSerializeaggregationTarget() = not aggregationTargetField.IsNone
        member __.ShouldSerializeanimation() = not animationField.IsNone
        member __.ShouldSerializeannotations() = not annotationsField.IsNone
        member __.ShouldSerializeareaOpacity() = not areaOpacityField.IsNone
        member __.ShouldSerializeaxisTitlesPosition() = not axisTitlesPositionField.IsNone
        member __.ShouldSerializebackgroundColor() = not backgroundColorField.IsNone
        member __.ShouldSerializechartArea() = not chartAreaField.IsNone
        member __.ShouldSerializecolors() = not colorsField.IsNone
        member __.ShouldSerializecrosshair() = not crosshairField.IsNone
        member __.ShouldSerializedataOpacity() = not dataOpacityField.IsNone
        member __.ShouldSerializeenableInteractivity() = not enableInteractivityField.IsNone
        member __.ShouldSerializeexplorer() = not explorerField.IsNone
        member __.ShouldSerializefocusTarget() = not focusTargetField.IsNone
        member __.ShouldSerializefontSize() = not fontSizeField.IsNone
        member __.ShouldSerializefontName() = not fontNameField.IsNone
        member __.ShouldSerializeforceIFrame() = not forceIFrameField.IsNone
        member __.ShouldSerializehAxis() = not hAxisField.IsNone
        member __.ShouldSerializeheight() = not heightField.IsNone
        member __.ShouldSerializeinterpolateNulls() = not interpolateNullsField.IsNone
        member __.ShouldSerializeisStacked() = not isStackedField.IsNone
        member __.ShouldSerializelegend() = not legendField.IsNone
        member __.ShouldSerializelineWidth() = not lineWidthField.IsNone
        member __.ShouldSerializeorientation() = not orientationField.IsNone
        member __.ShouldSerializepointShape() = not pointShapeField.IsNone
        member __.ShouldSerializepointSize() = not pointSizeField.IsNone
        member __.ShouldSerializereverseCategories() = not reverseCategoriesField.IsNone
        member __.ShouldSerializeselectionMode() = not selectionModeField.IsNone
        member __.ShouldSerializeseries() = not seriesField.IsNone
        member __.ShouldSerializetheme() = not themeField.IsNone
        member __.ShouldSerializetitle() = not titleField.IsNone
        member __.ShouldSerializetitlePosition() = not titlePositionField.IsNone
        member __.ShouldSerializetitleTextStyle() = not titleTextStyleField.IsNone
        member __.ShouldSerializetooltip() = not tooltipField.IsNone
        member __.ShouldSerializevAxes() = not vAxesField.IsNone
        member __.ShouldSerializevAxis() = not vAxisField.IsNone
        member __.ShouldSerializewidth() = not widthField.IsNone

let jsTemplate =
    """google.setOnLoadCallback(drawChart);
            function drawChart() {
                var data = new google.visualization.DataTable({DATA});

                var options = {OPTIONS} 

                var chart = new google.visualization.{TYPE}(document.getElementById('{GUID}'));
                chart.draw(data, options);
            }"""


let template =
    """<html>
    <head>
        <title>Google Chart</title>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <script type="text/javascript">
            google.load("visualization", "1", {packages:["{PACKAGES}"]})
            {JS}
        </script>
    </head>
    <body>
        <div id="{GUID}"></div>
    </body>
</html>"""

type GoogleChart() =

    [<DefaultValue>]
    val mutable private data : seq<Data.Series>
    
    [<DefaultValue>]
    val mutable private options : Options

    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery
    
    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString()
        with get, set

    static member internal Create data options ``type`` =
        let gc = GoogleChart()
        gc.data <- data
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    /// The chart's JavaScript code. Doesn't contain the
    /// necessary line for loading the appropiate Google
    /// visualization package. 
    member __.Js =
        let dt = makeDataTable __.data
        let dataJson = dt.GetJson()         
        let optionsJson = JsonConvert.SerializeObject(__.options)
        jsTemplate.Replace("{DATA}", dataJson)
            .Replace("{OPTIONS}", optionsJson)
            .Replace("{TYPE}", __.``type``.ToString())
            .Replace("{GUID}", __.Id)

    /// The chart's complete HTML code.
    member __.Html =
        let packages =
            match __.``type`` with
            | Area -> "corechart"
        template.Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.Js)
            .Replace("{GUID}", __.Id)

    /// Displays the chart in the default browser.
    member __.Show() =
        let htmlFile = Path.GetTempPath() + __.Id + ".html"
        File.WriteAllText(htmlFile, __.Html)
        Process.Start htmlFile
        |> ignore

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    member __.WithLabel label =
        __.data <-
            __.data
            |> Seq.head
            |> fun series -> [series.WithName (Some label)]

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    member __.WithLabels labels =
        __.data <-
            __.data
            |> Seq.mapi (fun idx series -> series.WithName (labels |> Seq.nth idx |> Some))

    /// Sets the chart's title.
    member __.WithTitle title =
        __.options.title <- title

    /// Sets the chart's X-axis title.
    member __.WithXTitle xTitle =
        try
            __.options.hAxis.title <- xTitle
        with _ ->
            __.options.hAxis <- Axis(title = xTitle)

    /// Sets the chart's Y-axis title.
    member __.WithYTitle yTitle =
        try
            __.options.vAxis.title <- yTitle
        with _ ->
            __.options.vAxis <- Axis(title = yTitle)

    /// Display/hide the legend.
    member __.WithLegend enabled =
        match __.options.legend <> Unchecked.defaultof<Legend> with
        | false ->
            match enabled with
            | false -> __.options.legend <- Legend(position = "none")
            | true -> __.options.legend <- Legend(position = "right")
        | true ->
            match enabled with
            | false -> __.options.legend.position <- "none"
            | true -> __.options.legend.position <- "right"

    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the chart's configuration options.
    member __.WithOptions options = __.options <- options

type Chart =

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Name">The data set name.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#key * #value>, ?Name, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New Name

        GoogleChart.Create [data'] (defaultArg Options <| Configuration.Options()) Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Name">The data sets names.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Names, ?Options) =
        let data' =
            data
            |> Seq.mapi (fun idx x ->
                x 
                |> Seq.map Datum.New
                |> fun datums ->
                    match Names with
                    | None -> Series.New None datums
                    | Some names -> Series.New (Seq.nth idx names |> Some) datums)

        GoogleChart.Create data' (defaultArg Options <| Configuration.Options()) Area
        
type Chart with

    /// Displays the chart in the default browser.    
    static member Show (chart:GoogleChart) =
        chart.Show()
        chart

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    static member WithLabel label (chart:GoogleChart) =
        chart.WithLabel label
        chart

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    static member WithLabels labels (chart:GoogleChart) =
        chart.WithLabels labels
        chart

    /// Sets the chart's title.
    static member WithTitle title (chart:GoogleChart) =
        chart.WithTitle title
        chart

    /// Sets the chart's X-axis title.
    static member WithXTitle xTitle (chart:GoogleChart) =
        chart.WithXTitle xTitle
        chart

    /// Sets the chart's Y-axis title.
    static member WithYTitle yTitle (chart:GoogleChart) =
        chart.WithYTitle yTitle
        chart

    /// Display/hide the legend.
    static member WithLegend enabled (chart:GoogleChart) =
        chart.WithLegend enabled
        chart

    /// Sets the chart's container div id.
    static member WithId id (chart:GoogleChart) =
        chart.WithId id
        chart

    /// Sets the chart's configuration options.
    static member WithOptions options (chart:GoogleChart) =
        chart.WithOptions options
        chart