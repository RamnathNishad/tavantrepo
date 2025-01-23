use empdb;

--creating table
create table employee
(
	ecode int primary key,
	ename varchar(25),
	salary int,
	deptid int
)


select * from employee

--adding records
insert into employee values(101,'Ravi',1111,201);
insert into employee values(102,'John',2222,202);
insert into employee values(103,'Tom',3333,203);
insert into employee values(104,'David',4444,203);
insert into employee values(105,'Shyam',5555,202);

select * from employee;

--adding multiple records with single INSERT statement
insert into employee values(106,'Suresh',6666,201),
							(107,'Iyan',7777,202);

--deleting records
--a) deleting selected records
delete from employee where ecode=105

--b) unconditional delete (be sure as it deleted all the data)
delete from employee   --can be rolled back, i.e. soft delete

--truncate 
truncate employee  -- hard delete , cannot be rolled back

--drop table employee   : it drops data along with structure also

--updating records
--a) conditional update
UPDATE employee SET salary=salary + 1000 WHERE ecode=101
--b) unconditional update
UPDATE employee SET salary=salary + 1000

--updating more than one column values
UPDATE employee SET salary=50000,deptid=206 WHERE ecode=101

--insert only few column values
insert into employee(ecode,ename) values(105,'Ramnath')

--displaying computed values like bonus of a salary
select ecode,ename,salary,deptid,salary*0.1 as Bonus from employee

--sorting the records
select * from employee order by salary desc

--select records with null column
select * from employee where salary is not null


select * from employee

