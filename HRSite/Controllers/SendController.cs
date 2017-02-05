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
            string Subject = "账单"+ rtnCorpBill.BillDate.ToString("yyyyMMdd");
            string Body = "客户您好，当月账单费用为："+ rtnCorpBill.TotalAmount;
            SendMail.Send(To, Subject, Body);

            result = new ResultModel();
            result.ResultStatus = 0;
            result.Message = "发送成功";
            return Json(result);
        }
    }
}