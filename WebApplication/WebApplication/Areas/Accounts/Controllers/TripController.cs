using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Models.Admin;

namespace WebApplication.Areas.Accounts.Controllers
{
    [Area("Accounts")]
    [Route("Accounts/[controller]/[action]")]
    public class TripController : Controller
    {
        public MyDBContext _context;

        public TripController(MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
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


            var listUser = _context.Users.Count();
            var listDriver = _context.Driver.Count();
            var listSameFrom = _context.Booking.OrderBy(x => x.EndFrom).Count();

            ViewBag.listST = getShareTrip;
            ViewBag.CountUser = listUser;
            ViewBag.CountDriver = listDriver;
          
            ViewBag.CountSameFrom = listSameFrom;
            return View();
        }
    }
}
