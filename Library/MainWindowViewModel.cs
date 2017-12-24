using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Clients;
using Library.Reservations;

namespace Library
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _clientListViewModel.PlaceReservationRequested += BookABook;
            _clientListViewModel.AddClientCommandRequested += AddClient;
        }

        private ClientListViewModel _clientListViewModel = new ClientListViewModel();
        private BookListViewModel _bookListViewModel = new BookListViewModel();
        private ReservationListViewModel _reservationListViewModel = new ReservationListViewModel();
        private AddReservationViewModel _addReservationViewModel = new AddReservationViewModel();
        private AddEditClientViewModel _addEditClientViewModel = new AddEditClientViewModel();

        private BindableBase _currentViewModel;

        public RelayCommand<string> NavCommand { get; set; }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "clientList":
                    CurrentViewModel = _clientListViewModel;
                    break;
                case "bookList":
                    CurrentViewModel = _bookListViewModel;
                    break;
                case "reservationList":
                    CurrentViewModel = _reservationListViewModel;
                    break;
            }
        }

        private void BookABook(int clientId)
        {
            _addReservationViewModel.ClientId = clientId;
            CurrentViewModel = _addReservationViewModel;
        }
        private void AddClient()
        {
            CurrentViewModel = _addEditClientViewModel;
        }
    }
}
