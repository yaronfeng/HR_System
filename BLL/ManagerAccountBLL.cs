using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.SQLServerDAL;
using HR.Model;

namespace HR.BLL
{
    public class ManagerAccountBLL
    {
        private ManagerAccountSQL sql_insrance = new ManagerAccountSQL();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public ManagerAccount Login(string account, string passWord)
        {

            return sql_insrance.Login(account, passWord);
        }
    }
}
