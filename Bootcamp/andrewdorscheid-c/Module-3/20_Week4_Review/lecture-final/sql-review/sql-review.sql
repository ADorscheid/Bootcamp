create table person (
	id int,
	name varchar(20)
);
insert into person (id, name) values (1, 'Luci');
insert into person values (2,'Aklile');
select count(*) from person;
create table person_car (
	person_id int,
	model varchar(20)
);
insert into person_car values (1,'Tesla');
select * from person_car;
----------------------------
--shows all on the left and data/nulls from the right
select * from person left join person_car pc on person.id = pc.person_id;
--shows only things in the left that have a match on the right
select * from person join person_car pc on person.id = pc.person_id;
--all the people that do not have a car
select * from person_car;   --1 record, 1 person/car 
select * from person WHERE id not in (select person_id from person_car);
select * from person left join person_car pc on person.id = pc.person_id WHERE pc.model IS null;