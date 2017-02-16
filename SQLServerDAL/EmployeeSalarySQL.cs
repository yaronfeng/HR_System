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
                select.OrderStr = " EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "emp.EmpId,emp.EmpName,corp.CorpName,sdsex.DetailName Sex,emp.CardNo,emp.Phone,emp.ConStartDate,emp.ConEndDate,emp.TotalAmount,sddeg.DetailName as Degree,sdcity.DetailName as PayCity,emp.EmpEmail,emp.EmpStatus,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Employee emp");
            sb.Append(" left join Usr_Corporation corp on corp.CorpId = emp.CorpId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdsex on sdsex.DetailId = emp.Sex and sdsex.StyleId = {0}", (int)StyleTypeEnum.性别类型);
            sb.AppendFormat(" left join bd_StyleDetail sddeg on sddeg.DetailId = emp.Degree and sddeg.StyleId = {0}", (int)StyleTypeEnum.学历类型);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emp.EmpStatus ={0} ", (int)StatusEnum.已完成);

            if (!string.IsNullOrEmpty(empName))
                sb.AppendFormat(" and emp.EmpName ='%{0}%' ", empName);
            if (corpId > 0)
                sb.AppendFormat(" and emp.CorpId ={0} ", corpId);


            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
