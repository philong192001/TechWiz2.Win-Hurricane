using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Booking
    {
        public Booking()
        {
            ShareBooking = new HashSet<ShareBooking>();
        }

        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdDriver { get; set; }
        public string StartTo { get; set; }
        public string EndFrom { get; set; }
        public string Date { get; set; }
        public int Distance { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public int Member { get; set; }
        public int? IsCancel { get; set; }

        public virtual Driver IdDriverNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<ShareBooking> ShareBooking { get; set; }
    }
}
