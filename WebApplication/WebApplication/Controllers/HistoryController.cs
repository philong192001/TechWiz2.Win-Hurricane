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
        public IActionResult Detail(int Id)
        {
            var data = _context.ShareTrip.Where(x => x.Id == Id).FirstOrDefault();
            return View(data);
        }
        public IActionResult Delete(int Id)
        {
            var id_user = HttpContext.Session.GetInt32("id_user");
            var data = _context.ShareTrip.Where(x => x.Id == Id).FirstOrDefault();
            var data_1 = _context.ShareBooking.Where(x => x.IdSharetrip == Id).ToList();
            var value = new Booking();
            foreach(var item in data_1)
            {
                value = _context.Booking.Where(x => x.Id == item.BookingId && x.IdUser == id_user).FirstOrDefault();
            }
            _context.Booking.Remove(value);
            _context.SaveChanges();
            //var data_1 = _context.Booking.Where(x=>x.Id)
            return View();
        }
    }
}
