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

        public SelectModel EmployeeListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "emp.EmpId,emp.EmpName,corp.CorpName,sdsex.DetailName Sex,emp.CardNo,emp.Phone,emp.ConStartDate,emp.ConEndDate,emp.TotalAmount,sddeg.DetailName as Degree,sdcity.DetailName as PayCity,emp.EmpEmail,emp.EmpStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Employee emp");
            sb.Append(" inner join Usr_Corporation corp on corp.CorpId = emp.CorpId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}",(int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" inner join bd_StyleDetail sdsex on sdsex.DetailId = emp.Sex and sdsex.StyleId = {0}", (int)StyleTypeEnum.性别类型);
            sb.AppendFormat(" inner join bd_StyleDetail sddeg on sddeg.DetailId = emp.Degree and sddeg.StyleId = {0}", (int)StyleTypeEnum.学历类型);
            sb.AppendFormat(" inner join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }

    }
}
