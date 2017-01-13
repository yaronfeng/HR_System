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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeAdd()
        {
            return View();
        }
        public ActionResult EmployeeList()
        {
            return View();
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
    }
}