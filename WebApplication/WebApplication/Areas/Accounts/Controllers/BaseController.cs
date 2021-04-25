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
    public class BaseController : Controller
    {
        [Area("Accounts")]

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var session = HttpContext.Session.GetString("UserSession");
            //if (session == null)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Accounts", action = "Login", area = "Account" }));
            //}

            //base.OnActionExecuting(filterContext);

           

        }
    }
}
