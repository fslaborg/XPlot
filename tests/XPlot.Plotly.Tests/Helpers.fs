namespace Testing

open System.Text.RegularExpressions

module Helpers =
    let cleanJS (js: string) =
        let noWS = Regex.Replace(js, @"\s+", "")
        Regex.Replace(noWS, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}", "")