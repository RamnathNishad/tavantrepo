using Npgsql; //for PostGreSql
using System.Configuration;

namespace ADOLib
{
    public class AdoConnected : IEmployeeDataAccess
    {
        NpgsqlConnection con;
        public AdoConnected()
        {
            con= new NpgsqlConnection();
            //read the connection string from the configuration file
            string conStr = ConfigurationManager.ConnectionStrings["pgconstr"].ConnectionString;
            con.ConnectionString = conStr;
        }


        public void AddEmployee(Employee employee)
        {
            try
            {
                //configure command for INSERT statement
                NpgsqlCommand cmd = new NpgsqlCommand("insert into employee values(@ec,@en,@sal,@did) returning ecode;", con);
                cmd.CommandType = System.Data.CommandType.Text;
                //specify the parameters values
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", employee.Ecode);
                cmd.Parameters.AddWithValue("@en", employee.Ename);
                cmd.Parameters.AddWithValue("@sal", employee.Salary);
                cmd.Parameters.AddWithValue("@did", employee.Deptid);
                //open the connection
                con.Open();
                //execute the command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close conection
                con.Close();
            }
        }

        public void DeleteEmployee(int ecode)
        {
            try
            {
                //configure command DELETE BY ECODE 
                NpgsqlCommand cmd = new NpgsqlCommand("delete from employee where ecode=@ec", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);
                //open connection
                con.Open();
                var count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    throw new Exception("ecode does not exist");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            { 
                con.Close(); 
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var lstEmps=new List<Employee>();
            try
            {
                //configure the command for SELECT ALL statement
                NpgsqlCommand cmd = new NpgsqlCommand("select ecode,ename,salary,deptid from employee", con);
                cmd.CommandType=System.Data.CommandType.Text;
                //open the connection
                con.Open();
                //execute the command
                NpgsqlDataReader sdr= cmd.ExecuteReader();
                while (sdr.Read())
                {
                    //get the record one by one and add into collection
                    var emp = new Employee
                    {                        
                        Ecode = sdr.IsDBNull(0) ? 0 : sdr.GetInt32(0),
                        Ename =sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid= sdr.IsDBNull(3) ? 0 : sdr.GetInt32(3)
                    };
                    //add to the collection
                    lstEmps.Add(emp);
                }
                //close the datareader
                sdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
            //return the result
            return lstEmps;
        }

        public Employee GetEmployee(int ecode)
        {
            Employee emp = null;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select ecode,ename,salary,deptid from employee where ecode=@ec", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);

                con.Open();
                var sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    emp = new Employee
                    {
                        Ecode = sdr.GetInt32(0),
                        Ename = sdr.GetString(1),
                        Salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3)
                    };

                }
                sdr.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return emp;
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                //configure command for UPDATE statement
                NpgsqlCommand cmd = new NpgsqlCommand("update employee set salary=@sal where ecode=@ec", con);
                cmd.CommandType = System.Data.CommandType.Text;
                //specify the parameters values
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", employee.Ecode);
                cmd.Parameters.AddWithValue("@sal", employee.Salary);
                //open the connection
                con.Open();
                //execute the command
                var count=cmd.ExecuteNonQuery();
                if(count==0)
                {
                    throw new Exception("ecode does not exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close conection
                con.Close();
            }
        }

        public void UpdateSalUsingSP(int ecode, int salary)
        {
            //configure command for calling Stored procedure
            NpgsqlCommand cmd = new NpgsqlCommand("sp_updatesal", con);
            //command type
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("ec", ecode);
            cmd.Parameters.AddWithValue("sal", salary);

            con.Open();
            cmd.ExecuteNonQuery();
            //use if function which returns a value
            //var data = (int)cmd.ExecuteScalar();

            con.Close();
        }
    }
}
