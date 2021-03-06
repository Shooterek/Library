﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Reservations
{
    public class AddReservationViewModel : BindableBase
    {
        private IReservationsRepository _reservationsRepository;
        private IBooksRepository _booksRepository;

        public AddReservationViewModel(IReservationsRepository reservationsRepository, IBooksRepository booksRepository)
        {
            _reservationsRepository = reservationsRepository;
            _booksRepository = booksRepository;
            AddReservation = new RelayCommand<int>(OnAddReservation);
            LoadBooksCommand = new RelayCommand(OnLoadBooks);
            ClearSearchInputCommand = new RelayCommand(OnClearSearchInput);
        }

        private void OnClearSearchInput()
        {
            SearchInput = null;
        }

        public RelayCommand<int> AddReservation { get; set; }
        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public event Action Done = delegate { };

        private List<Book> _allBooks;
        private string _searchInput;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterBooks(_searchInput);
            }
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
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }

        private void OnLoadBooks()
        {
            _allBooks = _booksRepository.GetBooks();
            Books = new ObservableCollection<Book>(_allBooks);
        }

        private void OnAddReservation(int bookId)
        {
            var reservation = new Reservation { BookId = bookId, ClientId = ClientId, ReservationDate = DateTime.Now };
            _reservationsRepository.AddReservation(reservation);
            Done();
        }

        private void FilterBooks(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Books = new ObservableCollection<Book>(_allBooks);
            }
            else
            {
                Books = new ObservableCollection<Book>(_allBooks.Where(c => c.Title.ToLower().Contains(searchInput)));
            }
        }
    }
}
