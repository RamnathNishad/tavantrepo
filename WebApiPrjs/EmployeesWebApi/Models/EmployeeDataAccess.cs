
namespace EmployeesWebApi.Models
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly EmployeeDbContext dbCtx;
        public EmployeeDataAccess(EmployeeDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        public void Add(Employee employee)
        {
            dbCtx.Employees.Add(employee);
            dbCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            var record=dbCtx.Employees.Find(id);
            if (record != null)
            {
                dbCtx.Employees.Remove(record);
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public Employee Get(int id)
        {
            var record = dbCtx.Employees.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public List<Employee> GetAll()
        {
            return dbCtx.Employees.ToList();
        }

        public void Update(Employee employee)
        {
            var record = dbCtx.Employees.Find(employee.Ecode);
            if (record != null)
            {
                record.Ename = employee.Ename;
                record.Salary = employee.Salary;
                record.Deptid = employee.Deptid;

                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
