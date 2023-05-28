using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Todo.Application.Services;

namespace Todo.API
{
    public class CloseTask
    {
        private readonly ITaskService _taskService;

        public CloseTask(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [FunctionName("CloseTask")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "put",
                Route = "tasks/{id}/close"
            )] HttpRequest req, string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var task = await _taskService.CloseById(id)
                .ConfigureAwait(false);

            return new OkObjectResult(task);
        }
    }
}

