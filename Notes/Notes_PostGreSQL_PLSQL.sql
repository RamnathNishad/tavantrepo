--======================PL/SQL=============================
It is a block of statements combined with SQL and some programming
constructs to peform some task in database. These blocks can be 
anonymous or can be stored in database with sime names like
stored procedures,functions, triggers which can be called as and when
needed by the users or applications.

--declaring variables 
	var_name data-type:=value;

DO
$$
DECLARE
--all variables are declared 
BEGIN
--statemenst and logic 	
END$$;

e.g.
DO $$
DECLARE
	first_name VARCHAR(20):='Ramnath';
	last_name VARCHAR(20):='Nishad';
BEGIN
	RAISE NOTICE 'First Name:%, Last Name: % ',first_name,last_name;
END $$;

--Stored procedures vs User-defined: Stored procedure perform
--some task and do not return anything so no RETURN statement
--is used inside the SP whereas functions return a value using
--RETURN statement and also declare return type of the 
--function.

create or replace function fn_name(param1 data-type) returns int
as 
$$
DECLARE

BEGIN

 RETURN value;
END;
$$

e.g. define a function to add two numbers and return the sum

create or replace function fn_add_numbers(num1 int,num2 int)
returns int
as $$
declare 
	result int;
begin	
    result:=num1 + num2;
	return result;
end;
$$ language plpgsql;


--call the function
DO $$
declare
	num1 int:=100;
	num2 int:=200;
	result int;
begin
	result:=fn_add_numbers(num1,num2);
	raise notice 'sum of % and % is %',num1,num2,result;
END;
$$

--define a functions get_bonus which accepts salary and 
--returns 10% of salary as bonus
create or replace function get_bonus(salary int)
returns numeric(10,2)
as
$$
declare 
	bonus numeric(10,2);
begin
	bonus:=0.1*salary;
	return bonus;
end;
$$ language plpgsql;


--test the function
select get_bonus(5000) as bonus;

--test the function on table records
select ecode,salary,get_bonus(salary) as Bonus from employee;
-----Simple IF statement----

create or replace function get_bonus(salary int)
returns numeric(10,2)
as
$$
declare 
	bonus numeric(10,2);
begin
	if salary>5000 then
		bonus:=0.1*salary;
	else
		bonus:=0.2*salary;
	end if;	
	return bonus;
end;
$$ language plpgsql;


select get_bonus(7000) as bonus;

----using CASE statements-------------
--1)simple CASE statement:- direct value is compared
--2) Search expression CASE statement:- some expression is compared

--example of Simple CASE statement:-
create or replace function get_bonus(salary int,deptid int) returns numeric(10,2)
as
$$
declare
	bonus numeric(10,2);
begin
	case deptid
		when 201 then bonus:=0.1*salary;
		when 202 then bonus:=0.2*salary;
		else bonus:=0;
	end case;

	return bonus;
end;
$$ language plpgsql;



---CASE with searched expression----
--example of searched expression CASE statement:-
create or replace function get_bonus(salary int) returns numeric(10,2)
as
$$
declare
	bonus numeric(10,2);
begin
	case 
		when salary>5000 and salary<10000 then bonus:=0.1*salary;
		when salary>=10000 and salary<50000 then bonus:=0.2*salary;
		else bonus:=0;
	end case;

	return bonus;
end;
$$ language plpgsql;



--example of Simple CASE statement with data from table:-
drop function get_bonus(int);

create or replace function get_bonus(ec int) returns numeric(10,2)
as
$$
declare
	bonus numeric(10,2);
	sal int;
	did int;
begin
	--get the employee salary and deptid from table
	select salary,deptid into sal,did from employee where ecode=ec;
	case did
		when 201 then bonus:=0.1*sal;
		when 202 then bonus:=0.2*sal;
		else bonus:=0;
	end case;

	return bonus;
end;
$$ language plpgsql;



--test 
select get_bonus(25000) as bonus;
select ecode,salary,deptid,get_bonus(ecode) as bonus 
from employee;

------Loop statement-----
Loop 
---
Exit when condition
---
End Loop;

eg. 
do $$
declare 
	counter int:=0;
begin
	loop
		counter:=counter + 1;		
		exit when counter>10;
		raise notice '%',counter;
	end loop;
end;
$$;

---------WHILE loop-----
--add numbers upto 10
do $$
declare 
	sum integer:=0;
	i integer:=0;
begin	
while i<=10 
loop
	sum:=sum + i;
	i:=i+1;
end loop;
raise notice 'sum of numbers upto 10 is %',sum;
end $$;


-----Types of functions based on return values-----
--1) Scaler-valued functions:-these functions return rimitive single value
--like int,char,decimal etc
--2) Table-valued functions:- These functions return TABLE tyoe
--and should return a query statement result

drop function get_emps_by_did(int);

create or replace function get_emps_by_did(did int)
returns table(ec int,sal int,dept_id int) language plpgsql
as
$$
begin
	return query select ecode,salary,deptid 
	from employee where deptid=did;
end;$$


--test the table-valued functions
select * from get_emps_by_did(202);


-----parameter modes or directions-------------
--a)IN :- default mode i.e. u can only pass it and any modification to th e
--passed parameters will not retained after exiting the block.
--b) OUT:- it will retain the modifications out of the block
--c) INOUT:- u can assign the value and also retain the changes
--out of the block.

drop function calculate_bonus(int);
--example of OUT mode-------------
create or replace function calculate_bonus(salary int, out bonus int,out x int ) 
language plpgsql
as
$$
begin
	select 0.1*salary,100 into bonus,x;
end;$$ 


--test the function --

do
$$
declare
 salary int:=7000;
 bvalue int;
 xvalue int;
begin
	--call the function 
	select bonus,x from calculate_bonus(salary) into bvalue,xvalue;
	raise notice 'bonus:%,x:%',bvalue,xvalue;
end;$$




select 


