// Learn more about F# at http://fsharp.org

open System
open System.IO
open TinifyAPI

[<EntryPoint>]
let main argv =
    Tinify.Key = ""

    let files = Directory.GetFiles "C://Users//rkvillegas//Downloads//Pictures-20180802T153825Z-001//Pictures//Lima"
    files |> Array.iter (fun t -> async{  Tinify.FromFile t |> Async.AwaitTask })

    printfn "Hello World from F#!"
    Console.ReadLine() |> ignore
    0
