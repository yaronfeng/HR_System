using HR.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using System.Data.SqlClient;
using System.Data;

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
                employee.EmpId = int.Parse(rd["EmpId"].ToString());
            employee.EmpName = rd["EmpName"].ToString();
            if (rd["Sex"] != DBNull.Value)
                employee.Sex = int.Parse(rd["Sex"].ToString());
            employee.CardNo = rd["CardNo"].ToString();
            employee.Address = rd["Address"].ToString();
            employee.Phone = rd["Phone"].ToString();
            if (rd["EntryDate"] != DBNull.Value)
                employee.EntryDate = DateTime.Parse(rd["EntryDate"].ToString());
            if (rd["ConStartDate"] != DBNull.Value)
                employee.ConStartDate = DateTime.Parse(rd["ConStartDate"].ToString());
            if (rd["ConEndDate"] != DBNull.Value)
                employee.ConEndDate = DateTime.Parse(rd["ConEndDate"].ToString());
            if (rd["LeaveDate"] != DBNull.Value)
                employee.LeaveDate = DateTime.Parse(rd["LeaveDate"].ToString());
            if (rd["Degree"] != DBNull.Value)
                employee.Degree = int.Parse(rd["Degree"].ToString());
            employee.Jobs = rd["Jobs"].ToString();
            if (rd["TotalAmount"] != DBNull.Value)
                employee.TotalAmount = decimal.Parse(rd["TotalAmount"].ToString());
            if (rd["SocialFundNum"] != DBNull.Value)
                employee.SocialFundNum = decimal.Parse(rd["SocialFundNum"].ToString());
            if (rd["HouseFundNum"] != DBNull.Value)
                employee.HouseFundNum = decimal.Parse(rd["HouseFundNum"].ToString());
            if (rd["PayCity"] != DBNull.Value)
                employee.PayCity = int.Parse(rd["PayCity"].ToString());
            if (rd["SocialStartDate"] != DBNull.Value)
                employee.SocialStartDate = Convert.ToDateTime(rd["SocialStartDate"]);
            if (rd["HouseStartDate"] != DBNull.Value)
                employee.HouseStartDate = Convert.ToDateTime(rd["HouseStartDate"]);
            if (rd["HouseAccount"] != DBNull.Value)
                employee.HouseAccount = rd["HouseAccount"].ToString();
            if (rd["HandBook"] != DBNull.Value)
                employee.HandBook = Convert.ToInt32(rd["HandBook"]);
            if (rd["ResidentPermit"] != DBNull.Value)
                employee.ResidentPermit = Convert.ToInt32(rd["ResidentPermit"]);
            if (rd["Bank"] != DBNull.Value)
                employee.Bank = Convert.ToInt32(rd["Bank"]);
            employee.BankAccount = rd["BankAccount"].ToString();
            employee.ContractNo = rd["ContractNo"].ToString();
            if (rd["EmployDate"] != DBNull.Value)
                employee.EmployDate = Convert.ToDateTime(rd["EmployDate"]);
            if (rd["SocialSignDate"] != DBNull.Value)
                employee.SocialSignDate = Convert.ToDateTime(rd["SocialSignDate"]);
            if (rd["IsBirthIns"] != DBNull.Value)
                employee.IsBirthIns = Convert.ToInt32(rd["IsBirthIns"]);
            employee.InsCardNo = rd["InsCardNo"].ToString();
            employee.EmpEmail = rd["EmpEmail"].ToString();
            if (rd["EmpStatus"] != DBNull.Value)
                employee.EmpStatus = Convert.ToInt32(rd["EmpStatus"]);
            employee.Memo = rd["Memo"].ToString();
            if (rd["CreatorId"] != DBNull.Value)
                employee.CreatorId = Convert.ToInt32(rd["CreatorId"]);
            if (rd["CreateTime"] != DBNull.Value)
                employee.CreateTime = Convert.ToDateTime(rd["CreateTime"]);
            if (rd["LastModifyId"] != DBNull.Value)
                employee.LastModifyId = Convert.ToInt32(rd["LastModifyId"]);
            if (rd["LastModifyTime"] != DBNull.Value)
                employee.LastModifyTime = Convert.ToDateTime(rd["LastModifyTime"]);
            return employee;
        }

        public int AddProductExtion(Employee emp)
        {
            var sql = @"delete product_extend where product_id = @pid and product_ver = @ver
insert into product_extend (product_id,product_ver,product_memo,product_rule)values(@pid,@ver,@memo,@rule)";
            var parms = new List<SqlParameter>();
            parms.Add(new SqlParameter() { ParameterName = "@pid", Value = emp.EmpId });
            parms.Add(new SqlParameter() { ParameterName = "@ver", Value = emp.EmpName });
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                return (int)SqlHelper.ExecuteScalar(conn, CommandType.Text, sql, parms.ToArray());
            }
        }
    }
}
