module Install

open System
open System.IO
open Url

[<Literal>]
let UninstallerUrl = @"https://raw.githubusercontent.com/omaus/Swate_Install/master/uninstall.cmd"

module Paths = 

    let getXdgHomeConfig () =
        let appDataRoaming = Environment.SpecialFolder.ApplicationData
        Environment.GetFolderPath(appDataRoaming, Environment.SpecialFolderOption.DoNotVerify)
    let getConfigPath () = Path.Combine(getXdgHomeConfig (), "DataPANT", "Swate")
    let getSideloaderZipPath () = Path.Combine(getConfigPath (), "Set-WebAddin.zip")
    let getSideloaderPath () = Path.Combine(getConfigPath (), "Set-WebAddin.exe")
    let getManifestPath () = Path.Combine(getConfigPath (), "manifest.xml")
    let getUninstallerPath () = Path.Combine(getConfigPath (), "uninstall.cmd")
    let createConfigFolder () = Directory.CreateDirectory (getConfigPath ())

module Download =

    open Paths

    let webCl = new System.Net.WebClient()

    let downloadSideLoader() = webCl.DownloadFile(SideloaderUrl, getSideloaderZipPath ())

    let downloadManifestXml() = webCl.DownloadFile(ManifestUrl, getManifestPath ())

    let downloadUninstaller() = webCl.DownloadFile(UninstallerUrl, getUninstallerPath ())


module Unzip =
    
    open System.IO
    open System.IO.Compression
    open System.Reflection
    open System

    let unzipFile (zipArchivePath : string) (targetDir : string) =
        ZipFile.ExtractToDirectory(zipArchivePath, targetDir)

/// works in .fsx scripting (maybe due to FSI not closing?) but not compiled -> TO DO!
//module internal TestInstall =

//    open System
//    open System.Diagnostics
    
//    // Use this snippet to run process to check for possible errors, without much time effort.
//    let runProc filename args startDir = 
//        let procStartInfo = 
//            ProcessStartInfo(
//                RedirectStandardOutput = true,
//                RedirectStandardError = true,
//                UseShellExecute = false,
//                FileName = filename,
//                Arguments = args
//            )
//        match startDir with | Some d -> procStartInfo.WorkingDirectory <- d | _ -> ()
    
//        let outputs = System.Collections.Generic.List<string>()
//        let errors = System.Collections.Generic.List<string>()
//        let outputHandler f (_sender:obj) (args:DataReceivedEventArgs) = f args.Data
//        let p = new Process(StartInfo = procStartInfo)
//        p.OutputDataReceived.AddHandler(DataReceivedEventHandler (outputHandler outputs.Add))
//        p.ErrorDataReceived.AddHandler(DataReceivedEventHandler (outputHandler errors.Add))
//        let started = 
//            try
//                p.Start()
//            with | ex ->
//                ex.Data.Add("filename", filename)
//                reraise()
//        if not started then
//            failwithf "Failed to start process %s" filename
//        printfn "Started %s with pid %i" p.ProcessName p.Id
//        p.BeginOutputReadLine()
//        p.BeginErrorReadLine()
//        let cleanOut l = l |> Seq.filter (fun o -> String.IsNullOrEmpty o |> not)
//        let tmp = cleanOut outputs//, cleanOut errors
//        p.WaitForExit()
//        //p.Dispose()
//        tmp
    

module SideloaderCommands =

    open System.Diagnostics

    // commented due to TestInstall not running atm.
    //// returns true if correctly installed
    //let testSideloadInstall() = 
    //    let errorMsg = "The process DID NOT complete successfully."
    //    let c = TestInstall.runProc (Paths.sideloaderPath()) "-help" None
    //    Seq.contains errorMsg c |> not

    let installSwateTest() =
        Process.Start(Paths.getSideloaderPath (), ["-test"; "-manifestPath"; Paths.getManifestPath ()])

    let installSwateFull() =
        let getInstallPath () = Path.Combine(Paths.getConfigPath (), "sideloaderData")
        Directory.CreateDirectory(getInstallPath ()) |> ignore
        Process.Start(Paths.getSideloaderPath (), ["-install"; "-manifestPath"; Paths.getManifestPath (); "-installPath"; getInstallPath ()])

    let removeSwateTest() =
        Process.Start(Paths.getSideloaderPath (), ["-cleanup"; "-manifestPath"; Paths.getManifestPath ()])

    let removeSwateFull() =
        // manifestPaths könnte failen, weil nicht das Gleiche weil manifestPath ≠ installedManifestFullname (gilt auch für die Uninstaller!)
        Process.Start(Paths.getSideloaderPath (), ["-uninstall"; "-installedManifestFullname"; Paths.getManifestPath ()])

open Console

let downloadMain() =

    // create config folder if not existing
    let createConfigFolder = Paths.createConfigFolder ()

    printfn "Clean configs."
    let cleanFolder = 
        let files = System.IO.Directory.GetFiles (Paths.getConfigPath ())
        files |> Array.iter System.IO.File.Delete

    Console.info "Download and unzip required utilities."

    let downloadSideLoader = Download.downloadSideLoader ()
    Console.info "Download Sideloader done!"
    /// Unzip downloaded sideloader zip file
    let unzip = Unzip.unzipFile (Paths.getSideloaderZipPath ()) (Paths.getConfigPath ())
    /// Delete downloaded sideloader zip file
    let cleanUp = System.IO.File.Delete (Paths.getSideloaderZipPath ())

    let downloadManifestXml = Download.downloadManifestXml ()
    Console.info "Download Manifest.xml done!"

    let downloaderUninstaller = Download.downloadUninstaller ()
    Console.info "Download Uninstaller done!"

    Console.ok "Finished downloading utilities."


let installMain() =
    
    Console.info "Check Sideloader status."

    // commented due to TestInstall not running atm.
    //match SideloaderCommands.testSideloadInstall() with
    //| true -> Console.ok <| "Sideloader ready to use."
    //| false -> Console.error <| "Sideloader failed to start."

    let installSwate = 
        //SideloaderCommands.installSwateTest()
        SideloaderCommands.installSwateFull ()

    Console.ok "Swate registry done."