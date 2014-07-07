//https://www.hackerrank.com/contests/w6/challenges/minimum-average-waiting-time
open System
open System.Collections.Generic
type Client = {Id:Int64;Time:Int64;CookTime:Int64;Wait:Int64}

(*
Runtime errors on Cases 1 and 2
*)


[<EntryPoint>]
let main argv = 
    
    let n = Console.ReadLine() |> Int64.Parse
    
    let clients = 
        let rec readNext state acc =
            let toClient = fun (arr:Int64[]) -> {Id=state; Time=arr.[0]; CookTime=arr.[1]; Wait=0L}
            match state with
            | 0L -> acc
            | _ -> 
                let client = Console.ReadLine().Split(' ')
                            |> Array.map Int64.Parse
                            |> toClient
                readNext (state-1L) ((client.Id,client)::acc)
        
        
        let cls = readNext n [] |> List.sortBy (fun c -> (snd c).Time) |> dict
        (new Dictionary<Int64,Client>(cls))
                    
        
    
    let rec next tc (cs:Dictionary<Int64,Client>) accTime =
        if cs.Count > 0 then
            let clientsInRange = cs 
                                    |>Seq.takeWhile (fun c -> c.Value.Time <= tc)
                                    |>Seq.sortBy (fun c -> c.Value.CookTime)
                                    |>List.ofSeq
            let nextClient = 
                    match  clientsInRange with
                    | head::tail -> head.Value
                    | [] -> cs 
                            |> Seq.minBy (fun kvp -> kvp.Value.Time, kvp.Value.CookTime)
                            |> fun h -> h.Value

            let newTc = Math.Max(tc, nextClient.Time) + nextClient.CookTime
            let wait = newTc - nextClient.Time 
            
            cs.Remove(nextClient.Id) |> ignore
            next newTc cs accTime+wait
        else
            accTime
        
    let accWait = next 0L clients 0L
    let average = accWait/n
    printfn "%d" average
    0 // return an integer exit code
