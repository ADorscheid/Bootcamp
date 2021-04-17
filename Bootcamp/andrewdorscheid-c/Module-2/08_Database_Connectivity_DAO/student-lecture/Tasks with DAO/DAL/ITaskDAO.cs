using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.DAL
{
    public interface ITaskDAO
    {
        void AddTask(Task newTask);
        void DeleteTask(Task taskToRemove);
        IList<Task> GetAllTasks();
        Task GetById(int id);
        IList<Task> GetOpenTasks();
        bool Update(Task task);
    }
}