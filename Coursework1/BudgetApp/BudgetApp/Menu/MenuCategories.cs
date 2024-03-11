using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using static BudgetApp.Transaction.Transactions;

namespace BudgetApp.Menu
{
    //Using a menu interface as opposed to nested cases as this is more intuitive
    // and less messy + more flexible.
    internal class MenuCategories
    {
        private BudgetManager budgetManager;
        private List<IMenuItem> mainMenuItems;
        public MenuCategories(BudgetManager budgetManager) 
        {
            this.budgetManager = budgetManager;
            this.mainMenuItems = new List<IMenuItem>();
        }
        public void AddMenuItem(IMenuItem menuItem)
        {
            mainMenuItems.Add(menuItem); // Add menu items to the list
        }

        public void StartMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                AddMenuItem(new MenuAddTransaction(budgetManager));
                AddMenuItem(new MenuViewAnotherCategory(budgetManager));
                mainMenuItems.Add(new Menu_AddNewCategory());

                MenuManager mainMenuManager = new MenuManager(mainMenuItems);

                mainMenuManager.DisplayMenu();
                mainMenuManager.RunMenu();
            }
        }

        public void AddTransactionMenu()
        {
            new MenuAddTransaction(budgetManager).Action();
        }

        //View another category
        public void ViewAnotherCategory()
        {
            new MenuViewAnotherCategory(budgetManager).Action();
        }
        //Add New Category
        public class Menu_AddNewCategory : IMenuItem
        {
            public int OptionNumber => 3;
            public string OptionName => "Add New Category.";
            public void Action()
            {
                Console.Write("Please enter the name of your new Category: ");
                string categoryName = Console.ReadLine();
                Category newCategory = new Category(categoryName);
                Console.Write("Please enter the Budget Goal for " + categoryName + ": ");
                string newBudgetGoal = Console.ReadLine();
                Budget newBudget = new Budget(newCategory, Convert.ToDouble(newBudgetGoal));
                Console.WriteLine("Category added successfully!");
                Console.WriteLine();
                Console.Write("Category: " + newCategory.GetCategory());
                Console.Write("Budget: £" + newBudget.GetBudgetValue() + " - Remaining Budget: £" + " - Total Spending: £");
            }
        }
        //Edit Budget for this Category
        public class Menu_EditBudget : IMenuItem
        {
            public int OptionNumber => 4;
            public string OptionName => "Edit Budget for the Current Catagory.";
            public void Action()
            {
                Console.Write("Please input the value for your Budget: ");
            }
        }
    }
}
