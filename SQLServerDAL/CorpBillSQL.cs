using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;
using HR.DBUtility;

namespace HR.SQLServerDAL
{
    public class CorpBillSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }
        public SelectModel CorpBillListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " CorpBillId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "CorpBillId,BillDate,PayDate,cbl.PayCity,cbl.CorpId,corp.CorpName as CorpName,SupId,BillPensionIns,BillMedicalIns,BillUnempIns,BillInjuryIns,BillBirthIns,BillDisabledIns,BillIllnessIns,BillHeatAmount,BillHouseFund,BillRepInjuryIns,CorpOtherPay,EmpOtherPay,ServiceAmount,TotalAmount,CorpBillStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_CorpBill cbl");
            sb.Append(" inner join Usr_Corporation corp on corp.CorpId = cbl.CorpId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = cbl.CorpBillStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel CorpBillReadyList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " CorpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "CorpId,CorpName,CorpAddress,CorpContacts,CorpTel,CorpEmail,sdcity.DetailName as PayCity,CorpStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Corporation corp");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = corp.CorpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" inner join bd_StyleDetail sdcity on sdcity.DetailId = corp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }

        /// <summary>
        /// 未生成
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderStr"></param>
        /// <param name="corpId"></param>
        /// <returns></returns>
        public SelectModel EmployeeByCorpIdSelect(int pageIndex, int pageSize, string orderStr,int corpId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " emp.EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = @"emp.EmpName,emp.CardNo,sdcity.DetailName as PayCity,emp.SocialFundNum,emp.HouseFundNum,emp.SocialFundNum * (soc.CorpPensionInsPoint/100)  as CorpPensionIns
                                ,emp.SocialFundNum * (soc.CorpMedicalInsPoint/100)  as CorpMedicalIns
                                ,emp.SocialFundNum * (soc.CorpUnempInsPoint/100)  as CorpUnempIns
                                ,emp.SocialFundNum * (soc.CorpInjuryInsPoint/100)  as CorpInjuryIns
                                ,emp.SocialFundNum * (soc.CorpBirthInsPoint/100)  as CorpBirthIns
                                ,emp.SocialFundNum * (soc.CorpBirthInsPoint/100)  as CorpDisabledIns
                                ,emp.SocialFundNum * (soc.CorpIllnessInsPoint/100)  as CorpIllnessIns
                                ,emp.SocialFundNum * (soc.CorpHeatAmountPoint/100)  as CorpHeatAmount
                                ,emp.HouseFundNum * (soc.CorpHouseFundPoint/100)  as CorpHouseFund
                                ,emp.SocialFundNum * (soc.CorpRepInjuryInsPoint/100)  as CorpRepInjuryIns
                                , 0 as CorpTotal
                                ,emp.SocialFundNum * (soc.EmpPensionInsPoint/100)  as EmpPensionIns
                                ,emp.SocialFundNum * (soc.EmpMedicalInsPoint/100)  as EmpMedicalIns
                                ,emp.SocialFundNum * (soc.EmpUnempInsPoint/100)  as EmpUnempIns
                                ,emp.SocialFundNum * (soc.EmpInjuryInsPoint/100)  as EmpInjuryIns
                                ,emp.SocialFundNum * (soc.EmpBirthInsPoint/100)  as EmpBirthIns
                                ,emp.SocialFundNum * (soc.EmpBirthInsPoint/100)  as EmpDisabledIns
                                ,emp.SocialFundNum * (soc.EmpIllnessInsPoint/100)  as EmpIllnessIns
                                ,emp.SocialFundNum * (soc.EmpHeatAmountPoint/100)  as EmpHeatAmount
                                ,emp.HouseFundNum * (soc.EmpHouseFundPoint/100)  as EmpHouseFund
                                ,emp.SocialFundNum * (soc.EmpRepInjuryInsPoint/100)  as EmpRepInjuryIns,0 as EmpTotal,ISNULL(emps.PersonalTax,0) as PersonalTax,ISNULL(emps.TotalAmount,0) as TotalAmount,ISNULL(emps.RepairAmount,0) as RepairAmount,ISNULL(emps.GrossAmount,0) as GrossAmount,ISNULL(emps.FinalAmount,0) as FinalAmount,ISNULL(emps.ServiceAmount,0) as ServiceAmount,ISNULL(emps.RefundAmount,0) as RefundAmount,0 as AllTotalAmount";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Corporation corp");
            sb.Append(" inner join Usr_Employee emp on emp.CorpId = corp.CorpId");
            sb.AppendFormat(" left join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);
            sb.Append(" left join Usr_CorpBill cbl on cbl.CorpId = corp.CorpId and datediff(month,[PayDate],getdate())= 0");
            sb.Append(" left join Usr_EmployeeSalary emps on emps.EmpId = emp.EmpId and emps.CorpBillId = cbl.CorpBillId");
            sb.Append(" left join bd_SocialBase soc on soc.CityId = emp.PayCity");

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emp.CorpId ={0} and emp.EmpStatus = {1} ", corpId,(int)StatusEnum.已完成);

            select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel EmployeeSalaryByCorpBillIdSelect(int pageIndex, int pageSize, string orderStr, int corpBillId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " EmpSalaryId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "EmpSalaryId,EmpId,EmpName,PayCity,sdcity.DetailName as PayCityName,CardNo,SocialFundNum,HouseFundNum,CorpId,CorpPensionIns,CorpMedicalIns,CorpUnempIns,CorpInjuryIns,CorpBirthIns,CorpDisabledIns,CorpIllnessIns,CorpHeatAmount,CorpHouseFund,CorpRepInjuryIns,CorpTotal,EmpPensionIns,EmpMedicalIns,EmpUnempIns,EmpInjuryIns,EmpBirthIns,EmpDisabledIns,EmpIllnessIns,EmpHeatAmount,EmpHouseFund,EmpRepInjuryIns,EmpTotal,PersonalTax,TotalAmount,RepairAmount,GrossAmount,FinalAmount,ServiceAmount,RefundAmount,PayDate,CorpBillId,EmpSalaryStatus,Memo";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_EmployeeSalary emps");
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emps.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emps.CorpBillId ={0} ", corpBillId);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
