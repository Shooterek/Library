using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Clients
{
    public class ClientListViewModel : BindableBase
    {
        private EfClientsRepository _repo = new EfClientsRepository();
        public ClientListViewModel()
        {
            PlaceReservationCommand = new RelayCommand<Client>(AddReservation);
            AddClientCommand = new RelayCommand(AddClient);
            LoadClientsCommand = new RelayCommand(LoadClients);
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(_repo.GetClients());
        }

        private void AddClient()
        {
            AddClientCommandRequested();
        }

        private ObservableCollection<Client> _clients;

        public event Action<int> PlaceReservationRequested = delegate { };
        public event Action AddClientCommandRequested = delegate { };
        public RelayCommand<Client> PlaceReservationCommand { get; set; }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand LoadClientsCommand { get; set; }
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetProperty(ref _clients, value);}
        }

        private void AddReservation(Client client)
        {
            PlaceReservationRequested(client.ClientId);
        }

    }
}
