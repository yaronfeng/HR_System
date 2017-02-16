using HR.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Model;
using System.Data.SqlClient;
using System.Data;
using HR.Common;

namespace HR.SQLServerDAL
{
    public class EmployeeSQL
    {
        private string ConnectString
        {
            get
            {
                return SQLConnString.GetConnSting();
            }
        }

        public SelectModel EmployeeListSelect(int pageIndex, int pageSize, string orderStr, string empName, int corpId, DateTime conStartDate, DateTime conEndDate)
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
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}",(int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdsex on sdsex.DetailId = emp.Sex and sdsex.StyleId = {0}", (int)StyleTypeEnum.性别类型);
            sb.AppendFormat(" left join bd_StyleDetail sddeg on sddeg.DetailId = emp.Degree and sddeg.StyleId = {0}", (int)StyleTypeEnum.学历类型);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emp.EmpStatus ={0} ", (int)StatusEnum.已完成);
            sb.AppendFormat(" and emp.ConEndDate between '{0}' and '{1}' ", conStartDate, conEndDate);

            if (!string.IsNullOrEmpty(empName))
                sb.AppendFormat(" and emp.EmpName ='%{0}%' ", empName);
            if(corpId > 0)
                sb.AppendFormat(" and emp.CorpId ={0} ", corpId);
            

            select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel EmployeeSalaryListSelect(int pageIndex, int pageSize, string orderStr,int empId)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " EmpSalaryId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "EmpSalaryId,emps.EmpId,emp.EmpName,emps.PayCity,sdcity.DetailName as PayCityName,emps.CorpId,CorpPensionIns,CorpMedicalIns,CorpUnempIns,CorpInjuryIns,CorpBirthIns,CorpDisabledIns,CorpIllnessIns,CorpHeatAmount,CorpHouseFund,CorpRepInjuryIns,CorpTotal,EmpPensionIns,EmpMedicalIns,EmpUnempIns,EmpInjuryIns,EmpBirthIns,EmpDisabledIns,EmpIllnessIns,EmpHeatAmount,EmpHouseFund,EmpRepInjuryIns,EmpTotal,PersonalTax,emps.TotalAmount,RepairAmount,GrossAmount,FinalAmount,ServiceAmount,RefundAmount,PayDate,EmpSalaryStatus";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_EmployeeSalary emps");
            sb.Append(" left join Usr_Employee emp on emp.EmpId = emps.EmpId");
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emps.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;
            if(empId >0)
                sb.AppendFormat(" emps.EmpId ={0} ", empId);

            select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel EmployeeExpireListSelect(int pageIndex, int pageSize, string orderStr,string empName,int corpId,DateTime conStartDate,DateTime conEndDate)
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
            sb.AppendFormat(" and emp.ConEndDate between '{0}' and '{1}' ", conStartDate, conEndDate);

            if (!string.IsNullOrEmpty(empName))
                sb.AppendFormat(" and emp.EmpName ='%{0}%' ", empName);
            if (corpId > 0)
                sb.AppendFormat(" and emp.CorpId ={0} ", corpId);

            select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel EmployeePayListSelect(int pageIndex, int pageSize, string orderStr, int corpId, DateTime payDate)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " emp.EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "emp.EmpId,emp.CorpId,emp.SupId,emp.EmpName,corp.CorpName,sdsex.DetailName Sex,emp.CardNo,emp.Phone,emp.ConStartDate,emp.ConEndDate,emp.TotalAmount,sddeg.DetailName as Degree,sdcity.DetailName as PayCity,emp.EmpEmail,emp.EmpStatus,corp.ServiceAmount,sd.DetailName as StatusName";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_Employee emp");
            sb.Append(" left join Usr_Corporation corp on corp.CorpId = emp.CorpId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}", (int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" left join bd_StyleDetail sdsex on sdsex.DetailId = emp.Sex and sdsex.StyleId = {0}", (int)StyleTypeEnum.性别类型);
            sb.AppendFormat(" left join bd_StyleDetail sddeg on sddeg.DetailId = emp.Degree and sddeg.StyleId = {0}", (int)StyleTypeEnum.学历类型);
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);
            sb.AppendFormat(" left join Usr_EmployeeSalary emps on emps.EmpId = emp.EmpId and datediff(month,[PayDate],'{0}')= 0", payDate);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.Append("1=1");
            if(corpId > 0)
                sb.AppendFormat(" and emp.CorpId = {0}", corpId);
            sb.AppendFormat(" and emps.EmpSalaryId is null", corpId);

            select.WhereStr = sb.ToString();

            return select;
        }

        public SelectModel EmployeeExpireDownLoadSelect(int pageIndex, int pageSize, string orderStr, string empName, int corpId, DateTime conStartDate, DateTime conEndDate)
        {
            SelectModel select = new SelectModel();

            select.PageIndex = pageIndex;
            select.PageSize = pageSize;
            if (string.IsNullOrEmpty(orderStr))
                select.OrderStr = " EmpId desc";
            else
                select.OrderStr = orderStr;

            select.ColumnName = "emp.EmpName,corp.CorpName,sdsex.DetailName Sex,emp.CardNo,emp.Phone,emp.ConStartDate,emp.ConEndDate,emp.TotalAmount,sddeg.DetailName as Degree,sdcity.DetailName as PayCity,emp.EmpEmail";

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
            sb.AppendFormat(" and emp.ConEndDate between '{0}' and '{1}' ", conStartDate, conEndDate);

            if (!string.IsNullOrEmpty(empName))
                sb.AppendFormat(" and emp.EmpName ='%{0}%' ", empName);
            if (corpId > 0)
                sb.AppendFormat(" and emp.CorpId ={0} ", corpId);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
