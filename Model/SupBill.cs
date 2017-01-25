using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    [Serializable]
    public class SupBill : MasterModel
    {
        #region 字段

        private int supBillId;
        private DateTime billDate;
        private DateTime payDate;
        private int payCity;
        private int supId;
        private decimal billPensionIns;
        private decimal billMedicalIns;
        private decimal billUnempIns;
        private decimal billInjuryIns;
        private decimal billBirthIns;
        private decimal billDisabledIns;
        private decimal billIllnessIns;
        private decimal billHeatAmount;
        private decimal billHouseFund;
        private decimal billRepInjuryIns;
        private decimal corpOtherPay;
        private decimal empOtherPay;
        private decimal serviceAmount;
        private decimal totalAmount;
        private string memo = String.Empty;
        private int corpBillStatus;
        #endregion

        #region 构造函数

        public SupBill()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        public int SupBillId
        {
            get { return supBillId; }
            set { supBillId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public DateTime BillDate
        {
            get { return billDate; }
            set { billDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int PayCity
        {
            get { return payCity; }
            set { payCity = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int SupId
        {
            get { return supId; }
            set { supId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillPensionIns
        {
            get { return billPensionIns; }
            set { billPensionIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillMedicalIns
        {
            get { return billMedicalIns; }
            set { billMedicalIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillUnempIns
        {
            get { return billUnempIns; }
            set { billUnempIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillInjuryIns
        {
            get { return billInjuryIns; }
            set { billInjuryIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillBirthIns
        {
            get { return billBirthIns; }
            set { billBirthIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillDisabledIns
        {
            get { return billDisabledIns; }
            set { billDisabledIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillIllnessIns
        {
            get { return billIllnessIns; }
            set { billIllnessIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillHeatAmount
        {
            get { return billHeatAmount; }
            set { billHeatAmount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillHouseFund
        {
            get { return billHouseFund; }
            set { billHouseFund = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal BillRepInjuryIns
        {
            get { return billRepInjuryIns; }
            set { billRepInjuryIns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal CorpOtherPay
        {
            get { return corpOtherPay; }
            set { corpOtherPay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal EmpOtherPay
        {
            get { return empOtherPay; }
            set { empOtherPay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal ServiceAmount
        {
            get { return serviceAmount; }
            set { serviceAmount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int CorpBillStatus
        {
            get { return corpBillStatus; }
            set { corpBillStatus = value; }
        }

        #endregion
    }
}
