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
            int result = employeeBLL.AddEmployee(employee);
            if (result > 0)
                return Content("1000");
            return Content("1001");
        }

        public ActionResult EmployeeDetail()
        {
            
            return View();
        }
        public ActionResult EmployeeUpdate()
        {
            return View();
        }

        protected string ModelName
        {
            get { return "员工"; }
        }
    }
}