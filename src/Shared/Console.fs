module Console 

//http://www.fssnip.net/7Vy/title/Supersimple-thread-safe-colored-console-output 

open System

let log =
    let lockObj = obj()
    fun color s ->
        lock lockObj (fun _ ->
            Console.ForegroundColor <- color
            printfn "%s" s
            Console.ResetColor())

let ok = log ConsoleColor.Green
let info = log ConsoleColor.Cyan
let warn = log ConsoleColor.Yellow
let error = log ConsoleColor.Red