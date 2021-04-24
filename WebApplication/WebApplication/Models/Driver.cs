using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string IdProof { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int? IdCar { get; set; }

        public virtual Car IdCarNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
