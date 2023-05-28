using Todo.Configuration;
using Todo.Data.Base;
using Todo.Domain;

namespace Todo.Data.Repository;

public class TaskCosmosDbRepository : CosmosDbRepository, ITaskRepository
{
    public TaskCosmosDbRepository(IDatabaseConfiguration databaseConfiguration) 
        : base(databaseConfiguration, "Tasks") { }

    public Task<TaskModel> CloseById(string id)
    {
        var task = FindById(id).Result;

        if (task == null) return null;

        task.Close();

        return Update(task);
    }

    public Task<TaskModel> CreateTask(string name)
    {
        var task = new TaskModel(name);

        return AddIfNotExistsAsync(task);
    }

    public Task<bool> DeleteById(string id)
    {
        return DeleteById<TaskModel>(id);
    }

    public Task<TaskModel> FindById(string id)
    {
        return FindById<TaskModel>(id);
    }

    public Task<IEnumerable<TaskModel>> GetAll()
    {
        return GetAll<TaskModel>();
    }
}
