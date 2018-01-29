using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library
{
    public static class EmailFactory
    {
        public static MailMessage CreateEmail(Reminder reminder)
        {
            MailAddress email = new MailAddress(reminder.Email);
            var message = new MailMessage();
            message.To.Add(email);
            message.From = new MailAddress("asp.netmvc.store@gmail.com");
            message.Subject = "Powiadomienie";
            message.Body =
                $"{reminder.First_Name} {reminder.Last_Name},{System.Environment.NewLine} pragniemy poinformować, że {reminder.Reservation_End} upływa termin oddania książki {reminder.Title}";

            return message;
        }
    }
}
