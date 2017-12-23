using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public interface IBooksRepository
    {
        List<Book> GetBooks();
        List<Book> GetBooksByTitle(string bookTitle);
        void UpdateBook(Book book);
        void AddBook(Book book);
        void DeleteBook(int bookId);
    }
}
