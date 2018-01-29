using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Reservations
{
    public class RemindersViewModel : BindableBase
    {
        private IClientsRepository _clientsRepository;

        public RemindersViewModel(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
            LoadData = new RelayCommand(OnLoadData);
            SendNotificationsCommand = new RelayCommand(OnSendNotifications);
        }

        private void OnSendNotifications()
        {
            foreach (var client in Reminders)
            {
                SendNotifications(client);
            }
            Done();
        }

        public RelayCommand LoadData { get; set; }
        public RelayCommand SendNotificationsCommand { get; set; }
        public event Action Done = delegate { };

        private ObservableCollection<Reminder> _reminders;
        public ObservableCollection<Reminder> Reminders
        {
            get { return _reminders; }
            set
            {
                SetProperty(ref _reminders, value);
            }
        }

        private void OnLoadData()
        {
            Reminders = new ObservableCollection<Reminder>(_clientsRepository.GetReminders());
        }

        private async void SendNotifications(Reminder reminder)
        {
            MailAddress email = new MailAddress(reminder.Email);
            var message = new MailMessage();
            message.To.Add(email);
            message.From = new MailAddress("asp.netmvc.store@gmail.com");
            message.Subject = "Powiadomienie";
            message.Body =
                $"{reminder.First_Name} {reminder.Last_Name},{System.Environment.NewLine} pragniemy poinformować, że {reminder.Reservation_End} upływa termin oddania książki {reminder.Title}";

            using (var smtp = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = "asp.netmvc.store@gmail.com",
                    Password = "storepassword"
                };
                smtp.Credentials = credentials;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
