using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{
    public class ConfigValue
    {
        private const string userCookieName = "HRUser";
        /// <summary>
        /// 用户cookie名称
        /// </summary>
        public static string UserCookieName
        {
            get { return userCookieName; }
        }
    }
}
