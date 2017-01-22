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
    public class SocialBaseController : Controller
    {
        // GET: SocialBase
        // GET: Corporation
        public ActionResult SocialBaseAdd()
        {
            return View();
        }

        public ActionResult SocialBaseList()
        {
            return View();
        }

        public ActionResult SocialBaseDetail()
        {
            return View();
        }

        public ActionResult SocialBaseUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadSocialBaseList(int pageIndex, int pageSize, string orderField, string sortOrder)
        {
            switch (orderField)
            {
                case "SocId":
                    orderField = "SocId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            SocialBaseBLL socialBLL = new SocialBaseBLL();
            ResultModel result = socialBLL.LoadSocialBaseList(pageIndex, pageSize, orderStr);

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

            SocialBaseBLL dal = new SocialBaseBLL();
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
        public ActionResult Insert(SocialBase social)
        {
            SocialBaseBLL socBLL = new SocialBaseBLL();
            social.CreatorId = 1;
            ResultModel result = socBLL.Insert(social);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "社保区域新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }

        [HttpPost]
        public ActionResult Update(SocialBase socialBase)
        {
            SocialBaseBLL socialBLL = new SocialBaseBLL();

            //获取社保比例信息
            ResultModel<SocialBase> socialResult = socialBLL.Get<SocialBase>(socialBase.SocId);
            if (socialResult == null || socialResult.ResultStatus != 0)
                new ResultModel("社保比例获取失败或不存在");

            SocialBase rtnSocialBase = socialResult.ReturnValue;
            if (rtnSocialBase == null || rtnSocialBase.SocId <= 0)
                new ResultModel("社保比例获取失败或不存在");

            rtnSocialBase.CityId = socialBase.CityId;
            rtnSocialBase.SocName = socialBase.SocName;
            rtnSocialBase.SocialFundNum = socialBase.SocialFundNum;
            rtnSocialBase.HouseFundNum = socialBase.HouseFundNum;
            rtnSocialBase.CorpPensionInsPoint = socialBase.CorpPensionInsPoint;
            rtnSocialBase.CorpMedicalInsPoint = socialBase.CorpMedicalInsPoint;
            rtnSocialBase.CorpUnempInsPoint = socialBase.CorpUnempInsPoint;
            rtnSocialBase.CorpInjuryInsPoint = socialBase.CorpInjuryInsPoint;
            rtnSocialBase.CorpBirthInsPoint = socialBase.CorpBirthInsPoint;
            rtnSocialBase.CorpDisabledInsPoint = socialBase.CorpDisabledInsPoint;
            rtnSocialBase.CorpIllnessInsPoint = socialBase.CorpIllnessInsPoint;
            rtnSocialBase.CorpHeatAmountPoint = socialBase.CorpHeatAmountPoint;
            rtnSocialBase.CorpHouseFundPoint = socialBase.CorpHouseFundPoint;
            rtnSocialBase.CorpRepInjuryInsPoint = socialBase.CorpRepInjuryInsPoint;

            rtnSocialBase.EmpPensionInsPoint = socialBase.EmpPensionInsPoint;
            rtnSocialBase.EmpMedicalInsPoint = socialBase.EmpMedicalInsPoint;
            rtnSocialBase.EmpUnempInsPoint = socialBase.EmpUnempInsPoint;
            rtnSocialBase.EmpInjuryInsPoint = socialBase.EmpInjuryInsPoint;
            rtnSocialBase.EmpBirthInsPoint = socialBase.EmpBirthInsPoint;
            rtnSocialBase.EmpDisabledInsPoint = socialBase.EmpDisabledInsPoint;
            rtnSocialBase.EmpIllnessInsPoint = socialBase.EmpIllnessInsPoint;
            rtnSocialBase.EmpHeatAmountPoint = socialBase.EmpHeatAmountPoint;
            rtnSocialBase.EmpHouseFundPoint = socialBase.EmpHouseFundPoint;
            rtnSocialBase.EmpRepInjuryInsPoint = socialBase.EmpRepInjuryInsPoint;

            ResultModel result = socialBLL.Update(rtnSocialBase);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "社保比例修改成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }

        protected string ModelName
        {
            get { return "社保"; }
        }
    }
}