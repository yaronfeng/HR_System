using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;
using HR.DBUtility;

namespace HR.SQLServerDAL
{
    public class SocialBaseSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }
        public SelectModel SocialBaseListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " SocId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "SocId,CityId,sdcity.DetailName as PayCityName,SocName,PensionInsNum,MedicalInsNum,UnempInsNum,InjuryInsNum,BirthInsNum,DisabledInsNum,IllnessInsNum,HeatAmountNum,HouseFundINum,RepInjuryInsNum,CorpPensionInsPoint,CorpMedicalInsPoint,CorpUnempInsPoint,CorpInjuryInsPoint,CorpBirthInsPoint,CorpDisabledInsPoint,CorpIllnessInsPoint ,CorpHeatAmountPoint ,CorpHouseFundPoint ,CorpRepInjuryInsPoint,EmpPensionInsPoint,EmpMedicalInsPoint,EmpUnempInsPoint,EmpInjuryInsPoint,EmpBirthInsPoint,EmpDisabledInsPoint,EmpIllnessInsPoint,EmpHeatAmountPoint,EmpHouseFundPoint,EmpRepInjuryInsPoint,PensionInsFix,MedicalInsFix,UnempInsFix,InjuryInsFix,BirthInsFix,DisabledInsFix,IllnessInsFix,HeatAmountFix,HouseFundFix,RepInjuryInsFix";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" bd_SocialBase soc");
            //sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = corp.CorpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" inner join bd_StyleDetail sdcity on sdcity.DetailId = soc.CityId and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }
    }
}
