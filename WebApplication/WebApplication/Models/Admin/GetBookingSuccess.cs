using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Admin
{
    public class GetBookingSuccess
    {
        public int? BookingId { get; set; }
        public int? IdSharetrip { get; set; }
        public int? IdDriver { get; set; }
        public string StartTo { get; set; }
        public string EndFrom { get; set; }
        public string Date { get; set; }
        public int Distance { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public int Member { get; set; }
        public int? IsCancel { get; set; }
        public int? SubAmount { get; set; }
        public int Seat { get; set; }
        public string UserName { get; set; }
        public string EmailUser { get; set; }
        public string NameDriver { get; set; }
    }
}
