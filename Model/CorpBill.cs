using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    public class CorpBill:MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CorpBillId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public DateTime BillDate { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public DateTime PayDate { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int PayCity { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int CorpId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int SupId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillPensionIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillMedicalIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillUnempIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillInjuryIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillBirthIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillDisabledIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillIllnessIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillHeatAmount { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillHouseFund { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal BillRepInjuryIns { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal CorpOtherPay { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal EmpOtherPay { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal ServiceAmount { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int CorpBillStatus { get; set; }
    }
}
