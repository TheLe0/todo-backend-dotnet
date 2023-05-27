using System;
using Todo.Domain;

namespace Todo.Data.Repository
{
	public interface ITaskRepository
	{
        Task<TaskModel> CreateTask(string name);
        Task<IEnumerable<TaskModel>> GetAll();
        Task<TaskModel> FindById(string id);
    }
}

