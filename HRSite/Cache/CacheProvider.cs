using System;
using System.Collections.Generic;
using System.Web;

namespace HR.Cache
{
    public class CacheProvider
    {
        /// <summary>
        /// Insert存在相同的键会替换，无返回值
        /// Cache的过期策略使用滑动过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Insert(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value, null, DateTime.MaxValue, HR.Common.ConfigValue.UserTimeout);
        }

        public static object Get(string key)
        {
            if (HttpRuntime.Cache[key] != null)
                return HttpRuntime.Cache[key];

            return null;
        }

        public static void Remove(string key)
        {
            if (HttpRuntime.Cache[key] != null)
                HttpRuntime.Cache.Remove(key);
        }
    }
}