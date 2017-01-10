using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{

    /// <summary>
    /// 用户实体
    /// </summary>
    [Serializable]
    public class UserModel
    {
        private int accountId = 0;
        private string accountName = string.Empty;
        private string userName = string.Empty;
        private string deptment = string.Empty;

        private string cookieValue = string.Empty;
        /// <summary>
        /// 账户序号
        /// </summary>
        public int AccountId
        {
            get { return this.accountId; }
            set { this.accountId = value; }
        }
        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName
        {
            get { return this.accountName; }
            set { this.accountName = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Deptment
        {
            get { return this.deptment; }
            set { this.deptment = value; }
        }
        /// <summary>
        /// Cookie
        /// </summary>
        public string CookieValue
        {
            get { return this.cookieValue; }
            set { this.cookieValue = value; }
        }
    }
}
