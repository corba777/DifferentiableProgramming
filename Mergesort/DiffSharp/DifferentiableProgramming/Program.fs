// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float32


[<EntryPoint>]
let main argv = 
    printfn "%A" argv    
    let zero=D.Zero
    let f (x :D)= 
        if(x= D 0.0f)
        then -x
        else x    

    let df=diff f
    
     

    let dfv= df(D 0.0f)           
    

    let df0=df(D 0.0f)
    
    

    //------------------------------------------------------------------------------------------------------------//
    
   





    0 // return an integer exit code
