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
    public class AddEditBookViewModel : BindableBase
    {
        ICategoriesRepository _categoriesRepository = new EfCategoriesRepository();

        public AddEditBookViewModel()
        {
            Categories = new List<Category>(_categoriesRepository.GetCategories());
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            Done();
        }

        private bool CanSave()
        {
            throw new NotImplementedException();
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public event Action Done = delegate { };

        private bool _editMode;
        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value);}
        }

        private Book _book = null;
        public Book Book
        {
            get { return _book; }
            set
            {
                SetProperty(ref _book, value);
                var category = Categories.SingleOrDefault(c => c.CategoryId == value.CategoryId);
                SelectedCategory = category;
            }
        }

        private Category _selectedCategory = null;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value);}
        }

        private List<Category> _categories;
        public List<Category> Categories
        {
            get { return _categories; }
            set
            {
                SetProperty(ref _categories, value);
            }
        }
    }
}
