using System;
using Tasks.Models;
using Tasks.Views;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Prompt the user for task name, due date
            //string taskName = "test";
            //DateTime dueDate = DateTime.Now;

            //// Create a task that has not yet been added to the list
            //Task task = new Task(taskName, dueDate);

            //TaskList list = new TaskList("foo");

            //task = list.AddTask(task);

            // Create the menu and show it

            TaskMenu menu = new TaskMenu();
            menu.Show();

        }
    }
}
