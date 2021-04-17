using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int taskId, string taskName, DateTime dueDate, bool isCompleted)
        {
            TaskId = taskId;
            TaskName = taskName;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }

        public Task(string taskName, DateTime dueDate)
        {
            TaskName = taskName;
            DueDate = dueDate;
        }
    }
}
