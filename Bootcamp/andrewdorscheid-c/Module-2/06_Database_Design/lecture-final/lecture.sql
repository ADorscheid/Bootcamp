-- Use master so that we are not "sitting" in the Art datbaaee
Use master
GO

-- Drop the database to start from scratch
Drop Database If Exists ArtGallery


-- Create a new empty database
Create Database ArtGallery

Use ArtGallery


-- Start a transaction so the create process is ALL or NOTHING
Begin Transaction

/*********************** Create Tables *****************************/

-- First create any tables with no foreign keys

-- Address
Create Table Address(
	AddressId int identity(1,1),
	Street nvarchar(100),
	City nvarchar(50),
	State nvarchar(50),
	PostalCode nvarchar(10),
	Constraint PK_Address Primary Key (AddressId)
)

-- Customer
Create Table Customer(
	CustomerId int identity(1,1),
	CustomerName nvarchar(100) not null,
	Phone varchar(20) null,
	Constraint PK_Customer Primary Key (CustomerId),
)

-- Artist
Create Table Artist (
--	ArtistId int Identity(1000, 10),	-- 1000 is starting number, 10 is increment
	ArtistId int Identity(1,1),	
	ArtistName nvarchar(50) Not Null,
	AddressId int Null,
	Phone varchar(20),
	Constraint PK_Artist Primary Key (ArtistId),
	Constraint FK_Artist_Address Foreign Key (AddressId) References Address(AddressId)
)

-- Painting
Create table Painting (
	PaintingId int identity(1,1),
	ArtistId int not null,
	Title nvarchar(100) not null,
	AskingPrice money null,
	Constraint PK_Painting Primary Key (PaintingId),
	Constraint FK_Painting_Artist Foreign Key (ArtistId) References Artist(ArtistId)
)

-- Transaction
Create Table ArtTransaction(
	ArtTransactionId int identity(1,1),
	TransactionType varchar(8) not null,
	CustomerId int not null,
	PaintingId int not null,
	TransactionDate datetime not null Default(getdate()),
	Price money not null,
	Constraint PK_ArtTransaction Primary Key (ArtTransactionId),
	Constraint FK_ArtTransaction_Customer Foreign Key (CustomerId) References Customer(CustomerId),
	Constraint FK_ArtTransaction_Painting Foreign Key (PaintingId) References Painting(PaintingId),
	Constraint CK_ArtTransction_TransactionType Check (TransactionType IN('sale', 'purchase')),
)

-- CustomerAddress
Create Table CustomerAddress(
	CustomerId int,
	AddressId int,
	Constraint PK_CustomerAddress Primary Key (CustomerId, AddressId),
	Constraint FK_CustomerAddress_Customer Foreign Key (CustomerId) References Customer(CustomerId),
	Constraint FK_CustomerAddress_Address Foreign Key (AddressId) References Address(AddressId),

)

/*********************** Insert some test data *****************************/

-- Address
Insert Into Address (Street, City, State, PostalCode)
	Values('123 4th Avenue', 'Fonthill', 'ON', 'L3J 4S4')
-- Customer
Insert Into Customer(CustomerName, Phone)
	Values('Elizabeth Jackson', '2060284-6783')
--CustomerAddress
Insert Into CustomerAddress(CustomerId, AddressId)
	Values(1,1)
-- Artist
Insert Into Artist(ArtistName) Values
	('Carol Channing'),	-- 1
	('Dennis Frings')	-- 2
-- Painting
Insert Into Painting (ArtistId, Title, AskingPrice) Values
	(1, 'Laugh with Teeth', 10000),				-- 1
	(2, 'South toward Emerald Sea', 3000),		-- 2
	(1, 'At the Movies', 7000)					-- 3
-- Transactions
Insert into ArtTransaction(TransactionType, CustomerId, PaintingId, TransactionDate, Price) Values
	('sale', 1, 1, '2000-09-17', 7000),
	('sale', 1, 2, '2000-05-11', 1800),
	('sale', 1, 3, '2002-02-14', 5500),
	('sale', 1, 2, '2003-07-15', 2200)

-- Complete the transaction
Commit Transaction

