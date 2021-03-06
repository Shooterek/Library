﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Books
{
    public class AddEditBookViewModel : BindableBase
    {
        private IBooksRepository _booksRepository;

        public AddEditBookViewModel(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
            Categories = new List<Category>(_booksRepository.GetCategories());
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
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
                SelectedCategory = Categories.SingleOrDefault(c => c.CategoryId == value.CategoryId);
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

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            Book.Category = SelectedCategory;
            try
            {
                if (EditMode)
                {
                    _booksRepository.UpdateBook(Book);
                }
                else
                {
                    _booksRepository.AddBook(Book);
                }
                Done();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
