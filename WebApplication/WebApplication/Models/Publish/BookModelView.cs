using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Publish
{
    public class BookModelView
    {
        [Required]
        public string address_from { get; set; }
        [Required]
        public string address_to { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public int menber { get; set; }
    }
}
