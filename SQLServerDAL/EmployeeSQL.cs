using HR.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using System.Data.SqlClient;
using System.Data;
using HR.Common;

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

        /// <summary>
        /// 员工新增
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int AddEmployee(Employee emp)
        {
            var sql = @"INSERT INTO [HR_System].[dbo].[Usr_Employee] 
([EmpName],[Sex],[CardNo],[Address],[Phone],[EntryDate],[ConStartDate],[ConEndDate],[LeaveDate],[Degree],[Jobs],[TotalAmount],[SocialFundNum],[HouseFundNum],[PayCity],[SocialStartDate],[HouseStartDate],[HouseAccount],[HandBook],[ResidentPermit],[Bank],[BankAccount],[ContractNo],[EmployDate],[SocialSignDate],[IsBirthIns],[InsCardNo],[EmpEmail],[EmpStatus],[Memo],[CreatorId],[CreateTime],[LastModifyId],[LastModifyTime])
     VALUES
(@EmpName,@Sex,@CardNo,@Address,@Phone,@EntryDate,@ConStartDate,@ConEndDate,@LeaveDate,@Degree,@Jobs,@TotalAmount,@SocialFundNum,@HouseFundNum,@PayCity,@SocialStartDate ,@HouseStartDate,@HouseAccount,@HandBook,@ResidentPermit ,@Bank,@BankAccount,@ContractNo,@EmployDate,@SocialSignDate,@IsBirthIns,@InsCardNo ,@EmpEmail,@EmpStatus,@Memo,@CreatorId ,getdate(),@LastModifyId,getdate())";
            SqlParameter[] parmes = new[]
            {
                new SqlParameter("@EmpName", SqlDbType.VarChar,100),
                new SqlParameter("@Sex", SqlDbType.Int,4),
                new SqlParameter("@CardNo", SqlDbType.VarChar,100),
                new SqlParameter("@Address", SqlDbType.VarChar,100),
                new SqlParameter("@Phone", SqlDbType.VarChar,100),
                new SqlParameter("@EntryDate", SqlDbType.DateTime,8),
                new SqlParameter("@ConStartDate", SqlDbType.DateTime,8),
                new SqlParameter("@ConEndDate", SqlDbType.DateTime,8),
                new SqlParameter("@LeaveDate", SqlDbType.DateTime,8),
                new SqlParameter("@Degree", SqlDbType.Int,4),
                new SqlParameter("@Jobs", SqlDbType.VarChar,100),
                new SqlParameter("@TotalAmount", SqlDbType.Decimal,9),
                new SqlParameter("@SocialFundNum", SqlDbType.Decimal,9),
                new SqlParameter("@HouseFundNum", SqlDbType.Decimal,9),
                new SqlParameter("@PayCity", SqlDbType.Int,4),
                new SqlParameter("@SocialStartDate", SqlDbType.DateTime,8),
                new SqlParameter("@HouseStartDate", SqlDbType.DateTime,8),
                new SqlParameter("@HouseAccount", SqlDbType.VarChar,100),
                new SqlParameter("@HandBook", SqlDbType.Int,4),
                new SqlParameter("@ResidentPermit", SqlDbType.Int,4),
                new SqlParameter("@Bank", SqlDbType.Int,4),
                new SqlParameter("@BankAccount", SqlDbType.VarChar,100),
                new SqlParameter("@ContractNo", SqlDbType.VarChar,100),
                new SqlParameter("@EmployDate", SqlDbType.DateTime,8),
                new SqlParameter("@SocialSignDate", SqlDbType.DateTime,8),
                new SqlParameter("@IsBirthIns", SqlDbType.Int,4),
                new SqlParameter("@InsCardNo", SqlDbType.VarChar,100),
                new SqlParameter("@EmpEmail", SqlDbType.VarChar,100),
                new SqlParameter("@EmpStatus", SqlDbType.Int,4),
                new SqlParameter("@Memo", SqlDbType.VarChar,100),
                new SqlParameter("@CreatorId", SqlDbType.Int,4),
                new SqlParameter("@LastModifyId", SqlDbType.Int,100),
            };
            parmes[0].Value = emp.EmpName;
            parmes[1].Value = emp.Sex;
            parmes[2].Value = emp.CardNo;
            parmes[3].Value = emp.Address;
            parmes[4].Value = emp.Phone;
            parmes[5].Value = emp.EntryDate;
            parmes[6].Value = emp.ConStartDate;
            parmes[7].Value = emp.ConEndDate;
            parmes[8].Value = emp.LeaveDate;
            parmes[9].Value = emp.Degree;
            parmes[10].Value = emp.Jobs;
            parmes[11].Value = emp.TotalAmount;
            parmes[12].Value = emp.SocialFundNum;
            parmes[13].Value = emp.HouseFundNum;
            parmes[14].Value = emp.PayCity;
            parmes[15].Value = emp.SocialStartDate;
            parmes[16].Value = emp.HouseStartDate;
            parmes[17].Value = emp.HouseAccount;
            parmes[18].Value = emp.HandBook;
            parmes[19].Value = emp.ResidentPermit;
            parmes[20].Value = emp.Bank;
            parmes[21].Value = emp.BankAccount;
            parmes[22].Value = emp.ContractNo;
            parmes[23].Value = emp.EmployDate;
            parmes[24].Value = emp.SocialSignDate;
            parmes[25].Value = emp.IsBirthIns;
            parmes[26].Value = emp.InsCardNo;
            parmes[27].Value = emp.EmpEmail;
            parmes[28].Value = emp.EmpStatus;
            parmes[29].Value = emp.Memo;
            parmes[30].Value = emp.CreatorId;
            parmes[31].Value = emp.LastModifyId;

            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                return (int)SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, parmes.ToArray());
            }
        }

        public List<Employee> EmployeeListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = "di.DeliveryInId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "DeliveryInId,inCorp.CorpName as InCorpName,outCorp.CorpName as OutCorpName,PromptDate,brk.BrokerName,std.DetailName as PositionDirection,ass.AssetName,exc.ExchangeName,fuc.TradeCode,PositionWeight,Lots,uni.UnitName,StrikePrice,Spread,styd.DetailName as OpenPositionType,sd.StatusName,di.PositionStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" dbo.St_DeliveryIn di ");

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            select.WhereStr = sb.ToString();

            List<Employee> empList = new List<Employee>();
            return empList;
        }
    }
}
