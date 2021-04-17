using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    public class TaskList
    {
        private const string FILE_SEPARATOR_CHARACTER = "|||";
        private List<Task> taskList = new List<Task>();
        private int maxId = 0;

        /// <summary>
        /// Public access to the list of tasks (unmodifiable result)
        /// </summary>
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
            set { }
        }


        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }
        /// <summary>
        /// This points to the file that persistently holds the tasks.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Creates a new TaskList reading task data from the given file path.
        /// </summary>
        /// <param name="path">Path to the file that holds Task info</param>
        public TaskList(string path)
        {
            Path = path;
            this.Load();
        }

        /// <summary>
        /// Saves all the tasks in the list to the file at PATH
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.Path, false))
                {
                    foreach (Task task in this.taskList)
                    {
                        string outputline = string.Join(FILE_SEPARATOR_CHARACTER, task.TaskId, task.TaskName, task.DueDate, task.IsCompleted);
                        writer.WriteLine(outputline);
                    }
                }
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Read the list of tasks from the tile at PATH and load into THIS instance of TaskList
        /// </summary>
        /// <returns></returns>
        private bool Load()
        {
            //clear out all the current items
            this.taskList.Clear();
            this.maxId = 0;
            try
            {
                using (StreamReader reader = new StreamReader(this.Path))
                {
                    while (!reader.EndOfStream)
                    {
                        string inputLine = reader.ReadLine();
                        string[] fields = inputLine.Split(FILE_SEPARATOR_CHARACTER);

                        Task task = new Task(
                            int.Parse(fields[0]),
                            fields[1],
                            DateTime.Parse(fields[2]),
                            bool.Parse(fields[3])
                        );
                        this.maxId = Math.Max(this.maxId,task.TaskId);

                        this.taskList.Add(task);
                    }
                }
            } catch (Exception Ex)
            {
                return false;
            }
            return true;
        }

        public Task addTask(Task task)
        {
            //come up with an ID
            if (task.TaskId == 0) {
                task.TaskId = this.GetNextId();
            }

            //addTask to the list
            this.taskList.Add(task);


            //save
            this.Save();

            return task;
        }

        public int GetNextId() {
            this.maxId++;

            return this.maxId;
        }
    }
}
