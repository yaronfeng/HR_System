using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Model;
using HR.BLL;
using HR.Common;

namespace HRSite.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult SupplierAdd()
        {
            return View();
        }

        public ActionResult SupplierList()
        {
            return View();
        }

        public ActionResult SupplierDetail()
        {
            return View();
        }

        public ActionResult SupplierUpdate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Supplier supplier)
        {
            supplier.SupStatus = (int)StatusEnum.已完成;

            SupplierBLL supplierBLL = new SupplierBLL();
            ResultModel result = supplierBLL.Insert(supplier);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "供应商新增成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);
        }
    }
}