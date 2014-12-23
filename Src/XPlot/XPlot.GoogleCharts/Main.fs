module XPlot.GoogleCharts

open Google.DataTable.Net.Wrapper.Extension
open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open System
open System.Data
open System.Globalization
open System.Windows
open System.Windows.Controls
open System.Windows.Media.Imaging

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
            DataPoints : seq<Datum>
        }

        static member New dps = {DataPoints = dps}

    let makeDataTable series labels =
    
        let rows =
            let dps =
                series
                |> Seq.map (fun x -> x.DataPoints)
                |> Seq.concat
            match Seq.length series with
            | 1 ->
                dps
                |> Seq.map (fun x ->
                    [
                        yield x.X
                        yield x.Y1
                        if x.Y2.IsSome then yield x.Y2.Value
                        if x.Y3.IsSome then yield x.Y3.Value
                        if x.Y4.IsSome then yield x.Y4.Value
                    ]
                )
            | _ ->
                dps
                |> Seq.groupBy (fun x -> x.X)
                |> Seq.map (fun (key, dps) ->
                    [
                        yield key
                        for x in dps do
                            yield x.Y1
                            if x.Y2.IsSome then yield x.Y2.Value
                            if x.Y3.IsSome then yield x.Y3.Value
                            if x.Y4.IsSome then yield x.Y4.Value
                    ]
                )

        let sysDt = new System.Data.DataTable()
        sysDt.Locale <- CultureInfo.InvariantCulture

        let firstRow =
            rows
            |> Seq.maxBy (fun x -> x.Length)

        let labels' =
            match labels with
            | None -> seq {for x in 1 .. firstRow.Length -> "Column " + string x}
            | Some labelsSeq ->
                match (Seq.length labelsSeq) = firstRow.Length with
                | false -> Seq.append ["Column 1"] labelsSeq
                | true -> labelsSeq

        firstRow
        |> List.iteri (fun idx x ->
    //        let typeCode = x.GetTypeCode()
    //        let columnType =
    //            match typeCode with
    //            | TypeCode.Boolean -> typeof<bool>
    //            | TypeCode.DateTime -> typeof<DateTime>
    //            | TypeCode.String -> typeof<string>
    //            | TypeCode.Decimal -> typeof<Decimal>
    //            | TypeCode.Double -> typeof<Double>
    //            | TypeCode.Int16 -> typeof<Int16>
    //            | TypeCode.Int32 -> typeof<Int32>
    //            | TypeCode.Int64 -> typeof<Int64>
    //            | TypeCode.UInt16 -> typeof<UInt16>
    //            | TypeCode.UInt32 -> typeof<UInt32>
    //            | _ -> typeof<UInt64>
            sysDt.Columns.Add(Seq.nth idx labels', x.GetType()) |> ignore
        )

        rows
        |> Seq.iter (fun values -> 
            let row = sysDt.NewRow()
            values
            |> Seq.iteri (fun idx v -> row.[idx] <- v)
            sysDt.Rows.Add(row)
        )
    
        sysDt

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
            with get() = x2Field.Value
            and set(value) = x2Field <- Some value

        member __.y2
            with get() = y2Field.Value
            and set(value) = y2Field <- Some value

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

        let mutable alwaysOutsideField : bool option = None
        let mutable boxStyleField : BoxStyle option = None
        let mutable highContrastField : bool option = None
        let mutable textStyleField : TextStyle option = None

        member __.alwaysOutside
            with get() = alwaysOutsideField.Value
            and set(value) = alwaysOutsideField <- Some value

        member __.boxStyle
            with get() = boxStyleField.Value
            and set(value) = boxStyleField <- Some value

        member __.highContrast
            with get() = highContrastField.Value
            and set(value) = highContrastField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ShouldSerializealwaysOutside() = not alwaysOutsideField.IsNone
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
        // Combo
        let mutable curveTypeField : string option = None
        let mutable typeField : string option = None

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

        member __.curveType
            with get() = curveTypeField.Value
            and set(value) = curveTypeField <- Some value

        member __.``type``
            with get() = typeField.Value
            and set(value) = typeField <- Some value

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
        member __.ShouldSerializecurveType() = not curveTypeField.IsNone
        member __.ShouldSerializetype() = not typeField.IsNone

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
    
    type MagnifyingGlass()  =

        let mutable enableField : bool option = None
        let mutable zoomFactorField : float option = None

        member __.enable
            with get() = enableField.Value
            and set(value) = enableField <- Some value

        member __.zoomFactor
            with get() = zoomFactorField.Value
            and set(value) = zoomFactorField <- Some value

        member __.ShouldSerializeenable() = not enableField.IsNone
        member __.ShouldSerializezoomFactor() = not zoomFactorField.IsNone
         
    type SizeAxis() =

        let mutable maxSizeField : int option = None
        let mutable maxValueField : int option = None
        let mutable minSizeField : int option = None
        let mutable minValueField : int option = None

        member __.maxSize
            with get() = maxSizeField.Value
            and set(value) = maxSizeField <- Some value

        member __.maxValue
            with get() = maxValueField.Value
            and set(value) = maxValueField <- Some value

        member __.minSize
            with get() = minSizeField.Value
            and set(value) = minSizeField <- Some value

        member __.minValue
            with get() = minValueField.Value
            and set(value) = minValueField <- Some value

        member __.ShouldSerializemaxSize() = not maxSizeField.IsNone
        member __.ShouldSerializemaxValue() = not maxValueField.IsNone
        member __.ShouldSerializeminSize() = not minSizeField.IsNone
        member __.ShouldSerializeminValue() = not minValueField.IsNone

    type Histogram() =

        let mutable bucketSizeField : int option = None
        let mutable hideBucketItemsField : bool option = None
        let mutable lastBucketPercentileField : int option = None

        member __.bucketSize
            with get() = bucketSizeField.Value
            and set(value) = bucketSizeField <- Some value

        member __.hideBucketItems
            with get() = hideBucketItemsField.Value
            and set(value) = hideBucketItemsField <- Some value

        member __.lastBucketPercentile
            with get() = lastBucketPercentileField.Value
            and set(value) = lastBucketPercentileField <- Some value

        member __.ShouldSerializebucketSize() = not bucketSizeField.IsNone
        member __.ShouldSerializehideBucketItems() = not hideBucketItemsField.IsNone
        member __.ShouldSerializelastBucketPercentile() = not lastBucketPercentileField.IsNone
       
    type Slice() =

        let mutable colorField : string option = None
        let mutable offsetField : float option = None
        let mutable textStyleField : TextStyle option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.offset
            with get() = offsetField.Value
            and set(value) = offsetField <- Some value

        member __.textStyle
            with get() = textStyleField.Value
            and set(value) = textStyleField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializeoffset() = not offsetField.IsNone
        member __.ShouldSerializetextStyle() = not textStyleField.IsNone    

    type Color() =

        let mutable fillField : string option = None
        let mutable fillOpacityField : float option = None
        let mutable strokeField : string option = None
        let mutable strokeWidthField : int option = None

        member __.fill
            with get() = fillField.Value
            and set(value) = fillField <- Some value

        member __.fillOpacity
            with get() = fillOpacityField.Value
            and set(value) = fillOpacityField <- Some value

        member __.stroke
            with get() = strokeField.Value
            and set(value) = strokeField <- Some value

        member __.strokeWidth
            with get() = strokeWidthField.Value
            and set(value) = strokeWidthField <- Some value

        member __.ShouldSerializefill() = not fillField.IsNone
        member __.ShouldSerializefillOpacity() = not fillOpacityField.IsNone
        member __.ShouldSerializestroke() = not strokeField.IsNone
        member __.ShouldSerializestrokeWidth() = not strokeWidthField.IsNone

    type Label() =

        let mutable fontNameField : string option = None
        let mutable fontSizeField : int option = None
        let mutable colorField : string option = None
        let mutable boldField : bool option = None
        let mutable italicField : bool option = None

        member __.fontName
            with get() = fontNameField.Value
            and set(value) = fontNameField <- Some value

        member __.fontSize
            with get() = fontSizeField.Value
            and set(value) = fontSizeField <- Some value

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.bold
            with get() = boldField.Value
            and set(value) = boldField <- Some value

        member __.italic
            with get() = italicField.Value
            and set(value) = italicField <- Some value

        member __.ShouldSerializefontName() = not fontNameField.IsNone
        member __.ShouldSerializefontSize() = not fontSizeField.IsNone
        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializebold() = not boldField.IsNone
        member __.ShouldSerializeitalic() = not italicField.IsNone

    type Node() =

        let mutable colorField : Color option = None
        let mutable labelField : Label option = None
        let mutable labelPaddingField : int option = None
        let mutable nodePaddingField : int option = None
        let mutable widthField : int option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.label
            with get() = labelField.Value
            and set(value) = labelField <- Some value

        member __.labelPadding
            with get() = labelPaddingField.Value
            and set(value) = labelPaddingField <- Some value

        member __.nodePadding
            with get() = nodePaddingField.Value
            and set(value) = nodePaddingField <- Some value

        member __.width
            with get() = widthField.Value
            and set(value) = widthField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializelabel() = not labelField.IsNone
        member __.ShouldSerializelabelPadding() = not labelPaddingField.IsNone
        member __.ShouldSerializenodePadding() = not nodePaddingField.IsNone
        member __.ShouldSerializewidth() = not widthField.IsNone

    type Link() =
        let mutable colorField : Color option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone

    type Sankey() =

        let mutable iterationsField : int option = None
        let mutable linkField : Link option = None
        let mutable nodeField : Node option = None

        member __.iterations
            with get() = iterationsField.Value
            and set(value) = iterationsField <- Some value

        member __.link
            with get() = linkField.Value
            and set(value) = linkField <- Some value

        member __.node
            with get() = nodeField.Value
            and set(value) = nodeField <- Some value

        member __.ShouldSerializeiterations() = not iterationsField.IsNone
        member __.ShouldSerializelink() = not linkField.IsNone
        member __.ShouldSerializenode() = not nodeField.IsNone

    type Trendline() =

        let mutable colorField : string option = None
        let mutable degreeField : int option = None
        let mutable labelInLegendField : string option = None
        let mutable lineWidthField : int option = None
        let mutable opacityField : float option = None
        let mutable pointSizeField : int option = None
        let mutable showR2Field : bool option = None
        let mutable typeField : string option = None
        let mutable visibleInLegendField : bool option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.degree
            with get() = degreeField.Value
            and set(value) = degreeField <- Some value

        member __.labelInLegend
            with get() = labelInLegendField.Value
            and set(value) = labelInLegendField <- Some value

        member __.lineWidth
            with get() = lineWidthField.Value
            and set(value) = lineWidthField <- Some value

        member __.opacity
            with get() = opacityField.Value
            and set(value) = opacityField <- Some value

        member __.pointSize
            with get() = pointSizeField.Value
            and set(value) = pointSizeField <- Some value

        member __.showR2
            with get() = showR2Field.Value
            and set(value) = showR2Field <- Some value

        member __.``type``
            with get() = typeField.Value
            and set(value) = typeField <- Some value

        member __.visibleInLegend
            with get() = visibleInLegendField.Value
            and set(value) = visibleInLegendField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone    
        member __.ShouldSerializedegree() = not degreeField.IsNone
        member __.ShouldSerializelabelInLegend() = not labelInLegendField.IsNone
        member __.ShouldSerializelineWidth() = not lineWidthField.IsNone
        member __.ShouldSerializeopacity() = not opacityField.IsNone
        member __.ShouldSerializepointSize() = not pointSizeField.IsNone                       
        member __.ShouldSerializeshowR2() = not showR2Field.IsNone
        member __.ShouldSerializetype() = not typeField.IsNone
        member __.ShouldSerializevisibleInLegend() = not visibleInLegendField.IsNone

    type LabelStyle() =

        let mutable colorField : string option = None
        let mutable fontNameField : string option = None
        let mutable fontSizeField : string option = None

        member __.color
            with get() = colorField.Value
            and set(value) = colorField <- Some value

        member __.fontName
            with get() = fontNameField.Value
            and set(value) = fontNameField <- Some value

        member __.fontSize
            with get() = fontSizeField.Value
            and set(value) = fontSizeField <- Some value

        member __.ShouldSerializecolor() = not colorField.IsNone
        member __.ShouldSerializefontName() = not fontNameField.IsNone
        member __.ShouldSerializefontSize() = not fontSizeField.IsNone

    type Timeline() =

        let mutable barLabelStyleField : LabelStyle option = None
        let mutable colorByRowLabelField : bool option = None
        let mutable groupByRowLabelField : bool option = None
        let mutable rowLabelStyleField : LabelStyle option = None
        let mutable showBarLabelsField : bool option = None
        let mutable showRowLabelsField : bool option = None
        let mutable singleColorField : string option = None

        member __.barLabelStyle
            with get() = barLabelStyleField.Value
            and set(value) = barLabelStyleField <- Some value

        member __.colorByRowLabel
            with get() = colorByRowLabelField.Value
            and set(value) = colorByRowLabelField <- Some value

        member __.groupByRowLabel
            with get() = groupByRowLabelField.Value
            and set(value) = groupByRowLabelField <- Some value

        member __.rowLabelStyle
            with get() = rowLabelStyleField.Value
            and set(value) = rowLabelStyleField <- Some value

        member __.showBarLabels
            with get() = showBarLabelsField.Value
            and set(value) = showBarLabelsField <- Some value

        member __.showRowLabels
            with get() = showRowLabelsField.Value
            and set(value) = showRowLabelsField <- Some value

        member __.singleColor
            with get() = singleColorField.Value
            and set(value) = singleColorField <- Some value

        member __.ShouldSerializebarLabelStyle() = not barLabelStyleField.IsNone
        member __.ShouldSerializecolorByRowLabel() = not colorByRowLabelField.IsNone
        member __.ShouldSerializegroupByRowLabel() = not groupByRowLabelField.IsNone
        member __.ShouldSerializerowLabelStyle() = not rowLabelStyleField.IsNone
        member __.ShouldSerializeshowBarLabels() = not showBarLabelsField.IsNone
        member __.ShouldSerializeshowRowLabels() = not showRowLabelsField.IsNone
        member __.ShouldSerializesingleColor() = not singleColorField.IsNone

    type ClassNames() =

        let mutable headerRowField : string option = None
        let mutable tableRowField : string option = None
        let mutable oddTableRowField : bool option = None
        let mutable selectedTableRowField : string option = None
        let mutable hoverTableRowField : string option = None
        let mutable headerCellField : string option = None
        let mutable tableCellField : string option = None
        let mutable rowNumberCellField : string option = None

        member __.headerRow
            with get() = headerRowField.Value
            and set(value) = headerRowField <- Some value

        member __.tableRow
            with get() = tableRowField.Value
            and set(value) = tableRowField <- Some value

        member __.oddTableRow
            with get() = oddTableRowField.Value
            and set(value) = oddTableRowField <- Some value

        member __.selectedTableRow
            with get() = selectedTableRowField.Value
            and set(value) = selectedTableRowField <- Some value

        member __.hoverTableRow
            with get() = hoverTableRowField.Value
            and set(value) = hoverTableRowField <- Some value

        member __.headerCell
            with get() = headerCellField.Value
            and set(value) = headerCellField <- Some value

        member __.tableCell
            with get() = tableCellField.Value
            and set(value) = tableCellField <- Some value

        member __.rowNumberCell
            with get() = rowNumberCellField.Value
            and set(value) = rowNumberCellField <- Some value

        member __.ShouldSerializeheaderRow() = not headerRowField.IsNone
        member __.ShouldSerializetableRow() = not tableRowField.IsNone
        member __.ShouldSerializeoddTableRow() = not oddTableRowField.IsNone
        member __.ShouldSerializeselectedTableRow() = not selectedTableRowField.IsNone
        member __.ShouldSerializehoverTableRow() = not hoverTableRowField.IsNone
        member __.ShouldSerializeheaderCell() = not headerCellField.IsNone
        member __.ShouldSerializetableCell() = not tableCellField.IsNone
        member __.ShouldSerializerowNumberCell() = not rowNumberCellField.IsNone

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
        // Combo
        let mutable curveTypeField : string option = None
        let mutable seriesTypeField : string option = None
        // Gauge
        let mutable greenColorField : string option = None
        let mutable greenFromField : int option = None
        let mutable greenToField : int option = None
        let mutable majorTicksField : string [] option = None
        let mutable minorTicksField : int option = None
        let mutable redColorField : string option = None
        let mutable redFromField : int option = None
        let mutable redToField : int option = None
        let mutable yellowColorField : string option = None
        let mutable yellowFromField : int option = None
        let mutable yellowToField : int option = None
        // Geo
        let mutable datalessRegionColorField : string option = None
        let mutable displayModeField : string option = None
        let mutable domainField : string option = None
        let mutable enableRegionInteractivityField : bool option = None
        let mutable keepAspectRatioField : bool option = None
        let mutable regionField : string option = None
        let mutable magnifyingGlassField : MagnifyingGlass option = None
        let mutable markerOpacityField : float option = None
        let mutable resolutionField : string option = None
        let mutable sizeAxisField : SizeAxis option = None
        // Histogram
        let mutable histogramField : Histogram option = None
        // Map
        let mutable enableScrollWheelField : bool option = None
        let mutable showTipField : bool option = None
        let mutable showLineField : bool option = None
        let mutable lineColorField : string option = None
        let mutable mapTypeField : string option = None
        let mutable useMapTypeControlField : bool option = None
        let mutable zoomLevelField : int option = None
        // Pie
        let mutable is3DField : bool option = None
        let mutable pieHoleField : float option = None
        let mutable pieSliceBorderColorField : string option = None
        let mutable pieSliceTextField : string option = None
        let mutable pieSliceTextStyleField : TextStyle option = None
        let mutable pieStartAngleField : int option = None
        let mutable pieResidueSliceColorField : string option = None
        let mutable pieResidueSliceLabelField : string option = None
        let mutable slicesField : Slice option = None
        let mutable sliceVisibilityThresholdField : int option = None
        // Sankey
        let mutable sankeyField : Sankey option = None
        // Scatter
        let mutable trendlinesField : Trendline [] option = None
        // Stepped Area
        let mutable connectStepsField : bool option = None
        // Table
        let mutable alternatingRowStyleField : bool option = None
        let mutable cssClassNamesField : ClassNames option = None
        let mutable firstRowNumberField : int option = None
        let mutable pageField : string option = None
        let mutable pageSizeField : int option = None
        let mutable rtlTableField : bool option = None
        let mutable scrollLeftStartPositionField : int option = None
        let mutable showRowNumberField : bool option = None
        let mutable sortField : string option = None
        let mutable sortAscendingField : bool option = None
        let mutable sortColumnField : int option = None
        let mutable startPageField : int option = None
        // Timeline
        let mutable avoidOverlappingGridLinesField : bool option = None
        let mutable timelineField : Timeline option = None
        // Treemap
        let mutable fontColorField : string option = None
        let mutable fontFamilyField : string option = None
        let mutable headerColorField : string option = None
        let mutable headerHeightField : int option = None
        let mutable headerHighlightColorField : string option = None
        let mutable hintOpacityField : float option = None
        let mutable maxColorField : string option = None
        let mutable maxDepthField : int option = None
        let mutable maxHighlightColorField : string option = None
        let mutable maxPostDepthField : int option = None
        let mutable maxColorValueField : int option = None
        let mutable midColorField : string option = None
        let mutable midHighlightColorField : string option = None
        let mutable minColorField : string option = None
        let mutable minHighlightColorField : string option = None
        let mutable minColorValueField : int option = None
        let mutable noColorField : string option = None
        let mutable noHighlightColorField : string option = None
        let mutable showScaleField : bool option = None
        let mutable showTooltipsField : bool option = None
        let mutable useWeightedAverageForAggregationField : bool option = None

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

        member __.candlestick
            with get() = candlestickField.Value
            and set(value) = candlestickField <- Some value

        member __.curveType
            with get() = curveTypeField.Value
            and set(value) = curveTypeField <- Some value

        member __.seriesType
            with get() = seriesTypeField.Value
            and set(value) = seriesTypeField <- Some value

        member __.greenColor
            with get() = greenColorField.Value
            and set(value) = greenColorField <- Some value

        member __.greenFrom
            with get() = greenFromField.Value
            and set(value) = greenFromField <- Some value

        member __.greenTo
            with get() = greenToField.Value
            and set(value) = greenToField <- Some value


        member __.majorTicks
            with get() = majorTicksField.Value
            and set(value) = majorTicksField <- Some value

        member __.minorTicks
            with get() = minorTicksField.Value
            and set(value) = minorTicksField <- Some value

        member __.redColor
            with get() = redColorField.Value
            and set(value) = redColorField <- Some value

        member __.redFrom
            with get() = redFromField.Value
            and set(value) = redFromField <- Some value

        member __.redTo
            with get() = redToField.Value
            and set(value) = redToField <- Some value

        member __.yellowColor
            with get() = yellowColorField.Value
            and set(value) = yellowColorField <- Some value

        member __.yellowFrom
            with get() = yellowFromField.Value
            and set(value) = yellowFromField <- Some value

        member __.yellowTo
            with get() = yellowToField.Value
            and set(value) = yellowToField <- Some value

        member __.datalessRegionColor
            with get() = datalessRegionColorField.Value
            and set(value) = datalessRegionColorField <- Some value
        
        member __.displayMode
            with get() = displayModeField.Value
            and set(value) = displayModeField <- Some value

        member __.domain
            with get() = domainField.Value
            and set(value) = domainField <- Some value

        member __.enableRegionInteractivity
            with get() = enableRegionInteractivityField.Value
            and set(value) = enableRegionInteractivityField <- Some value

        member __.keepAspectRatio
            with get() = keepAspectRatioField.Value
            and set(value) = keepAspectRatioField <- Some value

        member __.region
            with get() = regionField.Value
            and set(value) = regionField <- Some value

        member __.magnifyingGlass
            with get() = magnifyingGlassField.Value
            and set(value) = magnifyingGlassField <- Some value

        member __.markerOpacity
            with get() = markerOpacityField.Value
            and set(value) = markerOpacityField <- Some value

        member __.resolution
            with get() = resolutionField.Value
            and set(value) = resolutionField <- Some value

        member __.sizeAxis
            with get() = sizeAxisField.Value
            and set(value) = sizeAxisField <- Some value

        member __.histogram
            with get() = histogramField.Value
            and set(value) = histogramField <- Some value

        member __.enableScrollWheel
            with get() = enableScrollWheelField.Value
            and set(value) = enableScrollWheelField <- Some value

        member __.showTip
            with get() = showTipField.Value
            and set(value) = showTipField <- Some value

        member __.showLine
            with get() = showLineField.Value
            and set(value) = showLineField <- Some value

        member __.lineColor
            with get() = lineColorField.Value
            and set(value) = lineColorField <- Some value

        member __.mapType
            with get() = mapTypeField.Value
            and set(value) = mapTypeField <- Some value

        member __.useMapTypeControl
            with get() = useMapTypeControlField.Value
            and set(value) = useMapTypeControlField <- Some value

        member __.zoomLevel
            with get() = zoomLevelField.Value
            and set(value) = zoomLevelField <- Some value

        member __.is3D
            with get() = is3DField.Value
            and set(value) = is3DField <- Some value

        member __.pieHole
            with get() = pieHoleField.Value
            and set(value) = pieHoleField <- Some value

        member __.pieSliceBorderColor
            with get() = pieSliceBorderColorField.Value
            and set(value) = pieSliceBorderColorField <- Some value

        member __.pieSliceText
            with get() = pieSliceTextField.Value
            and set(value) = pieSliceTextField <- Some value

        member __.pieSliceTextStyle
            with get() = pieSliceTextStyleField.Value
            and set(value) = pieSliceTextStyleField <- Some value

        member __.pieStartAngle
            with get() = pieStartAngleField.Value
            and set(value) = pieStartAngleField <- Some value

        member __.pieResidueSliceColor
            with get() = pieResidueSliceColorField.Value
            and set(value) = pieResidueSliceColorField <- Some value

        member __.pieResidueSliceLabel
            with get() = pieResidueSliceLabelField.Value
            and set(value) = pieResidueSliceLabelField <- Some value

        member __.slices
            with get() = slicesField.Value
            and set(value) = slicesField <- Some value

        member __.sliceVisibilityThreshold
            with get() = sliceVisibilityThresholdField.Value
            and set(value) = sliceVisibilityThresholdField <- Some value

        member __.sankey
            with get() = sankeyField.Value
            and set(value) = sankeyField <- Some value

        member __.trendlines
            with get() = trendlinesField.Value
            and set(value) = trendlinesField <- Some value

        member __.connectSteps
            with get() = connectStepsField.Value
            and set(value) = connectStepsField <- Some value

        member __.alternatingRowStyle
            with get() = alternatingRowStyleField.Value
            and set(value) = alternatingRowStyleField <- Some value

        member __.cssClassNames
            with get() = cssClassNamesField.Value
            and set(value) = cssClassNamesField <- Some value

        member __.firstRowNumber
            with get() = firstRowNumberField.Value
            and set(value) = firstRowNumberField <- Some value

        member __.page
            with get() = pageField.Value
            and set(value) = pageField <- Some value

        member __.pageSize
            with get() = pageSizeField.Value
            and set(value) = pageSizeField <- Some value

        member __.rtlTable
            with get() = rtlTableField.Value
            and set(value) = rtlTableField <- Some value

        member __.scrollLeftStartPosition
            with get() = scrollLeftStartPositionField.Value
            and set(value) = scrollLeftStartPositionField <- Some value

        member __.showRowNumber
            with get() = showRowNumberField.Value
            and set(value) = showRowNumberField <- Some value

        member __.sort
            with get() = sortField.Value
            and set(value) = sortField <- Some value

        member __.sortAscending
            with get() = sortAscendingField.Value
            and set(value) = sortAscendingField <- Some value

        member __.sortColumn
            with get() = sortColumnField.Value
            and set(value) = sortColumnField <- Some value

        member __.startPage
            with get() = startPageField.Value
            and set(value) = startPageField <- Some value

        member __.avoidOverlappingGridLines
            with get() = avoidOverlappingGridLinesField.Value
            and set(value) = avoidOverlappingGridLinesField <- Some value

        member __.timeline
            with get() = timelineField.Value
            and set(value) = timelineField <- Some value


        member __.fontColor
            with get() = fontColorField.Value
            and set(value) = fontColorField <- Some value

        member __.fontFamily
            with get() = fontFamilyField.Value
            and set(value) = fontFamilyField <- Some value

        member __.headerColor
            with get() = headerColorField.Value
            and set(value) = headerColorField <- Some value

        member __.headerHeight
            with get() = headerHeightField.Value
            and set(value) = headerHeightField <- Some value

        member __.headerHighlightColor
            with get() = headerHighlightColorField.Value
            and set(value) = headerHighlightColorField <- Some value

        member __.hintOpacity
            with get() = hintOpacityField.Value
            and set(value) = hintOpacityField <- Some value

        member __.maxColor
            with get() = maxColorField.Value
            and set(value) = maxColorField <- Some value

        member __.maxDepth
            with get() = maxDepthField.Value
            and set(value) = maxDepthField <- Some value

        member __.maxHighlightColor
            with get() = maxHighlightColorField.Value
            and set(value) = maxHighlightColorField <- Some value

        member __.maxPostDepth
            with get() = maxPostDepthField.Value
            and set(value) = maxPostDepthField <- Some value

        member __.maxColorValue
            with get() = maxColorValueField.Value
            and set(value) = maxColorValueField <- Some value

        member __.midColor
            with get() = midColorField.Value
            and set(value) = midColorField <- Some value

        member __.midHighlightColor
            with get() = midHighlightColorField.Value
            and set(value) = midHighlightColorField <- Some value

        member __.minColor
            with get() = minColorField.Value
            and set(value) = minColorField <- Some value

        member __.minHighlightColor
            with get() = minHighlightColorField.Value
            and set(value) = minHighlightColorField <- Some value

        member __.minColorValue
            with get() = minColorValueField.Value
            and set(value) = minColorValueField <- Some value

        member __.noColor
            with get() = noColorField.Value
            and set(value) = noColorField <- Some value

        member __.noHighlightColor
            with get() = noHighlightColorField.Value
            and set(value) = noHighlightColorField <- Some value

        member __.showScale
            with get() = showScaleField.Value
            and set(value) = showScaleField <- Some value

        member __.showTooltips
            with get() = showTooltipsField.Value
            and set(value) = showTooltipsField <- Some value

        member __.useWeightedAverageForAggregation
            with get() = useWeightedAverageForAggregationField.Value
            and set(value) = useWeightedAverageForAggregationField <- Some value

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
        member __.ShouldSerializecandlestick() = not candlestickField.IsNone
        member __.ShouldSerializecurveType() = not curveTypeField.IsNone
        member __.ShouldSerializeseriesType() = not seriesTypeField.IsNone
        member __.ShouldSerializegreenColor() = not greenColorField.IsNone
        member __.ShouldSerializegreenFrom() = not greenFromField.IsNone
        member __.ShouldSerializegreenTo() = not greenToField.IsNone
        member __.ShouldSerializemajorTicks() = not majorTicksField.IsNone
        member __.ShouldSerializeminorTicks() = not minorTicksField.IsNone
        member __.ShouldSerializeredColor() = not redColorField.IsNone
        member __.ShouldSerializeredFrom() = not redFromField.IsNone
        member __.ShouldSerializeredTo() = not redToField.IsNone
        member __.ShouldSerializeyellowColor() = not yellowColorField.IsNone
        member __.ShouldSerializeyellowFrom() = not yellowFromField.IsNone
        member __.ShouldSerializeyellowTo() = not yellowFromField.IsNone
        member __.ShouldSerializedatalessRegionColor() = not datalessRegionColorField.IsNone
        member __.ShouldSerializedisplayMode() = not displayModeField.IsNone
        member __.ShouldSerializedomain() = not domainField.IsNone
        member __.ShouldSerializeenableRegionInteractivity() = not enableRegionInteractivityField.IsNone
        member __.ShouldSerializekeepAspectRatio() = not keepAspectRatioField.IsNone
        member __.ShouldSerializeregion() = not regionField.IsNone
        member __.ShouldSerializemagnifyingGlass() = not magnifyingGlassField.IsNone
        member __.ShouldSerializemarkerOpacity() = not markerOpacityField.IsNone
        member __.ShouldSerializeresolution() = not resolutionField.IsNone
        member __.ShouldSerializesizeAxis() = not sizeAxisField.IsNone
        member __.ShouldSerializehistogram() = not histogramField.IsNone
        member __.ShouldSerializeenableScrollWheel() = not enableScrollWheelField.IsNone
        member __.ShouldSerializeshowTip() = not showTipField.IsNone
        member __.ShouldSerializeshowLine() = not showLineField.IsNone
        member __.ShouldSerializelineColor() = not lineColorField.IsNone
        member __.ShouldSerializemapType() = not mapTypeField.IsNone
        member __.ShouldSerializeuseMapTypeControl() = not useMapTypeControlField.IsNone
        member __.ShouldSerializezoomLevel() = not zoomLevelField.IsNone
        member __.ShouldSerializeis3D() = not is3DField.IsNone
        member __.ShouldSerializepieHole() = not pieHoleField.IsNone
        member __.ShouldSerializepieSliceBorderColor() = not pieSliceBorderColorField.IsNone
        member __.ShouldSerializepieSliceText() = not pieSliceTextField.IsNone
        member __.ShouldSerializepieSliceTextStyle() = not pieSliceTextStyleField.IsNone
        member __.ShouldSerializepieStartAngle() = not pieStartAngleField.IsNone
        member __.ShouldSerializepieResidueSliceColor() = not pieResidueSliceColorField.IsNone
        member __.ShouldSerializepieResidueSliceLabel() = not pieResidueSliceLabelField.IsNone
        member __.ShouldSerializeslices() = not slicesField.IsNone
        member __.ShouldSerializesliceVisibilityThreshold() = not sliceVisibilityThresholdField.IsNone
        member __.ShouldSerializesankey() = not sankeyField.IsNone
        member __.ShouldSerializetrendlines() = not trendlinesField.IsNone
        member __.ShouldSerializeconnectSteps() = not connectStepsField.IsNone
        member __.ShouldSerializealternatingRowStyle() = not alternatingRowStyleField.IsNone
        member __.ShouldSerializecssClassNames() = not cssClassNamesField.IsNone
        member __.ShouldSerializefirstRowNumber() = not firstRowNumberField.IsNone
        member __.ShouldSerializepage() = not pageField.IsNone
        member __.ShouldSerializepageSize() = not pageSizeField.IsNone
        member __.ShouldSerializertlTable() = not rtlTableField.IsNone
        member __.ShouldSerializescrollLeftStartPosition() = not scrollLeftStartPositionField.IsNone
        member __.ShouldSerializeshowRowNumber() = not showRowNumberField.IsNone
        member __.ShouldSerializesort() = not sortField.IsNone
        member __.ShouldSerializesortAscending() = not sortAscendingField.IsNone
        member __.ShouldSerializesortColumn() = not sortColumnField.IsNone
        member __.ShouldSerializestartPage() = not startPageField.IsNone
        member __.ShouldSerializeavoidOverlappingGridLines() = not avoidOverlappingGridLinesField.IsNone
        member __.ShouldSerializetimeline() = not timelineField.IsNone
        member __.ShouldSerializefontColor() = not fontColorField.IsNone
        member __.ShouldSerializefontFamily() = not fontFamilyField.IsNone
        member __.ShouldSerializeheaderColor() = not headerColorField.IsNone
        member __.ShouldSerializeheaderHeight() = not headerHeightField.IsNone
        member __.ShouldSerializeheaderHighlightColor() = not headerHighlightColorField.IsNone
        member __.ShouldSerializehintOpacity() = not hintOpacityField.IsNone
        member __.ShouldSerializemaxColor() = not maxColorField.IsNone
        member __.ShouldSerializemaxDepth() = not maxDepthField.IsNone
        member __.ShouldSerializemaxHighlightColor() = not maxHighlightColorField.IsNone
        member __.ShouldSerializemaxPostDepth() = not maxPostDepthField.IsNone
        member __.ShouldSerializemaxColorValue() = not maxColorValueField.IsNone
        member __.ShouldSerializemidColor() = not midColorField.IsNone
        member __.ShouldSerializemidHighlightColor() = not midHighlightColorField.IsNone
        member __.ShouldSerializeminColor() = not minColorField.IsNone
        member __.ShouldSerializeminHighlightColor() = not minHighlightColorField.IsNone
        member __.ShouldSerializeminColorValue() = not minColorValueField.IsNone
        member __.ShouldSerializenoColor() = not noColorField.IsNone
        member __.ShouldSerializenoHighlightColor() = not noHighlightColorField.IsNone
        member __.ShouldSerializeshowScale() = not showScaleField.IsNone
        member __.ShouldSerializeshowTooltips() = not showTooltipsField.IsNone
        member __.ShouldSerializeuseWeightedAverageForAggregation() = not useWeightedAverageForAggregationField.IsNone

let jsTemplate =
    """google.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = new google.visualization.DataTable({DATA});

            var options = {OPTIONS} 

            var chart = new google.visualization.{TYPE}(document.getElementById('{GUID}'));
            chart.draw(data, options);
        }"""

let template =
    """<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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

type ChartGallery =
    | Annotation
    | Area
    | Bar
    | Bubble
    | Calendar
    | Candlestick
    | Column
    | Combo
    | Gauge
    | Geo
    | Histogram
    | Line
    | Map
    | Pie
    | Sankey
    | Scatter
    | SteppedArea
    | Table
    | Timeline
    | TreeMap

    override __.ToString() =
        match FSharpValue.GetUnionFields(__, typeof<ChartGallery>) with
        | case, _ ->
            let name = case.Name
            match name with
            | "Calendar"
            | "Gauge"
            | "Histogram"
            | "Map"
            | "Sankey"
            | "Table"
            | "Timeline"
            | "TreeMap" -> name
            | _ -> name + "Chart"

/// Creates the bitmap frame used to set the chart's window icon.
let private icon =
    let uriString = @"pack://application:,,,/XPlot.GoogleCharts;component/XPlot.ico"
    let iconUri = Uri(uriString, UriKind.RelativeOrAbsolute)
    BitmapFrame.Create(iconUri)

type GoogleChart() =

    [<DefaultValue>]
    val mutable private dataTable : DataTable
    
    [<DefaultValue>]
    val mutable private options : Options

    [<DefaultValue>]
    val mutable private ``type`` : ChartGallery
    
    /// The chart's container div id.
    member val Id =
        Guid.NewGuid().ToString()
        with get, set

    /// The height of the chart container element.
    member val Height = 500 with get, set

    /// The width of the chart container element.
    member val Width = 900 with get, set

    static member Create data labels options ``type`` =
        let dt = makeDataTable data labels
        let gc = GoogleChart()
        gc.dataTable <- dt
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    static member CreateFromDataTable dataTable options ``type`` =
        let gc = GoogleChart()
        gc.dataTable <- dataTable
        gc.options <- options
        gc.``type`` <- ``type``
        gc

    /// The chart's JavaScript code. Doesn't contain the
    /// necessary line for loading the appropiate Google
    /// visualization package. 
    member __.Js =
        let dataJson = __.dataTable.ToGoogleDataTable().GetJson()         
        let optionsJson = JsonConvert.SerializeObject(__.options)
        jsTemplate.Replace("{DATA}", dataJson)
            .Replace("{OPTIONS}", optionsJson)
            .Replace("{TYPE}", __.``type``.ToString())
            .Replace("{GUID}", __.Id)

    /// The chart's complete HTML code.
    member __.Html =
        let version =
            match __.``type`` with
            | Calendar | Sankey -> "1.1"            
            | _ -> "1"
        let packages =
            match __.``type`` with
            | Annotation -> "annotationchart"
            | Calendar -> "calendar"
            | Gauge -> "gauge"
            | Geo -> "geochart"
            | Map -> "map"
            | Sankey -> "sankey"
            | Table -> "table"
            | Timeline -> "timeline"
            | TreeMap -> "treemap"
            | _ -> "corechart"
        template.Replace("{VERSION}", version)
            .Replace("{PACKAGES}", packages)
            .Replace("{JS}", __.Js)
            .Replace("{GUID}", __.Id)
            .Replace("{WIDTH}", string(__.Width))
            .Replace("{HEIGHT}", string(__.Height))

    /// Displays the chart in a window.
    member __.Show() =
        let wnd = Window()
        wnd.Icon <- icon
        wnd.Height <- 600.
        wnd.Width <- 1000.
        wnd.Topmost <- true
        wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
        let browser = new WebBrowser()
        browser.NavigateToString __.Html
        wnd.Content <- browser
        wnd.Show()
        wnd.Topmost <- false

    /// Sets the data series label. Use this member if the
    /// chart's data is a single series.
    member __.WithLabel label =
        let columns = __.dataTable.Columns
        columns.[1].ColumnName <- label

    /// Sets the data series labels. Use this member if the
    /// chart's data is a series collection.
    member __.WithLabels labels =
        let columns = __.dataTable.Columns
        let names =
            match (Seq.length labels) = columns.Count with
            | false -> Seq.append ["Column 1"] labels
            | true -> labels
        names
        |> Seq.iteri (fun idx x -> columns.[idx].ColumnName <- x)
            
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
                
    /// Sets the chart's container div id.
    member __.WithId newId = __.Id <- newId

    /// Sets the chart's configuration options.
    member __.WithOptions options = __.options <- options

    /// Sets the chart's height.
    member __.WithHeight height = __.Height <- height

    /// Sets the chart's width.
    member __.WithWidth width = __.Width <- width

type Chart =

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<DateTime * #value * string * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Annotation

    /// <summary>Creates an annotation chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Annotation(data:seq<#seq<DateTime * 'V * string * string>> when 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Annotation

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Area

    /// <summary>Creates an area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Area(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Area

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bar

    /// <summary>Creates a bar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bar(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Bar

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble

    /// <summary>Creates a bubble chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Bubble(data:seq<string * #value * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Bubble
     
    /// <summary>Creates a calendar chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Calendar(data:seq<DateTime * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Calendar
 
    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#key * #value * #value * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Candlestick

    /// <summary>Creates a candlestick chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Candlestick(data:seq<#seq<'K * 'V * 'V * 'V * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Candlestick

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Column

    /// <summary>Creates a column chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Column(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Column

    /// <summary>Creates a combo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Combo(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Combo

    /// <summary>Creates a gauge chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Gauge(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Gauge

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Geo

    /// <summary>Creates a geo chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Geo(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Geo

    /// <summary>Creates a histogram chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Histogram(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Histogram

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Line

    /// <summary>Creates a line chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Line(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Line
     
    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<string * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Map

    /// <summary>Creates a map chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Map(data:seq<float * float * string>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Map

    /// <summary>Creates a pie chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Pie(data:seq<string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Pie

    /// <summary>Creates a sankey diagram.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Sankey(data:seq<string * string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Sankey

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Scatter

    /// <summary>Creates a scatter chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Scatter(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Scatter

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options SteppedArea

    /// <summary>Creates a stepped area chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member SteppedArea(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options SteppedArea

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#key * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Table

    /// <summary>Creates a table chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Table(data:seq<#seq<'K * 'V>> when 'K :> key and 'V :> value, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map (fun x ->
                x 
                |> Seq.map Datum.New
                |> Series.New)
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create series Labels options Table

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Timeline

    /// <summary>Creates a timeline chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Timeline(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options Timeline

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options TreeMap

    /// <summary>Creates a treemap chart.</summary>
    /// <param name="data">The chart's data.</param>
    /// <param name="Labels">Labels for the data table columns.</param>
    /// <param name="Options">The chart's options.</param>
    static member Treemap(data:seq<string * string * #value * #value>, ?Labels, ?Options) =
        let series =
            data
            |> Seq.map Datum.New
            |> Series.New
        let options = defaultArg Options <| Configuration.Options()
        GoogleChart.Create [series] Labels options TreeMap
        
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

    /// Sets the chart's height.
    static member WithHeight height (chart:GoogleChart) =
        chart.WithHeight height
        chart

    /// Sets the chart's width.
    static member WithWidth width (chart:GoogleChart) =
        chart.WithWidth width
        chart

//============================
// TODO: build Google data tables from System.Data.DataTable
//let sysDt = new System.Data.DataTable()
//
//let ``type`` = typeof<string>
//sysDt.Columns.Add("firstcolumn", ``type``) |> ignore
//sysDt.Columns.Add("secondcolumn", typeof<int>) |> ignore
//sysDt.Columns.Add("thirdcolumn", typeof<decimal>) |> ignore
//sysDt.Locale = System.Globalization.CultureInfo.InvariantCulture |> ignore
// 
//let row1 = sysDt.NewRow()
//row1.[0] <- "Ciao"
//row1.[1] <- 10
//row1.[2] <- 2.2
//sysDt.Rows.Add(row1)
// 
//let dataTable = sysDt.ToGoogleDataTable()
//     
//let json = dataTable.GetJson()
//=============================