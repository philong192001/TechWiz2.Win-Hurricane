using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Components
{
    public class SuitableCarComponent : ViewComponent
    {
        public readonly MyDBContext _context;
        public SuitableCarComponent(MyDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
           
            return View();
        }

    }
}
