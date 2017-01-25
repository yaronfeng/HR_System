using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;

namespace HR.Model
{
    /// <summary>
	/// dbo.Usr_SupBillDetail实体类。
	/// </summary>
    [Serializable]
    public class SupBillDetail : MasterModel
    {
        #region 字段

        private int detailId;
        private int supBillId;
        private int empSalaryId;
        private decimal serviceAmount;
        private int detailStatus;
        private string creatorId = String.Empty;
        private DateTime createTime;
        private int lastModifyId;
        private DateTime lastModifyTime;
        #endregion

        #region 构造函数

        public SupBillDetail()
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
		public int SupBillId
        {
            get { return supBillId; }
            set { supBillId = value; }
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
