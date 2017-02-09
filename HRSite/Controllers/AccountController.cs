using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.BLL;
using HR.Model;
using HR.Common;

namespace HRSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(string accountName, string password)
        {
            if (string.IsNullOrEmpty(accountName) || accountName == null)
                return Content("0");
            if (string.IsNullOrEmpty(password) || password == null)
                return Content("0");

            ResultModel result = new ResultModel();
            ManagerAccountBLL manAccountBLL = new ManagerAccountBLL();
            result = manAccountBLL.Login(accountName, password);

            UserModel user = result.ReturnValue as UserModel;
            if (result.ResultStatus != 0)
                return Content("0");

            Session["accountName"] = user;
            return Content("1");
        }

        public ActionResult LoginOut()
        {
            return RedirectToAction("Login");
        }
    }
}