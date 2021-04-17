-- Create the tables for the Team database
Use master
GO

Drop Database if exists NFLDB;

Create Database NFLDB;
GO

Use NFLDB
GO

-- Create the Team table first
Create Table Team (
    TeamId int Primary Key identity,
    Location varchar(25) not null,
    TeamName varchar(25) not null,
    Conference int not null,
    Division int not null, 
    Wins int not null default 0,
    Losses int not null default 0,
    Constraint Check_TeamConference Check (Conference Between 1 and 2),
    Constraint Check_TeamDivision Check (Division Between 1 and 4)
);

-- Create the Player table
Create Table Player (
    PlayerId int identity,
    FirstName nvarchar(30) not null,
    LastName nvarchar(30) not null,
    TeamId int NULL,
	BirthDate date not null,
    Position varchar(3) not null,
    Constraint PK_Player Primary Key (PlayerId),
    Constraint FK_PlayerTeam Foreign Key (TeamId) References Team(TeamId)
);

-- Insert Data here...
​
insert into team (location,teamName, conference,division) values ('Cleveland','Browns',1,1);
insert into team (location,teamName, conference,division) values ('Pittsburgh','Steelers',1,1);
insert into team (location,teamName, conference,division) values ('Baltimore','Ravens',1,1);
insert into team (location,teamName, conference,division) values ('Cincinnati','Bengals',1,1);
​
insert into team (location,teamName, conference,division) values ('Buffalo','Bills',1,2);
insert into team (location,teamName, conference,division) values ('Cleveland','Dolphins',1,2);
insert into team (location,teamName, conference,division) values ('New England','Patriots',1,2);
insert into team (location,teamName, conference,division) values ('New York','Jets',1,1);
​
insert into team (location,teamName, conference,division) values ('Tennessee','Titans',1,3);
insert into team (location,teamName, conference,division) values ('Indianapolis','Colts',1,3);
insert into team (location,teamName, conference,division) values ('Houston','Texans',1,3);
insert into team (location,teamName, conference,division) values ('Jacksonville','Jaguars',1,3);
​
insert into team (location,teamName, conference,division) values ('Kansas City','Chiefs',1,4);
insert into team (location,teamName, conference,division) values ('Las Vegas','Raiders',1,4);
insert into team (location,teamName, conference,division) values ('Los Angeles','Chargers',1,4);
insert into team (location,teamName, conference,division) values ('Denver','Broncos',1,4);
​
​
insert into team (location,teamName, conference,division) values ('Green Bay','Packers',2,1);
insert into team (location,teamName, conference,division) values ('Chicago','Bears',2,1);
insert into team (location,teamName, conference,division) values ('Minnesota','Vikings',2,1);
insert into team (location,teamName, conference,division) values ('Detroit','Lions',2,1);
​
insert into team (location,teamName, conference,division) values ('Washington',' ',2,2);
insert into team (location,teamName, conference,division) values ('New York','Giants',2,2);
insert into team (location,teamName, conference,division) values ('Dallas','Cowboys',2,2);
insert into team (location,teamName, conference,division) values ('Philadelphia','Eagles',2,2);
​
insert into team (location,teamName, conference,division) values ('New Orleans','Saints',2,3);
insert into team (location,teamName, conference,division) values ('Tampa Bay','Buccaneers',2,3);
insert into team (location,teamName, conference,division) values ('Carolina','Panthers',2,3);
insert into team (location,teamName, conference,division) values ('Atlanta','Falcons',2,3);
​
insert into team (location,teamName, conference,division) values ('Seattle','Seahawks',2,4);
insert into team (location,teamName, conference,division) values ('Los Angeles','Rams',2,4);
insert into team (location,teamName, conference,division) values ('Arizona','Cardinals',2,4);
insert into team (location,teamName, conference,division) values ('San Fancisco','49ers',2,4);
--------------------------
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values
	('Baker','Mayfield',(select teamid from team where teamname = 'Browns'),'1/1/1995','QB')
	,('Nick','Chubb',(select teamid from team where teamname = 'Browns'),'1/1/1996','RB')
	,('Myles','Garrett',(select teamid from team where teamname = 'Browns'),'1/1/1994','DE')
	,('Denzel','Ward',(select teamid from team where teamname = 'Browns'),'1/1/1993','CB')
	,('Jarvis','Landry',(select teamid from team where teamname = 'Browns'),'1/1/1992','WR')
	,('Rashard','Higgins',(select teamid from team where teamname = 'Browns'),'1/1/1991','WR')
	,('David','Njoku',(select teamid from team where teamname = 'Browns'),'1/1/1990','TE')
	,('Sione','Takitaki',(select teamid from team where teamname = 'Browns'),'1/1/1990','LB')
	,('Sheldon','Richardson',(select teamid from team where teamname = 'Browns'),'1/1/1990','DT')
	,('JC','Tretter',(select teamid from team where teamname = 'Browns'),'1/1/1990','C')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values
	('James','Conner',(select teamid from team where teamname = 'Steelers'),'1/1/1995','RB')
	,('JuJu','Smith-Schuster',(select teamid from team where teamname = 'Steelers'),'1/1/1998','WR')
	,('TJ','Watt',(select teamid from team where teamname = 'Steelers'),'1/1/1997','LB')
	,('Ben','Roethlisberger',(select teamid from team where teamname = 'Steelers'),'1/1/1988','QB')
	,('James','Washington',(select teamid from team where teamname = 'Steelers'),'1/1/1997','WR')
	,('Joe','Haden',(select teamid from team where teamname = 'Steelers'),'1/1/1996','CB')
	,('Minkah','Fitzpatrick',(select teamid from team where teamname = 'Steelers'),'1/1/1995','S')
	,('Cameron','Heyward',(select teamid from team where teamname = 'Steelers'),'1/1/1994','DT')
	,('Alejandro','Villanueva',(select teamid from team where teamname = 'Steelers'),'1/1/1993','T')
