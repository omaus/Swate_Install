module Url

open System
open System.IO

[<Literal>]
let SwateUrl = @"https://swate.denbi.uni-tuebingen.de/"
/// Can be used to check Client - Server connection

[<Literal>]
let GetAppVersionAPI = SwateUrl + @"api/IServiceAPIv1/getAppVersion"
/// Can be used to check Server - Database connection

[<Literal>]
let GetAllOntologiesAPI = SwateUrl + @"api/IAnnotatorAPIv1/getAllOntologies"

[<Literal>]
// let ManifestUrl = @"https://raw.githubusercontent.com/nfdi4plants/Swate/developer/.assets/assets/manifest.xml" // atm. outdated, uncomment when next version is live
let ManifestUrl = @"https://raw.githubusercontent.com/nfdi4plants/Swate/47965986e914f30b3b438bc44ede81308dc16d39/.assets/assets/manifest.xml"

[<Literal>]
let SideloaderUrl = @"https://github.com/davecra/WebAddinSideloader/raw/master/Set-WebAddin%20(v1.0.0.1).zip"