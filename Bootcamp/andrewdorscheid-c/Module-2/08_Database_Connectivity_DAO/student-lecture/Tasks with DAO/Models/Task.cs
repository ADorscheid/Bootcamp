using System;

namespace Tasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public Task(int id, string taskName, DateTime dueDate)
        {
            this.Id = id;
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Completed = false;
        }

        public Task(int id, string taskName, DateTime dueDate, bool completed)
        {
            this.Id = id;
            this.TaskName = taskName;
            this.DueDate = dueDate;
            this.Completed = completed;
        }

        public override string ToString()
        {
            return $"{Id, 3} {TaskName}";
        }
    }
}
