open System
open System.IO
open TinifyAPI

type ResizeOption = { method:string; width:int; height:int} 

[<EntryPoint>]
let main argv =

    Tinify.Key <- "A5lM3cfqk5BhU0nGFa0JEjKEQd550JAO"

    let outputPath =  "C://Users//rkvillegas//output//"

    let getFiles (path: string)  =
        Directory.GetDirectories path
        |> Array.collect Directory.GetFiles
        |> Array.append (Directory.GetFiles path)
        |> Array.map (fun file ->
            async {
               let! source = Tinify.FromFile file |> Async.AwaitTask
               let options = { method = "fit"; width = 2408; height = 1365}

               let fileInfo = new FileInfo(file)
               let fullOutPath = Path.Combine(outputPath, fileInfo.Name)

               Console.WriteLine ("Started processing image " +  fileInfo.Name)
               
               let resized = source.Resize options

               resized.ToFile fullOutPath |> Async.AwaitTask |> ignore

               Console.WriteLine ("Finished processing image " + fileInfo.Name)
            })

    printfn "--- Welcome to ResizerFTW Program ---"
    printfn "Just let magic happens"

    let tasks = getFiles "C://Users//rkvillegas//Downloads//Pictures-20180802T153825Z-001//Pictures//"

    tasks
        |> Async.Parallel
        |> Async.RunSynchronously
        |> ignore

    Console.ReadLine() |> ignore
    0