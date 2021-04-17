--use World_Test
--Go

-- This script will be run before every integration test to establisdh the
-- database into a known state.

-- First, remove all data from the tables
-- We have to null all the capitals first, so we do not have dual references between city and country
Update Country Set Capital = null
delete from CountryLanguage
delete from City
delete from Country
delete from Language


-- Insert rows into Language
Insert into Language(LanguageName) Values
	('English'),
	('Javascript'),
	('Elvish')

-- Insert rows into COuntry
INSERT INTO [dbo].[Country]
           ([Code]
           ,[Name]
           ,[Continent]
           ,[Region]
           ,[SurfaceArea]
           ,[IndepYear]
           ,[Population]
           ,[LifeExpectancy]
           ,[GNP]
           ,[GNPOld]
           ,[LocalName]
           ,[GovernmentForm]
           ,[HeadOfState]
           ,[Capital]
           ,[Code2])
     VALUES
           ('USA', 'United States', 'North America', '', 100000, 1776, 1000000, 80, null, null, 'United States', 'Kingdom', 'Mickey Mouse', null, 'US'),
           ('CAN', 'Canada', 'North America', '', 200000, null, 2000000, 60, null, null, 'Canada', 'Kingdom', 'Daffy Duck', null, 'CA'),
           ('GBR', 'United Kingdom', 'Europe', '', 200000, 1066, 2000000, 60, null, null, 'England', 'Kingdom', 'Daffy Duck', null, 'UK')

-- Insert rows into Country-Language
Insert into CountryLanguage(CountryCode, LanguageId, IsOfficial, Percentage) Values
	('USA',(Select LanguageId from Language Where LanguageName = 'English'), 0, 75.0),
	('USA',(Select LanguageId from Language Where LanguageName = 'Javascript'), 1, 55.0),
	('CAN',(Select LanguageId from Language Where LanguageName = 'Elvish'), 1, 95.0),
	('GBR',(Select LanguageId from Language Where LanguageName = 'English'), 0, 53.0),
	('GBR',(Select LanguageId from Language Where LanguageName = 'Elvish'), 1, 85.0)

-- Insert rows into City
Insert into City (Name, CountryCode, District, Population) Values
	('Cleveland', 'USA', 'Ohio', 10000),
	('Mayberry', 'USA', 'North Carolina', 20000),
	('Toronto', 'CAN', 'Ontario', 10000),
	('London', 'GBR', '', 10000)

-- Set the Capital Cities
Update Country Set Capital = (Select CityId from City Where Name = 'Cleveland') Where Code = 'USA'
Update Country Set Capital = (Select CityId from City Where Name = 'Toronto') Where Code = 'CAN'
Update Country Set Capital = (Select CityId from City Where Name = 'London') Where Code = 'GBR'


