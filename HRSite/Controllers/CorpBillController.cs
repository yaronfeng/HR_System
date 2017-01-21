using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.BLL;
using HR.Common;
using HR.Model;

namespace HRSite.Controllers
{
    public class CorpBillController : Controller
    {
        // GET: CorpBill
        public ActionResult CorpBillAdd()
        {
            int id = 0;
            if (string.IsNullOrEmpty(Request.QueryString["id"]) || !int.TryParse(Request.QueryString["id"], out id) || id <= 0)
                return Content("客户不存在");

            CorpBillBLL corpbillBLL = new CorpBillBLL();
            ResultModel result = corpbillBLL.LoadCorpEmployeeList(0, 100, null, id);

            if (result.ResultStatus != 0)
                return Content("获取错误");
            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            if (dt == null)
                return Content("获取错误");
            string optJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dt, new Newtonsoft.Json.Converters.DataTableConverter());
            ViewData["JsonOptData"] = optJsonStr;
            return View();
        }

        public ActionResult CorpBillList()
        {
            return View();
        }

        public ActionResult CorpBillDetail()
        {
            return View();
        }

        public ActionResult CorpBillUpdate()
        {
            return View();
        }

        public ActionResult CorpBillReadyList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadCorpBillReadyList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "CorpId":
                    orderField = "CorpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            CorpBillBLL corpbillBLL = new CorpBillBLL();
            ResultModel result = corpbillBLL.LoadCorpBillReadyList(0, 200, orderStr);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult LoadCorpEmployeeList(int pageIndex, int pageSize, string orderField, string sortOrder,int corpId)
        {
            switch (orderField)
            {
                case "CorpId":
                    orderField = "CorpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            CorpBillBLL corpbillBLL = new CorpBillBLL();
            ResultModel result = corpbillBLL.LoadCorpEmployeeList(pageIndex, pageSize, orderStr, corpId);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult Insert(CorpBill corpBill,EmployeeSalary[] details)
        {
            corpBill.CorpBillStatus = (int)StatusEnum.已完成;
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);

            CorpBillBLL corpBillBLL = new CorpBillBLL();
            EmployeeSalaryBLL empSalaryBLL = new EmployeeSalaryBLL();
            //新增账单
            ResultModel result = corpBillBLL.Insert(corpBill);
            if (result.ResultStatus != 0)
                return Json(result);

            int corpBillId = 0;
            if (result.ReturnValue == null || !int.TryParse(result.ReturnValue.ToString(), out corpBillId) || corpBillId <= 0)
                return Content("账单新增失败");

            //新增制单明细
            foreach (EmployeeSalary detail in details)
            {
                detail.PayDate = corpBill.PayDate;
                result = empSalaryBLL.Insert(detail);
                if (result.ResultStatus != 0)
                    return Json(result);
            }

            result.Message = "账单新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);
        }
    }
}