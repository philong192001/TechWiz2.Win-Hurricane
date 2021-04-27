using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Accounts.Controllers;
using WebApplication.Models;
using WebApplication.Services.Convertmd5;

namespace WebApplication.Controllers
{
    public class ProfileController: BasicController
    {
        private MyDBContext _context;
        private IConvertmd5 _convertmd5;


        public ProfileController( MyDBContext context, IConvertmd5 convertmd5)
        {
            _context = context;
            _convertmd5 = convertmd5;
        }
        public IActionResult Index()
        {
            var id_user= HttpContext.Session.GetInt32("id_user");
            if (id_user != null)
            {
                var data = _context.Users.ToList().FirstOrDefault(x=>x.Id == id_user);

                return View(data);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Users model) 
        {
            if (ModelState.IsValid)
            {
                var id_user = HttpContext.Session.GetInt32("id_user");
                var data = _context.Users.Where(x => x.Id == id_user).FirstOrDefault();
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Phone = model.Phone;
                data.Email = model.Email;
                _context.Users.Update(data);
                _context.SaveChangesAsync();

                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
    }
}
