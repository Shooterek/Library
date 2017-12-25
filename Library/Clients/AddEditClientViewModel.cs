﻿using System;
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
        IClientsRepository _clientsRepository = new EfClientsRepository();
        public AddEditClientViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public RelayCommand SaveCommand;
        public RelayCommand CancelCommand;
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

        private bool CanSave()
        {
            return true;
        }

    }
}
