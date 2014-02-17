open System
open System.Diagnostics
let MonteCarloPi(n : int64) : double =
    let generator = System.Random()

    let square x = x * x
 
    let incircle (x, y) =
        square(x) + square(y) <= 1.0

    let darts = seq { for i in 1L .. n -> (generator.NextDouble(), generator.NextDouble()) } 

    let dartsInCircle = darts |> Seq.filter incircle |> Seq.length
    4.0 * double(dartsInCircle) / double(n)

let SeqMax(n : int64) : int64 =
    let darts = seq { for i in 1L .. n -> i }
    darts |> Seq.max

[<EntryPoint>]
let main argv = 
    let n = int64(argv.[0])
    System.Console.WriteLine("{0} Darts", n)
    let sqr x : double = x * x
    let timer = new System.Diagnostics.Stopwatch()
    timer.Start()
    printfn "Monte Carlo %A" (MonteCarloPi n)
    timer.Stop()
    printfn "Elapsed Time: %i" timer.ElapsedMilliseconds
    timer.Reset();
    timer.Start();
    printfn "SeqMax (to determine overheads of random generation) %A" (SeqMax n)
    printfn "Elapsed Time: %i" timer.ElapsedMilliseconds
    0
