using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;
using HR.DBUtility;

namespace HR.SQLServerDAL
{
    public class SupBillSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }

        public SelectModel SupBillListSelect(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " SupBillId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "SupBillId,BillDate,PayDate,sbl.PayCity,sbl.SupId,sup.SupName as SupName,BillPensionIns,BillMedicalIns,BillUnempIns,BillInjuryIns,BillBirthIns,BillDisabledIns,BillIllnessIns,BillHeatAmount,BillHouseFund,BillRepInjuryIns,CorpOtherPay,EmpOtherPay,sbl.ServiceAmount,TotalAmount,SupBillStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_SupBill sbl");
            sb.Append(" inner join Usr_Supplier sup on sup.SupId = sbl.SupId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = sbl.SupBillStatus and sd.StyleId = 5", (int)StyleTypeEnum.通用状态);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel SupBillReadyList(int pageIndex, int pageSize, string orderStr)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " SupId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "SupId,SupName,SupAddress,SupContacts,SupTel,SupEmail,SupStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Supplier sup");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = sup.SupStatus and sd.StyleId =  {0}", (int)StyleTypeEnum.通用状态);

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
        /// <param name="supId"></param>
        /// <returns></returns>
        public SelectModel EmployeeBySupIdSelect(int pageIndex, int pageSize, string orderStr, int supId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " emp.EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = @"emps.EmpSalaryId,emps.EmpId,emp.EmpName,sdcity.DetailName as PayCityName,emps.PayCity,emps.CorpId,emps.SupId,emps.CorpPensionIns,emps.CorpMedicalIns,emps.CorpUnempIns,emps.CorpInjuryIns,emps.CorpBirthIns,emps.CorpDisabledIns,emps.CorpIllnessIns,emps.CorpHeatAmount,emps.CorpHouseFund,emps.CorpRepInjuryIns,emps.CorpTotal,emps.EmpPensionIns,emps.EmpMedicalIns,emps.EmpUnempIns,emps.EmpInjuryIns,emps.EmpBirthIns,emps.EmpDisabledIns,emps.EmpIllnessIns,emps.EmpHeatAmount,emps.EmpHouseFund,emps.EmpRepInjuryIns,emps.EmpTotal,emps.PersonalTax,emps.TotalAmount,emps.RepairAmount,emps.GrossAmount,emps.FinalAmount,sup.ServiceAmount,emps.RefundAmount,emps.PayDate,emps.EmpSalaryStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_EmployeeSalary emps");
            sb.Append(" left join Usr_Employee emp on emps.EmpId = emp.EmpId");
            sb.Append(" left join Usr_Supplier sup on sup.SupId = emps.SupId");
            sb.AppendFormat(" left join bd_StyleDetail sd on sd.DetailId = emps.EmpSalaryStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emp.supId = {0} ", supId);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
