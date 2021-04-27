using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Please enter a title")]

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Users User { get; set; }
    }
}
