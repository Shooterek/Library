using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public interface ICategoriesRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
    }
}
