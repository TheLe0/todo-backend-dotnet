using Todo.Domain;

namespace Todo.Application.Services
{
	public interface ITaskService
	{
        Task<TaskModel> CreateTask(string name);
        Task<IEnumerable<TaskModel>> GetAll();
        Task<TaskModel> FindById(string id);
        Task<bool> DeleteById(string id);
        Task<TaskModel> CloseById(string id);
    }
}

