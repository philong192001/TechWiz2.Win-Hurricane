using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }

        public virtual Users User { get; set; }
    }
}
