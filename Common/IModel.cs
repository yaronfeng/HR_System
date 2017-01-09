using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Common
{
    /// <summary>
    /// 实体接口
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        Common.StatusEnum Status { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// 创建人序号
        /// </summary>
        int CreatorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改人序号
        /// </summary>
        int LastModifyId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime LastModifyTime { get; set; }
    }
}
