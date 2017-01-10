using System;
using System.Configuration;

namespace DBUtility
{
    public class SQLConnString
    {
        public static string GetConnSting()
        {
            return ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        }

        public static string GetConnSting2()
        {
            return ConfigurationManager.ConnectionStrings["ConnStr2"].ConnectionString;
        }

        public static string GetConnSting3()
        {
            return ConfigurationManager.ConnectionStrings["ConnStr3"].ConnectionString;
        }

        public static string GetRecharge2()
        {
            return ConfigurationManager.ConnectionStrings["ConnStrRecharge2"].ConnectionString;
        }
    }
}
