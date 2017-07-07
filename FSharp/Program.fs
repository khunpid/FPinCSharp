// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let fibs = Seq.unfold (fun (m,n) -> Some (m, (n,n+m))) (0I,1I)  


(*
   fibs = 0 : 1 : zipWith (+) (fibs) (tail (fibs))
 *)

let rec fibs2 =
   seq {
       yield 0I
       yield 1I
       for (a, b) in Seq.zip fibs2 (Seq.skip 1 fibs2) do
           yield a + b
   }
   |> Seq.cache


let seqNumber = Seq.initInfinite(fun x -> x)

let indexFib = Seq.zip seqNumber fibs

let rec ConvertToString list =
   match list with
   | [l] -> l.ToString()
   | head :: tail -> head.ToString() + " " + ConvertToString tail
   | [] -> ""

let tento999 = 10I ** 999

[<EntryPoint>]
let main argv = 
    let listString = Seq.take 50 fibs |> Seq.toList |> ConvertToString
    printfn "%A" listString
    printfn ""
    //let theFib = Seq.takeWhile (fun elem -> elem < tento1000) indexFibs |> Seq.length 
    //printfn "%A" theFib
    let theFib = Seq.filter(fun (a, b) -> b >= tento999) indexFib |> Seq.head
    let theFib2 = Seq.filter(fun (a, b) -> b < 10I) indexFib
    printfn "%A" theFib
    printfn "%A" theFib2

    0 // return an integer exit code
