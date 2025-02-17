using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql; //for ADO.NET

namespace ADOLib
{
    public class AdoDisconnected : IEmployeeDataAccess
    {
        NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;

        public AdoDisconnected()
        {
            con = new NpgsqlConnection();
            con.ConnectionString = "Host=localhost;Database=empdb;Username=postgres;Password=sa;Persist Security Info=True";

            da = new NpgsqlDataAdapter("select * from employee", con);
            //create and fill the DataSet using Adapter
            ds = new DataSet();
            da.Fill(ds, "employee");
            //add constraint 
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns[0], true);
        }
        public void AddEmployee(Employee employee)
        {
            //create a new row in DataSet Table rows collection
            DataRow row = ds.Tables[0].NewRow();
            //specify column values to this new row
            row[0] = employee.Ecode;
            row[1] = employee.Ename;
            row[2] = employee.Salary;
            row[3] = employee.Deptid;

            //add this new row to the DataSet Table Rows
            ds.Tables[0].Rows.Add(row);
            //using DataAdapter save this insert in database
            NpgsqlCommandBuilder builder= new NpgsqlCommandBuilder(da);
            //save changes to database
            da.Update(ds, "employee");
        }

        public void DeleteEmployee(int ecode)
        {
            DataRow row =ds.Tables[0].Rows.Find(ecode);
            if (row != null)
            {
                //delete the row and update
                row.Delete();
                //using DataAdapter save this insert in database
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
                //save changes to database
                da.Update(ds, "employee");
            }
            else
            {
                throw new Exception("ecode not found");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps=new List<Employee>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var emp = new Employee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary=(int)row[2],
                    Deptid=(int)row[3]
                };
                //add to the collection
                lstEmps.Add(emp);
            }
            return lstEmps;
        }

        public Employee GetEmployee(int ecode)
        {
            DataRow row =ds.Tables[0].Rows.Find(ecode);
            if(row == null)
            {
                throw new Exception("ecode does not exist");
            }
            else
            {
                var emp = new Employee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };
                return emp;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            DataRow row = ds.Tables[0].Rows.Find(employee.Ecode);
            if (row != null)
            {
                //update the row columns and update
                row[2]=employee.Salary;
                //using DataAdapter save this insert in database
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
                //save changes to database
                da.Update(ds, "employee");
            }
            else
            {
                throw new Exception("ecode not found");
            }
        }

        public void UpdateSalUsingSP(int ecode, int salary)
        {
            throw new NotImplementedException();
        }
    }
}
