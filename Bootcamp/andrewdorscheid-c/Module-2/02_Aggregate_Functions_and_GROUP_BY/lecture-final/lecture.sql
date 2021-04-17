/*************************************************************************************
	Some additional queries from yesterday
*************************************************************************************/

-- The name and region of all countries in North or South America.  HOW MANY ways can we do this?
Select name, region, continent
	from Country
	Where continent = 'North America' OR Continent = 'South America'

Select name, region, continent
	from Country
	Where continent in ('North America', 'South America')

Select name, region, continent
	from Country
	Where continent like '%America'	-- Values that would "pass" this filter: 'America', 'North America'. Values that would NOT pass: 'American'

-- The name, continent, and head of state of all countries whose form of government is a monarchy
Select name, continent, HeadOfState, GovernmentForm
	From Country
	where GovernmentForm like '%monarchy%'


-- The name and region of all countries in North or South America except for countries in the Caribbean

-- The name, population, and GNP of all countries with a GNP greater than $1 trillion dollars and a population of less than 1 billion people

-- The names of all the US States
Select Distinct District
	From City
	where CountryCode = 'USA'


/*************************************************************************************
*************************************************************************************/

-- ORDERING RESULTS

-- Order cities by country, then by the name of the city
Select name, countryCode
	From city
	order by countryCode desc, name desc

-- Populations of all countries in descending order
Select Name, Population
	From Country
	Order by Population desc

--Names of countries and continents in ascending order
Select Name, Continent
	From Country
	--Order by Name
	Order By Continent, Name


-- LIMITING RESULTS (TOP)
-- The name and life expectancy of the countries with the 10 highest life expectancies.
Select top(10) name, LifeExpectancy
	From Country
	Order By LifeExpectancy DESC

-- ISNULL example

Select Name, IsNull(Cast (IndepYear as varchar(15)), 'Not Independent')
From Country
Order By IndepYear



-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select Name + ', ' + District
	From City
	Where district in ('California', 'Oregon', 'Washington')
	Order By District, Name


-- Can you do it another way?


-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
Select Avg(LifeExpectancy)
	From Country
	--Where Continent = 'Africa'

-- Total population in Ohio
Select Sum(Population) As TotalPopulation
	From City
	Where District = 'Ohio'
		And countryCode = 'USA'

-- The surface area of the smallest country in the world
Select Min(SurfaceArea), Max(SurfaceArea)
	From Country

-- Another way (so we can get the name also)
Select Top 1 Name, SurfaceArea
	From Country
	Order By SurfaceArea ASC


-- The 10 largest countries in the world
Select Top 10 Name, SurfaceArea
	From Country
	Order By SurfaceArea DESC

-- The number of countries who declared independence in 1991
Select Count(*) As NumCountries
	From Country
	Where IndepYear = 1991


-- GROUP BY

-- Africa			88
-- Asia				77
-- North America	66


-- Average life expectancy of each continent ordered from highest to lowest
Select Continent, Avg(LifeExpectancy) As AverageLifeExpectancy
	From Country
	Group By Continent
	Order By AverageLifeExpectancy Desc

-- Exclude Antarctica from consideration for average life expectancy
Select Continent, Avg(LifeExpectancy) As AverageLifeExpectancy
	From Country
	--Where LifeExpectancy Is Not NULL
	Where Continent != 'Antarctica'
	Group By Continent
	Order By AverageLifeExpectancy Desc

-- Sum of the population of cities in each state in the USA ordered by state name
Select district As State, Sum(Population) As SumPopulation
	From City
	Where CountryCode = 'USA'
	Group By District
	Order By District

-- The average population of cities in each state in the USA ordered by state name
Select district As State, Sum(Population) As SumPopulation, Avg(Population) As AveragePopulation
	From City
	Where CountryCode = 'USA'
	Group By District
	Order By District

-- Count the number of languages spoken in each country, ordered from most languages to least

Select CountryCode, Count(*) As LanguageCount
from CountryLanguage
Group By CountryCode
Order By LanguageCount desc

-- Show the total populations of all districts in the world, ordered by Country and District

--CAN New Brunswick 9999999
--CAN Ontario 4444444
--USA New York 8888888
--USA Ohio 54545455

Select CountryCode, District, Sum(Population)
From City
Group By CountryCode, District
Order by CountryCode, District




-- SUBQUERIES
-- Find the names of cities under a given government leader
-- 'George W. Bush'

-- First find the countries under this leader
Select *
	from Country 
	where HeadOfState = 'George W. Bush'

-- Now find the cities in these countries
Select *
	From City
	Where CountryCode in ('ASM', 'GUM', 'MNP','PRI','UMI','USA','VIR')

-- Use a SUB-QUERY to accomplish the above

Select *
	From City
	Where CountryCode in (Select Code from Country where HeadOfState = 'George W. Bush')

Select Concat(name, ' ', district) [City-State] from City

-- Examples of Count

-- How many countries are there?
Select count(*) from Country

-- How many countries in Asia?
Select Count(*) from Country Where Continent = 'Asia'

-- How many countries are on each continent?
Select Continent, Count(*) from Country Group By Continent

-- How many countries are independent?
Select Count(*) from Country where IndepYear is not null

-- How many countries are independent? (Another way)
Select Count(IndepYear) from Country

-- How many countries in Africa are independent? (Another way)
Select Count(IndepYear) from Country Where continent = 'Africa'




-- Find the names of cities whose country they belong to has not declared independence yet

-- Select those countries with lower than average life expectancy

-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
