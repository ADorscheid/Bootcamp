using System;
using Tasks.DAL;
using Tasks.Views;

namespace Tasks
{
    class Program
    {
        static private ITaskDAO taskDAO;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task List!\r\n");
            System.Threading.Thread.Sleep(500);

            // Read the config file
            Config config = new Config("appsettings.json");

            if (config.UseSql)
            {
                taskDAO = new TaskSqlDAO(config.ConnectionString);
            }
            else
            {
                taskDAO = new TaskFileDAO(config.FilePath);
            }

            Menu menu = new Menu(taskDAO);
            menu.Show();
        }
    }
}
