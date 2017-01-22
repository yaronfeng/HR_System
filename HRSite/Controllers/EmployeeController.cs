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

        [HttpPost]
        public ActionResult LoadEmployeeList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "EmpId":
                    orderField = "EmpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            EmployeeBLL employeeBLL = new EmployeeBLL();
            ResultModel result = employeeBLL.LoadEmployeeList(pageIndex, pageSize, orderStr);

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
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);

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
            rtnEmployee.CardNo = employee.CardNo;
            rtnEmployee.Address = employee.Address;
            rtnEmployee.Phone = employee.Phone;
            rtnEmployee.EntryDate = employee.EntryDate;
            rtnEmployee.ConStartDate = employee.ConStartDate;
            rtnEmployee.ConEndDate = employee.ConEndDate;
            rtnEmployee.LeaveDate = employee.LeaveDate;
            rtnEmployee.Degree = employee.Degree;
            rtnEmployee.Jobs = employee.Jobs;
            rtnEmployee.TotalAmount = employee.TotalAmount;
            rtnEmployee.SocialFundNum = employee.SocialFundNum;
            rtnEmployee.HouseFundNum = employee.HouseFundNum;
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