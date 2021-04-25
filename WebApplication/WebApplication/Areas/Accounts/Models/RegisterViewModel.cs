using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Accounts.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter First Name")]
        public string first_name { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        public string last_name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string phone { get; set; }


        [Required(ErrorMessage = "Please enter Email Adress")]
        [EmailAddress]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "Length must be between 6 to 50")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the User Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 50")]
        public string user_name { get; set; }
    }
}
