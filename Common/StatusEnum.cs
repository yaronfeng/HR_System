using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Common
{
    /// <summary>
    /// 通用状态枚举
    /// </summary>
    [Serializable]
    public enum StatusEnum
    {
        已作废 = -10,
        已完成 = 100,
    }
}
