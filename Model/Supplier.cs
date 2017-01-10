using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier : MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int SupId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public int SupCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public int SupName { get; set; }
        /// <summary>
        /// 供应商英文名
        /// </summary>
        public int SupEName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public int SupAddress { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public int SupContacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public int SupTel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public int SupFax { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public int SupZip { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public int SupEmail { get; set; }
        /// <summary>
        /// 银行
        /// </summary>
        public int Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public int BankAccount { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public int ServiceAmount { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int SupStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public int Memo { get; set; }
    }
}
