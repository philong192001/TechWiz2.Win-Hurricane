using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class ShareTrip
    {
        public ShareTrip()
        {
            ShareBooking = new HashSet<ShareBooking>();
        }

        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? DriverId { get; set; }
        public int? Distance { get; set; }
        public int? Amount { get; set; }
        public string StartTo { get; set; }
        public int? SubAmount { get; set; }
        public string Date { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<ShareBooking> ShareBooking { get; set; }
    }
}
