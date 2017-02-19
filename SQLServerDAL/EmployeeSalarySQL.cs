using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Common;

namespace HR.SQLServerDAL
{
    public class EmployeeSalarySQL
    {
        public SelectModel EmployeeSalaryListSelect(int pageIndex, int pageSize, string orderStr, string empName, int corpId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " EmpSalaryId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "emps.EmpSalaryId,emps.EmpId,emp.EmpName,emps.PayCity,sdcity.DetailName as PayCityName,emps.CorpId,CorpPensionIns,CorpMedicalIns,CorpUnempIns,CorpInjuryIns,CorpBirthIns,CorpDisabledIns,CorpIllnessIns,CorpHeatAmount,CorpHouseFund,CorpRepInjuryIns,CorpTotal,EmpPensionIns,EmpMedicalIns,EmpUnempIns,EmpInjuryIns,EmpBirthIns,EmpDisabledIns,EmpIllnessIns,EmpHeatAmount,EmpHouseFund,EmpRepInjuryIns,EmpTotal,PersonalTax,emps.TotalAmount,RepairAmount,GrossAmount,FinalAmount,ServiceAmount,RefundAmount,PayDate,EmpSalaryStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_EmployeeSalary emps");
            sb.Append(" left join Usr_Employee emp on emp.EmpId = emps.EmpId");
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emps.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat("emps.EmpSalaryStatus = {0}", (int)StatusEnum.已完成);
            if (corpId > 0)
                sb.AppendFormat(" and emps.CorpId ={0} ", corpId);
            if (empName != "")
                sb.AppendFormat(" and emp.EmpName like '%{0}%' ", empName);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
