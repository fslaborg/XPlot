namespace XPlot.Plotly

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Media.Imaging

do ()

//[<AutoOpen>]
//module WpfExtensions = 
//  type XPlot.Plotly.Figure with
//    /// Displays the Figure in a window.
//    member __.Show() =
//        match __.Response with
//        | None -> printfn "Call the Plot member first."
//        | Some resp ->
//            let html =
//                """<html><head></head><body><iframe width="100%" height="100%" frameborder="0" seamless="seamless" scrolling="no" src="""
//                + "\""
//                + resp.url
//                + """.embed?width=900&height=500"></iframe></body></html>"""        
//            ChartWindow.show html
//            let wnd = Window()
//    //        wnd.Icon <- icon
//            wnd.Height <- 600.
//            wnd.Width <- 1000.
//            wnd.Topmost <- true
//            wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
//            let browser = new WebBrowser()
//            let html =
//                """<html><head></head><body><iframe width="500" height="500" frameborder="0" seamless="seamless" scrolling="no" src="""
//                + "\""
//                + resp.url
//                + """.embed?width=500&height=500"></iframe></body></html>"""
//            browser.NavigateToString html
//            wnd.Content <- browser
//            wnd.Show()
//            wnd.Topmost <- false