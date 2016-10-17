namespace XPlot.D3

open System.IO
open System
open System.Drawing
open System.Text
open Newtonsoft.Json

type Node = {
        Name:string
    }

type Edge = {
    From:Node
    To:Node
}

type Link = {
    source:int
    target:int
}

[<AutoOpen>]
module Configuration = 

    type NodeOptions = {
        Fill: Color
        Stroke: Color
        StrokeWidth:int
        RadiusScale:float
    }

    type NodeStyle = {
            FillHex :string
            StrokeHex:string
            StrokeWidth:string
            RadiusScale:float
        }

    type EdgeOptions = {
        Stroke: Color
        StrokeWidth:int
    }

    type EdgeStyle = {
        StrokeHex: string
        StrokeWidth: string
    }

    type Options = {
        NodeOptions:Node -> NodeOptions
        Gravity:float
    }

    let grey = Color.FromArgb(200,200,200)
    let darkGrey = Color.FromArgb(150,150,150)

    let defaultNodeOptions = 
        {
            RadiusScale = 1.0
            Fill = grey
            Stroke = darkGrey
            StrokeWidth = 2
        }

    let defaultOptions = 
        {
            Gravity = 1.0
            NodeOptions = (fun n -> defaultNodeOptions)
        }

    
