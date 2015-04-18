module XPlot.GoogleCharts

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Media.Imaging

open XPlot.GoogleCharts

[<AutoOpen>]
module WpfExtensions = 
  /// Creates the bitmap frame used to set the chart's window icon.
  let private icon =
      let uriString = @"pack://application:,,,/XPlot.GoogleCharts.WPF;component/XPlot.ico"
      let iconUri = Uri(uriString, UriKind.RelativeOrAbsolute)
      BitmapFrame.Create(iconUri)

  type GoogleChart with
    
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

  type Chart with

      /// Displays the chart in the default browser.    
      static member Show (chart:GoogleChart) =
          chart.Show()
          chart
