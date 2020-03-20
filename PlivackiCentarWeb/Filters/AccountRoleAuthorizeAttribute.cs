using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlivackiCentarWeb.Filters
{
    public class AccountRoleAuthorizeAttribute : AuthorizeAttribute
    {
        private string roleValue;

        public AccountRoleAuthorizeAttribute(string role)
        {
            roleValue = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.IsInRole("admin"))
                return true;
            string currentAccountRole = httpContext.Session["current-account-role"] as string;
            if (currentAccountRole == null)
                return false;

            return currentAccountRole == roleValue;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
                filterContext.Result = new RedirectResult("/Guest/Error");
        }


    }
}