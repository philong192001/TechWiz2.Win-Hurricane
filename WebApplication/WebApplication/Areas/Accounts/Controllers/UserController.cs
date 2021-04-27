using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Route("Accounts/[controller]/[action]")]
    public class UserController : BasicController
    {
        public MyDBContext _context;

        public UserController(MyDBContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if(user_role == "Admin")
            {
                var listUsers = _context.Users.ToList();
                ViewBag.listUsers = listUsers;
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });

        }

        public IActionResult Create()
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Users users)
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                if (ModelState.IsValid)
            {
                _context.Add(users);
                _context.SaveChanges();
                return RedirectToAction("Index", "User", new { area = "Accounts" });
            }
            return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Update(int? id)
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                if (id == null)
            {
                return NotFound();
            }
           var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return View(user);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id ,[Bind] Users users)
        {
            if ( id != users.Id)
            {
                return NotFound(); 
            }
            var user = _context.Users.Find(id);
            if(user != null && ModelState.IsValid)
          
            {
                user = users;
               
                _context.SaveChanges();
                return RedirectToAction("Index", "User", new { area = "Accounts" });
            }
            return View();
        }

        //public IActionResult Delete(int? id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //   var data = _context.Users.FirstOrDefault(x=>x.Id == id);

        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    data.isDelete = 1;
        //    _context.Users.Update(data);

        //    return View();
        //}
    }
}
