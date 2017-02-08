using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Common;
using System.Configuration;

namespace HRSite
{
    public class CheckLogin
    {
        private static readonly string SessionName = ConfigurationManager.AppSettings["SessionName"].ToString();

        public static void ExitSessionInfo()
        {
            HttpContext.Current.Session.Abandon();  //清空session
        }

        public static UserModel GetSessionInfo()
        {
            object userModel = HttpContext.Current.Session[SessionName];
            if (userModel != null)
            {
                return userModel as UserModel;
            }
            else
            {
                return null;
            }
        }
    }
}