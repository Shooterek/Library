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
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            EditClientCommand = new RelayCommand<Client>(OnClientEdit);
        }

        private void OnClientEdit(Client client)
        {
            EditClientRequested(client);
        }

        private void ClearSearchInput()
        {
            SearchInput = null;
        }

        private void LoadClients()
        {
            _allClients = _repo.GetClients();
            Clients = new ObservableCollection<Client>(_allClients);
        }

        private void AddClient()
        {
            AddClientRequested(new Client());
        }

        private ObservableCollection<Client> _clients;

        public event Action<int> PlaceReservationRequested = delegate { };
        public event Action<Client> AddClientRequested = delegate { };
        public event Action<Client> EditClientRequested = delegate { };
        public RelayCommand<Client> PlaceReservationCommand { get; set; }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand LoadClientsCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public RelayCommand<Client> EditClientCommand{ get; set; }
        private List<Client> _allClients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                SetProperty(ref _clients, value);
            }
        }

        private string _searchInput;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterClients(_searchInput);
            }
        }

        private void FilterClients(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Clients = new ObservableCollection<Client>(_allClients);
            }
            else
            {
                Clients = new ObservableCollection<Client>(_allClients.Where(c => c.LastName.ToLower().Contains(searchInput)));
            }
        }

        private void AddReservation(Client client)
        {
            PlaceReservationRequested(client.ClientId);
        }


    }
}
