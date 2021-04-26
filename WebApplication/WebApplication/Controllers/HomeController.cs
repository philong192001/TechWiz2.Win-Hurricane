using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Accounts.Controllers;
using WebApplication.Models;
using WebApplication.Models.Publish;
using WebApplication.Services.Search;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext _context;
        private ISearchService _search_service;
        private readonly ILogger<HomeController> _logger;
      

        public HomeController(ILogger<HomeController> logger, MyDBContext context, ISearchService search_ervice)
        {
            _context = context;
            _logger = logger;
            _search_service = search_ervice;
        }

        public IActionResult Index()
        {

            //var data = _context.Booking.ToList();
            //var id_userr = HttpContext.Session.GetInt32("id_user");
            //ViewBag.KeyUser = id_userr;
            //ViewBag.listbook = data;
            //var data = _context.Car.ToList();
            ViewBag.SuccessfulAnnouncement = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BookModelView reqest_book)
        {
            try
            {
                if (HttpContext.Session.GetInt32("id_user") != null)
                {
                    if (ModelState.IsValid)
                    {
                        var data = new Booking()
                        {
                            IdUser = HttpContext.Session.GetInt32("id_user"),
                            Distance = 100,
                            Amount = 100000,
                            Status = 0,
                            EndFrom = reqest_book.address_to,
                            StartTo = reqest_book.address_from,
                            Date = reqest_book.date,
                            Member = reqest_book.menber,
                        };

                        _context.Booking.Add(data);
                        _context.SaveChanges();
                        ViewBag.SuccessfulAnnouncement = "Your request has been sent";
                        return RedirectToAction("Index");

                    }
                    return View();
                }
                else ModelState.AddModelError("", "This account does not exist in the system");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Implementation failed. There was a system problem";
            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuitableCar(SuitableCarModelView req )
        {
            var data = _search_service.Search(req);
            return View("/Views/Shared/Components/ListBookingComponent/Default.cshtml", data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
