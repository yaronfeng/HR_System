using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Common
{
    /// <summary>
    /// 通用状态枚举
    /// </summary>
    [Serializable]
    public enum StyleTypeEnum
    {
        SexType = 1,
        性别类型 = SexType,

        DegreeType = 2,
        学历类型 = DegreeType,

        BankType = 3,
        银行类型 = BankType,

        PayCityType = 4,
        缴费城市类型 = PayCityType,

        CommonStatus = 5,
        通用状态 = CommonStatus,
    }
}
