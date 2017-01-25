using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    public class CorpBillDetail :MasterModel
    {
        #region 字段

        private int detailId;
        private int corpBillId;
        private int empSalaryId;
        private decimal serviceAmount;
        private int detailStatus;
        #endregion

        #region 构造函数

        public CorpBillDetail()
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        public int DetailId
        {
            get { return detailId; }
            set { detailId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int CorpBillId
        {
            get { return corpBillId; }
            set { corpBillId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public int EmpSalaryId
        {
            get { return empSalaryId; }
            set { empSalaryId = value; }
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
		public int DetailStatus
        {
            get { return detailStatus; }
            set { detailStatus = value; }
        }

        #endregion
    }
}
