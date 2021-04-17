-- Switch to the system (aka master) database
USE master;
GO

-- Delete the RosterDB Database (IF EXISTS)
DROP DATABASE If Exists RosterDB;
GO

-- Create a new RosterDB Database
CREATE DATABASE RosterDB;
GO

-- Switch to the World Database
USE RosterDB
GO

BEGIN TRANSACTION

-- Creat the Roster table
Create Table Player (
	Number int not null primary key,
	Name varchar(40),
	Position char(2),
	Age int,
	HeightFeet int,
	HeightInches int,
	WeightPounds int
)

-- Insert the 2019 Indians roster into the table
Insert INTO Player
Values
(22, 'Jason Kipnis',     '2B',	32,	5,11,	200),
(30, 'Tyler Naquin',     'CF',	28,	6,2,	195),
(6,	 'Mike Freeman',	 'SS',	31,	6,0,	195),
(8,	 'Jordan Luplow',	 'LF',	25,	6,1,	195),
(35, 'Oscar Mercado',    'CF',	24,	6,2,	197),
(10, 'Jake Bauers',      'LF',	23,	6,1,	195),
(27, 'Kevin Plawecki',   'C ',	28,	6,2,	220),
(55, 'Roberto Pérez',    'C ',	30,	5,11,	220),
(12, 'Francisco Lindor', 'SS',	25,	5,11,	190),
(41, 'Carlos Santana',   '1B',	33,	5,11,	210),
(11, 'José Ramírez',     '3B',	26,	5,9,	190),
(2,	 'Leonys Martin',    'CF',	31,	6,2,	205),
(47, 'Trevor Bauer',     'P ',	28,	6,1,	205),
(33, 'Brad Hand',        'P ',	29,	6,3,	220),
(49, 'Tyler Olson',      'P ',	29,	6,3,	205),
(44, 'Nick Goody',       'P ',	27,	5,11,	200),
(45, 'Adam Plutko',      'P ',	27,	6,3,	215),
(57, 'Shane Bieber',     'P ',	24,	6,3,	200),
(90, 'Adam Cimber',      'P ',	28,	6,3,	195),
(34, 'A.J. Cole',        'P ',	27,	6,5,	238),
(62, 'Nick Wittgren',    'P ',	28,	6,2,	216),
(36, 'Tyler Clippard',   'P ',	34,	6,3,	200),
(63, 'Josh Smith',       'P ',	29,	6,3,	200),
(39, 'Oliver Pérez',     'P ',	37,	6,3,	225),
(65, 'Zach Plesac',      'P ',	24,	6,2,	200)

COMMIT TRANSACTION