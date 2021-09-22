namespace Shared
open System


type BookingInfo = {
    id: string
    name: string
}

type ResourceInfo = {
    id: Guid
    name: string
    description: string
}


type CreateResourceInfo = {
    name: string
    description: string
}

type Todo =
    { Id : Guid
      Description : string }

module Todo =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) =
        { Id = Guid.NewGuid()
          Description = description }


type ITodosApi =
    { getTodos : unit -> Async<Todo list>
      addTodo : Todo -> Async<Todo> }