using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string DateRun { get; set; }
        public string TimeRun { get; set; }
        public string Description { get; set; }
        public string StartTo { get; set; }
        public string EndFrom { get; set; }
        public int? IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
    }
}
