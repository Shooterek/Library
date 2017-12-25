using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Clients;
using Library.Data;
using Library.Reservations;

namespace Library
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _clientListViewModel.PlaceReservationRequested += NavToBookABook;
            _clientListViewModel.AddClientRequested += NavToAddClient;
            _bookListViewModel.EditBookRequested += NavToEditBook;
            _bookListViewModel.AddBookRequested += NavToAddBook;
        }

        private void NavToAddBook(Book book)
        {
            _addEditBookViewModel.EditMode = false;
            _addEditBookViewModel.Book = book;
            CurrentViewModel = _addEditBookViewModel;
        }

        private void NavToEditBook(Book book)
        {
            _addEditBookViewModel.EditMode = true;
            _addEditBookViewModel.Book = book;
            CurrentViewModel = _addEditBookViewModel; ;
        }

        private ClientListViewModel _clientListViewModel = new ClientListViewModel();
        private BookListViewModel _bookListViewModel = new BookListViewModel();
        private ReservationListViewModel _reservationListViewModel = new ReservationListViewModel();
        private AddReservationViewModel _addReservationViewModel = new AddReservationViewModel();
        private AddEditClientViewModel _addEditClientViewModel = new AddEditClientViewModel();
        private AddEditBookViewModel _addEditBookViewModel = new AddEditBookViewModel();

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

        private void NavToBookABook(int clientId)
        {
            _addReservationViewModel.ClientId = clientId;
            CurrentViewModel = _addReservationViewModel;
        }
        private void NavToAddClient()
        {
            CurrentViewModel = _addEditClientViewModel;
        }
    }
}
