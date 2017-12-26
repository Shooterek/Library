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
            EditBookCommand = new RelayCommand<int>(OnBookEdit);
            DeleteBookCommand = new RelayCommand<int>(OnBookDelete);
        }

        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public RelayCommand<int> EditBookCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand<int> DeleteBookCommand { get; set; }
        public event Action<Book> AddBookRequested = delegate { };
        public event Action<Book> EditBookRequested = delegate { };
        public event Action Done = delegate { };

        private void OnBooksLoad()
        {
            _allBooks = _booksRepository.GetBookDataList();
            Books = new ObservableCollection<BookData>(_allBooks);
        }

        private List<BookData> _allBooks;
        private ObservableCollection<BookData> _books;
        public ObservableCollection<BookData> Books
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

        private BookData _selectedBook;
        public BookData SelectedBook
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

        private void OnBookEdit(int id)
        {
            var book = _booksRepository.GetBookById(id);
            EditBookRequested(book);
        }

        private void OnBookDelete(int id)
        {
            _booksRepository.DeleteBook(id);
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
                Books = new ObservableCollection<BookData>(_allBooks);
            }
            else
            {
                Books = new ObservableCollection<BookData>(_allBooks.Where(c => c.title.ToLower().Contains(searchInput)));
            }
        }
    }
}
