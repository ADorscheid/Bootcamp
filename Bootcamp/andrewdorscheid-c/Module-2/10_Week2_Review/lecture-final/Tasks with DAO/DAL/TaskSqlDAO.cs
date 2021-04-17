using System;
using System.Collections.Generic;
using Tasks.Models;
using System.Data.SqlClient;

namespace Tasks.DAL
{
    public class TaskSqlDAO : ITaskDAO
    {
        private string connectionString;
        public TaskSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddTask(Task newTask)
        {
            SqlCommand cmd = new SqlCommand(
@"Insert Task (TaskName, DueDate, Completed)
Values (@taskName, @dueDate, @completed)");
            cmd.Parameters.AddWithValue("@taskName", newTask.TaskName);
            cmd.Parameters.AddWithValue("@dueDate", newTask.DueDate);
            cmd.Parameters.AddWithValue("@completed", newTask.Completed);

            int rows = ExecuteNonQuery(cmd);
            return;
        }

        public Task GetById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Task where TaskId = @taskId");
            cmd.Parameters.AddWithValue("@taskId", id);
            IList<Task> list = GetList(cmd);
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        public bool Update(Task task)
        {
            SqlCommand cmd = new SqlCommand(
@"Update Task 
Set TaskName = @taskName,
DueDate = @dueDate,
Completed = @completed
Where TaskId = @taskId
");
            cmd.Parameters.AddWithValue("@taskId", task.Id);
            cmd.Parameters.AddWithValue("@taskName", task.TaskName);
            cmd.Parameters.AddWithValue("@dueDate", task.DueDate);
            cmd.Parameters.AddWithValue("@completed", task.Completed);

            int rows = ExecuteNonQuery(cmd);
            return rows > 0;
        }

        public void DeleteTask(Task taskToRemove)
        {
            SqlCommand cmd = new SqlCommand("Delete from Task where TaskId = @taskId");
            cmd.Parameters.AddWithValue("@taskId", taskToRemove.Id);
            int rows = ExecuteNonQuery(cmd);
            return;
        }

        public IList<Task> GetAllTasks()
        {
            string sql = "Select * from task order by DueDate";
            return GetList(sql);
        }

        public IList<Task> GetOpenTasks()
        {
            string sql = "Select * from task where Completed = 0 order by DueDate";
            return GetList(sql);
        }

        private List<Task> GetList(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            return GetList(cmd);
        }
        private List<Task> GetList(SqlCommand cmd)
        {
            List<Task> list = new List<Task>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.Connection = conn;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        private int ExecuteNonQuery(SqlCommand cmd)
        {
            int rows = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.Connection = conn;
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }

        private Task RowToObject(SqlDataReader rdr)
        {
            Task task = new Task(
                Convert.ToInt32(rdr["TaskId"]),
                Convert.ToString(rdr["TaskName"]),
                Convert.ToDateTime(rdr["DueDate"]),
                Convert.ToBoolean(rdr["Completed"])
                );
            return task;
        }
    }
}
