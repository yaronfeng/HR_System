using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.BLL;
using HR.Model;

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

            ManagerAccount manAccount = new ManagerAccount();
            ManagerAccountBLL manAccountBLL = new ManagerAccountBLL();
            manAccount = manAccountBLL.Login(accountName, password);
            if (manAccount == null || string.IsNullOrEmpty(manAccount.ManAccount))
                return Content("0");

            Session["accountName"] = manAccount;
            return Content("1");
        }

        public ActionResult LoginOut()
        {
            return RedirectToAction("Login");
        }
    }
}