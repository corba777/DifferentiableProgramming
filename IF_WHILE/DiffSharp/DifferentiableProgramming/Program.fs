// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float32
open DiffSharp.AD.Float32


[<EntryPoint>]
let main argv = 
       

    let rec sum (x :D)=
        if x < D 1.0f then D 0.0f
        else x + sum(x- D 1.0f)
    
    let s=sum(D 6.0f)

    let diff_sum= diff sum
    let ds=diff_sum (D 6.0f)

    let dss=ds.ToString()

    printfn "%s" dss
    
    let sum1 (x:D)=
        let mutable i=D 0.0f
        let mutable sum=D 0.0f

        while i<=x do
            sum<-sum+i
            i<-i+D 1.0f

        sum
    let s1=sum1(D 6.0f)

    let diff_sum1=diff sum1

    let ds1=diff_sum1(D 6.0f)

    let dss1=ds1.ToString()

    printfn "%s" dss1

    let sum2 (x:D)=
        let mutable i=D 0.0f
        let mutable sum=D 0.0f

        while i<=x do
            sum<-sum+x-i
            i<-i+D 1.0f

        sum
    let s2=sum2(D 6.0f)

    let diff_sum2=diff sum2

    let ds2=diff_sum2(D 6.0f)

    let dss2=ds2.ToString()

    printfn "%s" dss2
        
  
    
   





    0 // return an integer exit code
