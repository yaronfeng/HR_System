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
    public class SupBillController : Controller
    {
        private string redirectUrl = "/CorpBill/CorpBillReadyList";
        // GET: SupBill
        public ActionResult SupBillList()
        {
            return View();
        }
        public ActionResult SupBillReadyList()
        {
            return View();
        }
        public ActionResult SupBillAdd()
        {
            int id = 0;
            if (string.IsNullOrEmpty(Request.QueryString["id"]) || !int.TryParse(Request.QueryString["id"], out id) || id <= 0)
                return Content(JsUtility.WarmAlert("供应商不存在", redirectUrl));

            SupBillBLL supBillBLL = new SupBillBLL();
            ResultModel<SupBill> supBillResult = supBillBLL.LoadSupBills(id);
            if (supBillResult.ResultStatus != 0)
                return Json(ResultModel.GenericResult<SupBill>(supBillResult));

            List<SupBill> rtnSupBill = supBillResult.ReturnValues;
            if (rtnSupBill == null)
                return Json(new ResultModel("获取账单列表失败"));

            int supBillCount = rtnSupBill.Count();
            if (supBillCount > 0)
                return Content(JsUtility.WarmAlert("供应商本月账单已生成", redirectUrl));

            ResultModel result = supBillBLL.LoadSupEmployeeList(0, 500, null, id);

            if (result.ResultStatus != 0)
                return Content(JsUtility.WarmAlert("获取错误", redirectUrl));
            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            if (dt == null)
                return Content(JsUtility.WarmAlert("获取错误", redirectUrl));
            string optJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dt, new Newtonsoft.Json.Converters.DataTableConverter());
            ViewData["JsonOptData"] = optJsonStr;
            return View();
        }
        [HttpPost]
        public ActionResult LoadSupBillReadyList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "SupId":
                    orderField = "SupId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            SupBillBLL supbillBLL = new SupBillBLL();
            ResultModel result = supbillBLL.LoadSupBillReadyList(0, 200, orderStr);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult Insert(SupBill supBill, SupBillDetail[] details)
        {
            supBill.SupBillStatus = (int)StatusEnum.已完成;
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);

            SupBillBLL supBillBLL = new SupBillBLL();
            SupBillDetailBLL detailBLL = new SupBillDetailBLL();

            //获取企业账单
            ResultModel<SupBill> supBillResult = supBillBLL.LoadSupBills(supBill.SupId);
            if (supBillResult.ResultStatus != 0)
                return Json(ResultModel.GenericResult<SupBill>(supBillResult));

            List<SupBill> rtnSupBill = supBillResult.ReturnValues;
            if (rtnSupBill == null)
                return Json(new ResultModel("获取账单列表失败"));

            int supBillCount = rtnSupBill.Count();
            if (supBillCount > 0)
                return Content(JsUtility.WarmAlert("供应商本月账单已生成", redirectUrl));

            //新增账单
            ResultModel result = supBillBLL.Insert(supBill);
            if (result.ResultStatus != 0)
                return Json(result);

            int supBillId = 0;
            if (result.ReturnValue == null || !int.TryParse(result.ReturnValue.ToString(), out supBillId) || supBillId <= 0)
                return Content("账单新增失败");

            //新增制单明细
            foreach (SupBillDetail detail in details)
            {
                detail.SupBillId = supBillId;
                detail.DetailStatus = (int)StatusEnum.已完成;

                result = detailBLL.Insert(detail);
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