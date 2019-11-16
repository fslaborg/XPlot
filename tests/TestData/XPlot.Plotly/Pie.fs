namespace Pie

open XPlot.Plotly

module Chart1 =
    let js =
        let chart =
            [
                "Work", 11
                "Eat", 2
                "Commute", 2
                "Watch TV", 2
                "Sleep", 7
            ]
            |> Chart.Pie
        chart.GetInlineJS()

// Basic pie chart
module Chart2 =
    let data =
        Pie(
            values = [19; 26; 55],
            labels = ["Residential"; "Non-Residential"; "Utility"]
        )

    let options =
        Options(
            height = 400.,
            width = 500.
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

// Pie chart subplots
module Chart3 =

    let allLabels = ["1st"; "2nd"; "3rd"; "4th"; "5th"]

    let allValues =
        [
            [38; 27; 18; 10; 7];
            [28; 26; 21; 15; 10];
            [38; 19; 16; 14; 13];
            [31; 24; 19; 18; 8]
        ]

    let ultimateColors =
        [
            ["rgb(56, 75, 126)"; "rgb(18, 36, 37)"; "rgb(34, 53, 101)"; "rgb(36, 55, 57)"; "rgb(6, 4, 4)"];
            ["rgb(177, 127, 38)"; "rgb(205, 152, 36)"; "rgb(99, 79, 37)"; "rgb(129, 180, 179)"; "rgb(124, 103, 37)"];
            ["rgb(33, 75, 99)"; "rgb(79, 129, 102)"; "rgb(151, 179, 100)"; "rgb(175, 49, 35)"; "rgb(36, 73, 147)"];
            ["rgb(146, 123, 21)"; "rgb(177, 180, 34)"; "rgb(206, 206, 40)"; "rgb(175, 51, 21)"; "rgb(35; 36, 21)"]
        ]

    let data =
        [
            Pie(
                values = allValues.[0],
                labels = allLabels,
                name = "Starry Night",
                marker = Marker(colors = ultimateColors.[0]),
                domain =
                    Domain(
                        x = [0.; 0.48],
                        y = [0.; 0.49]
                    ),
                hoverinfo = "label+percent+name",
                textinfo = "none")
            Pie(
                values = allValues.[1],
                labels = allLabels,
                name = "Sunflowers",
                marker = Marker(colors = ultimateColors.[1]),
                domain =
                    Domain(
                        x = [0.52; 1.],
                        y = [0.; 0.49]
                    ),
                hoverinfo = "label+percent+name",
                textinfo = "none")
            Pie(
                values = allValues.[2],
                labels = allLabels,
                name = "Irises",
                marker = Marker(colors = ultimateColors.[2]),
                domain =
                    Domain(
                        x = [0.; 0.48],
                        y = [0.51; 1.]
                    ),
                hoverinfo = "label+percent+name",
                textinfo = "none")
            Pie(
                values = allValues.[3],
                labels = allLabels,
                name = "The Night Cafe",
                marker = Marker(colors = ultimateColors.[3]),
                domain =
                    Domain(
                        x = [0.52; 1.],
                        y = [0.52; 1.]
                    ),
                hoverinfo = "label+percent+name",
                textinfo = "none")
        ]

    let options =
        Options(
            height = 400.,
            width = 500.
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()

// Donut chart
module Chart4 =
    let data =
        [
            Pie(
                values = [16; 15; 12; 6; 5; 4; 42],
                labels = ["US"; "China"; "European Union"; "Russian Federation"; "Brazil"; "India"; "Rest of World" ],
                domain = Domain(x = [0.; 0.48]),
                name = "GHG Emissions",
                hoverinfo = "label+percent+name",
                hole = 0.4)
            Pie(
                values = [27; 11; 25; 8; 1; 3; 25],
                labels = ["US"; "China"; "European Union"; "Russian Federation"; "Brazil"; "India"; "Rest of World" ],
                text = "CO2",
                textposition = "inside",
                domain = Domain(x = [0.52; 1.]),
                name = "CO2 Emissions",
                hoverinfo = "label+percent+name",
                hole = 0.4)
        ]

    let options =
        Options(
            title = "Global Emissions 1990-2011",
            annotations =
                [
                    Annotation(
                        font = Font(size = 20.),
                        showarrow = false,
                        text = "GHG",
                        x = 0.17,
                        y = 0.5
                    );
                    Annotation(
                        font = Font(size = 20.),
                        showarrow = false,
                        text = "CO2",
                        x = 0.82,
                        y = 0.5
                    )
                ],
            height = 600.,
            width = 600.
        )

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithOptions options
        chart.GetInlineJS()
