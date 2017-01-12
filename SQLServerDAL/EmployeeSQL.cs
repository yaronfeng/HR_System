using HR.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using System.Data.SqlClient;

namespace HR.SQLServerDAL
{
    public class EmployeeSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }
        private Employee SetOneRow(SqlDataReader rd)
        {
            Employee employee = new Employee();
            if (rd["EmpId"] != DBNull.Value)
            {
                employee.EmpId = int.Parse(rd["EmpId"].ToString());
            }
            employee.EmpName = rd["EmpName"].ToString();
            if (rd["Sex"] != DBNull.Value)
            {
                employee.Sex = int.Parse(rd["Sex"].ToString());
            }
            employee.CardNo = rd["CardNo"].ToString();
            employee.Address = rd["Address"].ToString();
            if (rd["EmpStatus"] != DBNull.Value)
            {
                employee.EmpStatus = int.Parse(rd["EmpStatus"].ToString());
            }
            return employee;
        }
    }
}
