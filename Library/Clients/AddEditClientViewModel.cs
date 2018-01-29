using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Clients
{
    public class AddEditClientViewModel : BindableBase
    {
        private IClientsRepository _clientsRepository;
        public AddEditClientViewModel(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action Done = delegate { };

        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set
            {
                SetProperty(ref _client, value);
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            try
            {
                if (EditMode)
                {
                    _clientsRepository.UpdateClient(Client);
                }
                else
                {
                    _clientsRepository.AddClient(Client);
                }
                Done();
            }
            catch (Exception)
            {
                // ignored
            }
        }

    }
}
