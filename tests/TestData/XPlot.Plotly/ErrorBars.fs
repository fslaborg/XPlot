namespace ErrorBars

open XPlot.Plotly
open MathNet.Numerics

module BasicSymmetricErrorBars =
    let trace =
        Scatter(
            x = [0; 1; 2],
            y = [6; 10; 2],
            error_y =
                Error_y(
                    ``type`` = "data",
                    array = [1; 2; 3],
                    visible = true
                )
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Basic Symmetric Error Bars Test"
        chart.GetInlineJS()

module BarChartErrorBars =
    let trace1 =
        Bar(
            x = ["Trial 1"; "Trial 2"; "Trial 3"],
            y = [3; 6; 4],
            name = "Control",
            error_y=
                Error_y(
                    ``type`` = "data",
                    array = [1.0; 0.5; 1.5],
                    visible = true
                )
        )

    let trace2 =
        Bar(
            x = ["Trial 1"; "Trial 2"; "Trial 3"],
            y = [4; 7; 3],
            name = "Experimental",
            error_y =
                Error_y(
                    ``type`` = "data",
                    array = [0.5; 1.0; 2.0],
                    visible = true
                )
        )

    let options = Options(barmode = "group", title = "Bar Chart with Error Bars Test")

    let js =
        let chart =
            [trace1; trace2]
            |> Chart.Plot
            |> Chart.WithOptions options

        chart.GetInlineJS()

module HorizontalErrorBars =
    let trace =
        Scatter(
            x = [1; 2; 3; 4],
            y=[2; 1; 3; 4],
            error_x =
                Error_x(
                    ``type`` = "percent",
                    value = 10.0
                )
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Horizontal Error Bars Test"
        chart.GetInlineJS()

module AsymmetricErrorBars =
    let trace =
        Scatter(
            x = [1; 2; 3; 4],
            y = [2; 1; 3; 4],
            error_y =
                Error_y(
                    ``type`` = "data",
                    symmetric = false,
                    array = [0.1; 0.2; 0.1; 0.1],
                    arrayminus = [0.2; 0.4; 1.0; 0.2]
                )
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Asymmetric Error Bars Test"
        chart.GetInlineJS()

// Not under test due to randomness
module ColoredStyledErrorBars =

    let x_theo = Generate.LinearSpaced(100, -4., 4.) // np.linspace(-4, 4, 100)
    let sincx =  Array.map Trig.Sinc x_theo

    let x = [-3.8; -3.03; -1.91; -1.46; -0.89; -0.24; -0.0; 0.41; 0.89; 1.01; 1.91; 2.28; 2.79; 3.56]
    let y = [-0.02; 0.04; -0.01; -0.27; 0.36; 0.75; 1.03; 0.65; 0.28; 0.02; -0.11; 0.16; 0.04; -0.15]

    let trace1 =
        Scatter(
            x = x_theo,
            y = sincx,
            name = "sinc(x)"
        )

    let trace2 =
        Scatter(
            x = x,
            y = y,
            mode = "markers",
            name = "measured",
            error_y=
                Error_y(
                    ``type`` = "constant",
                    value = 0.1,
                    color = "#85144B",
                    thickness = 1.5,
                    width = 3.
                ),
            error_x =
                Error_x(
                    ``type`` = "constant",
                    value = 0.2,
                    color = "#85144B",
                    thickness = 1.5,
                    width = 3.
                ),
            marker =
                Marker(
                    color = "#85144B",
                    size = 8.
                )
        )

    let data = [trace1; trace2]

    let js =
        let chart =
            data
            |> Chart.Plot
            |> Chart.WithTitle "Colored and Styled Error Bars Test"
        chart.GetInlineJS()

module ErrorBarsPercentageYValue =

    let trace =
        Scatter(
            x = [0; 1; 2],
            y = [6; 10; 2],
            error_y =
                Error_y(
                    ``type`` = "percent",
                    value = 50.,
                    visible = true
                )
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Error Bars as a Percentage of the y-Value Test"
        chart.GetInlineJS()

module AsymmetricErrorBarsConstantOffset =

    let trace =
        Scatter(
            x = [1; 2; 3; 4],
            y = [2; 1; 3; 4],
            error_y =
                Error_y(
                    ``type`` = "percent",
                    symmetric = false,
                    value = 15.,
                    valueminus = 25.
                )
        )

    let js =
        let chart =
            trace
            |> Chart.Plot
            |> Chart.WithTitle "Asymmetric Error Bars with a Constant Offset Test"
        chart.GetInlineJS()
