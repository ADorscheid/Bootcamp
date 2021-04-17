# Project Organizer Database Access


## Part 1 (Day 1 & 2) - Data Access Layer

**Setup:** Create a SQL Server database using the attached SQL script `projects.sql`. 

Complete the CLI application for the project database application by completing the following steps:

1. Edit the `appsettings.json` file with the appropriate database connection string.
2. Create the business objects in the `Models` folder which represent the `Department`, `Employee` and `Project` classes.
3. Find the `// TODO:` lines in `ProjectCLI.cs`, and uncomment the lines which follow.  To find all of the `TODO`s, you can use the Visual Studio Task View.
4. Implement the DAO classes `DepartmentSqlDAO`, `EmployeeSqlDAO` and `ProjectSqlDAO` in the `DAL` folder, to execute the appropriate SQL commands to the database.

## Part 2 (Day 3) - Integration Testing

Create a Unit Test project for the **ProjectDB** application. Implement integration tests for the `DepartmentSqlDAO`, `EmployeeSqlDAO`, and `ProjectSqlDAO` classes.

Be sure to clean up any test data so that the database is returned to its original state after the test is completed.