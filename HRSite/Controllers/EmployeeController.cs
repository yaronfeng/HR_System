using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Model;
using HR.BLL;
using HR.Common;


namespace HRSite.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult EmployeeAdd()
        {
            return View();
        }
        public ActionResult EmployeeList()
        {
            return View();
        }

        public ActionResult EmployeeDetail()
        {

            return View();
        }
        public ActionResult EmployeeUpdate()
        {
            return View();
        }
        public ActionResult EmployeeExpireList()
        {
            return View();
        }

        public ActionResult CalculatePay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadEmployeeList(int pageIndex, int pageSize, string orderField, string sortOrder,string empName,int corpId,DateTime conStartDate,DateTime conEndDate)
        {
            switch (orderField)
            {
                case "EmpId":
                    orderField = "EmpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.LoadEmployeeList(pageIndex, pageSize, orderStr, empName, corpId, conStartDate, conEndDate);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult LoadEmployeeExpireList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "EmpId":
                    orderField = "EmpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.LoadEmployeeExpireList(pageIndex, pageSize, orderStr);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult LoadEmployeeSalaryList(int pageIndex, int pageSize, string orderField, string sortOrder,int empId)
        {
            switch (orderField)
            {
                case "EmpId":
                    orderField = "EmpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.LoadEmployeeSalaryList(pageIndex, pageSize, orderStr,empId);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        /// <summary>
        /// 查询未发放薪资员工列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderField"></param>
        /// <param name="sortOrder"></param>
        /// <param name="corpId"></param>
        /// <param name="payDate"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoadEmployeePayList(int pageIndex, int pageSize, string orderField, string sortOrder,int corpId,DateTime payDate)
        {
            switch (orderField)
            {
                case "EmpId":
                    orderField = "EmpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.LoadEmployeePayList(0, 500, orderStr, corpId, payDate);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult InsertEmployeeSalary(EmployeeSalary[] details)
        {
            string empId = string.Empty;
            EmployeeBLL empBLL = new EmployeeBLL();
            EmployeeSalaryBLL empSalaryBLL = new EmployeeSalaryBLL();

            List<SocialBase> socialBaseList = BaseProvider.SocialBases;
            ResultModel result = new ResultModel();
            foreach (var emp in details)
            {
                ResultModel<Employee> resultEmployee = empBLL.Get<Employee>(emp.EmpId);
                if (resultEmployee.ResultStatus != 0)
                    return Json(resultEmployee);

                Employee rtnEmployee = resultEmployee.ReturnValue;
                if (rtnEmployee == null)
                    return Json(new ResultModel(string.Format("{0}不存在", this.ModelName)));

                SocialBase socialBase = socialBaseList.FirstOrDefault(temp => temp.CityId == rtnEmployee.PayCity);
                if (socialBase == null)
                    return Json(new ResultModel("社保信息不存在"));

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

                empSalary.TotalAmount = emp.TotalAmount;
                empSalary.RepairAmount = emp.RepairAmount;//补充社保
                decimal grossAmount = emp.TotalAmount - empTotal;
                empSalary.GrossAmount = grossAmount;//税前
                decimal personalTax = Calculator.PersonalTax(grossAmount);
                empSalary.PersonalTax = personalTax;//个调税
                decimal finalAmount = grossAmount - personalTax;
                empSalary.FinalAmount = finalAmount;//实发
                empSalary.ServiceAmount = emp.ServiceAmount;//服务费
                empSalary.RefundAmount = emp.RefundAmount;//补收/退款

                empSalary.PayDate = DateTime.Now;
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

        [HttpPost]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return Json(new ResultModel(string.Format("{0}不存在", this.ModelName)));

            EmployeeBLL dal = new EmployeeBLL();
            ResultModel result = dal.Get(id);
            if (result.ResultStatus != 0)
                return Json(result);

            object rtnObj = result.ReturnValue;
            if (rtnObj == null)
                return Json(new ResultModel(string.Format("{0}不存在", this.ModelName)));

            result.ResultStatus = 0;
            result.Message = string.Format("{0}获取成功", this.ModelName);
            result.ReturnValue = Newtonsoft.Json.JsonConvert.SerializeObject(rtnObj);
            return Json(result);
        }

        [HttpPost]
        public ActionResult Insert(Employee employee)
        {
            employee.EmpStatus = (int)StatusEnum.已完成;

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.Insert(employee);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "员工新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            EmployeeBLL empBLL = new EmployeeBLL();

            //获取客户信息
            ResultModel<Employee> empResult = empBLL.Get<Employee>(employee.EmpId);
            if (empResult == null || empResult.ResultStatus != 0)
                new ResultModel("用户获取失败或不存在");

            Employee rtnEmployee = empResult.ReturnValue;
            if (rtnEmployee == null || rtnEmployee.CorpId <= 0)
                new ResultModel("用户获取失败或不存在");

            rtnEmployee.EmpName = employee.EmpName;
            rtnEmployee.Sex = employee.Sex;
            rtnEmployee.CorpId = employee.CorpId;
            rtnEmployee.SupId = employee.SupId;
            rtnEmployee.CardNo = employee.CardNo;
            rtnEmployee.Address = employee.Address;
            rtnEmployee.Phone = employee.Phone;
            rtnEmployee.EntryDate = employee.EntryDate;
            rtnEmployee.IsContract = employee.IsContract;
            rtnEmployee.ConStartDate = employee.ConStartDate;
            rtnEmployee.ConEndDate = employee.ConEndDate;
            rtnEmployee.LeaveDate = employee.LeaveDate;
            rtnEmployee.Degree = employee.Degree;
            rtnEmployee.Jobs = employee.Jobs;
            rtnEmployee.TotalAmount = employee.TotalAmount;
            rtnEmployee.PayCity = employee.PayCity;
            rtnEmployee.SocialStartDate = employee.SocialStartDate;
            rtnEmployee.HouseStartDate = employee.HouseStartDate;
            rtnEmployee.HouseAccount = employee.HouseAccount;
            rtnEmployee.HandBook = employee.HandBook;
            rtnEmployee.ResidentPermit = employee.ResidentPermit;
            rtnEmployee.Bank = employee.Bank;
            rtnEmployee.BankAccount = employee.BankAccount;
            rtnEmployee.ContractNo = employee.ContractNo;
            rtnEmployee.EmployDate = employee.EmployDate;
            rtnEmployee.SocialSignDate = employee.SocialSignDate;
            rtnEmployee.IsBirthIns = employee.IsBirthIns;
            rtnEmployee.InsCardNo = employee.InsCardNo;
            rtnEmployee.EmpEmail = employee.EmpEmail;
            rtnEmployee.PISINum = employee.PISINum;
            rtnEmployee.MISINum = employee.MISINum;
            rtnEmployee.UISINum = employee.UISINum;
            rtnEmployee.IISINum = employee.IISINum;
            rtnEmployee.BISINum = employee.BISINum;
            rtnEmployee.DISINum = employee.DISINum;
            rtnEmployee.LISINum = employee.LISINum;
            rtnEmployee.HASINum = employee.HASINum;
            rtnEmployee.HFSINum = employee.HFSINum;
            rtnEmployee.RISINum = employee.RISINum;
            rtnEmployee.Memo = employee.Memo;

            ResultModel result = empBLL.Update(rtnEmployee);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "用户修改成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }

        protected string ModelName
        {
            get { return "员工"; }
        }
    }
}