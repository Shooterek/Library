using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        }

        public RelayCommand LoadData { get; set; }

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
