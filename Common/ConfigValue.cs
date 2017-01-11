using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{
    public class ConfigValue
    {
        private const string userCookieName = "HRUser";
        private static TimeSpan userTimeout = new TimeSpan(24, 0, 0);
        /// <summary>
        /// 用户cookie名称
        /// </summary>
        public static string UserCookieName
        {
            get { return userCookieName; }
        }
        /// <summary>
        /// 用户登录失效时长
        /// </summary>
        public static TimeSpan UserTimeout
        {
            get { return userTimeout; }
        }
    }
}
