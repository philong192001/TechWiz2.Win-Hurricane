using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Users
    {
        public Users()
        {
            Booking = new HashSet<Booking>();
            Feedback = new HashSet<Feedback>();
            Notification = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdPoof { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
    }
}
