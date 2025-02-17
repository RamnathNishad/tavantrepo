﻿namespace LinqDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //LinqSimpleDemo();

            var lstEmps = Employee.GetEmps();
            var lstDepts=Department.GetDepts();

            //1. Find employees whose salary is greater than 20000
            //SQL: select * from employee where salary>20000
            //LINQ:-
            //var result=from e in lstEmps
            //           where e.Salary>20000
            //           select e;
            
            //using extension methods
            var result = lstEmps.Where(e => e.Salary > 20000);


            foreach (var r in result)
            {
                Console.WriteLine($"{r.Ecode}\t{r.Ename}\t{r.Salary}\t{r.Deptid}");
            }
            //2. get the employees records sorted by salary descending
            //SQL: select * from employee order by salary desc
            //using LINQ:
            var res2 = from e in lstEmps
                       orderby e.Salary descending
                       select e;

            //extension method
            res2=lstEmps.OrderByDescending(e => e.Salary);

            foreach (var r in res2)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Ename}\t{r.Salary}\t{r.Deptid}");
            }
            //3.Retrieving only selected columns
            //SQL: select ecode,salary from employee
            var res3 = from e in lstEmps
                       select new 
                       { 
                           e.Ecode,
                           e.Salary
                       };

            //using extension method
            res3 = lstEmps.Select(e => new
            {
                e.Ecode,
                e.Salary
            });

            foreach (var r in res3)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Salary}");
            }

            //4.getting computed values in query
            //SQL: select ecode,salary,0.1*salary as Bonus from employee
            var res4 = from e in lstEmps
                       select new
                       {
                           e.Ecode,
                           e.Salary,
                           Bonus=0.1*e.Salary
                       };

            res4 = lstEmps.Select(e=> new
            {
                e.Ecode,
                e.Salary,
                Bonus = 0.1 * e.Salary
            });
            foreach (var r in res4)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Salary}\t{r.Bonus}");
            }

            //5. Aggregate functions
            //SQL: select sum(salary) as TotalSal,avg(salary) as AvgSal from employee
            var res5 = new
            {
                TotalSal=lstEmps.Sum(e=>e.Salary),
                AvgSal=lstEmps.Average(e=>e.Salary),
                MaxSalary=lstEmps.Max(e=>(e.Salary==null?0:e.Salary)),
                MinSalary=lstEmps.Min(e=>e.Salary),
                NoOfEmps=lstEmps.Count()
            };

            //6. Group by
            //SQL:
            //select deptid,sum(salary),avg(salary)
            //from employee group by deptid
            //using LINQ:
            var res6 = from e in lstEmps
                       group e by e.Deptid into g
                       select new
                       {
                           Deptid=g.Key,
                           TotalSal = g.Sum(e => e.Salary),
                           AvgSalary = g.Average(e => e.Salary),
                           MaxSalary = g.Max(e => (e.Salary == null ? 0 : e.Salary)),
                           MinSalary = g.Min(e => e.Salary),
                           NoOfEmps = g.Count()
                       };

            //using extension method
            res6 = lstEmps.GroupBy(e => e.Deptid)
                          .Select(g => new
                          {
                              Deptid = g.Key,
                              TotalSal = g.Sum(e => e.Salary),
                              AvgSalary = g.Average(e => e.Salary),
                              MaxSalary = g.Max(e => (e.Salary == null ? 0 : e.Salary)),
                              MinSalary = g.Min(e => e.Salary),
                              NoOfEmps = g.Count()
                          });

            foreach (var r in res6)
            {
                //Console.WriteLine($"{r.Deptid}\t{r.TotalSal}\t{r.TotalSal}\t{r.MaxSalary}\t{r.MinSalary}\t{r.NoOfEmps}");
            }

            //7. Joins
            //SQL :
            //select *
            //from employee as e,department as d
            //where e.deptid=d.deptid
            //using LINQ:
            var res7 = from e in lstEmps
                       join d in lstDepts on e.Deptid equals d.Deptid
                       select new
                       {
                           e.Ecode,
                           e.Ename,
                           e.Salary,
                           d.Deptid,
                           d.Dname,
                           d.Dhead
                       };

            //using extension method
            res7 = lstEmps.Join(lstDepts, 
                                e => e.Deptid, 
                                d => d.Deptid, 
                                (e, d) => new
                                {
                                    e.Ecode,
                                    e.Ename,
                                    e.Salary,
                                    d.Deptid,
                                    d.Dname,
                                    d.Dhead
                                });
            foreach (var r in res7)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Ename}\t{r.Salary}\t{r.Deptid}\t{r.Dname}\t{r.Dhead}");
            }

            //8. Find employees names staring with 'R'
            //SQL: select * from employee where ename like 'R%'
            //LINQ:
            var res8 = (from e in lstEmps
                       where e.Ename.Contains("R")
                       select e);
            
            //OR
            res8 = lstEmps.Where(e => e.Ename.Contains("R"));

            foreach (var r in res8)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Ename}\t{r.Salary}\t{r.Deptid}");
            }

            //Nested query:-
            //9. select *
            //from employee
            //where e.deptid=(select deptid
            //                from employee
            //                where ecode=101)
            //LINQ:
            var res9 = from e in lstEmps
                       where e.Deptid==(from p in lstEmps 
                                       where p.Ecode==101 
                                       select p.Deptid).SingleOrDefault()
                       select e;

            //OR
            res9 = lstEmps.Where(e => e.Deptid == lstEmps.Where(o => o.Ecode == 101)
                                                         .Select(o => o.Deptid)
                                                         .SingleOrDefault());

    
            foreach (var r in res9)
            {
                //Console.WriteLine($"{r.Ecode}\t{r.Ename}\t{r.Salary}\t{r.Deptid}");
            }
        }

        private static void LinqSimpleDemo()
        {
            var numbers = new List<int> { 1, 5, 7, 2, 4, 8, 21, 11 };
            //Q find all the even numbers and sort them in descending order
            //var result = new List<int>();
            //foreach (var number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        result.Add(number);
            //    }
            //}

            //result.Sort(new SortDescending());

            //using LINQ
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n descending
                         select n;

            //display the result
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }
    }    
}