;
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values 
	('Lamar','Jackson',(select teamid from team where teamname = 'Ravens'),'1/1/1995','QB')
	,('Dez','Bryant',(select teamid from team where teamname = 'Ravens'),'1/1/1996','WR')
	,('J.K.','Dobbins',(select teamid from team where teamname = 'Ravens'),'1/1/1997','RB')
	,('Mark','Andrews',(select teamid from team where teamname = 'Ravens'),'1/1/1998','TE')
	,('Justin','Tucker',(select teamid from team where teamname = 'Ravens'),'1/1/1998','K')
	,('Orlando','Brown',(select teamid from team where teamname = 'Ravens'),'1/1/1988','T')
	,('Sam','Koch',(select teamid from team where teamname = 'Ravens'),'1/1/1988','P')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values 
	('Joe','Burrow',(select teamid from team where teamname = 'Bengals'),'1/1/1995','QB')
	,('A.J.','Green',(select teamid from team where teamname = 'Bengals'),'1/1/1996','WR')
	,('Joe','Mixon',(select teamid from team where teamname = 'Bengals'),'1/1/1997','RB')
	,('Tyler','Boyd',(select teamid from team where teamname = 'Bengals'),'1/1/1998','WR')
	,('Jonah','Williams',(select teamid from team where teamname = 'Bengals'),'1/1/1998','T')
	,('Vonn','Bell',(select teamid from team where teamname = 'Bengals'),'1/1/1988','S')
	,('Giovani','Bernard',(select teamid from team where teamname = 'Bengals'),'1/1/1988','RB')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values
	('CJ','Mosley',(select teamid from team where teamname = 'Jets'),'1/1/1992','LB')
	,('Frank','Gore',(select teamid from team where teamname = 'Jets'),'1/1/1987','RB')
	,('Jamison','Crowder',(select teamid from team where teamname = 'Jets'),'1/1/1996','WR')
	,('Sam','Darnold',(select teamid from team where teamname = 'Jets'),'1/1/1992','QB')
	,('George','Fant',(select teamid from team where teamname = 'Jets'),'1/1/1994','T')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values 
	('Jamal','Adams',(select teamid from team where teamname = 'Seahawks'),'1/1/1995','S')
	,('Russell','Wilson',(select teamid from team where teamname = 'Seahawks'),'1/1/1988','QB')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values 
	('Aaron','Donald',(select teamid from team where teamname = 'Rams'),'1/1/1994','DE')
	,('Cam','Akers',(select teamid from team where teamname = 'Rams'),'1/1/1994','RB')
	,('Darrell','Henderson',(select teamid from team where teamname = 'Rams'),'1/1/1997','RB')
	,('Cooper','Kupp',(select teamid from team where teamname = 'Rams'),'1/1/1994','WR')
;
​
insert into player (FirstName,LastName,TeamId,BirthDate,Position) values 
	('Drew','Brees',(select teamid from team where teamname = 'Saints'),'1/1/1981','QB')
	,('Alvin','Kamara',(select teamid from team where teamname = 'Saints'),'1/1/1995','RB')
	,('Michael','Thomas',(select teamid from team where teamname = 'Saints'),'1/1/1997','WR')
	,('Marshon','Lattimore',(select teamid from team where teamname = 'Saints'),'1/1/1995','WR')
	,('Demario','Davis',(select teamid from team where teamname = 'Saints'),'1/1/1992','LB')
	,('Malcom','Jenkins',(select teamid from team where teamname = 'Saints'),'1/1/1995','S')
	,('Jameis','Winston',(select teamid from team where teamname = 'Saints'),'1/1/1995','QB')
;


