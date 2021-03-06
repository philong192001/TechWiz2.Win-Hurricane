using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApplication.Areas.Accounts.Models;
using WebApplication.Models;
using WebApplication.Services.Convertmd5;
using WebApplication.Services.Mail;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    public class AccountController : Controller
    {
        public MyDBContext _context;
        public IEmailSender _emailSender;
        public IConvertmd5 _convertmd5;
        public AccountController(MyDBContext context, IEmailSender emailSender, IConvertmd5 convertmd5)
        {
            _context = context;
            _emailSender = emailSender;
            _convertmd5 = convertmd5;
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

                    //var data = _context.Users.Where(a => a.Password.Equals(_encodeService.Decrypt(model.password)) && a.UserName.Equals(model.user_name)).FirstOrDefault(); 
                    model.password = _convertmd5.ConvertService(model.password);
                    var data = _context.Users.Where(a => a.UserName == model.user_name &&
                    a.Password == model.password).FirstOrDefault();
                    if (data != null)
                    {
                        HttpContext.Session.SetInt32("id_user", data.Id);
                        HttpContext.Session.SetString("role_user", data.Role);
                        if (data.Role == "Customer")
                        {
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin", new { area = "Accounts" });
                        }
                           
                    }
                    else ModelState.AddModelError("", "Login failed. Account does not exist");
                    return View();
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
            try
            {
                if (ModelState.IsValid)
                {
                    model.password = _convertmd5.ConvertService(model.password);
                    var data = _context.Users.Where(a => a.Password == model.password && a.UserName.Equals(model.user_name)).FirstOrDefault();
                    if (data == null)
                    {
                        var user = new Users()
                        {
                            UserName = model.user_name,
                            Password = model.password,
                            LastName = model.last_name,
                            FirstName = model.first_name,
                            Phone = model.phone,
                            Email = model.email,
                            Role = "Customer"
                        };
                        _context.Users.Add(user);
                        _context.SaveChanges();
                        _emailSender.Seed(user.Email, user.FirstName + " " + user.LastName, "Feed back", "<h1>Thank you for joining us</h1>");
                        var query = _context.Users.Where(x => (x.UserName == model.user_name && x.Password == model.password)).First();
                        HttpContext.Session.SetInt32("id_user", query.Id);

                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else ModelState.AddModelError("", "Registration failed, this account has already registered before measuring");
                    return View();
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["Message"] = "Implementation failed. There was a system problem";
            }
            //_emailSender.SendEmailAsync("truongthanhtu.it.1998@gmail.com", "Feed back", "<h1>Thank you for joining us</h1>");
            return RedirectToAction("Login", "Accounts", new { area = "Account" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "Accounts" });
        }
       
    }
}
