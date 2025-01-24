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


--
select * 
from employee 
order by salary,ecode desc

---grouping and group functions
select sum(salary) as TotalSalary,
avg(nullif(salary,0)) as AvgSalary,
max(salary) as MaxSalary,
min(salary) as MinSalary,
count(nullif(salary,0)) as NoOfEmps
from employee

select sum(salary) as TotalSalary,
avg(salary) as AvgSalary,
max(salary) as MaxSalary,
min(salary) as MinSalary,
count(salary) as NoOfEmps
from employee

--group by 
select deptid,sum(salary) as TotalSalary,
avg(coalesce(salary,0)) as AvgSalary,
max(salary) as MaxSalary,
min(salary) as MinSalary, ---2
count(coalesce(salary,0)) as NoOfEmps
from employee
where deptid>201 ---0
group by deptid    ---1
having avg(coalesce(salary,0))>4000  ---3
order by avg(coalesce(salary,0)) desc ---4

--Note: in GROUP BY query , we can only use either group functions 
--and/or group column. other than this column it is not allowed
--group functions i


select ecode,coalesce(salary,0) as salary from employee
--Note: coalesce(expr1,expr2) will return first NOT NULL value
--from the list. This can be used in group functions to 
--include the null records if needed as group functions
--ignores the null values. for e.g. count() and avg() may
--affect the result due null values


--Operators
+,-,*,/,<,>,<=,>=,!=

--string pattern matching
lIKE ---- 
%  for multiple charcter
-- underscore(_) for single character

--find the employees whose name starts with 'R'
select * from employee where ename like 'R%'

--find the employees whose name starts with 'R' having total 4 characters 
select * from employee where ename like 'R___'

--find the employees whose name contain 'R'  
select * from employee where ename like '%a%'

--Working with Date data-type
--1. NOW()
select now() --displays current and time

create table orders
(
order_id serial primary key,
order_date date,
quantity int
)
insert into orders(order_date,quantity) values(now(),5000)

insert into orders(order_date,quantity) values('2025-01-15',3000)

--2) AGE() calculates the difference between two dates
select AGE(now(),'2025-01-10') as age_diff

--3) EXTRACT() used for extracting parts of the date 
--like year,month,day
select EXTRACT(YEAR FROM now()) as month

--4) TO_CHAR() used for formatting the date and time output
select to_char(now(),'DD/MM/YYYY') as date


----working with BOOLEAN type--------------
--used for flag or status value which acepts TRUE,FALSE and NULL
--It also support other literals like
--true/false
--'t'/'f'
--'yes'/'no'
--'y'/'n'
--'1'/'0'

drop table test
create table test
(
 id int,
 price numeric(5,2)
)
insert into test values(1,true);
insert into test values(2,'1');
insert into test values(3,'t');
insert into test values(4,'y');
insert into test values(5,'yes');

---NUMERIC data-type----
NUMERIC(precision,scale)

e.g. NUMERIC(5,2)-----3 precision and 2 scale
		123.01

insert into test values(3,123.047)

--TIME formats 
drop table test
create table test
(
id int,
time_val time
)

insert into test values(1,now())


insert into test values(2,'01:02')
insert into test values(3,'01:02:50');
insert into test values(4,'010250')


---JSON data-type--
drop table test
create table test
(
 id serial primary key,
 info json
)

insert into test(info) values(
 '{
	"customer":"John",
	"items":
	{"product":"coffee","qty":6}
 }'
);

select info->'items' 
from test
where info->'items'->>'product'='coffee'


select * from test

select * from test



select * from orders




