﻿using System;
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
        private IClientsRepository _clientsRepository;

        public ClientListViewModel(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
            PlaceReservationCommand = new RelayCommand<Client>(OnAddReservation);
            AddClientCommand = new RelayCommand(OnAddClient);
            LoadClientsCommand = new RelayCommand(OnLoadClients);
            ClearSearchInputCommand = new RelayCommand(OnClearSearchInput);
            EditClientCommand = new RelayCommand<Client>(OnClientEdit);
            DeleteClientCommand = new RelayCommand<Client>(OnClientDelete);
        }

        private void OnClientDelete(Client client)
        {
            _clientsRepository.DeleteClient(client.ClientId);
            Done();
        }

        private void OnClientEdit(Client client)
        {
            EditClientRequested(client);
        }

        private void OnClearSearchInput()
        {
            SearchInput = null;
        }

        private List<Client> _allClients;
        private void OnLoadClients()
        {
            _allClients = _clientsRepository.GetClients();
            Clients = new ObservableCollection<Client>(_allClients);
        }

        private void OnAddClient()
        {
            AddClientRequested(new Client());
        }


        public event Action<int> PlaceReservationRequested = delegate { };
        public event Action<Client> AddClientRequested = delegate { };
        public event Action<Client> EditClientRequested = delegate { };
        public event Action Done = delegate { };
        public RelayCommand<Client> PlaceReservationCommand { get; set; }
        public RelayCommand<Client> DeleteClientCommand { get; set; }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand LoadClientsCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public RelayCommand<Client> EditClientCommand{ get; set; }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                SetProperty(ref _clients, value);
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                SetProperty(ref _selectedClient, value);
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

        private void OnAddReservation(Client client)
        {
            PlaceReservationRequested(client.ClientId);
        }

    }
}
