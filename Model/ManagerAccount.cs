using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    public class ManagerAccount : MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string ManAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string ManPassWord { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Depment { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int ManStatus { get; set; }
    }
}
