using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Common;

namespace HR.Model
{
    [Serializable]
    public class Corporation : MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CorpId { get; set; }
        /// <summary>
        /// 企业编号
        /// </summary>
        public string CorpCode { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CorpName { get; set; }
        /// <summary>
        /// 企业英文名
        /// </summary>
        public string CorpEName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string CorpAddress { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string CorpContacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string CorpTel { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string CorpFax { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string CorpZip { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string CorpEmail { get; set; }
        /// <summary>
        /// 组织结构代码
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 网上办事密码
        /// </summary>
        public string InternetPWD { get; set; }
        /// <summary>
        /// 社会保险登记码
        /// </summary>
        public string SocialRegCode { get; set; }
        /// <summary>
        /// 参保结算区域
        /// </summary>
        public int PayCity { get; set; }
        /// <summary>
        /// 公积金账号
        /// </summary>
        public string HouseAccount { get; set; }
        /// <summary>
        /// 公积金开户行
        /// </summary>
        public int HouseBank { get; set; }
        /// <summary>
        /// 公积金密码
        /// </summary>
        public string HousePWD { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceAmount { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int CorpStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
