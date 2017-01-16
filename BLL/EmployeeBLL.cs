using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.SQLServerDAL;
using HR.Model;
using HR.Common;
using System.Data.SqlClient;

namespace HR.BLL
{
    public class EmployeeBLL : Operate
    {
        private EmployeeSQL sql_insrance = new EmployeeSQL();

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            Employee employee = (Employee)obj;

            List<SqlParameter> paras = new List<SqlParameter>();
            return paras;
        }

        protected override IModel CreateModel(SqlDataReader rd)
        {
            Employee employee = new Employee();
            if (rd["EmpId"] != DBNull.Value)
                employee.EmpId = int.Parse(rd["EmpId"].ToString());
            employee.EmpName = rd["EmpName"].ToString();
            if (rd["Sex"] != DBNull.Value)
                employee.Sex = int.Parse(rd["Sex"].ToString());
            if (rd["CorpId"] != DBNull.Value)
                employee.CorpId = int.Parse(rd["CorpId"].ToString());
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

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            Corporation corp = (Corporation)obj;

            List<SqlParameter> paras = new List<SqlParameter>();

            return paras;
        }

        public int AddEmployee(Employee emp)
        {
            emp.CreatorId = 1;
            emp.LastModifyId = 1;
            return sql_insrance.AddEmployee(emp);
        }
        public ResultModel LoadEmployeeList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = sql_insrance.EmployeeListSelect(pageIndex, pageSize, orderStr);
            ResultModel result = Load(select);

            return result;

            //return sql_insrance.EmployeeListSelect(pageIndex, pageSize, orderStr);
        }
        public override string TableName
        {
            get
            {
                return "Usr_Employee";
            }
        }
    }
}
