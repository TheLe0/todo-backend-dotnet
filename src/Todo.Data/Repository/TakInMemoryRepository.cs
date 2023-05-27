using System;
using System.Collections.Immutable;
using System.Xml.Linq;
using Todo.Domain;

namespace Todo.Data.Repository;

public class TakInMemoryRepository : ITaskRepository
{
	private readonly IList<TaskModel> _tasks;

	public TakInMemoryRepository()
	{
		_tasks = new List<TaskModel>();
	}

    public Task<TaskModel> FindById(string id)
	{
        return Task.Run(() => FindTask(id));
    }


    public Task<IEnumerable<TaskModel>> GetAll()
    {
		return Task.Run(() => AllTasks());
    }

	public Task<TaskModel> CreateTask(string name)
	{
		var task = new TaskModel(name);

		return Task.Run(() => AddTask(name));
    }

	private IEnumerable<TaskModel> AllTasks()
	{
		return _tasks.ToImmutableList();
	}

    private TaskModel FindTask(string searchId)
    {
        return _tasks.FirstOrDefault(p => p.Id == searchId);
    }

    private TaskModel AddTask(string name)
	{
        var task = new TaskModel(name);

        _tasks.Add(task);

		return task;
    }
}

