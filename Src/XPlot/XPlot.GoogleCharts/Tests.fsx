#r """.\bin\Release\XPlot.GoogleCharts.dll"""

open System
open XPlot.GoogleCharts

module Annotation =

    let chart1 =
        [
            DateTime(2314, 2, 15), 12400, "", ""
            DateTime(2314, 2, 16), 24045, "Lalibertines", "First encounter"
            DateTime(2314, 2, 17), 35022, "Lalibertines", "They are very tall"
            DateTime(2314, 2, 18), 12284, "Lalibertines", "Attack on our crew!"
            DateTime(2314, 2, 19), 8476, "Lalibertines", "Heavy casualties"
            DateTime(2314, 2, 20), 0, "Lalibertines", "All crew lost"
        ]
        |> Chart.Annotation
        |> Chart.WithOptions(Options(displayAnnotations = true))
        |> Chart.WithLabels ["Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"]
        |> Chart.Show

    let chart2 =
        let kepler =
            [
                DateTime(2314, 3, 15), 12400, "", ""
                DateTime(2314, 3, 16), 24045, "Lalibertines", "First encounter"
                DateTime(2314, 3, 17), 35022, "Lalibertines", "They are very tall"
                DateTime(2314, 3, 18), 12284, "Lalibertines", "Attack on our crew!"
                DateTime(2314, 3, 19), 8476, "Lalibertines", "Heavy casualties"
                DateTime(2314, 3, 20), 0, "Lalibertines", "All crew lost"
            ]
        let gliese =
            [
                DateTime(2314, 3, 15), 10645, "", ""
                DateTime(2314, 3, 16), 12374, "", ""
                DateTime(2314, 3, 17), 15766, "Gallantors", "First Encounter"
                DateTime(2314, 3, 18), 34334, "Gallantors", "Statement of shared principles"
                DateTime(2314, 3, 19), 66467, "Gallantors", "Mysteries revealed"
                DateTime(2314, 3, 20), 79463, "Gallantors", "Omniscience achieved"
            ]
        [kepler; gliese]
        |> Chart.Annotation
        |> Chart.WithOptions(Options(displayAnnotations = true))
        |> Chart.WithLabels
            [
                "Kepler-22b mission"; "Kepler-22b title"; "Kepler-22b text"
                "Gliese 163 mission"; "Gliese title"; "Gliese text"            
            ]
        |> Chart.Show

module Area =

    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

    // single data series
    let chart1 =
        sales
        |> Chart.Area
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Year"
        |> Chart.WithYTitle "Amount"
        |> Chart.Show

    // multiple data series
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

    // custom options
    let options = Options()

    options.title <- "Company Performance"

    let hAxisOptions = Axis()
    hAxisOptions.title <- "Year"
    hAxisOptions.titleTextStyle <- TextStyle(color = "#333")
    options.hAxis <- hAxisOptions

    options.vAxis <- Axis(minValue = 0)

    let chart3 =
        [sales; expenses]
        |> Chart.Area
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

module Bar =

    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

    // single data series
    let chart1 =
        sales
        |> Chart.Bar
        |> Chart.WithTitle "Company Sales"
        |> Chart.WithXTitle "Amount"
        |> Chart.WithYTitle "Year"
        |> Chart.Show

    // multiple data series
    let chart2 =
        [sales; expenses]
        |> Chart.Bar
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithXTitle "Amount"
        |> Chart.WithYTitle "Year"
        |> Chart.WithLegend true
        |> Chart.Show

    // custom options
    let options = Options()

    options.title <- "Company Performance"

    let vAxisOptions = Axis()
    vAxisOptions.title <- "Year"
    vAxisOptions.titleTextStyle <- TextStyle(color = "red")
    options.vAxis <- vAxisOptions

    let chart3 =
        [sales; expenses]
        |> Chart.Bar
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    // stacked
    let chart4 =
        let fantasy = ["2010", 10; "2020", 16; "2030", 28]
        let romance = ["2010", 24; "2020", 22; "2030", 19]
        let mystery = ["2010", 20; "2020", 23; "2030", 29]
        let general = ["2010", 32; "2020", 30; "2030", 30]
        let western = ["2010", 18; "2020", 16; "2030", 12]
        let literature = ["2010", 5; "2020", 9; "2030", 13]

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

    let options =
        Options(
            title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
            hAxis = Axis(title = "Life Expectancy"),
            vAxis = Axis(title = "Fertility Rate"),
            bubble = Bubble(textStyle = TextStyle(fontSize = 11))
        )

    let chart =
        data
        |> Chart.Bubble
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Life Expectancy"; "Fertility Rat"; "Region"; "Population"]
        |> Chart.WithLegend true
        |> Chart.Show

module Calendar =

    let rnd = Random()

    let data =
        [
            for x in 1. .. 500. ->
                DateTime(2013, 1, 9).AddDays(x), rnd.Next(0, 9)
        ]

    let options =
        Options(
            title = "GitHub Contributions",
            height = 350
        )

    let chart =
        data
        |> Chart.Calendar
        |> Chart.WithOptions options
        |> Chart.Show

