using Microsoft.Extensions.Configuration;
using ProjectOrganizer.DAL;
using System;
using System.IO;

namespace ProjectOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            IProjectDAO projectDAO = new ProjectSqlDAO(connectionString);
            IEmployeeDAO employeeDAO = new EmployeeSqlDAO(connectionString);
            IDepartmentDAO departmentDAO = new DepartmentSqlDAO(connectionString);

            ProjectCLI projectCLI = new ProjectCLI(employeeDAO, projectDAO, departmentDAO);
            projectCLI.Show();

            Console.WriteLine("Thank you for using the project organizer");

        }
    }
}
