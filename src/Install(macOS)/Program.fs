open System.Runtime.InteropServices
open Checks

let checkParseResult (res : Checks.ParseResult<'a>) =
    if res.Success = false 
    then
        printfn "\nSwateCheck was unsuccessful. Press any key to close the app."
        System.Console.ReadKey() |> ignore
        System.Environment.Exit(0)

[<EntryPoint>]
let main argv =

    // Check if correct OS
    let rt = RuntimeInformation.RuntimeIdentifier
    if RuntimeInformation.IsOSPlatform OSPlatform.OSX |> not then
        printfn "OS is %s" rt;
        failwith "ERROR: This installer only works on macOS." 

    Console.info "Download Manifest file."
    Download.downloadManifest ()
    Console.ok "Manifest downloaded successfully."

    // Checks
    Console.info "Check connectivity."

    let appVer = getAppVersion ()
    checkParseResult appVer
    checkSemVer appVer.Result

    let allOntos = Checks.getAllOntologies ()
    checkParseResult allOntos
    let allOntosJsoned = Checks.getOntoList allOntos.Result
    
    List.iter Checks.checkOnto allOntosJsoned
    Console.ok "SwateCheck successful."

    Console.ok "Swate is installed and can be accessed, after an Excel restart. Press any key to close the app"
    System.Console.ReadKey() |> ignore

    // Return an integer exit code
    0