open System.Text.RegularExpressions
open System
open System.IO

let measurements = File.ReadAllLines "input.txt"

let navigation = {|horizontal=0;depth =0; |}

let (|ParseMovement|_|) regex str =
   let m = Regex(regex).Match(str)
   if m.Success
   then Some (m.Groups[1].Value |> Int32.Parse)
   else None


let calculate measurements =
    measurements 
    |> Seq.fold 
        (fun state movement -> 
            match  movement with
                | ParseMovement "up (\d+)" up -> {|horizontal=state.horizontal; depth=state.depth - up |}
                | ParseMovement "down (\d+)" down -> {|horizontal=state.horizontal; depth=state.depth + down |}
                | ParseMovement "forward (\d+)" forward -> {|horizontal=state.horizontal + forward; depth=state.depth |}
                | _ -> state
        ) navigation
    |> fun nav -> nav.horizontal * nav.depth

printfn "depth * horizonatl: %i" (calculate measurements)


let navigation2 = {|horizontal=0;depth =0;aim=0 |}

let calculate2 measurements =
    measurements 
    |> Seq.fold 
        (fun state movement -> 
            match  movement with
                | ParseMovement "up (\d+)" up -> {|horizontal=state.horizontal; depth=state.depth;aim=state.aim - up |}
                | ParseMovement "down (\d+)" down -> {|horizontal=state.horizontal; depth=state.depth; aim= state.aim + down |}
                | ParseMovement "forward (\d+)" forward -> {|horizontal=state.horizontal + forward; depth=state.depth + (state.aim * forward) ;aim=state.aim |}
                | _ -> state
        ) navigation2
    |> fun nav -> nav.horizontal * nav.depth

printfn "depth * horizonatl: %i" (calculate2 measurements)
 
 
 


