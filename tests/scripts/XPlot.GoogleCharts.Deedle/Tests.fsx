#load "../packages/XPlot.GoogleCharts.1.1.3/XPlot.GoogleCharts.fsx"
#load @"C:\Users\AHMED\Documents\GitHub\XPlot\Src\XPlot\packages\Deedle.1.0.6\Deedle.fsx"
//#r """../packages/Deedle.1.0.6/lib/net40/Deedle.dll"""
#r """./bin/Release/XPlot.GoogleCharts.Deedle.dll"""

open Deedle
open XPlot.GoogleCharts
open XPlot.GoogleCharts.Deedle
open System

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

    let chart1 =
        data
        |> Chart.Gauge
        |> Chart.WithOptions options
        |> Chart.Show

    let chart2 =
        ["System" => data]
        |> Frame.ofColumns
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

    let chart1 =
        data
        |> Chart.Histogram
        |> Chart.WithOptions options
        |> Chart.WithLabel "Length"
        |> Chart.Show

    let chart2 =
        ["Lengths of dinosaurs" => data]
        |> Frame.ofColumns
        |> Chart.Histogram
        |> Chart.WithOptions options
        |> Chart.WithLabel "Length"
        |> Chart.Show

module Line =

    let sales = series ["2013", 1000; "2014", 1170; "2015", 660; "2016", 1030]
    let expenses = series ["2013", 400; "2014", 460; "2015", 1120; "2016", 540]
    
    let chart1 =
        sales
        |> Chart.Line
        |> Chart.Show

    let chart2 =
        [sales; expenses]
        |> Chart.Line
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithLabels ["Sales"; "Expenses"]
        |> Chart.WithLegend true
        |> Chart.Show
        
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

    let chart4 =
        ["Sales" => sales; "Expenses" => expenses]
        |> Frame.ofColumns
        |> Chart.Line
        |> Chart.WithTitle "Company Performance"
        |> Chart.WithLegend true
        |> Chart.Show

