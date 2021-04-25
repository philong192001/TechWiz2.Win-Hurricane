using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Admin
{
    public class GetUserName
    {
        public string NameUser { get; set; }
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public int? IdDriver { get; set; }
        public string StartTo { get; set; }
        public string EndFrom { get; set; }
        public string Date { get; set; }
        public int? Distance { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public int? Member { get; set; }
        public int? IsCancel { get; set; }

    }
}
