-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
USE [dvdstore]
GO

INSERT INTO [dbo].[film]
           ([title]
           ,[description]
           ,[release_year]
           ,[language_id]
           ,[original_language_id]
           ,[length]
		   )
     VALUES
           ('Euclidean PI'
           ,'The epic story of Euclid as a pizza delivery boy in ancient Greece'
           ,2008
           ,(Select language_id from language where name = 'English')
           ,(Select language_id from language where name = 'English')
           ,198
		   )
GO


-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

-- 4. Add Mathmagical to the category table.

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

-- 7. Add a copy of "Euclidean PI" to all the stores.
Select * from store

Insert into inventory (film_id, store_id)
	values
		(1001, 1),
		(1001, 2)
Select *  from inventory where film_id = 1001

Insert into inventory (film_id, store_id)
	Select 
		(Select film_id from film where title = 'Euclidean PI'), 
		store_id 
		From store

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
Delete from film where title = 'Euclidean PI'

-- <YOUR ANSWER HERE>

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <YOUR ANSWER HERE>

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <YOUR ANSWER HERE>

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
SELECT * FROM INFORMATION_SCHEMA.TABLES
SELECT * FROM INFORMATION_SCHEMA.COLUMNS
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where TABLE_NAME = 'customer'
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS

