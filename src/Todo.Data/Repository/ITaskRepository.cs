using System;
using Todo.Domain;

namespace Todo.Data.Repository
{
	public interface ITaskRepository
	{
        Task<TaskModel> CreateTask(string name);

    }
}

