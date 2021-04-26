using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Route("Accounts/[controller]/[action]")]
    public class UserController : Controller
    {
        public MyDBContext _context;

        public UserController(MyDBContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var listUsers =_context.Users.ToList();
            ViewBag.listUsers = listUsers;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                _context.SaveChanges();
                return RedirectToAction("Index", "User", new { area = "Accounts" });
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id ,[Bind] Users users)
        {
            if ( id != users.Id)
            {
                return NotFound(); 
            }
            if (ModelState.IsValid)
            {
                _context.Users.Update(users);
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
