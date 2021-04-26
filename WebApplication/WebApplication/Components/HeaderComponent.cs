using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Components
{
 
    public class HeaderComponent : ViewComponent
    {
        public readonly MyDBContext _context;
        public HeaderComponent(MyDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var id_userr = HttpContext.Session.GetInt32("id_user");
            ViewBag.KeyUser = id_userr ;
            var user = _context.Users.FirstOrDefault(value => value.Id == id_userr);
            return View(user);
        }
    }
}
