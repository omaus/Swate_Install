module Url

open System
open System.IO

[<Literal>]
let SwateUrl = @"https://swate.nfdi4plants.de/"

/// Can be used to check Client - Server connection
[<Literal>]
let GetAppVersionAPI = SwateUrl + @"api/IServiceAPIv1/getAppVersion"

/// Can be used to check Server - Database connection
[<Literal>]
let GetAllOntologiesAPI = SwateUrl + @"api/IOntologyAPIv1/getAllOntologies"

[<Literal>]
let ManifestUrl = @"https://raw.githubusercontent.com/nfdi4plants/Swate/developer/.assets/assets/manifest.xml"

[<Literal>]
let SideloaderUrl = @"https://github.com/davecra/WebAddinSideloader/raw/master/Set-WebAddin%20(v1.0.0.1).zip"