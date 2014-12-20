#load "../packages/XPlot.GoogleCharts.1.1.3/XPlot.GoogleCharts.fsx"
#r """../packages/Deedle.1.0.6/lib/net40/Deedle.dll"""
#r """./bin/Release/XPlot.GoogleCharts.Deedle.dll"""

open Deedle
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle
open System

module Area =

    let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
    let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

    let chart1 =
        sales
        |> Chart.Area
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.Show

    let chart2 =
        [sales; expenses]
        |> Chart.Area
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.WithId "my_chart"
        |> Chart.WithLegend true
        |> Chart.Show

    let chart3 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Area
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.WithId "my_chart"
        |> Chart.WithLegend true
        |> Chart.Show

    let options = Options()
    options.title <- "Company Performance"
    let hAxisOptions = Axis()
    hAxisOptions.title <- "Year"
    hAxisOptions.titleTextStyle <- TextStyle(color = "#333")
    options.hAxis <- hAxisOptions
    options.vAxis <- Axis(minValue = 0)

    let chart4 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Area
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

module Bar =

    let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
    let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

    let chart1 =
        sales
        |> Chart.Bar
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.Show

    let chart2 =
        [sales; expenses]
        |> Chart.Bar
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.WithLegend true
        |> Chart.Show

    let options = Options()

    options.title <- "Company Performance"

    let vAxisOptions = Axis()
    vAxisOptions.title <- "Year"
    vAxisOptions.titleTextStyle <- TextStyle(color = "red")
    options.vAxis <- vAxisOptions

    let chart3 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Bar
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    let chart4 =
        let fantasy = series ["2010" => 10; "2020" => 16; "2030" => 28]
        let romance = series ["2010" => 24; "2020" => 22; "2030" => 19]
        let mystery = series ["2010" => 20; "2020" => 23; "2030" => 29]
        let general = series ["2010" => 32; "2020" => 30; "2030" => 30]
        let western = series ["2010" => 18; "2020" => 16; "2030" => 12]
        let literature = series ["2010" => 5; "2020" => 9; "2030" => 13]

        let options =
            Options(
                width = 600,
                height = 400,
                legend = Legend(position = "top", maxLines = 3),
                bar = Bar(groupWidth = "75%"),
                isStacked = true
            )

        [fantasy; romance; mystery; general; western; literature]
        |> Chart.Bar
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Fantasy & Sci Fi"; "Romance"; "Mystery/Crime"; "General"; "Western"; "Literature"]
        |> Chart.Show

module Bubble =

    type Correlation =
        {
            country : string
            lifeExpectancy : float
            fertilityRate : float
            region : string
            population : int
        }

        static member New (c, l, f, r, p) =
            {
                country = c
                lifeExpectancy = l
                fertilityRate = f
                region = r
                population = p
            }

    let data =
        [
            "CAN", 80.66, 1.67, "North America", 33739900
            "DEU", 79.84, 1.36, "Europe", 81902307
            "DNK", 78.6, 1.84, "Europe", 5523095
            "EGY", 72.73, 2.78, "Middle East", 79716203
            "GBR", 80.05, 2., "Europe", 61801570
            "RUS", 68.6, 1.54, "Europe", 141850000
            "USA", 78.09, 2.05, "North America", 307007000
        ]
        |> List.map Correlation.New

    let options =
        Options(
            title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
            hAxis = Axis(title = "Life Expectancy"),
            vAxis = Axis(title = "Fertility Rate"),
            bubble = Bubble(textStyle = TextStyle(fontSize = 11))
        )

    let chart1 =
        data
        |> Frame.ofRecords
        |> Frame.indexRowsString "country"     
        |> Chart.Bubble
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Life Expectancy"; "Fertility Rate"; "Region"; "Population"]
        |> Chart.WithLegend true
        |> Chart.Show

module Calendar =

    let rnd = Random()

    let data =
        series [
            for x in 1. .. 500. ->
                DateTime(2013, 1, 9).AddDays(x) => rnd.Next(0, 9)
        ]

    let options =
        Options(
            title = "GitHub Contributions",
            height = 350
        )

    let chart1 =
        data
        |> Chart.Calendar
        |> Chart.WithOptions options
        |> Chart.Show

