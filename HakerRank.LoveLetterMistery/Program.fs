// https://www.hackerrank.com/challenges/the-love-letter-mystery
open System

[<EntryPoint>]
let main args =
    let t = Console.ReadLine() |> int
    
    let operationCount (input:string) =
        let chars = input |> Array.ofSeq
        if chars.Length < 2 then 
            0
        else
            let middleIndex = chars.Length/2 - 1
            let getDiff index =
                let left = int chars.[index]
                let right = int chars.[chars.Length-1-index]
                Math.Abs(left-right)

            [0..middleIndex]
                        |> List.fold (fun acc i -> acc + getDiff i) 0
    
    
    let next() =
        let input = Console.ReadLine()
        let ops = operationCount input
        printfn "%d" ops
    
    [1..t] |> List.iter 
                (fun _ -> next() )
        
    

    0