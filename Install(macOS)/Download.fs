module Download

open System
open System.IO

[<Literal>]
let ManifestUrl = @"https://raw.githubusercontent.com/nfdi4plants/Swate/developer/.assets/assets/manifest.xml"

let webCl = new System.Net.WebClient()

let getDlPath () =
    
    let userFolder      = Environment.GetFolderPath Environment.SpecialFolder.UserProfile
    let libraryFolder   = Path.Combine(userFolder   , "Library")
    let wefFolder       = Path.Combine(libraryFolder, "Containers/com.microsoft.Excel/Data/Documents/wef")
    let manifestPath    = Path.Combine(wefFolder    , "Swate_Manifest.xml")
    wefFolder, manifestPath

let downloadManifest () =
    
    let dlFolder, xmlPath = getDlPath () |> fun (dlF,mP) -> dlF, mP
    
    // Create wef folder if not present
    Directory.CreateDirectory dlFolder |> ignore

    webCl.DownloadFile(ManifestUrl, xmlPath)