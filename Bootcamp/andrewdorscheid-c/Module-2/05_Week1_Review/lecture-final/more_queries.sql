-- *********** Sub-queries *************

-- List the cites that are in the 5 smallest countries in the world

	-- Find the 5 smallest countries
	Select Top 5 *
		From Country
		Order By SurfaceArea

	-- Above result is VAT, MCO, GIB, TKL, CCK
	-- Now get a list of cities in these countries
	Select *
		From City
		Where CountryCode in ('VAT', 'MCO', 'GIB', 'TKL', 'CCK')

	Select *
		From City
		Where CountryCode in (Select Top 5 Code From Country Order By SurfaceArea)

	-- Can I do this with a JOIN?
	Select Top 7 *
		From City ci
		Join Country co on co.Code = ci.CountryCode
		Order By SurfaceArea

-- *********** Transactions *************
-- Swap cities between USA and GBR
 -- BEGIN TRAN
 -- Create some dummy country ZZZ
 -- Update set  cc = ZZZ where cc = USA
 -- Update set cc = USA where cc = GBR
 -- Update set cc = GBR where cc = ZZZ
 -- Delete country ZZZ
 -- COMMIT TRAN


-- *********** UNION *************
-- I wonder how the world's largest cities stack up against entire countries?
-- Get the name, population, and whether it is a city or a country, order by population descending
Select Name, Population, '' As 'Is City' from Country
--Order By Population desc
Union
Select Name, Population, 'Yes' from City
Order By Population desc



-- *********** SELF_REFERENCING Constraints *************
Create table Employee (
	emp_id int identity primary key,
	name varchar(30),
	supervisor_id int null,
	constraint fk_supervisor Foreign Key (supervisor_id) references Employee (emp_id)
)

Insert into Employee (name, supervisor_id)
	values ('Ben', null)

Insert into Employee (name, supervisor_id)
	values ('Mike', 1)
Insert into Employee (name, supervisor_id)
	values ('Rosa', 1)
Insert into Employee (name, supervisor_id)
	values ('Luci', 1)
Insert into Employee (name, supervisor_id)
	values ('Robin', 4)

Select * from Employee

-- Tell me the name of Rosa's boss
Select emp.name, sup.name
	From Employee emp
	Join Employee sup on emp.supervisor_id = sup.emp_id
	Where emp.name = 'Rosa'




-- *********** SELF-JOINS *************
/***
***** List every city, alongside the capital city for the country this city is in.
e.g.:
Los Angeles		USA		Washington
New York		USA		Washington
Barcelona		ESP		Madrid
Madrid			ESP		Madrid
***/ 
-- List the city, its country, and the capital city for that country.



-- ******** SELF-JOIN ***************
-- An Example of joining a table to itself, AND
-- An Example of joining to columns other than the PK

-- List each US city along with the other cities in that state.