module Map =

    let options = Options(showTip = true)

    let chart1 =
        series [
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
        |> Chart.WithHeight 420
        |> Chart.Show
    
    type Destination =
        {
            lat : float
            long : float
            name : string
        }

        static member New (l, l', n) =
            {
                lat = l
                long = l'
                name = n
            }

    let chart2 =
        [
            37.4232, -122.0853, "Work"
            37.4289, -122.1697, "University"
            37.6153, -122.3900, "Airport"
            37.4422, -122.1731, "Shopping"            
        ]
        |> List.map Destination.New
        |> Frame.ofRecords
        |> Frame.indexRows "lat"
        |> Chart.Map
        |> Chart.WithOptions options
        |> Chart.Show

module Pie =

    let data =
        series [
            "Work", 11
            "Eat", 2
            "Commute", 2
            "Watch TV", 2
            "Sleep", 7
        ]

    let chart1 =
        data
        |> Chart.Pie
        |> Chart.WithTitle "My Daily Activities"
        |> Chart.WithLegend true
        |> Chart.Show

    let chart2 =
        ["My Daily Activities" => data]
        |> Frame.ofColumns
        |> Chart.Pie
        |> Chart.WithTitle "My Daily Activities"
        |> Chart.WithLegend true
        |> Chart.Show

    let chart3 =
        let options =
            Options(
                title = "My Daily Activities",
                is3D = true
            )
        data
        |> Chart.Pie
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    let chart4 =
        let options =
            Options(
                title = "My Daily Activities",
                pieHole = 0.4
            )
        data
        |> Chart.Pie
        |> Chart.WithOptions options
        |> Chart.WithLegend true
        |> Chart.Show

    let chart5 =
        let options =
            Options(
                pieSliceText = "label",
                title = "Swiss Language Use (100 degree rotation)",
                pieStartAngle = 100
            )
        [
            "German", 5.85
            "French", 1.66
            "Italian", 0.316
            "Romansh", 0.0791        
        ]
        |> series
        |> Chart.Pie
        |> Chart.WithOptions options
        |> Chart.Show

module Sankey =
    
    type Node =
        {
            source : string
            destination : string
            value : int
        }

        static member New (s, d, v) =
            {
                source = s
                destination = d
                value = v
            }

    let diagram1 =
        [
            "A", "X", 5 
            "A", "Y", 7 
            "A", "Z", 6 
            "B", "X", 2 
            "B", "Y", 9 
            "B", "Z", 4
        ]
        |> List.map Node.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "source"
        |> Chart.Sankey
        |> Chart.WithHeight 300
        |> Chart.Show

    let diagram2 =
        let options =
            Options(
                width = 600,
                sankey =
                    Sankey(
                        link =
                            Link(
                                color = Color(fill = "#d799ae")
                            ),
                        node =
                            Node(
                                color = Color(fill = "#a61d4c"),
                                label = Label(color = "#871b47")
                            )
                    )                
            )
        [
            "Brazil", "Portugal", 5 
            "Brazil", "France", 1 
            "Brazil", "Spain", 1 
            "Brazil", "England", 1 
            "Canada", "Portugal", 1 
            "Canada", "France", 5 
            "Canada", "England", 1 
            "Mexico", "Portugal", 1 
            "Mexico", "France", 1 
            "Mexico", "Spain", 5 
            "Mexico", "England", 1 
            "USA", "Portugal", 1 
            "USA", "France", 1 
            "USA", "Spain", 1 
            "USA", "England", 5 
            "Portugal", "Angola", 2 
            "Portugal", "Senegal", 1 
            "Portugal", "Morocco", 1 
            "Portugal", "South Africa", 3 
            "France", "Angola", 1 
            "France", "Senegal", 3 
            "France", "Mali", 3 
            "France", "Morocco", 3 
            "France", "South Africa", 1 
            "Spain", "Senegal", 1 
            "Spain", "Morocco", 3 
            "Spain", "South Africa", 1 
            "England", "Angola", 1 
            "England", "Senegal", 1 
            "England", "Morocco", 2 
            "England", "South Africa", 7 
            "South Africa", "China", 5 
            "South Africa", "India", 1 
            "South Africa", "Japan", 3 
            "Angola", "China", 5 
            "Angola", "India", 1 
            "Angola", "Japan", 3 
            "Senegal", "China", 5 
            "Senegal", "India", 1 
            "Senegal", "Japan", 3 
            "Mali", "China", 5 
            "Mali", "India", 1 
            "Mali", "Japan", 3 
            "Morocco", "China", 5 
            "Morocco", "India", 1 
            "Morocco", "Japan", 3
        ]
        |> List.map Node.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "source"
        |> Chart.Sankey
        |> Chart.WithHeight 300
        |> Chart.WithOptions options
        |> Chart.Show

module Scatter =
    
    let options =
        Options(
            title = "Age vs. Weight comparison",
            hAxis = Axis(title = "Age", minValue = 0, maxValue = 15),
            vAxis = Axis(title = "Weight", minValue = 0, maxValue = 15)
        )

    let chart =
        [8., 12.; 4., 5.5; 11., 14.; 4., 5.; 3., 3.5; 6.5, 7.]
        |> series
        |> Chart.Scatter
        |> Chart.WithOptions options
        |> Chart.Show

module SteppedArea =
    
    let options =
        Options(
            title = "The decline of 'The 39 Steps'",
            vAxis = Axis(title = "Accumulated Rating"),
            isStacked = true
        )

    let rottenTomatoes =
        series [
            "Alfred Hitchcock (1935)", 8.4
            "Ralph Thomas (1959)", 6.9
            "Don Sharp (1978)", 6.5
            "James Hawes (2008)", 4.4        
        ]

    let imdb =
        series [
            "Alfred Hitchcock (1935)", 7.9
            "Ralph Thomas (1959)", 6.5
            "Don Sharp (1978)", 6.4
            "James Hawes (2008)", 6.2        
        ]

    let chart1 =
        rottenTomatoes
        |> Chart.SteppedArea
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Rotten Tomatoes"; "IMDB"]
        |> Chart.WithLegend true
        |> Chart.Show

    let chart2 =
        [rottenTomatoes; imdb]
        |> Chart.SteppedArea
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Rotten Tomatoes"; "IMDB"]
        |> Chart.WithLegend true
        |> Chart.Show

    let chart3 =
        ["Rotten Tomatoes" => rottenTomatoes; "IMDB" => imdb]
        |> Frame.ofColumns
        |> Chart.SteppedArea
        |> Chart.WithOptions options
        |> Chart.WithLabels ["Rotten Tomatoes"; "IMDB"]
        |> Chart.WithLegend true
        |> Chart.Show

module Table =

    let salary =
        [
            "Mike", 10000
            "Jim", 8000
            "Alice", 12500
            "Bob", 7000
        ]
        |> List.map (fun (x, y) -> x, y :> value)
        |> series

    let fulltime =
        [
            "Mike", true
            "Jim", false
            "Alice", true
            "Bob", true
        ]
        |> List.map (fun (x, y) -> x, y :> value)
        |> series
        
    let table1 =
        salary
        |> Chart.Table
        |> Chart.WithOptions(Options(showRowNumber = true))
        |> Chart.WithLabels ["Name"; "Salary"]
        |> Chart.Show

    let table2 =
        [salary; fulltime]  
        |> Chart.Table
        |> Chart.WithOptions(Options(showRowNumber = true))
        |> Chart.WithLabels ["Name"; "Salary"; "Full Time Employee"]
        |> Chart.Show

    let table3 =
        ["Salary" => salary; "Full Time Employee" => fulltime]
        |> Frame.ofColumns
        |> Chart.Table
        |> Chart.WithOptions(Options(showRowNumber = true))
        |> Chart.WithLabels ["Name"; "Salary"; "Full Time Employee"]
        |> Chart.Show

module Timeline =

    type President =
        {
            name : string
            start : DateTime
            ``end`` : DateTime
        }

        static member New (n, s, e) =
            {
                name = n
                start = s
                ``end`` = e
            }

    let timeline1 =
        [
            "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
            "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
            "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
        ]
        |> List.map President.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "name"
        |> Chart.Timeline
        |> Chart.Show

    type PresidentWithIndex =
        {
            index : string
            name : string
            start : DateTime
            ``end`` : DateTime
        }

        static member New (i, n, s, e) =
            {
                index = i
                name = n
                start = s
                ``end`` = e
            }

    let timeline2 =
        [
            "1", "George Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
            "2", "John Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
            "3", "Thomas Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
        ]
        |> List.map PresidentWithIndex.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "index"
        |> Chart.Timeline
        |> Chart.Show

    let timeline3 =
        let options =
            Options(
                timeline = Timeline(showRowLabels = false)
            )
        [
            "1", "George Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
            "2", "John Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
            "3", "Thomas Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
        ]
        |> List.map PresidentWithIndex.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "index"
        |> Chart.Timeline
        |> Chart.WithOptions options
        |> Chart.Show

    type GovOfficer =
        {
            title : string
            name : string
            start : DateTime
            ``end`` : DateTime
        }

        static member New (i, n, s, e) =
            {
                index = i
                name = n
                start = s
                ``end`` = e
            }

    let timeline4 =
        [
            "President", "George Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
            "President", "John Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3)
            "President", "Thomas Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)
            "Vice President", "John Adams", DateTime(1789, 4, 20), DateTime(1797, 3, 3)
            "Vice President", "Thomas Jefferson", DateTime(1797, 3, 3), DateTime(1801, 3, 3)
            "Vice President", "Aaron Burr", DateTime(1801, 3, 3), DateTime(1805, 3, 3)
            "Vice President", "George Clinton", DateTime(1805, 3, 3), DateTime(1812, 4, 19)
            "Secretary of State", "John Jay", DateTime(1789, 9, 25), DateTime(1790, 3, 21)
            "Secretary of State", "Thomas Jefferson", DateTime(1790, 3, 21), DateTime(1793, 12, 30)
            "Secretary of State", "Edmund Randolph", DateTime(1794, 1, 1), DateTime(1795, 8, 19)
            "Secretary of State", "Timothy Pickering", DateTime(1795, 8, 19), DateTime(1800, 5, 11)
            "Secretary of State", "Charles Lee", DateTime(1800, 5, 12), DateTime(1800, 6, 4)
            "Secretary of State", "John Marshall", DateTime(1800, 6, 12), DateTime(1801, 3, 3)
            "Secretary of State", "Levi Lincoln", DateTime(1801, 3, 4), DateTime(1801, 5, 1)
            "Secretary of State", "James Madison", DateTime(1801, 5, 1), DateTime(1809, 3, 2)
        ]
        |> List.map GovOfficer.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "index"
        |> Chart.Timeline
        |> Chart.WithLabels ["Position"; "Name"; "Start"; "End"]
        |> Chart.Show

module Treemap =

    type Market =
        {
            location : string
            parent : string
            volume : int
        }
        
        static member New (l, p, v) =
            {
                location = l
                parent = p
                volume = v
            }

    let treemap1 =
        let data =
            [
                "Global", "", 0
                "America", "Global", 0
                "Europe", "Global", 0
                "Asia", "Global", 0
                "Australia", "Global", 0
                "Africa", "Global", 0
                "Brazil", "America", 11
                "USA", "America", 52
                "Mexico", "America", 24
                "Canada", "America", 16
                "France", "Europe", 42
                "Germany", "Europe", 31
                "Sweden", "Europe", 22
                "Italy", "Europe", 17
                "UK", "Europe", 21
                "China", "Asia", 36
                "Japan", "Asia", 20
                "India", "Asia", 40
                "Laos", "Asia", 4
                "Mongolia", "Asia", 1
                "Israel", "Asia", 12
                "Iran", "Asia", 18
                "Pakistan", "Asia", 11
                "Egypt", "Africa", 21
                "S. Africa", "Africa", 30
                "Sudan", "Africa", 12
                "Congo", "Africa", 10
                "Zaire", "Africa", 8
            ]

        let options =
            Options(
                minColor = "#f00",
                midColor = "#ddd",
                maxColor = "#0d0",
                headerHeight = 15,
                fontColor = "black",
                showScale = true        
            )

        data
        |> List.map Market.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "location"
        |> Chart.Treemap
        |> Chart.WithLabels  ["Location"; "Parent"; "Market trade volume (size)"]
        |> Chart.WithOptions options
        |> Chart.Show

    type MarketWithTrend =
        {
            location : string
            parent : string
            volume : int
            trend : int
        }
        
        static member New (l, p, v, t) =
            {
                location = l
                parent = p
                volume = v
                trend = t
            }

    let treemap2 =
        let data =
            [
                "Global", "", 0, 0
                "America", "Global", 0, 0
                "Europe", "Global", 0, 0
                "Asia", "Global", 0, 0
                "Australia", "Global", 0, 0
                "Africa", "Global", 0, 0
                "Brazil", "America", 11, 10
                "USA", "America", 52, 31
                "Mexico", "America", 24, 12
                "Canada", "America", 16, -23
                "France", "Europe", 42, -11
                "Germany", "Europe", 31, -2
                "Sweden", "Europe", 22, -13
                "Italy", "Europe", 17, 4
                "UK", "Europe", 21, -5
                "China", "Asia", 36, 4
                "Japan", "Asia", 20, -12
                "India", "Asia", 40, 63
                "Laos", "Asia", 4, 34
                "Mongolia", "Asia", 1, -5
                "Israel", "Asia", 12, 24
                "Iran", "Asia", 18, 13
                "Pakistan", "Asia", 11, -52
                "Egypt", "Africa", 21, 0
                "S. Africa", "Africa", 30, 43
                "Sudan", "Africa", 12, 2
                "Congo", "Africa", 10, 12
                "Zaire", "Africa", 8, 10
            ]

        let options =
            Options(
                minColor = "#f00",
                midColor = "#ddd",
                maxColor = "#0d0",
                headerHeight = 15,
                fontColor = "black",
                showScale = true        
            )

        data
        |> List.map MarketWithTrend.New
        |> Frame.ofRecords
        |> Frame.indexRowsString "location"
        |> Chart.Treemap
        |> Chart.WithLabels  ["Location"; "Parent"; "Market trade volume (size)"; "Market increase/decrease (color)"]
        |> Chart.WithOptions options
        |> Chart.Show