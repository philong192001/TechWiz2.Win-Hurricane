using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Accounts.Controllers
{
    public class AuthenticatioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
