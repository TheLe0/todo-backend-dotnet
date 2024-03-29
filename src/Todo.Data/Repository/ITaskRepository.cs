﻿using Todo.Domain;

namespace Todo.Data.Repository
{
	public interface ITaskRepository
	{
        Task<TaskModel> CreateTask(string name);
        Task<IEnumerable<TaskModel>> GetAll();
        Task<TaskModel> FindById(string id);
        Task<bool> DeleteById(string id);
        Task<TaskModel> CloseById(string id);
    }
}

