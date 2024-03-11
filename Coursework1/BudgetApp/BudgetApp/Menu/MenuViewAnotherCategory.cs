using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    internal class MenuViewAnotherCategory : IMenuItem
    {
        private BudgetManager budgetManager; // Assuming BudgetManager is injected

        public MenuViewAnotherCategory(BudgetManager budgetManager)
        {
            this.budgetManager = budgetManager;
        }
        public int OptionNumber => 2;
        public string OptionName => "View another Category.";
        public void Action()
        {
            string categoryName;
            do
            {
                Console.Write("Please type the name of the Category you wish to view: ");
                categoryName = Console.ReadLine();

                // Check if category exists using BudgetManager
                if (!budgetManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!budgetManager.CategoryExists(categoryName)); // Loop until a valid category is entered

            // Your logic to view the category (e.g., display category details, transactions, etc.)
            Console.WriteLine("You are now viewing Category: " + categoryName);
            //TO-DO: View Budget info and transactions under category

        }
    }
}
