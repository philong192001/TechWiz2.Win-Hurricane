using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Car
    {
        public Car()
        {
            Driver = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Driver> Driver { get; set; }
    }
}
