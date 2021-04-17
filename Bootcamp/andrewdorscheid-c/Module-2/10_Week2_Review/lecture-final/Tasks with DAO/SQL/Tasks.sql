-- Switch to the system (aka master) database
USE master;
GO

-- Delete the TaskDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='TaskDB')
DROP DATABASE TaskDB;
GO

-- Create a new TaskDB Database
CREATE DATABASE TaskDB;
GO

-- Switch to the TaskDB Database
USE TaskDB
GO

-- Creat the Task table
Create Table Task (
	TaskId int not null primary key identity,
	TaskName varchar(100) not null,
	DueDate date not null,
    Completed bit not null default 0
)

-- Add some dummy data
Insert Task (TaskName, DueDate, Completed) Values
	('Approve Budget', dateadd(day, 3, getdate()), 0),
	('Refine messaging', dateadd(day, 2, getdate()), 0),
	('Design new assets', dateadd(day, 7, getdate()), 0),
	('Conduct User Research', dateadd(day, 30, getdate()), 0),
	('Build PR Plan', dateadd(day, 45, getdate()), 0),
	('Analyze Performance', dateadd(day, 1, getdate()), 0)

