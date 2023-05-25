using System;
using Todo.Domain;

namespace Todo.Data.Repository;

public class TakInMemoryRepository : ITaskRepository
{
	private readonly IList<TaskModel> _tasks;

	public TakInMemoryRepository()
	{
		_tasks = new List<TaskModel>();
	}

	public Task<TaskModel> CreateTask(string name)
	{
		var task = new TaskModel(name);

		return Task.Run(() => AddTask(name));
    }

	private TaskModel AddTask(string name)
	{
        var task = new TaskModel(name);

        _tasks.Add(task);

		return task;
    }
}

