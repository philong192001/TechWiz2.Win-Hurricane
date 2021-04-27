using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Publish;

namespace WebApplication.Controllers
{
    public class FeedbackController : Controller
    {
        private MyDBContext _context;

        public FeedbackController(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var queryFeedBack = from f in _context.Feedback
                               join u in _context.Users on f.UserId equals u.Id
                               select new { f, u };

            var listFeedBack = queryFeedBack.Select(x => new FeedBackModelView()
            {
                
                Id = x.f.Id,
                UserId = x.f.UserId,
                Title = x.f.Title,
                Description = x.f.Description,
                UserName = x.u.UserName             
            }).Take(5).ToList();
            ViewBag.listFb = listFeedBack;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Feedback feedback)
        {
            feedback.UserId = HttpContext.Session.GetInt32("id_user");

            if (ModelState.IsValid && feedback.UserId != null)
            {
                _context.Feedback.Add(feedback);
                _context.SaveChanges();
                return RedirectToAction("Index","FeedBack");
            }
            return View();
        }
    }
}
