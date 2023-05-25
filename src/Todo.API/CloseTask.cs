using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Todo.Configuration;

namespace Todo.API
{
    public class CloseTask
    {
        private readonly IDatabaseConfiguration _config;

        public CloseTask(IDatabaseConfiguration configuration)
        {
            _config = configuration;
        }

        [FunctionName("CloseTask")]
        public IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "put",
                Route = "tasks/{id}/closeCloseTask"
            )] HttpRequest req, int id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = $"The id informed was: {id}. " +
                $"and the persistance mode is: {_config.GetDatabaseType()}";

            return new OkObjectResult(responseMessage);
        }
    }
}

