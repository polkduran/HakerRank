open System

[<EntryPoint>]

let main args = 
    let fact n =
        let rec ft i acc =
            if i <= 0 then acc
            else ft (i-1) (acc*i)
        ft n 1
    
    let term x n =
        Math.Pow(x,float n)/(n |> (fact>>float))
    
    let res x =
            [0..9] 
            |> List.map (term x) 
            |> List.reduce (+) 
            |> fun r -> Math.Round(r,4)
    
    let times = Console.ReadLine() |> int
    let rec next current =
        if current > 0 then
            let x = Console.ReadLine() |> float
            let ex = res x
            printfn "%f" ex
            next (current-1)
        else 
            ()
            
    next times
    
    0