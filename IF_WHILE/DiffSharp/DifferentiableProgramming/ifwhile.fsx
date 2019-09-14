#r "../packages/DiffSharp.0.7.7/lib/net46/DiffSharp.dll"

open FSharp
open DiffSharp.AD
open DiffSharp.AD.Float32

module DiffProgram=

    let zero=D.Zero
    
    let f (x :D)=
        if(x= D.Zero)
            then -x 
            else x   
    
 
    let df=diff f    
    
    let df0=df(D 0.0f)
    
    let rec fib(x :D)=
        if(x<=D 1.0f)
        then D 1.0f
        else fib(x-D 1.0f)+ fib(x-D 2.0f)
    
    fib(D 5.0f)

    
    let fib_dif=diff fib

    let rrr=fib_dif(D 6.0f)


    let rec factorial(x :D)=
        if(x<=D 1.0f)
        then D 1.0f
        else x*factorial(x- D 1.0f)

    let ff=factorial(D 6.0f)

    let factorial_diff=diff factorial
    let fff=factorial_diff(D 6.0f)

    let factorial_tail(x :D)=
        let rec fact(x :D, acc :D)=
            if(x<=D 1.0f)
            then acc
            else fact(x- D 1.0f,x*acc)
        fact(x,D 1.0f )

    let ff_tail=factorial_tail(D 6.0f)

    let factorial_tail_diff=diff factorial_tail
    let fff_tail=factorial_tail_diff(D 6.0f)    



    

    

    


