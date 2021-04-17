using MenuFramework;
using System;
using System.Collections.Generic;
using Tasks.DAL;
using Tasks.Models;

namespace Tasks.Views
{
    public class Menu : ConsoleMenu
    {
        public bool PremiumVersion { get; set; } = false;
        private ITaskDAO taskDAO;

        public Menu(ITaskDAO taskDAO)
        {
            this.taskDAO = taskDAO;

            AddOption("Add a new Task", AddTask);
            AddOption("Complete a Task", CompleteTask);
            AddOption("List All Tasks", ListAllTasks);
            AddOption("Exit", Exit);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.DarkYellow;
                cfg.SelectedItemForegroundColor = ConsoleColor.Yellow;
            });
        }

        private MenuOptionResult ListAllTasks()
        {
            IList<Task> allTasks = taskDAO.GetAllTasks();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ListTasks(allTasks);
            Console.ResetColor();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AddTask()
        {
            Task task = GetTaskinfo();
            if (task != null)
            {
                taskDAO.AddTask(task);
            }
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private MenuOptionResult CompleteTask()
        {
            IList<Task> list = taskDAO.GetOpenTasks();
            ConsoleMenu taskMenu = new ConsoleMenu()
                .AddOptionRange<Task>(list, CompleteTask)
                .AddOption("Cancel", () => MenuOptionResult.CloseMenuAfterSelection)
                .Configure(cfg => {
                    cfg.Title = "Select the Task to Complete";
                });
            return taskMenu.Show();

        }
        private MenuOptionResult CompleteTask(Task task)
        {
            task.Completed = true;
            taskDAO.Update(task);
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        protected override void OnBeforeShow()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(PremiumVersion ? "Premium Version" : "Free Version");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Tasks!!!"));

            // List all the tasks
            Console.ForegroundColor = ConsoleColor.Green;
            IList<Task> list = taskDAO.GetOpenTasks();
            ListTasks(list);
        }

        private Task GetTaskinfo()
        {
            Console.WriteLine("\r\n*** Add a Task ***");
            string taskName = GetString("Task Name: ", true);
            if (taskName.Trim().Length == 0)
            {
                return null;
            }
            DateTime dueDate = GetDate("Due Date: ", DateTime.Today + new TimeSpan(24, 0, 0));
            return new Task(0, taskName, dueDate);
        }
        private void ListTasks(IList<Task> list)
        {
            string[] headings = { "Number", "Task", "Due Date", "Completed" };
            Console.WriteLine($"{headings[0],6} {headings[1],-30} {headings[2],-15} {headings[3],-10}");
            foreach (Task task in list)
            {
                Console.WriteLine($"{task.Id,6} {task.TaskName,-30} {task.DueDate,-15:d} {task.Completed,-10}");
            }
            Console.WriteLine(new string('-', 80));
        }
    }
}
