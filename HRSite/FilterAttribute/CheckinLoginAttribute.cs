using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Common;

namespace HRSite
{
    public class CheckinLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToUpper() == "ORDER")
            {
                return;
            }
            //Call_SystemController
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                UserModel um = CheckLogin.GetSessionInfo();
                if (um == null)
                {
                    filterContext.Result = new RedirectResult("/Account/LoginOut");
                    return;
                }
            }
            else
            {
                UserModel um = CheckLogin.GetSessionInfo();
                if (um == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Account/LoginOut", false);
                    return;
                }
            }
        }
    }
}