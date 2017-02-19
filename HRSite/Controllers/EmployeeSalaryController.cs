using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Model;
using HR.BLL;
using HR.Common;
using System.Data;
using System.Data.OleDb;

namespace HRSite.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        // GET: EmployeeSalary
        public ActionResult EmployeeSalaryList()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoadEmployeeSalaryList(int pageIndex, int pageSize, string orderField, string sortOrder, string empName, int corpId)
        {
            switch (orderField)
            {
                case "EmpSalaryId":
                    orderField = "EmpSalaryId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeSalaryBLL empsBLL = new EmployeeSalaryBLL();
            ResultModel result = empsBLL.LoadEmployeeSalaryList(pageIndex, pageSize, orderStr, empName, corpId);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult EmpUpLoadFile()
        {
            HttpFileCollectionBase files = Request.Files;
            var file = files[0];

            //上传文件并指定上传目录的路径    
            String fileSave = Server.MapPath("~/uploads/") + file.FileName;//在服务器的路径，上传Excel的路径 
            file.SaveAs(fileSave);
            //解析Excel 
            DataSet ds = new DataSet();
            ds = ExcelToDS(fileSave); //调用ExcelToDS方法解析Excel 
            ResultModel result = new ResultModel();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime payDate = Convert.ToDateTime(ds.Tables[0].Rows[i][0]);
                string empName = ds.Tables[0].Rows[i][1].ToString();//姓名
                string cardNo = ds.Tables[0].Rows[i][2].ToString();//身份证
                decimal totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[i][3]);//应发工资

                EmployeeBLL empBLL = new EmployeeBLL();
                ResultModel<Employee> resultEmployee = empBLL.GetEmployeeByCardNo(cardNo);

                if (resultEmployee.ResultStatus != 0 || resultEmployee == null)
                    return Json(resultEmployee);

                List<Employee> employeeList = resultEmployee.ReturnValues;
                if (employeeList == null)
                    return Json(employeeList);
                Employee rtnEmployee = employeeList.FirstOrDefault();

                CorporationBLL corpBLL = new CorporationBLL();
                ResultModel<Corporation> resultCorp = corpBLL.Get<Corporation>(rtnEmployee.CorpId);
                if(resultCorp.ResultStatus != 0)
                    return Json(new ResultModel("企业不存在"));

                Corporation rtnCorp = resultCorp.ReturnValue;
                if(rtnCorp == null || rtnCorp.CorpId <0)
                    return Json(new ResultModel("企业不存在"));

                EmployeeSalaryBLL empSalaryBLL = new EmployeeSalaryBLL();
                List<SocialBase> socialBaseList = BaseProvider.SocialBases;
                
                SocialBase socialBase = socialBaseList.FirstOrDefault(temp => temp.CityId == rtnEmployee.PayCity);
                if (socialBase == null)
                    return Json(new ResultModel("社保信息不存在"));

                ResultModel<EmployeeSalary> resultEmps = empSalaryBLL.LoadEmployeeSalaryCheckOne(rtnEmployee.EmpId,payDate);
                if (resultEmps.ResultStatus != 0 || resultEmps == null)
                    return Json(resultEmps);
                List<EmployeeSalary> empsList = resultEmps.ReturnValues;
                if (empsList == null || empsList.Count > 0)
                    continue;

                decimal corpPensionIns = rtnEmployee.RISINum * socialBase.CorpPensionInsPoint / 100 + socialBase.PensionInsFix;
                decimal corpMedicalIns = rtnEmployee.MISINum * socialBase.CorpMedicalInsPoint / 100 + socialBase.MedicalInsFix;
                decimal corpUnempIns = rtnEmployee.UISINum * socialBase.CorpUnempInsPoint / 100 + socialBase.UnempInsFix;
                decimal corpInjuryIns = rtnEmployee.IISINum * socialBase.CorpInjuryInsPoint / 100 + socialBase.InjuryInsFix;
                decimal corpBirthIns = rtnEmployee.BISINum * socialBase.CorpBirthInsPoint / 100 + socialBase.BirthInsFix;
                decimal corpDisabledIns = rtnEmployee.DISINum * socialBase.CorpDisabledInsPoint / 100 + socialBase.DisabledInsFix;
                decimal corpIllnessIns = rtnEmployee.LISINum * socialBase.CorpIllnessInsPoint / 100 + socialBase.IllnessInsFix;
                decimal corpHeatAmount = rtnEmployee.HASINum * socialBase.CorpHeatAmountPoint / 100 + socialBase.HeatAmountFix;
                decimal corpHouseFund = rtnEmployee.HFSINum * socialBase.CorpHouseFundPoint / 100 + socialBase.HouseFundFix;
                decimal corpRepInjuryIns = rtnEmployee.RISINum * socialBase.CorpRepInjuryInsPoint / 100 + socialBase.RepInjuryInsFix;
                decimal corpTotal = corpPensionIns + corpMedicalIns + corpUnempIns + corpInjuryIns + corpBirthIns + corpDisabledIns + corpIllnessIns + corpHeatAmount + corpHouseFund + corpRepInjuryIns;

                decimal empPensionIns = rtnEmployee.RISINum * socialBase.EmpPensionInsPoint / 100 + socialBase.PensionInsFix;
                decimal empMedicalIns = rtnEmployee.MISINum * socialBase.EmpMedicalInsPoint / 100 + socialBase.MedicalInsFix;
                decimal empUnempIns = rtnEmployee.UISINum * socialBase.EmpUnempInsPoint / 100 + socialBase.UnempInsFix;
                decimal empInjuryIns = rtnEmployee.IISINum * socialBase.EmpInjuryInsPoint / 100 + socialBase.InjuryInsFix;
                decimal empBirthIns = rtnEmployee.BISINum * socialBase.EmpBirthInsPoint / 100 + socialBase.BirthInsFix;
                decimal empDisabledIns = rtnEmployee.DISINum * socialBase.EmpDisabledInsPoint / 100 + socialBase.DisabledInsFix;
                decimal empIllnessIns = rtnEmployee.LISINum * socialBase.EmpIllnessInsPoint / 100 + socialBase.IllnessInsFix;
                decimal empHeatAmount = rtnEmployee.HASINum * socialBase.EmpHeatAmountPoint / 100 + socialBase.HeatAmountFix;
                decimal empHouseFund = rtnEmployee.HFSINum * socialBase.EmpHouseFundPoint / 100 + socialBase.HouseFundFix;
                decimal empRepInjuryIns = rtnEmployee.RISINum * socialBase.EmpRepInjuryInsPoint / 100 + socialBase.RepInjuryInsFix;
                decimal empTotal = empPensionIns + empMedicalIns + empUnempIns + empInjuryIns + empBirthIns + empDisabledIns + empIllnessIns + empHeatAmount + empHouseFund + empRepInjuryIns;

                EmployeeSalary empSalary = new EmployeeSalary();
                empSalary.EmpId = rtnEmployee.EmpId;
                empSalary.PayCity = rtnEmployee.PayCity;
                empSalary.CorpId = rtnEmployee.CorpId;
                empSalary.SupId = rtnEmployee.SupId;
                empSalary.CorpPensionIns = corpPensionIns;
                empSalary.CorpMedicalIns = corpMedicalIns;
                empSalary.CorpUnempIns = corpUnempIns;
                empSalary.CorpInjuryIns = corpInjuryIns;
                empSalary.CorpBirthIns = corpBirthIns;
                empSalary.CorpDisabledIns = corpDisabledIns;
                empSalary.CorpIllnessIns = corpIllnessIns;
                empSalary.CorpHeatAmount = corpHeatAmount;
                empSalary.CorpHouseFund = corpHouseFund;
                empSalary.CorpRepInjuryIns = corpRepInjuryIns;
                empSalary.CorpTotal = corpTotal;

                empSalary.EmpPensionIns = empPensionIns;
                empSalary.EmpMedicalIns = empMedicalIns;
                empSalary.EmpUnempIns = empUnempIns;
                empSalary.EmpInjuryIns = empInjuryIns;
                empSalary.EmpBirthIns = empBirthIns;
                empSalary.EmpDisabledIns = empDisabledIns;
                empSalary.EmpIllnessIns = empIllnessIns;
                empSalary.EmpHeatAmount = empHeatAmount;
                empSalary.EmpHouseFund = empHouseFund;
                empSalary.EmpRepInjuryIns = empRepInjuryIns;
                empSalary.EmpTotal = empTotal;

                empSalary.TotalAmount = totalAmount;
                empSalary.RepairAmount = 0;//补充社保
                decimal grossAmount = totalAmount - empTotal;
                empSalary.GrossAmount = grossAmount;//税前
                decimal personalTax = Calculator.PersonalTax(grossAmount);
                empSalary.PersonalTax = personalTax;//个调税
                decimal finalAmount = grossAmount - personalTax;
                empSalary.FinalAmount = finalAmount;//实发
                empSalary.ServiceAmount = rtnCorp.ServiceAmount;//服务费
                empSalary.RefundAmount = 0;//补收/退款

                empSalary.PayDate = payDate;
                empSalary.EmpSalaryStatus = (int)StatusEnum.已完成;
                result = empSalaryBLL.Insert(empSalary);

                if (result.ResultStatus != 0)
                    return Json(result);
            }

            result.Message = "员工薪资发放成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }
        public DataSet ExcelToDS(string Path)
        {
            string strType = System.IO.Path.GetExtension(Path);
            if (System.IO.File.Exists(Path))
            {
                string strConn = string.Empty;
                if (strType == ".xlsx")
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;IMEX=1'";
                }
                else if (strType == ".xls")
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties='Excel 8.0;IMEX=1'";
                }
                //  string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;IMEX=1'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等　
                System.Data.DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                //包含excel中表名的字符串数组
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                }
                OleDbDataAdapter myCommand = null;
                DataSet ds = new DataSet();
                //从指定的表明查询数据,可先把所有表明列出来供用户选择
                string strExcel = "select*from[" + strTableNames[0] + "]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(ds);
                return ds;//绑定到界面
            }
            else
            {
                return new DataSet();
            }
        }
    }
}