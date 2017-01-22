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

        public SelectModel EmployeeListSelect(int pageIndex, int pageSize, string orderStr)
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
            sb.Append(" inner join Usr_Corporation corp on corp.CorpId = emp.CorpId");
            sb.AppendFormat(" inner join bd_StyleDetail sd on sd.DetailId = emp.EmpStatus and sd.StyleId = {0}",(int)StyleTypeEnum.通用状态);
            sb.AppendFormat(" inner join bd_StyleDetail sdsex on sdsex.DetailId = emp.Sex and sdsex.StyleId = {0}", (int)StyleTypeEnum.性别类型);
            sb.AppendFormat(" inner join bd_StyleDetail sddeg on sddeg.DetailId = emp.Degree and sddeg.StyleId = {0}", (int)StyleTypeEnum.学历类型);
            sb.AppendFormat(" inner join bd_StyleDetail sdcity on sdcity.DetailId = emp.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            //sb.Length = 0;

            //sb.AppendFormat(" and di.PositionStatus >{0} ", (int)StatusEnum.已作废);

            //select.WhereStr = sb.ToString();

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

            select.ColumnName = "EmpSalaryId,EmpId,EmpName,PayCity,sdcity.DetailName as PayCityName,CardNo,SocialFundNum,HouseFundNum,CorpId,CorpPensionIns,CorpMedicalIns,CorpUnempIns,CorpInjuryIns,CorpBirthIns,CorpDisabledIns,CorpIllnessIns,CorpHeatAmount,CorpHouseFund,CorpRepInjuryIns,CorpTotal,EmpPensionIns,EmpMedicalIns,EmpUnempIns,EmpInjuryIns,EmpBirthIns,EmpDisabledIns,EmpIllnessIns,EmpHeatAmount,EmpHouseFund,EmpRepInjuryIns,EmpTotal,PersonalTax,TotalAmount,RepairAmount,GrossAmount,FinalAmount,ServiceAmount,RefundAmount,PayDate,CorpBillId,EmpSalaryStatus,Memo";

            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(" Usr_EmployeeSalary emps");
            sb.AppendFormat(" left join bd_StyleDetail sdcity on sdcity.DetailId = emps.PayCity and sdcity.StyleId = {0}", (int)StyleTypeEnum.缴费城市类型);

            select.TableName = sb.ToString();

            sb.Length = 0;

            sb.AppendFormat(" emps.EmpId ={0} ", empId);

            select.WhereStr = sb.ToString();

            return select;
        }
    }
}
