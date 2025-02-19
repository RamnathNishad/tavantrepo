
namespace EFCoreDBFirstLib
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly EmpDBContext dbCtx;
        public EmployeeDataAccess(EmpDBContext ctx)
        {
            this.dbCtx = ctx;
        }
        public void Add(Employee employee)
        {
            dbCtx.employee.Add(employee);
            dbCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = dbCtx.employee.Where(o => o.ecode == id)
                                       .SingleOrDefault();
            if (record != null)
            {
                //delete the record
                dbCtx.employee.Remove(record);
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("ecode does not exist");
            }
        }

        public List<Employee> GetAllEmps()
        {
           return dbCtx.employee.ToList();
        }

        public Employee GetEmpById(int id)
        {
            var record = dbCtx.employee.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            var record = dbCtx.employee.Find(employee.ecode);
            if (record!=null)
            {   
                record.ename = employee.ename;
                record.salary = employee.salary;
                record.deptid = employee.deptid;
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
