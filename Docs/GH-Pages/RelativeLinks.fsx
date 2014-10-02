(*
Converts the website's relative links into absolute
ones using the project's URL on GitHub.
*)

open System.IO
open System.Text.RegularExpressions

let linkPattern = "(href|src)=\"(.+?)\""
let projectUrl = "http://tahahachana.github.io/FsPlot/"
let path = Path.Combine(__SOURCE_DIRECTORY__, "bin\html")

let updateLinks html =
    Regex.Replace(html, linkPattern, fun (matchObj:Match) ->
        let link = matchObj.Groups.[2].Value
        match link.StartsWith("http") with
        | false ->
            Regex.Replace(link, "^\.*/", "")
            |> fun x -> matchObj.Groups.[1].Value + "=\"" + projectUrl + x + "\""
        | true -> matchObj.Groups.[1].Value + "=\"" + link + "\""
    )

Directory.EnumerateFiles(path, "*.html", SearchOption.AllDirectories)
|> Seq.toList
|> List.filter (fun x -> x.Contains "/iframe/" = false)
|> List.iter (fun x ->
    File.ReadAllText x
    |> updateLinks
    |> fun html -> File.WriteAllText(x, html)
)

Directory.EnumerateFiles(path, "*.html", SearchOption.AllDirectories)
|> Seq.toList
|> List.map (fun x ->
    File.ReadAllText x
    |> Regex(linkPattern).Matches
    |> Seq.cast<Match>
    |> Seq.toList
    |> List.map (fun m -> m.Groups.[2].Value)  
    |> List.filter (fun x -> x.Contains projectUrl)
)
|> List.concat
|> List.iter(fun x -> printfn "%s" x)

