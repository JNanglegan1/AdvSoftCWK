using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal interface ICategoryItems
    {
        public void ListCategories();
        public void AddCategory(Category category);
        public void RemoveCategory(Category category);
        public bool CategoryExists(string categoryName);
        public Category GetCategoryByName(string categoryName);
    }
}
