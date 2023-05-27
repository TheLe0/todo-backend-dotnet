using System;
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

    public async Task<TaskModel> CreateTask(string name)
	{
		return await _taskRepository.CreateTask(name);
	}
}

