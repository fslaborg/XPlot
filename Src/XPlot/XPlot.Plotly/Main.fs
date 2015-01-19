namespace XPlot.Plotly

open Newtonsoft.Json
open HttpClient
open System.Windows
open System.Windows.Controls

type Trace() =
    let mutable xField : seq<string> option = None
    let mutable yField : seq<int> option = None

    member __.x
        with get() = xField.Value
        and set(value) = xField <- Some value

    member __.y
        with get() = yField.Value
        and set(value) = yField <- Some value

type Bar() =
    inherit Trace()
    
    member __.``type`` = "bar"       


type Data(traces:seq<Trace>) =

    member __.Json = JsonConvert.SerializeObject traces

type PlotlyResponse =
    {
        filename: string
        url: string
        error: string
        warning: string
        message: string
    }

type Credentials private () =

    static let mutable _username : string option = None
    static let mutable _key : string option = None

    /// The directory containing ChromeDriver.exe.
    static member username
        with get () = Option.get _username
        and set dir = _username <- Some dir

    /// The directory containing PhantomJS.exe.
    static member key
        with get () = Option.get _key
        and set dir = _key <- Some dir

type Plotly private () =

    static member Signin(username, password) =
        Credentials.username <- username
        Credentials.key <- password
   
type Kwargs =
    {
        filename: string
        fileopt: string
    }

    static member New filename fileopt =
        {
            filename = filename
            fileopt = fileopt
        }

    member this.Json() = JsonConvert.SerializeObject this

type Figure(data:Data, filename:string) =
    
    let mutable response = None //: PlotlyResponse option
    let mutable origin = "plot"
    let mutable fileopt = "new"

    member __.Origin
        with get () = origin
        and set(value) = origin <- value

    member __.Fileopt
        with get () = fileopt
        and set(value) = fileopt <- value

    member __.Plot() =
        let kwargs = Kwargs.New filename fileopt
        let body =
            [
                "un="
                Credentials.username
                "&key="
                Credentials.key
                "&origin="
                origin
                "&platform=f#&args="
                data.Json
                "&kwargs="
                kwargs.Json()
            ] |> String.concat ""
        let request =  
            createRequest Post "https://plot.ly/clientresp"  
            |> withBody body
        let resp = request |> getResponse
        match resp.EntityBody with
        | None -> None
        | Some x ->
            let resp =
                JsonConvert.DeserializeObject(x, typeof<PlotlyResponse>)
                :?> PlotlyResponse
            match resp.error with
            | "" ->
                response <- Some resp
                Some response
            | msg ->
                printfn "%s" msg
                None

    /// Displays the Figure in a window.
    member __.Show() =
        match response with
        | None -> printfn "Call the Plot member first."
        | Some resp ->
            let wnd = Window()
    //        wnd.Icon <- icon
            wnd.Height <- 600.
            wnd.Width <- 1000.
            wnd.Topmost <- true
            wnd.WindowStartupLocation <- WindowStartupLocation.CenterScreen 
            let browser = new WebBrowser()
            let html =
                """<html><head></head><body><iframe width="500" height="500" frameborder="0" seamless="seamless" scrolling="no" src="""
                + "\""
                + resp.url
                + """.embed?width=500&height=500"></iframe></body></html>"""
            browser.NavigateToString html
            wnd.Content <- browser
            wnd.Show()
            wnd.Topmost <- false