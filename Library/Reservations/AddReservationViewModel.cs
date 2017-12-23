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
    public class AddReservationViewModel : BindableBase
    {
        private EfReservationsRepository _reservationsRepository = new EfReservationsRepository();
        private EfBooksRepository _booksRepository = new EfBooksRepository();

        public AddReservationViewModel()
        {
            FindBook = new RelayCommand<string>(GetBook);
            AddReservation = new RelayCommand<int>(BookABook);
        }

        private void BookABook(int bookId)
        {
            var reservation = new Reservation{BookId = bookId, ClientId = ClientId, ReservationDate = DateTime.Now};
            _reservationsRepository.AddReservation(reservation);
        }

        private void GetBook(string bookTitle)
        {
            Books = new ObservableCollection<Book>(_booksRepository.GetBooksByTitle(bookTitle));
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                SetProperty(ref _clientId, value);
            }
        }

        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get { return _books;}
            set { SetProperty(ref _books, value);}
        }

        public RelayCommand<string> FindBook { get; set; }
        public RelayCommand<int> AddReservation { get; set; }
    }
}
