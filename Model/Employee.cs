using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    public class Employee : MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime ConStartDate { get; set; }
        /// <summary>
        /// 合同截止日
        /// </summary>
        public DateTime ConEndDate { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime LeaveDate { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public int Degree { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string Jobs { get; set; }
        /// <summary>
        /// 应发工资
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal SocialFundNum { get; set; }
        /// <summary>
        /// 公积金基数
        /// </summary>
        public decimal HouseFundNum { get; set; }
        /// <summary>
        /// 缴费区域
        /// </summary>
        public int PayCity { get; set; }
        /// <summary>
        /// 社保起缴月
        /// </summary>
        public DateTime SocialStartDate { get; set; }
        /// <summary>
        /// 公积金起缴月
        /// </summary>
        public DateTime HouseStartDate { get; set; }
        /// <summary>
        /// 公积金账号
        /// </summary>
        public string HouseAccount { get; set; }
        /// <summary>
        /// 是否劳动手册
        /// </summary>
        public int HandBook { get; set; }
        /// <summary>
        /// 是否居住证
        /// </summary>
        public int ResidentPermit { get; set; }
        /// <summary>
        /// 银行
        /// </summary>
        public int Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccount { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime EmployDate { get; set; }
        /// <summary>
        /// 社保办理日期
        /// </summary>
        public DateTime SocialSignDate { get; set; }
        /// <summary>
        /// 是否生育保险
        /// </summary>
        public int IsBirthIns { get; set; }
        /// <summary>
        /// 保险卡号
        /// </summary>
        public string InsCardNo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EmpEmail { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int EmpStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
