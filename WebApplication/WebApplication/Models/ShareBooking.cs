using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class ShareBooking
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? IdSharetrip { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ShareTrip IdSharetripNavigation { get; set; }
    }
}
