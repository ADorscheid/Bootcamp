using MenuFramework;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;

namespace ProjectOrganizer
{
    public class ProjectCLI : ConsoleMenu
    {
        private IEmployeeDAO employeeDAO;
        private IProjectDAO projectDAO;
        private IDepartmentDAO departmentDAO;

        public ProjectCLI(IEmployeeDAO employeeDAO, IProjectDAO projectDAO, IDepartmentDAO departmentDAO)
        {
            this.employeeDAO = employeeDAO;
            this.projectDAO = projectDAO;
            this.departmentDAO = departmentDAO;
            AddOption("Show all departments", GetAllDepartments)
                .AddOption("Show all employees", GetAllEmployees)
                .AddOption("Employee search by first and last name", EmployeeSearch)
                .AddOption("Get employees without projects", GetEmployeesWithoutProjects)
                .AddOption("Get all projects", GetAllProjects)
                .AddOption("Create Department", CreateDepartment)
                .AddOption("Update Department Name", UpdateDepartment)
                .AddOption("Create Project", CreateProject)
                .AddOption("Assign Employee to Project", AssignEmployeeToProject)
                .AddOption("Remove Employee from Project", RemoveEmployeeFromProject)
                .AddOption("Quit", Close, "Q");

            Configure(cfg =>
            {
                cfg.MenuSelectionMode = MenuSelectionMode.KeyString;
            });
            Console.WriteLine();

        }

        protected override void OnBeforeShow()
        {
            PrintHeader();
        }


        private MenuOptionResult RemoveEmployeeFromProject()
        {
            int projectId = GetInteger("Which project id is the employee removed from:");
            int employeeId = GetInteger("Which employee is getting removed:");

            bool result = projectDAO.RemoveEmployeeFromProject(projectId, employeeId);

            if (result)
            {
                Console.WriteLine("*** SUCCESS ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT CREATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult AssignEmployeeToProject()
        {
            int projectId = GetInteger("Which project id is the employee assigned to:");
            int employeeId = GetInteger("Which employee is getting added:");

            bool result = projectDAO.AssignEmployeeToProject(projectId, employeeId);

            if (result)
            {
                Console.WriteLine("*** SUCCESS ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT CREATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult CreateProject()
        {
            string projectName = GetString("Provide a name for the project:");
            DateTime startDate = GetDate("Provide a start date for the project:");
            DateTime endDate = GetDate("Provide an end date for the project");

            Project newProj = new Project()
            {
                // TODO: Uncomment this after the Project Model is implemented
                //Name = projectName,
                //StartDate = startDate,
                //EndDate = endDate
            };

            int id = projectDAO.CreateProject(newProj);

            if (id > 0)
            {
                Console.WriteLine($"*** Project {id} was created. ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT CREATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult UpdateDepartment()
        {
            int departmentId = GetInteger("Which department are you updating?");
            string updatedName = GetString("Provide the new name:");
            Department updatedDepartment = new Department
            {
                // TODO: Uncomment this after the Department Model is implemented
                //Id = departmentId,
                //Name = updatedName
            };

            bool result = departmentDAO.UpdateDepartment(updatedDepartment);

            if (result)
            {
                Console.WriteLine("*** SUCCESS ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT UPDATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult CreateDepartment()
        {
            string departmentName = GetString("Provide a name for the new department:");
            Department newDept = new Department
            {
                // TODO: Uncomment this after the Department Model is implemented
                //Name = departmentName
            };

            int id = departmentDAO.CreateDepartment(newDept);

            if (id > 0)
            {
                Console.WriteLine($"*** Department {id} was created. ***");
            }
            else
            {
                Console.WriteLine("*** DID NOT CREATE ***");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetAllDepartments()
        {
            IList<Department> departments = departmentDAO.GetDepartments();

            if (departments.Count > 0)
            {
                foreach (Department dept in departments)
                {
                    // TODO: Uncomment this after the Department Model is implemented
                    //Console.WriteLine(dept.Id.ToString().PadRight(10) + dept.Name.PadRight(40));
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetAllEmployees()
        {
            IList<Employee> employees = employeeDAO.GetAllEmployees();

            if (employees.Count > 0)
            {
                foreach (Employee emp in employees)
                {
                    // TODO: Uncomment this after the Employee Model is implemented
                    //Console.WriteLine(emp.EmployeeId.ToString().PadRight(5) + (emp.LastName + ", " + emp.FirstName).PadRight(30) + emp.JobTitle.PadRight(30) + emp.Gender.PadRight(3) + emp.BirthDate.ToShortDateString().PadRight(10));
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult EmployeeSearch()
        {
            string firstname = GetString("Enter the first name:");
            string lastname = GetString("Enter the last name:");

            IList<Employee> employees = employeeDAO.Search(firstname, lastname);

            if (employees.Count > 0)
            {
                foreach (Employee emp in employees)
                {
                    // TODO: Uncomment this after the Employee Model is implemented
                    //Console.WriteLine(emp.EmployeeId.ToString().PadRight(5) + (emp.LastName + ", " + emp.FirstName).PadRight(30) + emp.JobTitle.PadRight(30) + emp.Gender.PadRight(3) + emp.BirthDate.ToShortDateString().PadRight(10));
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetEmployeesWithoutProjects()
        {
            IList<Employee> employees = employeeDAO.GetEmployeesWithoutProjects();

            if (employees.Count > 0)
            {
                foreach (Employee emp in employees)
                {
                    // TODO: Uncomment this after the Employee Model is implemented
                    //Console.WriteLine(emp.EmployeeId.ToString().PadRight(5) + (emp.LastName + ", " + emp.FirstName).PadRight(30) + emp.JobTitle.PadRight(30) + emp.Gender.PadRight(3) + emp.BirthDate.ToShortDateString().PadRight(10));
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetAllProjects()
        {
            IList<Project> projects = projectDAO.GetAllProjects();

            if (projects.Count > 0)
            {
                foreach (Project proj in projects)
                {
                    // TODO: Uncomment this after the Project Model is implemented
                    //Console.WriteLine(proj.ProjectId.ToString().PadRight(5) + proj.Name.PadRight(20) + proj.StartDate.ToShortDateString().PadRight(10) + proj.EndDate.ToShortDateString().PadRight(10));
                }

            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private void PrintHeader()
        {
            Console.WriteLine(@" ______                 _                           _____           _           _       _____  ____  ");
            Console.WriteLine(@"|  ____|               | |                         |  __ \         (_)         | |     |  __ \|  _ \ ");
            Console.WriteLine(@"| |__   _ __ ___  _ __ | | ___  _   _  ___  ___    | |__) | __ ___  _  ___  ___| |_    | |  | | |_) |");
            Console.WriteLine(@"|  __| | '_ ` _ \| '_ \| |/ _ \| | | |/ _ \/ _ \   |  ___/ '__/ _ \| |/ _ \/ __| __|   | |  | |  _ < ");
            Console.WriteLine(@"| |____| | | | | | |_) | | (_) | |_| |  __/  __/   | |   | | | (_) | |  __/ (__| |_    | |__| | |_) |");
            Console.WriteLine(@"|______|_| |_| |_| .__/|_|\___/ \__, |\___|\___|   |_|   |_|  \___/| |\___|\___|\__|   |_____/|____/ ");
            Console.WriteLine(@"                 | |             __/ |                            _/ |                               ");
            Console.WriteLine(@"                 |_|            |___/                            |__/                                ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
