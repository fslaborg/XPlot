#I "../../../bin/XPlot.GoogleCharts/net472"
#r "XPlot.GoogleCharts.dll"

open System
open XPlot.GoogleCharts

let timeline1 =
    [
        "Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
        "Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
        "Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
    ]
    |> Chart.Timeline
    |> Chart.WithLabels ["Start"; "End"]
    |> Chart.Show

let timeline2 =
    [
        "1", "George Washington", DateTime(1789, 4, 29), DateTime(1797, 3, 3)
        "2", "John Adams", DateTime(1797, 3, 3), DateTime(1801, 3, 3) 
        "3", "Thomas Jefferson", DateTime(1801, 3, 3), DateTime(1809, 3, 3)        
    ]
    |> Chart.Timeline
    |> Chart.WithLabels ["Name"; "Start"; "End"]
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
    |> Chart.Timeline
    |> Chart.WithLabels ["Name"; "Start"; "End"]
    |> Chart.WithOptions options
    |> Chart.Show

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
    |> Chart.Timeline
    |> Chart.WithLabels ["Position"; "Name"; "Start"; "End"]
    |> Chart.Show
