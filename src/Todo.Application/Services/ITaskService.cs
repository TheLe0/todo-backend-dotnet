using System;
using Todo.Domain;

namespace Todo.Application.Services
{
	public interface ITaskService
	{
        Task<TaskModel> CreateTask(string name);

    }
}

