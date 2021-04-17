using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tasks.Models;

namespace Tasks.DAL
{
    public class TaskFileDAO : ITaskDAO
    {
        private string Path { get; set; }
        private List<Task> taskList { get; set; }
        public TaskFileDAO(string filePath)
        {
            this.Path = filePath;
            Load();
        }
        public Task GetById(int id)
        {
            return taskList.Where(t => t.Id == id).FirstOrDefault();
        }
        public IList<Task> GetAllTasks()
        {
            return this.taskList.ToList();
        }
        public IList<Task> GetOpenTasks()
        {
            return this.taskList.Where(t => !t.Completed).ToList();
        }
        public bool Update(Task task)
        {
            // Find the task in the list based on id
            Task taskToUpdate = this.taskList.Find(t => t.Id == task.Id);

            // Update the values
            if (taskToUpdate == null)
            {
                return false;
            }

            taskToUpdate.TaskName = task.TaskName;
            taskToUpdate.DueDate = task.DueDate;
            taskToUpdate.Completed = task.Completed;
            Save();
            return true;
        }
        public void AddTask(Task newTask)
        {
            // Set the new Id
            int maxId = 0;
            if (taskList.Count > 0)
            {
                maxId = taskList.Max(t => t.Id);
            }
            newTask.Id = maxId + 1;
            this.taskList.Add(newTask);
            this.Save();
        }
        public void DeleteTask(Task taskToRemove)
        {
            if (this.taskList.Contains(taskToRemove))
            {
                this.taskList.Remove(taskToRemove);
                this.Save();
            }
        }

        private void Load()
        {
            this.taskList = new List<Task>();

            try
            {
                if (File.Exists(this.Path))
                {
                    using (StreamReader sr = new StreamReader(this.Path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] fields = line.Split("|");

                            Task task = new Task(int.Parse(fields[0]), fields[1], DateTime.Parse(fields[2]), bool.Parse(fields[3]));

                            taskList.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Report the error to the user
                Console.WriteLine($"There was an error loading the Task List: {ex.Message}");

                // Allow the program to continue (with an empty task list)
            }
        }
        private void Save()
        {
            try
            {
                // Create a new file and store the tasks there
                using (StreamWriter sw = new StreamWriter(this.Path, false))
                {
                    foreach (Task task in this.taskList)
                    {
                        // Write the task to the file
                        sw.WriteLine(string.Join("|", task.Id, task.TaskName, task.DueDate, task.Completed));
                    }
                }
            }
            catch (Exception ex)
            {
                // Report the error
                Console.WriteLine($"ERROR saving task list: {ex.Message}");
            }
        }

    }
}