module Candlestick =
    
    let data =
        [
            "Mon", 20, 28, 38, 45
            "Tue", 31, 38, 55, 66
            "Wed", 50, 55, 77, 80
            "Thu", 77, 77, 66, 50
            "Fri", 68, 66, 22, 15        
        ]
        
    let chart =
        Chart.Candlestick data
        |> Chart.Show     
        
module Column =

    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]

    let options = Options()

    options.title <- "Company Performance"

    let hAxisOptions = Axis()
    hAxisOptions.title <- "Year"
    hAxisOptions.titleTextStyle <- TextStyle(color = "red")
    options.hAxis <- hAxisOptions

    let chart1 =
        [sales; expenses]
        |> Chart.Column
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    let chart2 =
        let fantasy = ["2010", 10; "2020", 16; "2030", 28]
        let romance = ["2010", 24; "2020", 22; "2030", 19]
        let mystery = ["2010", 20; "2020", 23; "2030", 29]
        let general = ["2010", 32; "2020", 30; "2030", 30]
        let western = ["2010", 18; "2020", 16; "2030", 12]
        let literature = ["2010", 5; "2020", 9; "2030", 13]

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

    [Bolivia; Ecuador; Madagascar; ``Papua New Guinea``; Rwanda; average]
    |> Chart.Combo
    |> Chart.WithOptions options
    |> Chart.Show

module Gauge =

    let data = ["Memory", 80; "CPU", 55; "Network", 68]

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
        Chart.Gauge data
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
        |> Chart.Geo
        |> Chart.WithLabel "Popularity"
        |> Chart.Show

    // marker geochart
    let data =
        [
            "Rome", 2761477, 1285.31
            "Milan", 1324110, 181.76
            "Naples", 959574, 117.27
            "Turin", 907563, 130.17
            "Palermo", 655875, 158.9
            "Genoa", 607906, 243.60
            "Bologna", 380181, 140.7
            "Florence", 371282, 102.41
            "Fiumicino", 67370, 213.44
            "Anzio", 52192, 43.43
            "Ciampino", 38262, 11.
        ]

    let options =
        Options(
            region = "IT",
            displayMode = "markers",
            colorAxis = ColorAxis(colors = [|"green"; "blue"|])
        ) 

    let chart =
        data
        |> Chart.Geo
        |> Chart.WithLabels ["Population"; "Area"]
        |> Chart.WithOptions options
        |> Chart.Show


    // Displaying Proportional Markers
    let data' =
        [
            "France", 65700000, 50
            "Germany", 81890000, 27
            "Poland", 38540000, 23
        ]

    let options' =
        Options(
            sizeAxis = SizeAxis(minValue = 0, maxValue = 100),
            region = "155",
            displayMode = "markers",
            colorAxis = ColorAxis(colors = [|"#e7711c"; "#4374e0"|])
        ) 

    let chart3 =
        data'
        |> Chart.Geo
        |> Chart.WithLabels ["Population"; "Area Percentage"]
        |> Chart.WithOptions options'
        |> Chart.Show

    // Text Geochart
    let data'' =
        [
            "South America", 600
            "Canada", 500
            "France", 600
            "Russia", 700
            "Australia", 600
        ]

    let options'' = Options(displayMode = "text")
     
    let chart4 =
        data''
        |> Chart.Geo
        |> Chart.WithLabel "Popularity"
        |> Chart.WithOptions options''
        |> Chart.Show

module Histogram =

    let data =
        [
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

module Line =

    let sales = ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
    
    // single data series
    let chart1 =
        sales
        |> Chart.Line
        |> Chart.Show

    // multiple series
    let chart2 =
        [sales; expenses]
        |> Chart.Line
        |> Chart.WithTitle "Company Performance"
        |> Chart.Show
        
    // spline
    let chart3 =
        let options =
            Options(
                title = "Company Performance",
                curveType = "function",
                legend = Legend(position = "bottom")
            )
        [sales; expenses]
        |> Chart.Line
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.Show
        
module Map =

    let options = Options(showTip = true)

    let chart1 =
        [
            "China", "China: 1,363,800,000"
            "India", "India: 1,242,620,000"
            "US", "US: 317,842,000"
            "Indonesia", "Indonesia: 247,424,598"
            "Brazil", "Brazil: 201,032,714"
            "Pakistan", "Pakistan: 186,134,000"
            "Nigeria", "Nigeria: 173,615,000"
            "Bangladesh", "Bangladesh: 152,518,015"
            "Russia", "Russia: 146,019,512"
            "Japan", "Japan: 127,120,000"
        ]
        |> Chart.Map
        |> Chart.WithOptions options
        |> Chart.Show 
            
    let chart2 =
        [
            37.4232, -122.0853, "Work"
            37.4289, -122.1697, "University"
            37.6153, -122.3900, "Airport"
            37.4422, -122.1731, "Shopping"            
        ]
        |> Chart.Map
        |> Chart.WithOptions options
        |> Chart.Show 
