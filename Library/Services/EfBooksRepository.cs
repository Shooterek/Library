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

        public List<BookData> GetBookDataList()
        {
            var books = _dbContext.Books.ToList();
            var bookdatas = books.Select(b => new BookData { author = b.Author, bookid = b.BookId, category = b.Category.Category1, title = b.Title });

            return bookdatas.ToList();
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

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
