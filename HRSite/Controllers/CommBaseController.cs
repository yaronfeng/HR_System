using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Common;
using HR.Model;

namespace HRSite.Controllers
{
    public class CommBaseController : Controller
    {
        // GET: CommBase

        /// <summary>
        /// 缴费城市类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PayCitys()
        {

            int styleId = (int)StyleTypeEnum.缴费城市类型;

            List<HR.Model.StyleDetail> details = HR.BLL.BaseProvider.StyleDetails.Where(temp => temp.StyleId == styleId).ToList();

            return Json(details);
        }

        /// <summary>
        /// 银行类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Banks()
        {

            int styleId = (int)StyleTypeEnum.银行类型;

            List<HR.Model.StyleDetail> details = HR.BLL.BaseProvider.StyleDetails.Where(temp => temp.StyleId == styleId).ToList();

            return Json(details);
        }

        /// <summary>
        /// 学历类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Degrees()
        {

            int styleId = (int)StyleTypeEnum.学历类型;

            List<HR.Model.StyleDetail> details = HR.BLL.BaseProvider.StyleDetails.Where(temp => temp.StyleId == styleId).ToList();

            return Json(details);
        }

        /// <summary>
        /// 学历类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Sexs()
        {

            int styleId = (int)StyleTypeEnum.性别类型;

            List<HR.Model.StyleDetail> details = HR.BLL.BaseProvider.StyleDetails.Where(temp => temp.StyleId == styleId).ToList();

            return Json(details);
        }
    }
}