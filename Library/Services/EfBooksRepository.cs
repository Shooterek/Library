using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public class EfBooksRepository : IBooksRepository
    {
        private readonly LibraryDbContext _dbContext = new LibraryDbContext();
        public List<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public List<Book> GetBooksByTitle(string bookTitle)
        {
            return _dbContext.Books.Where(b=>b.Title.Contains(bookTitle)).ToList();
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
            }
            _dbContext.SaveChanges();
        }
    }
}
