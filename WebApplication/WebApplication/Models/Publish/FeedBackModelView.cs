using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Publish
{
    public class FeedBackModelView
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string UserName { get; set; }
    }
}
