module Checks

open FSharp.Data

type ParseResult<'a> = {
    Result  : 'a
    Success : bool
}

let getParseResult res = {
    Result  = res
    Success = res <> ""
}

[<Literal>]
let SwateUrl = @"https://swate.denbi.uni-tuebingen.de/"
/// Can be used to check Client - Server connection

[<Literal>]
let GetAppVersionAPI = SwateUrl + @"api/IServiceAPIv1/getAppVersion"
/// Can be used to check Server - Database connection

[<Literal>]
let GetAllOntologiesAPI = SwateUrl + @"api/IAnnotatorAPIv1/getAllOntologies"

let getAppVersion () = 
    getParseResult (
        try FSharp.Data.Http.RequestString(GetAppVersionAPI)
        with err -> Console.error <| sprintf "ERROR: Did not get App version due to:\n%s" err.Message; ""
    )

let checkSemVer appVer =
    let pattern = @"""(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-(?<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?"""
    match System.Text.RegularExpressions.Regex.Match(appVer, pattern) with
    | x when x.Success -> Console.ok <| sprintf "AppVer %s is a SemVer" appVer
    | _ -> Console.error <| sprintf "ERROR: AppVer %s is not a SemVer" appVer

type Ontology = {
    Name            : string
    CurrentVersion  : string
    Definition      : string
    DateCreated     : string
    UserID          : string
}

let getAllOntologies () =
    getParseResult (
        try FSharp.Data.Http.RequestString(GetAllOntologiesAPI) 
        with err -> Console.error <| sprintf "ERROR: Was not able to parse ontologies due to:\n%s" err.Message; ""
    )
    
let getOntoList jsonedFullstring = Newtonsoft.Json.JsonConvert.DeserializeObject<Ontology list> jsonedFullstring

let checkOnto onto =
    let checkDate () =
        try onto.DateCreated |> System.DateTime.Parse |> fun date -> printfn "Ontology %s has System.DateTime (%A) in DateCreated" onto.Name date
        with err -> Console.error <| sprintf "ERROR: Ontology %s misses a System.DateTime in DateCreated" onto.Name
    checkDate ()