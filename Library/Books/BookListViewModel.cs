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
        public BookListViewModel()
        {
            Books = new ObservableCollection<Book>(_repo.GetBooks());
        }
        private EfBooksRepository _repo = new EfBooksRepository();
        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                SetProperty(ref _books, value);
            }
        }
    }
}
