using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Accounts.Models
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 50")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Length must be between 6 to 50")]
        public string password { get; set; }
        public bool remember { get; set; }
    }
}
