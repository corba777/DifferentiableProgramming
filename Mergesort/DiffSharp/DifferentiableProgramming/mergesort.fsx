#r "../packages/DiffSharp.0.7.7/lib/net46/DiffSharp.dll"

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float64

let mergesort (arr :DV)=     
    let split (arr : D list) =
        let n = arr.Length
        arr.[0..n/2-1], arr.[n/2..n-1] 

    let rec merge l r =   
        match l, r with
            | a :: ls, b :: rs ->
                if a > b
                then b :: merge l rs
                else a :: merge ls r
            | [], r -> r
            | l, [] -> l 
            
    let rec mergeSort (arr :D list) =
        if arr.Length < 2 then arr else       
        let (x, y) = split arr
        merge (mergeSort x) (mergeSort y) 
        
    let lst= arr.ToArray() |> Array.toList
    mergeSort lst |> List.toArray |> toDV

let rnd=System.Random()
let test= Array.init 5 (fun _-> rnd.NextDouble()) |> toDV

mergesort test

let jacobianmergesort=jacobian mergesort
jacobianmergesort test


