using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Todo.Application.Services;

namespace Todo.API
{
    public class DeleteTask
    {
        private readonly ITaskService _taskService;

        public DeleteTask(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [FunctionName("DeleteTask")]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "delete",
                Route = "tasks/{id}"
            )] HttpRequest req, string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var taskIsDeleted = await _taskService.DeleteById(id)
                .ConfigureAwait(false);    

            return taskIsDeleted ?
                new OkObjectResult("The task was successfully deleted") :
                new BadRequestObjectResult("No task found with the informed Id");
        }
    }
}

