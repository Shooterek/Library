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
            LoadBooksCommand = new RelayCommand(OnBooksLoad);
            ClearSearchInputCommand = new RelayCommand(OnClearSearchInput);
            AddBookCommand = new RelayCommand(OnBookAdd);
            EditBookCommand = new RelayCommand<Book>(OnBookEdit);
            DeleteBookCommand = new RelayCommand<Book>(OnBookDelete);
        }

        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public RelayCommand<Book> EditBookCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand<Book> DeleteBookCommand { get; set; }
        public event Action<Book> AddBookRequested = delegate { };
        public event Action<Book> EditBookRequested = delegate { };
        public event Action Done = delegate { };

        private void OnBooksLoad()
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

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                SetProperty(ref _selectedBook, value);
            }
        }

        private void OnBookAdd()
        {
            AddBookRequested(new Book());
        }

        private void OnBookEdit(Book book)
        {
            EditBookRequested(book);
        }

        private void OnBookDelete(Book book)
        {
            _booksRepository.DeleteBook(book.BookId);
            Done();
        }

        private void OnClearSearchInput()
        {
            SearchInput = null;
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
