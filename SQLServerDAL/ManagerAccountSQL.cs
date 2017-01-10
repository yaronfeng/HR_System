using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Model;
using HR.DBUtility;
using System.Data.SqlClient;
using System.Data;
using HR.Common;

namespace HR.SQLServerDAL
{
    public class ManagerAccountSQL
    {
        private string ConnectString
        {
            get
            {
               return SQLConnString.GetConnSting();
            }
        }
        private ManagerAccount SetOneRow(SqlDataReader rd)
        {
            ManagerAccount account = new ManagerAccount();
            if (rd["ManagerId"] != DBNull.Value)
            {
                account.ManagerId = int.Parse(rd["ManagerId"].ToString());
            }
            account.ManAccount = rd["ManAccount"].ToString();
            account.ManPassWord = rd["ManPassWord"].ToString();
            account.UserName = rd["UserName"].ToString();
            account.Depment = rd["Depment"].ToString();
            if (rd["ManStatus"] != DBNull.Value)
            {
                account.ManStatus = int.Parse(rd["ManStatus"].ToString());
            }
            return account;
        }

        public ManagerAccount Login(string account,string passWord)
        {
            string sql = string.Format(@"select count(1) from Sys_ManagerAccount where ManAccount = @ManAccount and ManPassWord = @ManPassWord and ManStatus = {0}",(int)Common.StatusEnum.已完成);

            SqlParameter[] parmes = new[]
            {
                new SqlParameter() {ParameterName="@ManAccount",Value=account },
                new SqlParameter() {ParameterName="@ManPassWord",Value=passWord }
            };

            return (ManagerAccount)SqlHelper.ExecuteScalar(ConnectString, CommandType.StoredProcedure, sql, parmes);
        }
    }
}
