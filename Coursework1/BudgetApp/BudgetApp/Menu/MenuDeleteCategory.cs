using BudgetApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    internal class Menu_DeleteCategory : IMenuItem
    {
        private MenuManager menuManager;
        private CategoryManager categoryManager;

        public Menu_DeleteCategory(MenuManager menuManager, CategoryManager categoryManager)
        {
            this.menuManager = menuManager;
            this.categoryManager = categoryManager;
        }
        public int OptionNumber => 7;
        public string OptionName => "Delete Category.";
        public void Action()
        {
            Console.Clear();
            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.WriteLine("Please select the Category you would like to delete.");
                categoryName = Console.ReadLine();
                if (!categoryManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!categoryManager.CategoryExists(categoryName));
            Category category = categoryManager.GetCategoryByName(categoryName);

            categoryManager.RemoveCategory(category);
            Console.WriteLine("Category succesfully removed.");
            Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
            Console.Read();
        }
    }
}
