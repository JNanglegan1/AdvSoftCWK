using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Managers
{
    internal class CategoryManager : ICategoryItems
    {
        List<Category> categories = new List<Category>();
        public void ListCategories()
        {
            if (categories.Count == 0)
            {
                Console.WriteLine("There are no categories to list.");
            }
            else
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("List of Available Categories:");
                foreach (Category category in categories)
                {
                    Console.WriteLine(category.GetCategory());
                }
                Console.WriteLine("----------------------------------");
            }
        }
        public void AddCategory(Category category)
        {
            categories.Add(category);
        }
        public void RemoveCategory(Category category)
        {
            categories.Remove(category);
        }
        public bool CategoryExists(string categoryName)
        {
            return categories.Any(category => category.GetCategory() == categoryName);
        }
        public Category GetCategoryByName(string categoryName)
        {
            Category category = categories.FirstOrDefault(c => c.GetCategory() == categoryName);
            if (category == null)
            {
                Console.WriteLine("Error: Category '{0}' does not exist. Please try again:", categoryName);
            }
            return category;
        }
    }
}
