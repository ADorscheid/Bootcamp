using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;

namespace Tasks.Views
{
    public class TaskMenu : ConsoleMenu
    {
        private TaskList tasks = new TaskList("Tasks.txt");

        public TaskMenu()
        {
            AddOption("Add a Task", AddNewTask);
            AddOption("Get Out", Exit);
        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("===                   Tasks!                  ====");
            Console.WriteLine("==================================================");
            Console.WriteLine("Here is where we woulsd list the tasks to the user...");
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine("This is displayed below the menu");
        }

        private MenuOptionResult AddNewTask()
        {
            // Prompt the user for task information

            // Task Name
            string taskName = GetString("Enter task name: ");
            if (taskName == "")
            {
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }

            // Due Date
            DateTime dueDate = GetDate("Enter Due Date: ", DateTime.Today);

            // Create a new Task instance
            Task task = new Task(taskName, dueDate);

            // Add the task to the tasklist
            task = this.tasks.AddTask(task);

            Console.WriteLine($"Task {task.TaskId} was created.");

            return MenuOptionResult.WaitAfterMenuSelection;
      
        }
    }
}
