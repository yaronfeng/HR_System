using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.BLL;
using HR.Common;

namespace HRSite.Controllers
{
    public class CorpBillController : Controller
    {
        // GET: CorpBill
        public ActionResult CorpBillAdd()
        {
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
            ResultModel result = corpbillBLL.LoadCorpBillReadyList(pageIndex, pageSize, orderStr);

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
    }
}