#r "../packages/DiffSharp.0.7.7/lib/net46/DiffSharp.dll"

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float32

 let splitList divSize lst =
        let rec splitAcc divSize cont = function
            | [] -> cont([],[])
            | l when divSize = 0 -> cont([], l)
            | h::t -> splitAcc (divSize-1) (fun acc -> cont(h::fst acc, snd acc)) t
        splitAcc divSize (fun x -> x) lst

    // merge two sub-lists
  let merge l r =
        let rec mergeCont cont l r = 
            match l, r with
            | l, [] -> cont l
            | [], r -> cont r
            | hl::tl, hr::tr ->
                if hl<hr then mergeCont (fun acc -> cont(hl::acc)) tl r
                else mergeCont (fun acc -> cont(hr::acc)) l tr
        mergeCont (fun x -> x) l r

    // Sorting via merge
   let mergeSort lst = 
        let rec mergeSortCont lst cont =
            match lst with
            | [] -> cont([])
            | [x] -> cont([x])
            | l -> let left, right = splitList (l.Length/2) l
                   mergeSortCont left  (fun accLeft ->
                   mergeSortCont right (fun accRight -> cont(merge accLeft accRight)))
        mergeSortCont lst (fun x -> x)

    
    let test=[|1.0f;4.0f;3.0f;2.0f;5.0f|]

     let mergesort_d(lst :DV)=
        match lst with
        |DV l->l |> Array.toList |> mergeSort |> List.toArray |> DV               
        |_ -> lst

      let r=mergesort_d(DV test)

       let mergesort_jacobian= jacobian mergesort_d
        let r_jacobian=mergesort_jacobian(DV test)
