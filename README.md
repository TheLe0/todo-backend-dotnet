# My TODO App Backend

This project is the backend of the [TODO frontend app](https://github.com/TheLe0/todo-frontend). This project was made using .NET and the serverless architecture running on Azure with the Azure Functions. 
This project is a simple CRUD, but shows you a little about this topics:

* Serverless computing
* Changing the data persistance mode on runtime;
* CI/CD;
* Dependency Injection.

## URLs

* [DEV](http://localhost:7107/api)
* [PROD](https://my-todo-dotnet-api.azurewebsites.net/api)

## Run locally

To run on your machine, you must create a file called ```local.settings.json``` on the root of the project ```Todo.API``` with the following body:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "DATABASE_TYPE": 1,
    "COSMOS_DB_PARTITION_KEY": "",
    "COSMOS_DB_ENDPOINT_URI": "",
    "COSMOS_DB_PRIMARY_KEY": "",
    "COSMOS_DB_DATABASE_ID": "",
    "COSMOS_DB_APPLICATION_NAME": ""
  },
  "Host": {
    "LocalHttpPort": 7107,
    "CORS": "*"
  }
}
```

>Note: You need only to change the ```DATABASE_TYPE``` and the ```COSMOS_DB_*``` configurations. 
>The others are fixed.

On the ```DATABASE_TYPE``` currently we support the following data persistances modes:

| Value  | Definition |
|--------|------------|
| 1      | In memory  |
| 2      | ComosDB    |

If you are going to use the CosmosDB persistance mode you must inform all the ```COSMOS_DB_*``` configurations. All the these configurations are self explanatory, you can get all on the Azure Portal on your CosmosDB resource.
