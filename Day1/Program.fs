open System
open System.IO

let measurements = File.ReadAllLines "input.txt"
                        |> Seq.map Int32.Parse

                    
let increasesPart1 = fun measurements ->
    measurements
        |> Seq.pairwise
        |> Seq.filter (fun (a,b) -> b > a)
        |> Seq.length

let increasesPart2 = fun measurements ->
    measurements
        |> Seq.windowed 3
        |> Seq.map (fun arr -> arr |> Array.sum)
        |> increasesPart1

printfn "number of increases: %i" (increasesPart1 measurements)
printfn "number of increases: %i" (increasesPart2 measurements)
