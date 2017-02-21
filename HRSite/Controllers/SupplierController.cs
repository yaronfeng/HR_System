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
        public ActionResult Suppliers()
        {
            string jsonStr = string.Empty;
            var corps = HR.BLL.BaseProvider.Suppliers.OrderBy(temp => temp.SupName);
   
            return Json(corps);
        }

        [HttpPost]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return Json(new ResultModel(string.Format("{0}不存在", this.ModelName)));

            SupplierBLL dal = new SupplierBLL();
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

        [HttpPost]
        public ActionResult LoadSupplierList(int pageIndex, int pageSize, string orderField, string sortOrder,int supId)
        {
            switch (orderField)
            {
                case "SupId":
                    orderField = "SupId";
                    break;
            }
            string orderStr = string.Format("{0} {1}", orderField, sortOrder);

            SupplierBLL supplierBLL = new SupplierBLL();
            ResultModel result = supplierBLL.LoadSupplierList(pageIndex, pageSize, orderStr, supId);

            System.Data.DataTable dt = result.ReturnValue as System.Data.DataTable;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("count", result.AffectCount);
            dic.Add("data", dt);
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(dic, new Newtonsoft.Json.Converters.DataTableConverter());
            result.ReturnValue = jsonStr;

            return Json(result);
        }

        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            SupplierBLL supBLL = new SupplierBLL();

            //获取客户信息
            ResultModel<Supplier> supResult = supBLL.Get<Supplier>(supplier.SupId);
            if (supResult == null || supResult.ResultStatus != 0)
                new ResultModel("用户获取失败或不存在");

            Supplier rtnSupplier = supResult.ReturnValue;
            if (rtnSupplier == null || rtnSupplier.SupId <= 0)
                new ResultModel("用户获取失败或不存在");

            rtnSupplier.SupCode = supplier.SupCode;
            rtnSupplier.SupName = supplier.SupName;
            rtnSupplier.SupEName = supplier.SupEName;
            rtnSupplier.SupAddress = supplier.SupAddress;
            rtnSupplier.SupContacts = supplier.SupContacts;
            rtnSupplier.SupTel = supplier.SupTel;
            rtnSupplier.SupFax = supplier.SupFax;
            rtnSupplier.SupZip = supplier.SupZip;
            rtnSupplier.SupEmail = supplier.SupEmail;
            rtnSupplier.Bank = supplier.Bank;
            rtnSupplier.BankAccount = supplier.BankAccount;
            rtnSupplier.ServiceAmount = supplier.ServiceAmount;
            rtnSupplier.Memo = supplier.Memo;

            ResultModel result = supBLL.Update(supplier);
            if (result.ResultStatus != 0)
                return Json(result);

            result.Message = "用户修改成功";
            result.ReturnValue = "";
            result.ResultStatus = 0;
            return Json(result);

        }
        protected string ModelName
        {
            get { return "供应商"; }
        }
    }
}