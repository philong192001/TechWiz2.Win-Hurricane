using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using WebApplication.Models.Mail;
using MimeKit.Text;
namespace WebApplication.Services.Mail
{
    public class SendMailService : IEmailSender
    {
        private readonly MailSettings mailSettings;

        private readonly ILogger<SendMailService> logger;
       
        public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
        }
       
        public bool Seed(string EmailTo, string name, string Subject, string Content)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Admin", "winhurricanee@gmail.com"));
            message.To.Add(new MailboxAddress(name, EmailTo));
            message.Subject = Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = (Content == null) ? "test" : Content

            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("winhurricanee@gmail.com", "Hurricane2021");
                client.Send(message);
                client.Disconnect(true);
            }
            return true;
        }
    }
}
