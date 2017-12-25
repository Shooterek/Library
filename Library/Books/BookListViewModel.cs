using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Books
{
    public class BookListViewModel : BindableBase
    {
        private IBooksRepository _booksRepository;

        public BookListViewModel(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
            LoadBooksCommand = new RelayCommand(LoadBooks);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
            AddBookCommand = new RelayCommand(AddBook);
            EditBookCommand = new RelayCommand<Book>(EditBook);
            DeleteBookCommand = new RelayCommand<Book>(OnBookDelete);
        }

        private void OnBookDelete(Book book)
        {
            _booksRepository.DeleteBook(book.BookId);
            Done();
        }


        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public RelayCommand<Book> EditBookCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand<Book> DeleteBookCommand { get; set; }
        public event Action<Book> AddBookRequested = delegate { };
        public event Action<Book> EditBookRequested = delegate { };
        public event Action Done = delegate { };


        private void AddBook()
        {
            AddBookRequested(new Book());
        }

        private void EditBook(Book book)
        { 
            EditBookRequested(book);
        }

        private void LoadBooks()
        {
            _allBooks = _booksRepository.GetBooks();
            Books = new ObservableCollection<Book>(_allBooks);
        }

        private List<Book> _allBooks;
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                SetProperty(ref _books, value);
            }
        }

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

        private void ClearSearchInput()
        {
            SearchInput = null;
        }
    }
}
