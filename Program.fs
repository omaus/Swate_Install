let checkParseResult (res : Checks.ParseResult) =
    if res.Success = false 
    then
        printfn "\nSwateCheck was unsuccessful. Press any key to close the app."
        System.Console.ReadKey() |> ignore
        System.Environment.Exit(0)

//let workDir = System.IO.Directory.GetCurrentDirectory()
//let tmpDir = System.IO.Path.GetTempPath()
//let manifestFullPath = System.IO.Path.Combine(tmpDir,"Swate_manifest.xml")


[<EntryPoint>]
let main argv =
    
    printfn "Installing Swate.\nDownloading newest Swate manifest.xml"
    
    printfn "manifest.xml downloaded to %s" manifestFullPath

    printfn "Try getting app version."
    let appVer = Checks.getAppVersion ()
    checkParseResult appVer
    printfn "AppVersion is %s" appVer.Result
    Checks.checkSemVer appVer.Result

    printfn "\nTry getting ontologies."
    let allOntos = Checks.getAllOntologies ()
    checkParseResult allOntos
    let allOntosJsoned = Checks.getOntoList allOntos.Result
    printfn "Ontologies gotten."

    printfn "\nChecking ontologies."
    List.iter Checks.checkOnto allOntosJsoned
    printfn "SwateCheck successful. Press any key to close the app"
    System.Console.ReadKey() |> ignore

    0 // return an integer exit code

System.Diagnostics.Process.Start(@"C:\Users\Mauso\OneDrive\CSB-Stuff\NFDI\ArcCommander\arc.exe",["i";"create"])