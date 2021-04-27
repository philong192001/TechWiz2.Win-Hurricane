using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Models.Admin;
using WebApplication.Services.Mail;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Route("Accounts/[controller]/[action]")]
    public class TripController : Controller
    {
        public MyDBContext _context;
        public IEmailSender _emailSender;

        public TripController(MyDBContext context, IEmailSender emailSender)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                var query = from st in _context.ShareTrip
                        join dr in _context.Driver on st.DriverId equals dr.Id
                        select new { st, dr };

            var getShareTrip = query.Select(x => new GetNameDriver()
            {

                NameDriver = x.dr.Name,
                Id = x.st.Id,
                Distance = x.st.Distance,
                Amount = x.st.Amount,
                StartTo = x.st.StartTo,
                FromTo = x.st.FromTo,
                SubAmount = x.st.SubAmount,
                Date = x.st.Date,
                Status = x.st.Status
            }).ToList();

            
            var CountShareTrip = getShareTrip.Count();
            var listUser = _context.Users.Count();
            var listDriver = _context.Driver.Count();
            var listSameFrom = _context.Booking.OrderBy(x => x.EndFrom).Count();


            ViewBag.listST = getShareTrip;
            ViewBag.CountUser = listUser;
            ViewBag.CountDriver = listDriver;
            ViewBag.CountShareTrip = CountShareTrip;
            ViewBag.CountSameFrom = listSameFrom;
            return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult SuccessTrip()
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                var query = from dr in _context.Driver 
                            join st in _context.ShareTrip on dr.Id equals st.DriverId
                            join ca in _context.Car on dr.IdCar equals ca.Id

                        select new { st,dr,ca };

                var getShareBooking = query.Select(x => new GetBookingSuccess()
                {
                    
                    Seat =Convert.ToInt32(x.ca.Type),
                    NameDriver = x.dr.Name,
                    StartTo = x.st.StartTo,
                    EndFrom = x.st.FromTo,
                    Date = x.st.Date,
                    Distance = (int)x.st.Distance,
                    Amount = Convert.ToInt32(100000),
                    Status = x.st.Status,
                    Member = x.st.Member,

                }).ToList();

            
            ViewBag.listBookSucces = getShareBooking;
            return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult SendMailConfirmUser()
        {
            //_emailSender.Seed(sendMailUser.Email, sendMailUser.FirstName + " " + sendMailUser.LastName, "Welcome to CarShare", "<h1>Are you ready? You match to going to </h1>");
            return RedirectToAction("SuccessTrip", "Trip", new { area = "Accounts" });
        }
    }
}

