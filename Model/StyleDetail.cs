using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;

namespace HR.Model
{
    public class StyleDetail : MasterModel
    {
        /// <summary>
        /// 明细Id
        /// </summary>
        public int DetailId { get; set; }
        /// <summary>
        /// 类型Id
        /// </summary>
        public int StyleId { get; set; }
        /// <summary>
        /// 名称code
        /// </summary>
        public string DetailCode { get; set; }
        /// <summary>
        /// 明细名称
        /// </summary>
        public string DetailName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int DetailStatus { get; set; }
    }
}