module Candlestick =
    
    type Marker =
        {
            x : string
            low : int
            opening : int
            closing : int
            high : int
        }

        static member New (x, l, o, c, h) =
            {
                x = x
                low = l
                opening = o
                closing = c
                high = h
            }

    let chart1 =
        [
            "Mon", 20, 28, 38, 45
            "Tue", 31, 38, 55, 66
            "Wed", 50, 55, 77, 80
            "Thu", 77, 77, 66, 50
            "Fri", 68, 66, 22, 15        
        ]
        |> List.map Marker.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "x"
        |> Chart.Candlestick
        |> Chart.Show     

module Column =

    let sales = series ["2013" => 1000; "2014" => 1170; "2015" => 660; "2016" => 1030]
    let expenses = series ["2013" => 400; "2014" => 460; "2015" => 1120; "2016" => 540]

    let chart1 =
        sales
        |> Chart.Column
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.Show

    let chart2 =
        [sales; expenses]
        |> Chart.Column
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.WithLegend true
        |> Chart.Show

    let options = Options()

    options.title <- "Company Performance"

    let hAxisOptions = Axis()
    hAxisOptions.title <- "Year"
    hAxisOptions.titleTextStyle <- TextStyle(color = "red")
    options.hAxis <- hAxisOptions

    let chart3 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Column
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    let chart4 =
        let fantasy = series ["2010" => 10; "2020" => 16; "2030" => 28]
        let romance = series ["2010" => 24; "2020" => 22; "2030" => 19]
        let mystery = series ["2010" => 20; "2020" => 23; "2030" => 29]
        let general = series ["2010" => 32; "2020" => 30; "2030" => 30]
        let western = series ["2010" => 18; "2020" => 16; "2030" => 12]
        let literature = series ["2010" => 5; "2020" => 9; "2030" => 13]

        let options =
            Options(
                width = 600,
                height = 400,
                legend = Legend(position = "top", maxLines = 3),
                bar = Bar(groupWidth = "75%"),
                isStacked = true
            )

        [fantasy; romance; mystery; general; western; literature]
        |> Chart.Column
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Fantasy & Sci Fi"; "Romance"; "Mystery/Crime"; "General"; "Western"; "Literature"]
        |> Chart.Show

module Combo =

    let Bolivia = series ["2004/05", 165.; "2005/06", 135.; "2006/07", 157.; "2007/08", 139.; "2008/09", 136.]
    let Ecuador = series ["2004/05", 938.; "2005/06", 1120.; "2006/07", 1167.; "2007/08", 1110.; "2008/09", 691.]
    let Madagascar = series ["2004/05", 522.; "2005/06", 599.; "2006/07", 587.; "2007/08", 615.; "2008/09", 629.]
    let ``Papua New Guinea`` = series ["2004/05", 998.; "2005/06", 1268.; "2006/07", 807.; "2007/08", 968.; "2008/09", 1026.]
    let Rwanda = series ["2004/05", 450.; "2005/06", 288.; "2006/07", 397.; "2007/08", 215.; "2008/09", 366.]
    let average = series ["2004/05", 614.6; "2005/06", 682.; "2006/07", 623.; "2007/08", 609.4; "2008/09", 569.6]

    let options =
        Options(
            title = "Monthly Coffee Production by Country",
            vAxis = Axis(title = "Cups"),
            hAxis = Axis(title = "Month"),
            seriesType = "bars",
            series = [|Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "bars"); Series(``type`` = "line")|]
        )

    let chart1 =
        [Bolivia; Ecuador; Madagascar; ``Papua New Guinea``; Rwanda; average]
        |> Chart.Combo
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Bolivia"; "Ecuador"; "Madagascar"; "Papua New Guinea"; "Rwanda"; "Average"]
        |> Chart.WithLegend true
        |> Chart.Show

    let chart2 =
        [
            "Bolivia" => Bolivia
            "Ecuador" => Ecuador
            "Madagascar" => Madagascar
            "Papua New Guinea" => ``Papua New Guinea``
            "Rwanda" => Rwanda
            "Average" => average
        ]
        |> Frame.ofColumns
        |> Chart.Combo
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Bolivia"; "Ecuador"; "Madagascar"; "Papua New Guinea"; "Rwanda"; "Average"]
        |> Chart.WithLegend true
        |> Chart.Show

