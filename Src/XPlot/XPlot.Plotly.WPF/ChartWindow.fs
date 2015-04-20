module XPlot.Plotly.ChartWindow

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Media.Imaging

let private icon =
    let uriString = @"pack://application:,,,/XPlot.Plotly.WPF;component/XPlot.ico"
    let iconUri = Uri(uriString, UriKind.RelativeOrAbsolute)
    BitmapFrame.Create(iconUri)

let show html =
    let wnd = Window()
    wnd.Icon <- icon
    wnd.Height <- 600.
    wnd.Width <- 1000.
    wnd.Topmost <- true
    wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
    let browser = new WebBrowser()
    browser.NavigateToString html
    wnd.Content <- browser
    wnd.Show()
    wnd.Topmost <- false
