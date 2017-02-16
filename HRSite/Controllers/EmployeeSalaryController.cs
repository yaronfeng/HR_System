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
                case "EmpId":
                    orderField = "EmpId";
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
    }
}