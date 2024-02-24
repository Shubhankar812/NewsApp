using NewsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.MVVM.ViewModel
{
    public class CategoryViewModel
    {
        public ObservableCollection<Category> ListOfCategories { get; set; }


        public CategoryViewModel()
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            ListOfCategories = new ObservableCollection<Category>()
            {
                new Category{Id=1, Name="breaking-news"},
                new Category{Id=2, Name="world"},
                new Category{Id=3, Name="nation"},
                new Category{Id=4, Name="business"},
                new Category{Id=5, Name="entertainment"},
                new Category{Id=6, Name="sports"},
                new Category{Id=7, Name="science"},
                new Category{Id=8, Name="health"},
            };
        }
    }
}
