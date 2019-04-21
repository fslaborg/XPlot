﻿#I "../../../bin"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.WPF.dll"

open XPlot.GoogleCharts

let Bolivia = ["2004/05", 165.; "2005/06", 135.; "2006/07", 157.; "2007/08", 139.; "2008/09", 136.]
let Ecuador = ["2004/05", 938.; "2005/06", 1120.; "2006/07", 1167.; "2007/08", 1110.; "2008/09", 691.]
let Madagascar = ["2004/05", 522.; "2005/06", 599.; "2006/07", 587.; "2007/08", 615.; "2008/09", 629.]
let ``Papua New Guinea`` = ["2004/05", 998.; "2005/06", 1268.; "2006/07", 807.; "2007/08", 968.; "2008/09", 1026.]
let Rwanda = ["2004/05", 450.; "2005/06", 288.; "2006/07", 397.; "2007/08", 215.; "2008/09", 366.]
let average = ["2004/05", 614.6; "2005/06", 682.; "2006/07", 623.; "2007/08", 609.4; "2008/09", 569.6]

let options =
    Options(
        title = "Monthly Coffee Production by Country",
        vAxis = Axis(title = "Cups"),
        hAxis = Axis(title = "Month"),
        seriesType = "bars",
        series = [|Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "line")|]
    )

let test =
    [Bolivia; Ecuador; Madagascar; ``Papua New Guinea``; Rwanda; average]
    |> Chart.Combo
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Bolivia"; "Ecuador"; "Madagascar"; "Papua New Guinea"; "Rwanda"; "Average"]
    |> Chart.Show
