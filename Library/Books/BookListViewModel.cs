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
        }

        private void LoadBooks()
        {
            Books = new ObservableCollection<Book>(_repo.GetBooks());
        }

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                SetProperty(ref _books, value);
            }
        }

        public RelayCommand LoadBooksCommand { get; set; }
    }
}
