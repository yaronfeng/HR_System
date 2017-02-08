using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Model;
using HR.Common;
using HR.BLL;

namespace HRSite.Controllers
{
    public class SendController : Controller
    {
        // GET: Send
        public ActionResult SendEmail(int id)
        {
            if (id <= 0)
                return Json(new ResultModel(string.Format("账单不存在")));

            CorpBillBLL dal = new CorpBillBLL();
            ResultModel result = dal.Get(id);
            if (result.ResultStatus != 0)
                return Json(result);

            CorpBill rtnCorpBill = result.ReturnValue as CorpBill;
            if (rtnCorpBill == null)
                return Json(new ResultModel(string.Format("账单不存在")));

            string[] To = { "147851808@qq.com" };
            string Subject = "账单" + rtnCorpBill.BillDate.ToString("yyyyMMdd");
            string Body = "客户您好，当月账单费用为：" + rtnCorpBill.TotalAmount;
            SendMail.Send(To, Subject, Body);

            result = new ResultModel();
            result.ResultStatus = 0;
            result.Message = "发送成功";
            return Json(result);
        }

        [HttpPost]
        public ActionResult SendEmployeeEmail(int id)
        {
            if (id <= 0)
                return Json(new ResultModel(string.Format("用户薪资不存在")));

            EmployeeSalaryBLL empsBLL = new EmployeeSalaryBLL();
            EmployeeBLL empBLL = new EmployeeBLL();

            ResultModel result = empsBLL.Get(id);
            if (result.ResultStatus != 0)
                return Json(result);

            EmployeeSalary rtnEmployeeSalary = result.ReturnValue as EmployeeSalary;
            if (rtnEmployeeSalary == null)
                return Json(new ResultModel(string.Format("用户薪资不存在")));

            result = empBLL.Get(rtnEmployeeSalary.EmpId);
            if (result.ResultStatus != 0)
                return Json(result);

            Employee rtnEmployee = result.ReturnValue as Employee;
            if (rtnEmployee == null)
                return Json(new ResultModel(string.Format("用户不存在")));



            string[] To = { "147851808@qq.com" };
            string Subject = "工资" + rtnEmployeeSalary.PayDate.ToString("yyyyMMdd");
            string Body = rtnEmployee.EmpName + "您好，"+ rtnEmployeeSalary.PayDate.ToString("yyyyMMdd") + "工资明细为：";
            Body += "<br>应发工资：" + rtnEmployeeSalary.TotalAmount;
            Body += "<br>养老保险：" + rtnEmployeeSalary.EmpPensionIns;
            Body += "<br>医疗保险：" + rtnEmployeeSalary.EmpMedicalIns;
            Body += "<br>失业保险：" + rtnEmployeeSalary.EmpUnempIns;
            Body += "<br>工伤保险：" + rtnEmployeeSalary.EmpInjuryIns;
            Body += "<br>生育保险：" + rtnEmployeeSalary.EmpBirthIns;
            Body += "<br>残疾人保险：" + rtnEmployeeSalary.EmpDisabledIns;
            Body += "<br>大病保险：" + rtnEmployeeSalary.EmpIllnessIns;
            Body += "<br>取暖费：" + rtnEmployeeSalary.EmpHeatAmount;
            Body += "<br>公积金：" + rtnEmployeeSalary.EmpHouseFund;
            Body += "<br>补充工伤：" + rtnEmployeeSalary.EmpRepInjuryIns;
            Body += "<br>个调税：" + rtnEmployeeSalary.PersonalTax;
            Body += "<br>实发工资：" + rtnEmployeeSalary.FinalAmount;
            SendMail.Send(To, Subject, Body);

            return Json(result);
        }
    }
}