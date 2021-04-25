using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Accounts.Models;
using WebApplication.Models;
using WebApplication.Services.EnCode_md5;
using WebApplication.Services.Mail;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class AccountController : Controller
    {
        public MyDBContext _context;
        public IEncodeServices _encodeService;
        public IEmailSender _emailSender;
        public AccountController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // HttpContext.Session.Clear();

                    var data = _context.Users.Where(a => a.Password.Equals(_encodeService.Decrypt(model.password)) && a.UserName.Equals(model.user_name)).FirstOrDefault(); 
                    if (data != null)
                    {
                        HttpContext.Session.SetInt32("id_user", data.Id);

                        if (data.Role == "Customer")
                            return RedirectToAction("Index", "Home", new { area = "" });
                        else
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else ModelState.AddModelError("", "Login failed. Account does not exist");
                    return View(nameof(Login));
                }
                else ModelState.AddModelError("", "Login failed. Please enter user and password");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["Message"] = "Implementation failed. There was a system problem";
            };
            return View(nameof(Login));
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            //try {
            //    if (ModelState.IsValid)
            //    {
            //        var data = _context.Users.Where(a => a.Password == model.password && a.UserName.Equals(model.user_name)).FirstOrDefault();
            //        if (data == null)
            //        {
            //            var user = new Users()
            //            {
            //                UserName = model.user_name,
            //                Password = model.password,
            //                LastName = model.last_name,
            //                FirstName = model.first_name,
            //                Email = model.email,
            //                Role = "Customer"
            //            };
            //            _context.Users.Add(user);
            //            _context.SaveChanges();
            //            //_emailSender.SendEmailAsync("truongthanhtu.it.1998@gmail.com", "Feed back", "<h1>Thank you for joining us</h1>");
            //            var query = _context.Users.Where(x => (x.UserName == model.user_name && x.Password == model.password)).First();
            //            HttpContext.Session.SetInt32("id_user", query.Id);
            //            return RedirectToAction("Index", "Home", new { area = "Admin" });
            //        }
            //        else ModelState.AddModelError("", "Registration failed, this account has already registered before measuring");
            //    }
            //} catch(Exception ex) {
            //    Console.WriteLine(ex.Message);
            //    TempData["Message"] = "Implementation failed. There was a system problem";
            //}
            _emailSender.SendEmailAsync("truongthanhtu.it.1998@gmail.com", "Feed back", "<h1>Thank you for joining us</h1>");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Accounts", new { area = "Account" });
        }

    }
}
