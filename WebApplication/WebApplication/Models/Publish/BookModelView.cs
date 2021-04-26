using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Publish
{
    public class BookModelView
    {
        [Required(ErrorMessage = "Please enter Address From")]
        public string address_from { get; set; }
        [Required(ErrorMessage = "Please enter Address To")]
        public string address_to { get; set; }
        [Required(ErrorMessage = "Please enter Date")]
        [DataType(DataType.Date, ErrorMessage = "Need to enter correct winning date format")]
        public string date { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        [Range(1, 16)]
        public int menber { get; set; }
    }
}
