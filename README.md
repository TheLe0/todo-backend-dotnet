# My TODO App Backend

Backend of the TODO app made with .NET and Azure Functions

## URLs

DEV: <http://localhost:7107/api>

PROD: <https://my-todo-dotnet-api.azurewebsites.net/api>

## Run locally

To run on your machine, you must create a file called ```local.settings.json``` on the root of the project ```Todo.API``` with the following body:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "DATABASE_TYPE": 1,
    "COSMOS_DB_PARTITION_KEY": "3a1355adad414236b9af0d4d7c5b8580",
    "COSMOS_DB_ENDPOINT_URI": "https://my-todo-app-db.documents.azure.com:443/",
    "COSMOS_DB_PRIMARY_KEY": "7macLYDE7S1QL58uu1RWloE7TQzgtneDsITxe350fSonyll12Be2mOECqAWxVv0kGXzNWeK9CjSpACDbIm2pbw==",
    "COSMOS_DB_DATABASE_ID": "TodoDB",
    "COSMOS_DB_APPLICATION_NAME": "TodoDotnetAPI"
  },
  "Host": {
    "LocalHttpPort": 7107,
    "CORS": "*"
  }
}
```

Currently we support the following data persistances modes:

| Value  | Definition |
|--------|------------|
| 1      | In memory  |
| 2      | ComosDB    |
