using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Publish
{
    public class HomeModelView
    {
        public BookModelView book_model { get; set; }
        public List<Car> car_model { get; set; }
    }
}
