using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public interface INotificationSender
    {
        Task Send(MailMessage mailMessage);
    }
}
