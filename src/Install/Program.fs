open Checks

let checkParseResult (res : Checks.ParseResult<'a>) =
    if res.Success = false 
    then
        printfn "\nSwateCheck was unsuccessful. Press any key to close the app."
        System.Console.ReadKey() |> ignore
        System.Environment.Exit(0)


[<EntryPoint>]
let main argv =
    Console.info "Installing Swate."

    // Download part
    Install.downloadMain ()
    
    // Install part
    Install.installMain ()

    // Check part
    Console.info "Check connectivity."

    let appVer = Checks.getAppVersion ()
    checkParseResult appVer
    Checks.checkSemVer appVer.Result

    let allOntos = Checks.getAllOntologies ()
    checkParseResult allOntos
    let allOntosJsoned = Checks.getOntoList allOntos.Result
    
    List.iter Checks.checkOnto allOntosJsoned
    Console.ok "SwateCheck successful."

    Console.ok "Swate is installed and can be accessed, after an Excel restart. Press any key to close the app"
    System.Console.ReadKey() |> ignore

    0 // return an integer exit code