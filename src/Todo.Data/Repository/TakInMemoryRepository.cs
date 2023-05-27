using System.Collections.Immutable;
using Todo.Domain;

namespace Todo.Data.Repository;

public class TakInMemoryRepository : ITaskRepository
{
	private readonly List<TaskModel> _tasks;

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

    public Task<bool> DeleteById(string id)
    {
        return Task.Run(() => DeleteTask(id));
    }

    private IEnumerable<TaskModel> AllTasks()
	{
		return _tasks.ToImmutableList();
	}

    private TaskModel FindTask(string searchId)
    {
        return _tasks.FirstOrDefault(p => p.Id == searchId);
    }

    private bool DeleteTask(string deleteId)
    {
        return 
            _tasks.RemoveAll(p => p.Id == deleteId) > 0;
    }

    private TaskModel AddTask(string name)
	{
        var task = new TaskModel(name);

        _tasks.Add(task);

		return task;
    }
}

