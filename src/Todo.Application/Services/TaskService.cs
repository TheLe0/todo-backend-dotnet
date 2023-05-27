using Todo.Data.Repository;
using Todo.Domain;

namespace Todo.Application.Services;

public class TaskService : ITaskService
{
	private readonly ITaskRepository _taskRepository;

	public TaskService(ITaskRepository taskRepository)
	{
		_taskRepository = taskRepository;
	}

    public async Task<IEnumerable<TaskModel>> GetAll()
	{
		return await _taskRepository.GetAll();
	}

    public async Task<TaskModel> FindById(string id)
    {
        return await _taskRepository.FindById(id);
    }

	public async Task<bool> DeleteById(string id)
	{
        return await _taskRepository.DeleteById(id);
    }

	public async Task<TaskModel> CloseById(string id)
	{
        return await _taskRepository.CloseById(id);
    }

    public async Task<TaskModel> CreateTask(string name)
	{
		return await _taskRepository.CreateTask(name);
	}
}

