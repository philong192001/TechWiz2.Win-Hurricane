using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Accounts.Controllers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HistoryController : BasicController
    {
        private MyDBContext _context;


        public HistoryController( MyDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var id_user = HttpContext.Session.GetInt32("id_user");
            if (id_user != null)
            {
                var query = from sb in _context.ShareBooking
                            join b in _context.Booking on sb.BookingId equals b.Id
                            join u in _context.Users on b.IdUser equals u.Id
                            select new { sb, b, u };
                var data = query.Where(x => x.u.Id == id_user).ToList();
                var list = new List<ShareTrip>();
                foreach(var item in data)
                {
                    var data_1 = _context.ShareTrip.Where(x => x.Id == item.sb.IdSharetrip).FirstOrDefault();
                    list.Add(data_1);
                }
                
                return View(list);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
