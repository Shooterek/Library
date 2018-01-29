using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class EmailNotificationSender : INotificationSender
    {
        private SmtpClient _smtpClient;

        public EmailNotificationSender()
        {
            _smtpClient = new SmtpClient();
            var credentials = new NetworkCredential
            {
                UserName = "asp.netmvc.store@gmail.com",
                Password = "storepassword"
            };
            _smtpClient.Credentials = credentials;
            _smtpClient.Host = "smtp.gmail.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
        }
        public async Task Send(MailMessage mailMessage)
        {
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
