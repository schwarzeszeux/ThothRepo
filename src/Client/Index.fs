module Index

open Elmish
open Thoth.Fetch
open System

type Resource = {
    id: Guid;
    name: string;
    description: string
}

type Msg =
| ResourcesLoaded of Resource list

type Model = { 
    resources: Resource list
}

let init (): Model * Cmd<Msg> =
    let loadResources() = Fetch.get<unit, Resource list >("/api/resources")
    let cmd = Cmd.OfPromise.perform loadResources () (ResourcesLoaded)
    let model = {
        resources = []
    }

    model, cmd

let update msg model =
    match msg with
    | ResourcesLoaded resources ->
        { model with resources = resources }, Cmd.none

open Fable.React

let view (model : Model) (dispatch : Msg -> unit) =
    div [] []