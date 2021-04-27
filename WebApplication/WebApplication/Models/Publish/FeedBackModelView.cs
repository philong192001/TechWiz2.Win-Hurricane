using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication.Models.Publish
{
    public class FeedBackModelView
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Please enter a title ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description ")]
        public string Description { get; set; }

        public string UserName { get; set; }
    }
}
