using System;
using System.Collections.Generic;
using System.Text;
using HR.Common;

namespace HR.Model
{
    public class BillDetail :MasterModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int DetailId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int CorpBillId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public int EmpSalaryId { get; set; }
    }
}
