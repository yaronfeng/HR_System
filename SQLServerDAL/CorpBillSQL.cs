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
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = corp.CorpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);

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
                select.OrderStr = " EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "EmpId,EmpName,CardNo,emp.PayCity,sdcity.DetailName as PayCityName,SocialFundNum,HouseFundNum,SocialFundNum * 0.19 as CorpPensionIns,SocialFundNum * 0.19 as CorpMedicalIns,SocialFundNum * 0.19 as CorpUnempIns,SocialFundNum * 0.19 as CorpInjuryIns,SocialFundNum * 0.19 as CorpBirthIns,SocialFundNum * 0.19 as CorpDisabledIns,SocialFundNum * 0.19 as CorpIllnessIns,SocialFundNum * 0.19 as CorpHeatAmount,SocialFundNum * 0.11 as CorpHouseFund,0 as CorpRepInjuryIns,0 as CorpTotal,0 as EmpPensionIns,0 as EmpMedicalIns,0 as EmpUnempIns,0 as EmpInjuryIns,0 as EmpBirthIns,0 as EmpDisabledIns,0 as EmpIllnessIns,0 as EmpHeatAmount,0 as EmpHouseFund,0 as EmpRepInjuryIns,0 as EmpTotal,0 as PersonalTax,0 as TotalAmount,0 as RepairAmount,0 as GrossAmount,0 as FinalAmount,20 as ServiceAmount,0 as RefundAmount,0 as AllTotalAmount";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Employee emp");
            sb.Append(" inner join Usr_Corporation corp on corp.CorpId = emp.CorpId");
            sb.AppendFormat(" left join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emp.CorpId ={0} ", corpId);

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
