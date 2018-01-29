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
        private INotificationSender _notificationSender;

        public RemindersViewModel(IClientsRepository clientsRepository, INotificationSender notificationSender)
        {
            _clientsRepository = clientsRepository;
            _notificationSender = notificationSender;
            LoadData = new RelayCommand(OnLoadData);
            SendNotificationsCommand = new RelayCommand(OnSendNotifications);
        }

        private void OnSendNotifications()
        {
            foreach (var reminder in Reminders)
            {
               var email = EmailFactory.CreateEmail(reminder);
                _notificationSender.Send(email);
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
    }
}