module Gauge =

    let data = series ["Memory", 80; "CPU", 55; "Network", 68]

    let options =
        Options(
            width = 400,
            height = 120,
            redFrom = 90,
            redTo = 100,
            yellowFrom = 75,
            yellowTo = 90,
            minorTicks = 5
        )

    let chart =
        data
        |> Chart.Gauge
        |> Chart.WithOptions options
        |> Chart.Show

module Geo =

    let chart1 =
        [
            "Germany", 200
            "United States", 300
            "Brazil", 400
            "Canada", 500
            "France", 600
            "RU", 700
        ]
        |> series
        |> Chart.Geo
        |> Chart.WithLabel "Popularity"
        |> Chart.Show

    let population =
        series [
            "Rome", 2761477.
            "Milan", 1324110.
            "Naples", 959574.
            "Turin", 907563.
            "Palermo", 655875.
            "Genoa", 607906.
            "Bologna", 380181.
            "Florence", 371282.
            "Fiumicino", 67370.
            "Anzio", 52192.
            "Ciampino", 38262.
        ]

    let area =
        series [
            "Rome", 1285.31
            "Milan", 181.76
            "Naples", 117.27
            "Turin", 130.17
            "Palermo", 158.9
            "Genoa", 243.60
            "Bologna", 140.7
            "Florence", 102.41
            "Fiumicino", 213.44
            "Anzio", 43.43
            "Ciampino", 11.
        ]

    let options =
        Options(
            region = "IT",
            displayMode = "markers",
            colorAxis = ColorAxis(colors = [|"green"; "blue"|])
        )

    let chart2 =
        [population; area]
        |> Chart.Geo
        |> Chart.WithLabels ["Population"; "Area"]
        |> Chart.WithOptions options
        |> Chart.Show

    let chart3 =
        ["Population" => population; "Area" => area]
        |> Frame.ofColumns
        |> Chart.Geo
        |> Chart.WithOptions options
        |> Chart.Show

module Histogram =

    let data =
        series [
            "Acrocanthosaurus (top-spined lizard)", 12.2
            "Albertosaurus (Alberta lizard)", 9.1
            "Allosaurus (other lizard)", 12.2
            "Apatosaurus (deceptive lizard)", 22.9
            "Archaeopteryx (ancient wing)", 0.9
            "Argentinosaurus (Argentina lizard)", 36.6
            "Baryonyx (heavy claws)", 9.1
            "Brachiosaurus (arm lizard)", 30.5
            "Ceratosaurus (horned lizard)", 6.1
            "Coelophysis (hollow form)", 2.7
            "Compsognathus (elegant jaw)", 0.9
            "Deinonychus (terrible claw)", 2.7
            "Diplodocus (double beam)", 27.1
            "Dromicelomimus (emu mimic)", 3.4
            "Gallimimus (fowl mimic)", 5.5
            "Mamenchisaurus (Mamenchi lizard)", 21.0
            "Megalosaurus (big lizard)", 7.9
            "Microvenator (small hunter)", 1.2
            "Ornithomimus (bird mimic)", 4.6
            "Oviraptor (egg robber)", 1.5
            "Plateosaurus (flat lizard)", 7.9
            "Sauronithoides (narrow-clawed lizard)", 2.0
            "Seismosaurus (tremor lizard)", 45.7
            "Spinosaurus (spiny lizard)", 12.2
            "Supersaurus (super lizard)", 30.5
            "Tyrannosaurus (tyrant lizard)", 15.2
            "Ultrasaurus (ultra lizard)", 30.5
            "Velociraptor (swift robber)", 1.8        
        ]

    let options = Options(title = "Lengths of dinosaurs, in meters")

    let chart =
        data
        |> Chart.Histogram
        |> Chart.WithOptions options
        |> Chart.WithLabel "Length"
        |> Chart.Show
