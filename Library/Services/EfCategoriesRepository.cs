using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public class EfCategoriesRepository : ICategoriesRepository
    {
        private LibraryDbContext _dbContext;

        public EfCategoriesRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
