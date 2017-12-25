using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Books;
using Library.Clients;
using Library.Data;
using Library.Reservations;
using Library.Services;

namespace Library
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            LibraryDbContext dbContext = new LibraryDbContext();

            IClientsRepository _clientsRepository = new EfClientsRepository(dbContext);
            IBooksRepository _booksRepository = new EfBooksRepository(dbContext);
            IReservationsRepository _reservationsRepository = new EfReservationsRepository(dbContext);
            ICategoriesRepository _categoriesRepository = new EfCategoriesRepository(dbContext);

            _addEditBookViewModel = new AddEditBookViewModel(_categoriesRepository, _booksRepository);
            _addEditClientViewModel = new AddEditClientViewModel(_clientsRepository);
            _addReservationViewModel = new AddReservationViewModel(_reservationsRepository, _booksRepository);
            _bookListViewModel = new BookListViewModel(_booksRepository);
            _clientListViewModel = new ClientListViewModel(_clientsRepository);
            _reservationListViewModel = new ReservationListViewModel(_reservationsRepository);

            NavCommand = new RelayCommand<string>(OnNav);

            _clientListViewModel.PlaceReservationRequested += NavToBookABook;
            _clientListViewModel.AddClientRequested += NavToAddClient;
            _clientListViewModel.EditClientRequested += NavToEditClient;
            _bookListViewModel.EditBookRequested += NavToEditBook;
            _bookListViewModel.AddBookRequested += NavToAddBook;
            _addEditClientViewModel.Done += ReturnToMenu;
            _addReservationViewModel.Done += ReturnToMenu;
            _addEditBookViewModel.Done += ReturnToMenu;
            _bookListViewModel.Done += ReturnToMenu;
            _clientListViewModel.Done += ReturnToMenu;
            _reservationListViewModel.Done += ReturnToMenu;
        }

        private void ReturnToMenu()
        {
            CurrentViewModel = _clientListViewModel;
        }


        private void NavToEditClient(Client client)
        {
            _addEditClientViewModel.Client = client;
            _addEditClientViewModel.EditMode = true;
            CurrentViewModel = _addEditClientViewModel;
        }

        private void NavToAddClient(Client client)
        {
            _addEditClientViewModel.Client = client;
            _addEditClientViewModel.EditMode = false;
            CurrentViewModel = _addEditClientViewModel;
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

        private ClientListViewModel _clientListViewModel;
        private BookListViewModel _bookListViewModel;
        private ReservationListViewModel _reservationListViewModel;
        private AddReservationViewModel _addReservationViewModel;
        private AddEditClientViewModel _addEditClientViewModel;
        private AddEditBookViewModel _addEditBookViewModel;

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
    }
}
