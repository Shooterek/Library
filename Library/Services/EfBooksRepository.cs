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
        private LibraryDbContext _dbContext;

        public EfBooksRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.Single(b => b.BookId == id);
        }

        public List<Book> GetBooksByTitle(string bookTitle)
        {
            return _dbContext.Books.Where(b=>b.Title.Contains(bookTitle)).ToList();
        }

        public List<BookData> GetBookDataList()
        {
            return _dbContext.BookDatas.ToList();
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
