using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Models.Admin;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Route("Accounts/[controller]/[action]")]
    public class AdminController : CheckAccountAdmin
    {
        public MyDBContext _context;

        public AdminController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                var booking = _context.Booking.OrderBy(x => x.EndFrom).ToList();
                //var JoinResult = from u in _context.Users
                //                 join b in _context.Booking on u.Id Equals b.IdUser
                //                 select s;

                var query = from b in _context.Booking
                            join u in _context.Users on b.IdUser equals u.Id
                            select new { b, u };
                var getUserName = query.Select(x => new GetUserName()
                {
                    NameUser = x.u.UserName,
                    Id = x.b.Id,
                    IdUser = x.b.IdUser,
                    IdDriver = x.b.IdDriver,
                    StartTo = x.b.StartTo,
                    EndFrom = x.b.EndFrom,
                    Date = x.b.Date,
                    Amount = x.b.Amount,
                    Distance = x.b.Distance,
                    IsCancel = x.b.IsCancel,
                    Member = x.b.Member,
                    Status = x.b.Status

                }).ToList();

                var userbooking = getUserName.Count();
                var listUser = _context.Users.Count();
                var listDriver = _context.Driver.Count();
                var listSameFrom = _context.Booking.OrderBy(x => x.EndFrom).Count();

                ViewBag.CountUser = listUser;
                ViewBag.CountDriver = listDriver;
                ViewBag.ListBooking = getUserName;
                ViewBag.CountSameFrom = listSameFrom;
                ViewBag.CountUserBooking = userbooking;

                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        public IActionResult ShareTrip(string[] data)
        {
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                int[] arr = data.Select(int.Parse).ToArray();

                /// so nguowi di
                int qty = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    qty += _context.Booking.First(x => x.Id == arr[i]).Member;
                }

                //tru so nguoi
                var query = from b in _context.Driver
                            join u in _context.Car on b.IdCar equals u.Id
                            select new { b, u };
                var result = query.Select(x => new DriverResponse()
                {
                    Id = x.b.Id,
                    Seats = int.Parse(x.u.Type),

                }).ToList();


                //bien luu
                List<DriverResponse> luutam = new List<DriverResponse>();
                foreach (var item in result)
                {
                    item.Count = null;
                    int sogheconlai = item.Seats - qty;
                    if (sogheconlai >= 0)
                    {
                        item.Count = sogheconlai;
                        luutam.Add(item);
                    }
                    //else(sogheconlai <= 0){

                    //}

                }
                luutam.OrderBy(x => x.Count);
                var driver_id = luutam[0].Id.ToString();

                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
