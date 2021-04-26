using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Publish
{
    public class SuitableCarModelView
    {
        public int? Id { get; set; }
        public string address_from { get; set; }
        public string address_to{ get; set; }
        public string date{ get; set; }
        public int member{ get; set; }
    }
}
