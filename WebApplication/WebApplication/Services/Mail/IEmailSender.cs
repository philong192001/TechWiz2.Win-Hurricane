using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services.Mail
{
    public interface IEmailSender
    {
        public bool Seed(string EmailTo, string name, string Subject, string Content);
    }
}
