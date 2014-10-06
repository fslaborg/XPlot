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
    | Annotation
    | Area
    | Bar
    | Bubble
    | Calendar
    | Candlestick

    override __.ToString() =
        match FSharpValue.GetUnionFields(__, typeof<ChartGallery>) with
        | case, _ ->
            let name = case.Name
            match name with
            | "Calendar" -> name
            | _ -> name + "Chart"

type key = IConvertible
type value = IConvertible

[<AutoOpen>]
module Data =

    type Datum =
        {
            X : key
            Y1 : value
            Y2 : value option
            Y3 : value option
            Y4 : value option
        }

        static member New(x, y) = {X = x; Y1 = y; Y2 = None; Y3 = None; Y4 = None}

        static member New(x, y1, y2) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = None; Y4 = None}

        static member New(x, y1, y2, y3) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = Some y3; Y4 = None}

        static member New(x, y1, y2, y3, y4) = {X = x; Y1 = y1; Y2 = Some y2; Y3 = Some y3; Y4 = Some y4}

    type Series =
        {
            Name : string option
            Datums : seq<Datum>
        }

        static member New name datums = {Name = name; Datums = datums}

        member __.WithName name = {__ with Name = name}

    // TODO: more elegant way to construct a data table
    let makeDataTable (series:seq<Series>) labels =
        let dt = new DataTable()
            
        let datum = Seq.head series |> fun x -> Seq.head x.Datums

        datum.X.GetTypeCode()
        |> function
        | TypeCode.Boolean -> ColumnType.Boolean
        | TypeCode.DateTime -> ColumnType.Datetime
        | TypeCode.String -> ColumnType.String
        | _ -> ColumnType.Number
        |> fun x -> dt.AddColumn(Column(x)) |> ignore

        
        [
            for x in 1 .. Seq.length series do
                yield datum.Y1.GetTypeCode()
//            for x in 1 .. Seq.length series do
                if datum.Y2.IsSome then yield datum.Y2.Value.GetTypeCode()
//            for x in 1 .. Seq.length series do                
                if datum.Y3.IsSome then yield datum.Y3.Value.GetTypeCode()
                if datum.Y4.IsSome then yield datum.Y4.Value.GetTypeCode()

        ]
        |> Seq.iteri (fun idx typecode ->
            let columnType =
                match typecode with
                | TypeCode.Boolean -> ColumnType.Boolean
                | TypeCode.DateTime -> ColumnType.Datetime
                | TypeCode.String -> ColumnType.String
                | _ -> ColumnType.Number
            let column = Column(columnType)
            match labels with
            | None -> ()
            | Some labelsSeq -> column.Label <- Seq.nth idx labelsSeq
            dt.AddColumn column |> ignore)

        // table rows
        series
        |> Seq.map (fun x -> x.Datums)
        |> Seq.concat
        |> Seq.groupBy (fun datum -> datum.X)
        |> Seq.map (fun (key, dps) ->
            key, dps |> Seq.map (fun dp -> 
                [
                    yield dp.Y1
                    if dp.Y2.IsSome then yield dp.Y2.Value
                    if dp.Y3.IsSome then yield dp.Y3.Value
                    if dp.Y4.IsSome then yield dp.Y4.Value
                ]
            )
        )
        |> Seq.iter (fun (key, values) ->
            let row = dt.NewRow()
            row.AddCell(Cell(key)) |> ignore
            values
            |> Seq.iter (fun value ->
                value
                |> Seq.iter (fun v ->
                    Cell(v)
                    |> row.AddCell
                    |> ignore
                )
            )
            dt.AddRow row |> ignore
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
        let mutable numberFormatField : string option = None

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

        member __.numberFormat
            with get() = numberFormatField.Value
            and set(value) = numberFormatField <- Some value

        member __.ShouldSerializealignment() = not alignmentField.IsNone
        member __.ShouldSerializemaxLines() = not maxLinesField.IsNone
        member __.ShouldSerializeposition() = not positionField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone
        member __.ShouldSerializenumberFormat() = not numberFormatField.IsNone

    type CandleColor() =
    
        let mutable fillField : string option = None
        let mutable strokeField : string option = None
        let mutable strokeWidthField : int option = None

        member __.fill
            with get() = fillField.Value
            and set(value) = fillField <- Some value

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.strokeWidth
            with get() = strokeWidthField.Value
            and set(value) = strokeWidthField <- Some value

        member __.ShouldSerializefill() = not fillField.IsNone
        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializestrokeWidth() = not strokeWidthField.IsNone

    type Series() =

        let mutable annotationsField : Annotations option = None
        let mutable colorField : string option = None
        let mutable targetAxisIndexField : int option = None
        let mutable pointShapeField : string option = None
        let mutable pointSizeField : int option = None
        let mutable lineWidthField : int option = None
        let mutable areaOpacityField : float option = None
        let mutable visibleInLegendField : bool option = None
        // Candlestick
        let mutable fallingColorField : CandleColor option = None
        let mutable risingColorField : CandleColor option = None

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

        member __.fallingColor
            with get() = fallingColorField.Value
            and set(value) = fallingColorField <- Some value

        member __.risingColor
            with get() = risingColorField.Value
            and set(value) = risingColorField <- Some value

        member __.ShouldSerializeannotations() = not annotationsField.IsNone
        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializetargetAxisIndex() = not targetAxisIndexField.IsNone
        member __.ShouldSerializepointShape() = not pointShapeField.IsNone
        member __.ShouldSerializepointSize() = not pointSizeField.IsNone
        member __.ShouldSerializelineWidth() = not lineWidthField.IsNone
        member __.ShouldSerializeareaOpacity() = not areaOpacityField.IsNone
        member __.ShouldSerializevisibleInLegend() = not visibleInLegendField.IsNone
        member __.ShouldSerializefallingColor() = not fallingColorField.IsNone
        member __.ShouldSerializerisingColor() = not risingColorField.IsNone

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

    type Bar() =

        let mutable groupWidthField : string option = None
        
        member __.groupWidth
            with get() = groupWidthField.Value
            and set(value) = groupWidthField <- Some value

        member __.ShouldSerializegroupWidth() = not groupWidthField.IsNone

    type Bubble() =

        let mutable opacityField : float option = None
        let mutable strokeField : string option = None
        let mutable textStyleField : TextStyle option = None
                
        member __.opacity
            with get() = opacityField.Value
            and set(value) = opacityField <- Some value

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ShouldSerializeopacity() = not opacityField.IsNone
        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone

    type ColorAxis() =

        let mutable minValueField : int option = None
        let mutable maxValueField : int option = None
        let mutable valuesField : int [] option = None
        let mutable colorsField : string [] option = None
        let mutable legendField : Legend option = None
        
        member __.minValue
            with get() = minValueField.Value
            and set(value) = minValueField <- Some value

        member __.maxValue
            with get() = maxValueField.Value
            and set(value) = maxValueField <- Some value

        member __.values
            with get() = valuesField.Value
            and set(value) = valuesField <- Some value

        member __.colors
            with get() = colorsField.Value
            and set(value) = colorsField <- Some value

        member __.legend
            with get() = legendField.Value
            and set(value) = legendField <- Some value

        member __.ShouldSerializeminValue() = not minValueField.IsNone
        member __.ShouldSerializemaxValue() = not maxValueField.IsNone
        member __.ShouldSerializevalues() = not valuesField.IsNone
        member __.ShouldSerializecolors() = not colorsField.IsNone
        member __.ShouldSerializelegend() = not legendField.IsNone

    type CellColor() =
        
        let mutable strokeField : string option = None
        let mutable strokeOpacityField : float option = None
        let mutable strokeWidthField : int option = None

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.strokeOpacity
            with get() = strokeOpacityField.Value
            and set(value) = strokeOpacityField <- Some value

        member __.strokeWidth
            with get() = strokeWidthField.Value
            and set(value) = strokeWidthField <- Some value

        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializestrokeOpacity() = not strokeOpacityField.IsNone
        member __.ShouldSerializestrokeWidth() = not strokeWidthField.IsNone

    type Calendar() =
        
        let mutable cellColorField : CellColor option = None
        let mutable cellSizeField : int option = None
        let mutable dayOfWeekLabelField : TextStyle option = None
        let mutable dayOfWeekRightSpaceField : int option = None
        let mutable daysOfWeekField : string option = None
        let mutable focusedCellColorField : CellColor option = None
        let mutable monthLabelField : TextStyle option = None
        let mutable monthOutlineColorField : CellColor option = None
        let mutable underMonthSpaceField : int option = None
        let mutable underYearSpaceField : int option = None
        let mutable unusedMonthOutlineColorField : CellColor option = None

        member __.cellColor
            with get() = cellColorField.Value
            and set(value) = cellColorField <- Some value

        member __.cellSize
            with get() = cellSizeField.Value
            and set(value) = cellSizeField <- Some value

        member __.dayOfWeekLabel
            with get() = dayOfWeekLabelField.Value
            and set(value) = dayOfWeekLabelField <- Some value

        member __.dayOfWeekRightSpace
            with get() = dayOfWeekRightSpaceField.Value
            and set(value) = dayOfWeekRightSpaceField <- Some value

        member __.daysOfWeek
            with get() = daysOfWeekField.Value
            and set(value) = daysOfWeekField <- Some value

        member __.focusedCellColor
            with get() = focusedCellColorField.Value
            and set(value) = focusedCellColorField <- Some value

        member __.monthLabel
            with get() = monthLabelField.Value
            and set(value) = monthLabelField <- Some value

        member __.monthOutlineColor
            with get() = monthOutlineColorField.Value
            and set(value) = monthOutlineColorField <- Some value

        member __.underMonthSpace
            with get() = underMonthSpaceField.Value
            and set(value) = underMonthSpaceField <- Some value

        member __.underYearSpace
            with get() = underYearSpaceField.Value
            and set(value) = underYearSpaceField <- Some value

        member __.unusedMonthOutlineColor
            with get() = unusedMonthOutlineColorField.Value
            and set(value) = unusedMonthOutlineColorField <- Some value

        member __.ShouldSerializecellColor() = not cellColorField.IsNone
        member __.ShouldSerializecellSize() = not cellSizeField.IsNone
        member __.ShouldSerializedayOfWeekLabel() = not dayOfWeekLabelField.IsNone
        member __.ShouldSerializedayOfWeekRightSpace() = not dayOfWeekRightSpaceField.IsNone
        member __.ShouldSerializedaysOfWeek() = not daysOfWeekField.IsNone
        member __.ShouldSerializefocusedCellColor() = not focusedCellColorField.IsNone
        member __.ShouldSerializemonthLabel() = not monthLabelField.IsNone
        member __.ShouldSerializemonthOutlineColor() = not monthOutlineColorField.IsNone
        member __.ShouldSerializeunderMonthSpace() = not underMonthSpaceField.IsNone
        member __.ShouldSerializeunderYearSpace() = not underYearSpaceField.IsNone
        member __.ShouldSerializeunusedMonthOutlineColor() = not unusedMonthOutlineColorField.IsNone

    type NoDataPattern() =

        let mutable backgroundColorField : string option = None
        let mutable colorField : string option = None

        member __.backgroundColor
            with get() = backgroundColorField.Value
            and set(value) = backgroundColorField <- Some value

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.ShouldSerializebackgroundColor() = not backgroundColorField.IsNone
        member __.ShouldSerializecolor() = not colorField.IsNone
           
    type Candlestick() =

        let mutable hollowIsRisingField : bool option = None
        let mutable fallingColorField : CandleColor option = None
        let mutable risingColorField : CandleColor option = None

        member __.hollowIsRising
            with get() = hollowIsRisingField.Value
            and set(value) = hollowIsRisingField <- Some value

        member __.fallingColor
            with get() = fallingColorField.Value
            and set(value) = fallingColorField <- Some value

        member __.risingColor
            with get() = risingColorField.Value
            and set(value) = risingColorField <- Some value

        member __.ShouldSerializehollowIsRising() = not hollowIsRisingField.IsNone
        member __.ShouldSerializefallingColor() = not fallingColorField.IsNone
        member __.ShouldSerializerisingColor() = not risingColorField.IsNone
    
            
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
        let mutable heightField : int option = None
        let mutable interpolateNullsField : bool option = None
        let mutable isStackedField : bool option = None
        let mutable legendField : Legend option = Some <| Legend(position="none")
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
        let mutable widthField : int option = None
        // Annotation
        let mutable allowHtmlField : bool option = None
        let mutable allValuesSuffixField : string option = None
        let mutable annotationsWidthField : int option = None
        let mutable dateFormatField : string option = None
        let mutable displayAnnotationsField : bool option = None
        let mutable displayAnnotationsFilterField : bool option = None
        let mutable displayDateBarSeparatorField : bool option = None
        let mutable displayExactValuesField : bool option = None
        let mutable displayLegendDotsField : bool option = None
        let mutable displayLegendValuesField : bool option = None
        let mutable displayRangeSelectorField : bool option = None
        let mutable displayZoomButtonsField : bool option = None
        let mutable fillField : int option = None
        let mutable legendPositionField : string option = None
        let mutable maxField : int option = None
        let mutable minField : int option = None
        let mutable numberFormatsField : string option = None
        let mutable scaleColumnsField : int [] option = None
        let mutable scaleFormatField : string option = None
        let mutable scaleTypeField : string option = None
        let mutable thicknessField : int option = None
        let mutable zoomEndTimeField : DateTime option = None
        let mutable zoomStartTimeField : DateTime option = None
        // Bar
        let mutable barField : Bar option = None
        // Bubble
        let mutable bubbleField : Bubble option = None
        let mutable colorAxisField : ColorAxis option = None
        // Calendar
        let mutable calendarField : Calendar option = None
        let mutable noDataPatternField : NoDataPattern option = None
        // Candlestick
        let mutable candlestickField : Candlestick option = None

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

        member __.allowHtml
            with get() = allowHtmlField.Value
            and set(value) = allowHtmlField <- Some value

        member __.allValuesSuffix
            with get() = allValuesSuffixField.Value
            and set(value) = allValuesSuffixField <- Some value

        member __.annotationsWidth
            with get() = annotationsWidthField.Value
            and set(value) = annotationsWidthField <- Some value

        member __.dateFormat
            with get() = dateFormatField.Value
            and set(value) = dateFormatField <- Some value

        member __.displayAnnotations
            with get() = displayAnnotationsField.Value
            and set(value) = displayAnnotationsField <- Some value

        member __.displayAnnotationsFilter
            with get() = displayAnnotationsFilterField.Value
            and set(value) = displayAnnotationsFilterField <- Some value

        member __.displayDateBarSeparator
            with get() = displayDateBarSeparatorField.Value
            and set(value) = displayDateBarSeparatorField <- Some value

        member __.displayExactValues
            with get() = displayExactValuesField.Value
            and set(value) = displayExactValuesField <- Some value

        member __.displayLegendDots
            with get() = displayLegendDotsField.Value
            and set(value) = displayLegendDotsField <- Some value

        member __.displayLegendValues
            with get() = displayLegendValuesField.Value
            and set(value) = displayLegendValuesField <- Some value

        member __.displayRangeSelector
            with get() = displayRangeSelectorField.Value
            and set(value) = displayRangeSelectorField <- Some value

        member __.displayZoomButtons
            with get() = displayZoomButtonsField.Value
            and set(value) = displayZoomButtonsField <- Some value

        member __.fill
            with get() = fillField.Value
            and set(value) = fillField <- Some value

        member __.legendPosition
            with get() = legendPositionField.Value
            and set(value) = legendPositionField <- Some value

        member __.max
            with get() = maxField.Value
            and set(value) = maxField <- Some value

        member __.min
            with get() = minField.Value
            and set(value) = minField <- Some value

        member __.numberFormats
            with get() = numberFormatsField.Value
            and set(value) = numberFormatsField <- Some value

        member __.scaleColumns
            with get() = scaleColumnsField.Value
            and set(value) = scaleColumnsField <- Some value

        member __.scaleFormat
            with get() = scaleFormatField.Value
            and set(value) = scaleFormatField <- Some value

        member __.scaleType
            with get() = scaleTypeField.Value
            and set(value) = scaleTypeField <- Some value

        member __.thickness
            with get() = thicknessField.Value
            and set(value) = thicknessField <- Some value

        member __.zoomEndTime
            with get() = zoomEndTimeField.Value
            and set(value) = zoomEndTimeField <- Some value

        member __.zoomStartTime
            with get() = zoomStartTimeField.Value
            and set(value) = zoomStartTimeField <- Some value

        member __.bar
            with get() = barField.Value
            and set(value) = barField <- Some value
        
        member __.bubble
            with get() = bubbleField.Value
            and set(value) = bubbleField <- Some value
        
        member __.colorAxis
            with get() = colorAxisField.Value
            and set(value) = colorAxisField <- Some value

        member __.calendar
            with get() = calendarField.Value
            and set(value) = calendarField <- Some value

        member __.noDataPattern
            with get() = noDataPatternField.Value
            and set(value) = noDataPatternField <- Some value

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
        member __.ShouldSerializeallowHtml() = not allowHtmlField.IsNone
        member __.ShouldSerializeallValuesSuffix() = not allValuesSuffixField.IsNone
        member __.ShouldSerializeannotationsWidth() = not annotationsWidthField.IsNone
        member __.ShouldSerializedateFormat() = not dateFormatField.IsNone
        member __.ShouldSerializedisplayAnnotations() = not displayAnnotationsField.IsNone
        member __.ShouldSerializedisplayAnnotationsFilter() = not displayAnnotationsFilterField.IsNone
        member __.ShouldSerializedisplayDateBarSeparator() = not displayDateBarSeparatorField.IsNone
        member __.ShouldSerializedisplayExactValues() = not displayExactValuesField.IsNone
        member __.ShouldSerializedisplayLegendDots() = not displayLegendDotsField.IsNone
        member __.ShouldSerializedisplayLegendValues() = not displayLegendValuesField.IsNone
        member __.ShouldSerializedisplayRangeSelector() = not displayRangeSelectorField.IsNone
        member __.ShouldSerializedisplayZoomButtons() = not displayZoomButtonsField.IsNone
        member __.ShouldSerializefill() = not fillField.IsNone
        member __.ShouldSerializelegendPosition() = not legendPositionField.IsNone
        member __.ShouldSerializemax() = not maxField.IsNone
        member __.ShouldSerializemin() = not minField.IsNone
        member __.ShouldSerializenumberFormats() = not numberFormatsField.IsNone
        member __.ShouldSerializescaleColumns() = not scaleColumnsField.IsNone
        member __.ShouldSerializescaleFormat() = not scaleFormatField.IsNone
        member __.ShouldSerializescaleType() = not scaleTypeField.IsNone
        member __.ShouldSerializethickness() = not thicknessField.IsNone
        member __.ShouldSerializezoomEndTime() = not zoomEndTimeField.IsNone
        member __.ShouldSerializezoomStartTime() = not zoomStartTimeField.IsNone
        member __.ShouldSerializebar() = not barField.IsNone
        member __.ShouldSerializebubble() = not bubbleField.IsNone
        member __.ShouldSerializecolorAxis() = not colorAxisField.IsNone
        member __.ShouldSerializecalendar() = not calendarField.IsNone
        member __.ShouldSerializenoDataPattern() = not noDataPatternField.IsNone


//    let ``default`` =
//        Options(
//            height = 500,
//            legend = Legend(position = "none"),
//            width =900
//        )

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
            google.load("visualization", "{VERSION}", {packages:["{PACKAGES}"]})
            {JS}
        </script>
    </head>
    <body>
        <div id="{GUID}" style="width: {WIDTH}px; height: {HEIGHT}px;"></div>
    </body>
</html>"""

type GoogleChart() =

    [<DefaultValue>]
    val mutable private data : seq<Data.Series>

    member val labels : seq<string> option = None with get, set
    
    [<DefaultValue>]
    val mutable private options : Options

    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery
    
    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString()
        with get, set

    member val height = 500 with get, set

    member val width = 900 with get, set

    static member internal Create data labels options ``type`` =
        let gc = GoogleChart()
        gc.data <- data
        gc.labels <- labels
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    /// The chart's JavaScript code. Doesn't contain the
    /// necessary line for loading the appropiate Google
    /// visualization package. 
    member __.Js =
        let dt = makeDataTable __.data __.labels
        let dataJson = dt.GetJson()         
        let optionsJson = JsonConvert.SerializeObject(__.options)
        jsTemplate.Replace("{DATA}", dataJson)
            .Replace("{OPTIONS}", optionsJson)
            .Replace("{TYPE}", __.``type``.ToString())
            .Replace("{GUID}", __.Id)

    /// The chart's complete HTML code.
    member __.Html =
        let version =
            match __.``type`` with
            | Calendar -> "1.1"            
            | _ -> "1"
        let packages =
            match __.``type`` with
            | Annotation -> "annotationchart"
            | Area | Bar | Bubble | Candlestick -> "corechart"
            | Calendar -> "calendar"
        template.Replace("{VERSION}", version)
            .Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.Js)
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.width))
            .Replace("{HEIGHT}", string(__.height))

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
    member __.WithLabels labels = __.labels <- Some labels

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
        match enabled with
        | false ->
            try
                __.options.legend.position <- "none"
            with _ -> __.options.legend <- Legend(position = "none") 
        | true ->
            try
                __.options.legend.position <- "right"
            with _ -> __.options.legend <- Legend(position = "right") 
                
//        match __.options.legend <> Unchecked.defaultof<Legend> with
//        | false ->
//            match enabled with
//            | false -> __.options.legend <- Legend(position = "none")
//            | true -> __.options.legend <- Legend(position = "right")
//        | true ->
//            match enabled with
//            | false -> __.options.legend.position <- "none"
//            | true -> __.options.legend.position <- "right"

    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the chart's configuration options.
    member __.WithOptions options = __.options <- options

type Chart =

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data columns label.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<DateTime * #value * string * string>, ?Labels, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        GoogleChart.Create [data'] Labels (defaultArg Options <| Configuration.Options()) Annotation

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data columns label.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<#seq<DateTime * 'V * string * string>> when 'V :> value, ?Labels, ?Options) =
        let data' =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New None)
        GoogleChart.Create data' Labels (defaultArg Options <| Configuration.Options()) Annotation

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Label">The data column label.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#key * #value>, ?Label:string, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        let labels =
            match Label with
            | None -> None
            | Some label -> [label] |> List.toSeq |> Some
        GoogleChart.Create [data'] labels (defaultArg Options <| Configuration.Options()) Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data clumns labels.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels:seq<string>, ?Options) =
        let data' =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New None)
        GoogleChart.Create data' Labels (defaultArg Options <| Configuration.Options()) Area

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Label">The data column label.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#key * #value>, ?Label:string, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        let labels =
            match Label with
            | None -> None
            | Some label -> [label] |> List.toSeq |> Some
        GoogleChart.Create [data'] labels (defaultArg Options <| Configuration.Options()) ChartGallery.Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data clumns labels.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels:seq<string>, ?Options) =
        let data' =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New None)
        GoogleChart.Create data' Labels (defaultArg Options <| Configuration.Options()) ChartGallery.Bar

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data clumns labels.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value * #value>, ?Labels, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        GoogleChart.Create [data'] Labels (defaultArg Options <| Configuration.Options()) ChartGallery.Bubble
     
    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Label">The data column label.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:seq<DateTime * #value>, ?Label:string, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        let labels =
            match Label with
            | None -> None
            | Some label -> [label] |> List.toSeq |> Some
        GoogleChart.Create [data'] labels (defaultArg Options <| Configuration.Options()) ChartGallery.Calendar
 
    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data clumns labels.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#key * #value * #value * #value * #value>, ?Labels, ?Options) =
        let data' =
            data
            |> Seq.map Datum.New
            |> Series.New None
        GoogleChart.Create [data'] Labels (defaultArg Options <| Configuration.Options()) ChartGallery.Candlestick

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">The data clumns labels.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#seq<'K * 'V * 'V * 'V * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let data' =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New None)
        GoogleChart.Create data' Labels (defaultArg Options <| Configuration.Options()) ChartGallery.Candlestick
        
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