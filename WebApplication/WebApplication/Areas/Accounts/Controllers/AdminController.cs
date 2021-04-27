using System;
using System.Collections.Generic;
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
    public class AdminController : CheckAccountAdmin
    {
        public MyDBContext _context;
        public IEmailSender _emailSender;

        public AdminController(MyDBContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var shareTrip = _context.ShareTrip.ToList();
            var user_role = HttpContext.Session.GetString("role_user");
            if (user_role == "Admin")
            {
                var booking = _context.Booking.OrderBy(x => x.EndFrom).ToList();
                //var JoinResult = from u in _context.Users
                //                 join b in _context.Booking on u.Id Equals b.IdUser
                //                 select s;

                var query = from b in _context.Booking
                            join u in _context.Users on b.IdUser equals u.Id
                            where b.Status == 0
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
        public async Task<IActionResult> ShareTrip(string[] data)
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
                if (luutam.Count == 0) return Content("false");
                luutam.OrderBy(x => x.Count);
                int driver_id = luutam[0].Id;
                var peopleDriver = _context.Driver.Find(driver_id);
                var date = "";
                int distance = 0;
                var startTo = "";
                var fromTo = "";
                var total = 0;
                var bookList = _context.Booking.ToList();
                var boookLists = new List<Booking>();
                for (int i = 0; i < arr.Length; i++)
                {
                    var record = bookList.Where(x => x.Id == arr[i]).FirstOrDefault();
                    boookLists.Add(record);
                    record.IdDriver = driver_id;
                    int sum = Convert.ToInt32(record.Amount);
                    total = sum;
                    record.Amount = (sum / qty) * record.Member;
                    startTo = record.StartTo;
                    fromTo = record.EndFrom;
                    distance = record.Distance;
                    date = record.Date;
                    record.Status = 1;
                }
                var userEmail = new List<Users>();
                foreach (var item in boookLists)
                {
                    var user = _context.Users.Find(item.IdUser);
                    userEmail.Add(user);
                }
                   var sharTrip =new ShareTrip()
                    {
                        FromTo = fromTo,
                        DriverId = driver_id,
                        Distance = 100,
                        Amount = total,
                        StartTo = startTo,
                        SubAmount = total,
                        Date = date,
                        Status = 1,
                        Member = qty
                    } ;
                _context.ShareTrip.Add(sharTrip);
               await _context.SaveChangesAsync();
                for (int i = 0; i < arr.Length; i++)
                {
                    _context.ShareBooking.Add(new ShareBooking()
                    {
                        BookingId = arr[i],
                        IdSharetrip = sharTrip.Id
                    });
                }
                
                _context.SaveChanges();

                foreach (var email in userEmail)
                {
                    _emailSender.Seed(email.Email, "" + " " + "", "Welcome to CarShare", "<h1>Are you ready? You have trip at " + sharTrip.Date + "please prepare well for this trip </h1> </hr> People joining the same trip are:" + peopleDriver.Name);
                }
               
                 
                    

                    //var getBookingByUser = _context.ShareBooking
                  

              
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
