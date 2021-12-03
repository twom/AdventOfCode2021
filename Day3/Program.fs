open System
open System.IO

let powerconsumption = File.ReadAllLines "input.txt"
                            |> Seq.map Seq.toList
                       

let map = []
let length = Seq.length powerconsumption

let calculate powerconsumption =
    powerconsumption
        |> Seq.fold (fun state el ->
                    let validatedState =
                        match (List.length state) with
                        | a when (List.length el) = a -> state
                        | b when b = 0 -> List.init (List.length el) (fun v -> 0)
                        | _ -> state
                    el
                    |> List.mapi (fun i num -> validatedState[i] + ((System.Char.GetNumericValue num) |> int) )
                   ) map
        |> List.map (fun el ->
                        match el with
                          | a when a |> int > length/2 -> ("1","0")
                          | a when a |> int < length/2 -> ("0","1")
                     )
        |> List.unzip
        |> (fun (a, b) ->
               let gamaRateBinary = a |> String.Concat
               let epsilonRateBinary = b |> String.Concat
               Convert.ToInt32(gamaRateBinary, 2) * Convert.ToInt32(epsilonRateBinary, 2)
           )
        
        
printfn "Power consumption: %i" (calculate powerconsumption)
                       