using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Managers;

namespace BudgetApp.Menu
{
    internal class MenuViewAnotherCategory : IMenuItem
    {
        private MenuManager menuManager;
        private CategoryManager categoryManager;

        public MenuViewAnotherCategory(MenuManager menuManager, CategoryManager categoryManager)
        {
            this.menuManager = menuManager;
            this.categoryManager = categoryManager;
        }
        public int OptionNumber => 2;
        public string OptionName => "View another Category.";
        public void Action()
        {
            Console.Clear();
            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.Write("Please type the name of the Category you wish to view: ");
                categoryName = Console.ReadLine();
                if (!categoryManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!categoryManager.CategoryExists(categoryName));
            Category category = categoryManager.GetCategoryByName(categoryName);

            category.Display();

            Console.WriteLine("You are now viewing Category: " + categoryName);
            Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
            Console.Read();
        }
    }
}
