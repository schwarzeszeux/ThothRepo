module Server

open Saturn
open Shared
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.NonAffine
open System

let getResources : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) -> 
        task {
            let resource = [{
                id = Guid.Empty
                name = "name"
                description = "description"
            }]
            return! json resource next ctx
        }

let webApp =
    router {
        get "/api/resource" getResources
    }

let app =
    application {
        url "http://0.0.0.0:8085"
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

run app
