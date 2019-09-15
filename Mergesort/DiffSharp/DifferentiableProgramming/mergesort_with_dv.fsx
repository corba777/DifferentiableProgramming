#r "../packages/DiffSharp.0.7.7/lib/net46/DiffSharp.dll"

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float32


let split (arr : DV) =
    let n = arr.Length
    arr.[0..n/2-1], arr.[n/2..n-1]
 
let rec merge (l : DV) (r : DV) =
    let n = l.Length + r.Length
    let res = Array.zeroCreate<D> n
    let mutable i, j = 0, 0
    for k = 0 to n-1 do
        if i >= l.Length   then res.[k] <- r.[j]; j <- j + 1
        elif j >= r.Length then res.[k] <- l.[i]; i <- i + 1
        elif l.[i] < r.[j] then res.[k] <- l.[i]; i <- i + 1
        else res.[k] <- r.[j]; j <- j + 1
    toDV res
        
let rec mergeSort (arr :DV) =
    if arr.Length<2 then arr else       
    let (x, y) = split arr
    merge (mergeSort x) (mergeSort y)
   
let test =DV [|5.0f; 4.0f;3.0f;2.0f;1.0f|]
let res=mergeSort(test)

let jacobianmergesort=jacobian mergeSort
let rr=jacobianmergesort test
rr
