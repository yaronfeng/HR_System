using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.SQLServerDAL;
using HR.Model;

namespace HR.BLL
{
    public class EmployeeBLL
    {
        private EmployeeSQL sql_insrance = new EmployeeSQL();

        public int AddEmployee(Employee emp)
        {
            emp.CreatorId = 1;
            emp.LastModifyId = 1;
            return sql_insrance.AddEmployee(emp);
        }
    }
}
