using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Components
{
    public class ListCarComponent: ViewComponent
    {
        public readonly MyDBContext _context;
        public ListCarComponent(MyDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Car.ToList();
            return View(data);
        }
    }
}
