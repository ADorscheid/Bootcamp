using System;
using System.Collections.Generic;
using System.Text;

using MenuFramework;

using Tasks.Models;

namespace Tasks.Views
{
    public class TaskMenu : ConsoleMenu
    {
        private TaskList taskList = new TaskList("tasks.list");

        public TaskMenu()
        {
            base.AddOption("Add a Task", addNewTask);
            base.AddOption("Exit", Exit); //Exit method already exists on the base class
        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine("========================");
            Console.WriteLine("======   TASKS!  =======");
            Console.WriteLine("========================");
            //optionally loop over the tasks in the list and print them


        }

        private MenuOptionResult addNewTask()
        {
            //prompt the user for task name
            string taskName = GetString("Enter Task Name:");
            
            //if they hit ENTER
            if (taskName.Equals("")) {
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }
            //due date
            DateTime dueDate = GetDate("Enter Due Date: ", DateTime.Today);

            //create a new Task instance
            Task newTask = new Task(taskName, dueDate);

            //add to task list
            this.taskList.addTask(newTask);

            Console.WriteLine($"Task {newTask.TaskId} was created");

            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
