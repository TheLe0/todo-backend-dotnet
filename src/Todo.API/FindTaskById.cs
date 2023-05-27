using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Todo.Application.Services;

namespace Todo.API
{
    public class FindTaskById
    {
        private readonly ITaskService _taskService;

        public FindTaskById(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [FunctionName("FindTaskById")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "tasks/{id}"
            )] HttpRequest req, string id,
            ILogger log)
        {
            var task = await _taskService.FindById(id)
                .ConfigureAwait(false);

            return new OkObjectResult(task);
        }
    }
}

