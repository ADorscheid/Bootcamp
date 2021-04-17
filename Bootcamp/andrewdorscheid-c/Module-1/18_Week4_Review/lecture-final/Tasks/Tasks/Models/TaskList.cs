using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tasks.Models
{
    public class TaskList
    {
        private const string FILE_SEPARATOR_CHARACTERS = "|||";

        // This is whare our working list of tasks is stored
        private List<Task> taskList = new List<Task>();
        private int maxId = 0;

        /// <summary>
        /// Public access to the list of tasks
        /// </summary>
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
        }

        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }

        /// <summary>
        /// This points to the file that persistently holds our tasks.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Creates a new TaskList object
        /// </summary>
        /// <param name="path">Path to the file that stores task info</param>
        public TaskList(string path)
        {
            Path = path;
            Load();
        }

        /// <summary>
        /// Saves all the Tasks that are in the list into a file at Path.
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            try
            {
                // Open the file for Overwrite
                using (StreamWriter sw = new StreamWriter(Path, false))
                {
                    foreach (Task task in taskList)
                    {
                        string outputLine = string.Join(FILE_SEPARATOR_CHARACTERS, task.TaskId, task.TaskName, task.DueDate, task.IsCompleted);
                        sw.WriteLine(outputLine);
                    }
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Open the file at Path and read it to create Task instances to load into taskList
        /// </summary>
        /// <returns></returns>
        private bool Load()
        {
            this.taskList.Clear();
            this.maxId = 0;
            try
            {
                // Use StreamReader to open and read the file
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string inputLine = sr.ReadLine();

                        string[] fields = inputLine.Split(FILE_SEPARATOR_CHARACTERS);

                        // Create a Task from the data
                        Task task = new Task(int.Parse(fields[0]), fields[1], DateTime.Parse(fields[2]), bool.Parse(fields[3]));

                        // See if this is the highest Id
                        this.maxId = Math.Max(this.maxId, task.TaskId);

                        // Add the task to the list
                        this.taskList.Add(task);
                    }
                }
                // Everything worked
                return true;
            }
            catch (Exception)
            {
                // Log to some error log

                return false;
            }
        }

        public Task AddTask(Task task)
        {
            // Fill in the id if needed

            if (task.TaskId == 0)
            {
                task.TaskId = GetNextId();
                task.IsCompleted = false;
            }

            this.taskList.Add(task);

            // Make sure the list is saved to the file
            Save();

            return task;
        }

        private int GetNextId()
        {
            this.maxId++;
            return this.maxId;
        }
    }
}
