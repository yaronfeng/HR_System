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
    public class CorporationController : Controller
    {
        // GET: Corporation
        public ActionResult CorporationAdd()
        {
            return View();
        }

        public ActionResult CorporationList()
        {
            return View();
        }

        public ActionResult CorporationDetail()
        {
            return View();
        }

        public ActionResult CorporationUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Corps()
        {
            string jsonStr = string.Empty;
            var corps = HR.BLL.BaseProvider.Corporations.OrderBy(temp => temp.CorpName);
            jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(corps);
            return Json(jsonStr);
        }

        [HttpPost]
        public ActionResult LoadCorporationList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "CorpId":
                    orderField = "CorpId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            CorporationBLL corporationBLL = new CorporationBLL();
            ResultModel result = corporationBLL.LoadCorporationList(pageIndex, pageSize, orderStr);

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

            CorporationBLL dal = new CorporationBLL();
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
        public ActionResult Insert(Corporation corp)
        {
            CorporationBLL corpBLL = new CorporationBLL();
            corp.CreatorId = 1;
            ResultModel result = corpBLL.Insert(corp);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "客户新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }

        [HttpPost]
        public ActionResult Update(Corporation corp)
        {
            CorporationBLL corpBLL = new CorporationBLL();

            //获取客户信息
            ResultModel<Corporation> corpResult = corpBLL.Get<Corporation>(corp.CorpId);
            if (corpResult == null || corpResult.ResultStatus != 0)
                new ResultModel("客户获取失败或不存在");

            Corporation rtnCorporation = corpResult.ReturnValue;
            if (rtnCorporation == null || rtnCorporation.CorpId <= 0)
                new ResultModel("客户获取失败或不存在");

            rtnCorporation.CorpCode = corp.CorpCode;
            rtnCorporation.CorpName = corp.CorpName;
            rtnCorporation.CorpEName = corp.CorpEName;
            rtnCorporation.CorpAddress = corp.CorpAddress;
            rtnCorporation.CorpContacts = corp.CorpContacts;
            rtnCorporation.CorpTel = corp.CorpTel;
            rtnCorporation.CorpFax = corp.CorpFax;
            rtnCorporation.CorpZip = corp.CorpZip;
            rtnCorporation.CorpEmail = corp.CorpEmail;
            rtnCorporation.OrganizationCode = corp.OrganizationCode;
            rtnCorporation.InternetPWD = corp.InternetPWD;
            rtnCorporation.SocialRegCode = corp.SocialRegCode;
            rtnCorporation.PayCity = corp.PayCity;
            rtnCorporation.HouseAccount = corp.HouseAccount;
            rtnCorporation.HouseBank = corp.HouseBank;
            rtnCorporation.HousePWD = corp.HousePWD;
            rtnCorporation.Memo = corp.Memo;

            ResultModel result = corpBLL.Update(corp);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "客户修改成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }

        protected string ModelName
        {
            get { return "客户"; }
        }
    }
}