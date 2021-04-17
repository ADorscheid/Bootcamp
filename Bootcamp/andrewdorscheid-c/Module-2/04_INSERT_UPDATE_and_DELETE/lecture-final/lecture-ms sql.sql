Select * from City Where District = 'Ohio'

-- INSERT
-- 1. Add a city to the City table, district 'Ohio'
Insert into City (Name, CountryCode, District, Population)
	Values('Richfield', 'USA', 'Ohio', 12000);

-- 1a. What is the @@Identity? (4080)
Select @@IDENTITY

-- 2. Add 2 more cities to Ohio using one insert statement
Insert Into City (Name, CountryCode, District, Population)
	Values
	('Cleveland Heights', 'USA', 'Ohio', 43000),
	('Lakewood', 'USA', 'Ohio', 50000)

-- 2a. What is the @@Identity? (4082)
Select @@IDENTITY

-- 0. Add Klingon to the Language table
	Insert Language (LanguageName)
	Values ('Klingon')

-- 0a. What is the @@Identity? (458)
	Select @@IDENTITY

-- 1. Add Klingon as a spoken language in the USA
	Insert  CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
		Values('USA', 458, 0, 12.0)

		-- Languages of the USA:
		Select *
			From CountryLanguage cl 
			Join Language l on cl.LanguageId = l.LanguageId
			Where cl.CountryCode = 'USA'

-- 2. Add Klingon as a spoken language in Great Britain (GBR)
	Insert Into CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
		Values('GBR', (Select LanguageId from Language where LanguageName = 'Klingon'), 1, 32.0)

		-- Languages of the GBR:
		Select *
			From CountryLanguage cl 
			Join Language l on cl.LanguageId = l.LanguageId
			Where cl.CountryCode = 'GBR'



-- UPDATE

-- 0. Update the population of Cleveland to 2020 values (379,233)
Update City
	Set Population = 379233	Where Name = 'Cleveland'

-- 1. Update the capital of the USA to Houston
Select * from City where Name = 'Houston'

Select * from COuntry where Code = 'USA'

Update Country
	Set Capital = (Select CityId from City where Name = 'Houston')
	Where Code = 'USA'


-- 2. Update the capital of the USA to Washington DC and the head of state
Update Country
	Set Capital = (Select CityId from City where Name = 'Washington'),
		HeadOfState = 'Joe Biden'
	Where Code = 'USA'

-- DELETE

-- 0. Delete the newly added Ohio cities
Delete from City Where Name = 'Richfield' And District = 'Ohio'
Delete from City Where Name in ('Richfield', 'Lakewood', 'Cleveland Heights') And District = 'Ohio'


-- 1. Delete English as a spoken language in the USA
Delete from CountryLanguage Where CountryCode = 'USA' and LanguageId = (Select LanguageId from Language Where LanguageName = 'Klingon')

-- 2. Delete all occurrences of the Klingon language 
Delete from CountryLanguage Where LanguageId = (Select LanguageId from Language Where LanguageName = 'Klingon')
Delete from  Language Where LanguageName = 'Klingon'


-- REFERENTIAL INTEGRITY

-- 1. Add a city to the City table in the country 'ZZZ'
Insert into City (Name, CountryCode, District, Population)
	Values('Richfield', 'ZZZ', 'Ohio', 12000);


-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?
Delete Country Where Code = 'USA'


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
Update Country 
	Set Continent = 'Outer Space'
	Where Code = 'USA'



-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

Begin Transaction
	Delete From CountryLanguage
	Select * from CountryLanguage
Rollback Transaction

Select * from CountryLanguage


select * from CountryLanguage
rollback tran


-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.