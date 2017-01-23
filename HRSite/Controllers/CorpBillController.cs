using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.BLL;
using HR.Common;
using HR.Model;
using HR.HRSite;

namespace HRSite.Controllers
{
    public class CorpBillController : Controller
    {
        private string redirectUrl = "/CorpBill/CorpBillReadyList";
        // GET: CorpBill
        public ActionResult CorpBillAdd()
        {
            int id = 0;
            if (string.IsNullOrEmpty(Request.QueryString["id"]) || !int.TryParse(Request.QueryString["id"], out id) || id <= 0)
                return Content(JsUtility.WarmAlert("客户不存在", redirectUrl));

            CorpBillBLL corpBillBLL = new CorpBillBLL();
            ResultModel<CorpBill> corpBillResult = corpBillBLL.LoadCorpBills(id);
            if (corpBillResult.ResultStatus != 0)
                return Json(ResultModel.GenericResult<CorpBill>(corpBillResult));

            List<CorpBill> rtnCorpBill = corpBillResult.ReturnValues;
            if (rtnCorpBill == null)
                return Json(new ResultModel("获取账单列表失败"));

            int corpBillCount = rtnCorpBill.Count();
            if (corpBillCount > 0)
                return Content(JsUtility.WarmAlert("客户本月账单已生成", redirectUrl));

            ResultModel result = corpBillBLL.LoadCorpEmployeeList(0, 100, null, id);

            if (result.ResultStatus != 0)
                return Content(JsUtility.WarmAlert("获取错误", redirectUrl));
            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            if (dt == null)
                return Content(JsUtility.WarmAlert("获取错误", redirectUrl));
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
        public ActionResult LoadEmployeeSalaryByIdList(int pageIndex, int pageSize, string orderField, string sortOrder,int corpBillId)
        {
            switch (orderField)
            {
                case "EmpSalaryId":
                    orderField = "EmpSalaryId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            CorpBillBLL corpbillBLL = new CorpBillBLL();
            ResultModel result = corpbillBLL.LoadEmployeeSalaryByIdList(0, 200, orderStr, corpBillId);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult LoadCorpBillList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "CorpId":
                    orderField = "CorpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            CorpBillBLL corpbillBLL = new CorpBillBLL();
            ResultModel result = corpbillBLL.LoadCorpBillList(pageIndex, pageSize, orderStr);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
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
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return Json(new ResultModel(string.Format("{0}不存在", this.ModelName)));

            CorpBillBLL dal = new CorpBillBLL();
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
                detail.CorpId = corpBill.CorpId;
                detail.CorpBillId = corpBillId;
                detail.PayDate = corpBill.PayDate;
                detail.EmpSalaryStatus = (int)StatusEnum.已完成;

                result = empSalaryBLL.Insert(detail);
                if (result.ResultStatus != 0)
                    return Json(result);
            }

            result.Message = "账单新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);
        }
        protected string ModelName
        {
            get { return "账单"; }
        }
    }
}