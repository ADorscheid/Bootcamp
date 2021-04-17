
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the World_Test Database (IF EXISTS)
DROP DATABASE IF Exists World_Test;
GO

-- Create a new World_Test Database
CREATE DATABASE World_Test;
GO

-- Switch to the World_Test Database
USE World_Test
GO

/**********************************************************************/
CREATE TABLE Country (
    Code character(3) NOT NULL,
    Name NVARCHAR(64) NOT NULL,
    Continent varchar(64) NOT NULL,
    Region NVARCHAR(64) NOT NULL,
    SurfaceArea real NOT NULL,
    IndepYear smallint,
    Population integer NOT NULL,
    LifeExpectancy real,
    GNP numeric(10,2),
    GNPOld numeric(10,2),
    LocalName varchar(64) NOT NULL,
    GovernmentForm varchar(64) NOT NULL,
    HeadOfState varchar(64),
    Capital integer,
    Code2 character(2) NOT NULL,
    CONSTRAINT pk_country_code PRIMARY KEY (Code),
    CONSTRAINT country_continent_check CHECK ((Continent = 'Asia') OR (Continent = 'Europe') OR (Continent = 'North America') OR (Continent = 'Africa') OR (Continent = 'Oceania') OR (Continent = 'Antarctica') OR (Continent = 'South America'))
);

CREATE TABLE City (
    CityId integer NOT NULL IDENTITY(1,1),
    Name NVARCHAR(64) NOT NULL,
    CountryCode character(3) NOT NULL,
    District NVARCHAR(64) NOT NULL,
    Population integer NOT NULL,
    CONSTRAINT pk_city_id PRIMARY KEY (CityId),
    CONSTRAINT fk_countrycode FOREIGN KEY (CountryCode) REFERENCES Country(Code)
);

CREATE TABLE Language
(
    LanguageId INT NOT NULL PRIMARY KEY Identity, 
    LanguageName NVARCHAR(50) NOT NULL
)

CREATE TABLE CountryLanguage (
    CountryCode character(3) NOT NULL,
    LanguageId int,
    IsOfficial bit NOT NULL,
    Percentage real NOT NULL,
    CONSTRAINT pk_countrylanguage PRIMARY KEY (CountryCode, LanguageId),
    CONSTRAINT fk_countrylanguage_country FOREIGN KEY (CountryCode) REFERENCES Country(Code),
    CONSTRAINT fk_countrylanguage_language FOREIGN KEY (LanguageId) REFERENCES Language(LanguageId)
);

-- Add the FK for Country-Capital to City-CityId
ALTER TABLE Country
    ADD constraint fk_countryCapital FOREIGN KEY (Capital) REFERENCES City(CityId)

