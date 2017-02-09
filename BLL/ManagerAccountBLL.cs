using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.SQLServerDAL;
using HR.Model;
using HR.Common;
using System.Data.SqlClient;
using System.Data;

namespace HR.BLL
{
    public class ManagerAccountBLL : Operate
    {
        private ManagerAccountSQL sql_insrance = new ManagerAccountSQL();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public ResultModel Login(string userName, string passWord)
        {
            ResultModel result = new ResultModel();

            string cmdText = "select * from dbo.Sys_ManagerAccount where ManAccount =@manAccount and ManPassWord=@manPassWord";

            SqlParameter[] paras = new SqlParameter[2];

            SqlParameter para1 = new SqlParameter("@manAccount", userName);
            paras[0] = para1;
            SqlParameter para2 = new SqlParameter("@manPassWord", passWord);
            paras[1] = para2;

            ResultModel<ManagerAccount> resultAcc = this.Get<ManagerAccount>(CommandType.Text, cmdText, paras);

            if (resultAcc.ResultStatus == 0 && resultAcc.ReturnValue != null)
            {
                ManagerAccount account = resultAcc.ReturnValue;

                //EmployeeDal empDal = new EmployeeDal();
                //ResultModel<Employee> resultEmp = empDal.Get<Employee>(ConfigValue.SysUser, account.EmpId);
                //Employee emp = resultEmp.ReturnValue;

                UserModel user = new UserModel();
                user.AccountId = account.ManagerId;
                user.UserName = account.UserName;
                //user.EmpId = emp.EmpId;
                //user.EmpName = emp.Name;
                //user.DeptId = emp.DeptId;

                result.AffectCount = 0;
                result.Message = "登录成功";
                result.ResultStatus = 0;
                result.ReturnValue = user;

            }
            else
            {
                result.ResultStatus = -1;
                result.Message = "用户名或密码错误";
                result.ReturnValue = null;
            }

            return result;
        }

        protected override List<SqlParameter> CreateInsertParameters(IModel obj, ref SqlParameter returnValue)
        {
            return null;
        }

        protected override IModel CreateModel(SqlDataReader dr)
        {
            ManagerAccount managerAccount = new ManagerAccount();

            int indexManagerId = dr.GetOrdinal("ManagerId");
            managerAccount.ManagerId = Convert.ToInt32(dr[indexManagerId]);
            int indexManAccount = dr.GetOrdinal("ManAccount");
            if (dr[indexManAccount] != DBNull.Value)
            {
                managerAccount.ManAccount = Convert.ToString(dr[indexManAccount]);
            }
            int indexManPassWord = dr.GetOrdinal("ManPassWord");
            if (dr[indexManPassWord] != DBNull.Value)
            {
                managerAccount.ManPassWord = Convert.ToString(dr[indexManPassWord]);
            }
            int indexUserName = dr.GetOrdinal("UserName");
            if (dr[indexUserName] != DBNull.Value)
            {
                managerAccount.UserName = Convert.ToString(dr[indexUserName]);
            }
            return managerAccount;
        }

        public override List<SqlParameter> CreateUpdateParameters(IModel obj)
        {
            return null;
        }
        public override string TableName
        {
            get
            {
                return "Sys_ManagerAccount";
            }
        }
    }
}
