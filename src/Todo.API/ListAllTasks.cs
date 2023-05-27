using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Todo.Application.Services;

namespace Todo.API
{
    public class ListAllTasks
    {
        private readonly ITaskService _taskService;

        public ListAllTasks(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [FunctionName("ListAllTasks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "tasks/"
            )] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var tasks = await _taskService.GetAll()
                .ConfigureAwait(false);

            return new OkObjectResult(tasks);
        }
    }
}

