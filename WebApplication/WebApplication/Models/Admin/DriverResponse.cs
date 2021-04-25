using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Admin
{
    public class DriverResponse
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public int Status { get; set; }
        public int? Count { get; set; }
    }
}
