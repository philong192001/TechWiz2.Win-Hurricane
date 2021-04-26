using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Accounts.Controllers
{
    public class CheckAccountAdmin : BasicController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user_role = HttpContext.Session.GetString("role_user");

            if (user_role == "Customer")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
            }
           
            base.OnActionExecuting(filterContext);
        }
    }
}
