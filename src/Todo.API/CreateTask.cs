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
using Todo.Application.Services;

namespace Todo.API
{
    public class CreateTask
    {
        private readonly ITaskService _taskService;

        public CreateTask(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [FunctionName("CreateTask")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = "tasks"
            )] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var task = await _taskService.CreateTask(name)
                .ConfigureAwait(false);

            return new OkObjectResult(task);
        }
    }
}

