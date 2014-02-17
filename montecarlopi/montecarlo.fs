open System
open System.Diagnostics

let MonteCarloPi(n : int64) : double =
    let generator = System.Random()

    let square x = x * x
 
    let incircle (x, y) =
        square(x) + square(y) <= 1.0

    let darts = seq { for i in 1L .. n -> (generator.NextDouble(), generator.NextDouble()) }

    let dartsInCircle = Seq.filter incircle darts
    4.0 * double(Seq.length dartsInCircle) / double(Seq.length darts)

[<EntryPoint>]
let main argv = 
    let n = int64(argv.[0])
    Console.WriteLine("{0} Darts", n)
    let sqr x : double = x * x
    let timer = new System.Diagnostics.Stopwatch()
    timer.Start()
    printfn "Monte Carlo %A" (MonteCarloPi n)
    printfn "Elapsed Time: %i" timer.ElapsedMilliseconds
    0


