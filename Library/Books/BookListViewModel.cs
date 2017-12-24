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
        private EfBooksRepository _repo = new EfBooksRepository();

        public BookListViewModel()
        {
            LoadBooksCommand = new RelayCommand(LoadBooks);
            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);
        }

        private void LoadBooks()
        {
            _allBooks = _repo.GetBooks();
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

        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
    }
}
