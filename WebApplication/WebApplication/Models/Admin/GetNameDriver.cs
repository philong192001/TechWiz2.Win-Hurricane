using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Admin
{
    public class GetNameDriver
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? DriverId { get; set; }
        public int? Distance { get; set; }
        public int? Amount { get; set; }
        public string StartTo { get; set; }
        public string FromTo { get; set; }
        public int? SubAmount { get; set; }
        public string Date { get; set; }
        public int? Status { get; set; }

        public string NameDriver { get; set; }
    }
}
