using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using static BudgetApp.Transaction.Transactions;
using BudgetApp.Managers;

namespace BudgetApp.Menu
{
    //Using a menu interface as opposed to nested cases as this is more intuitive
    // and less messy + more flexible.
    internal class MenuCategories
    {
        private MenuManager menuManager;
        private CategoryManager categoryManager;
        private TransactionManager transactionManager;
        private List<IMenuItem> mainMenuItems;
        public MenuCategories(MenuManager menuManager, List<IMenuItem> mainMenuItems) 
        {
            this.menuManager = menuManager;
            this.mainMenuItems = mainMenuItems;
            this.categoryManager = new CategoryManager();
            this.transactionManager = new TransactionManager();
        }
        public void AddMenuItem(IMenuItem menuItem)
        {
            mainMenuItems.Add(menuItem); 
        }

        public void FirstTimeUserScene()
        {
            Console.Clear();
            //First time users will be directed to create a new catagory and a budget
            Console.WriteLine("Welcome, First Time User.");
            Console.WriteLine();
            Console.WriteLine("Please create a new Category:");
            string firstCat = Console.ReadLine();
            Category FirstCat = new Category(firstCat);
            Console.WriteLine();
            double firstBudget;
            while (true)
            {
                Console.Write("Please set a Budget Goal for this Category (Please type a double): ");
                if (double.TryParse(Console.ReadLine(), out firstBudget)) { break; }
                else { Console.WriteLine("Invalid input. Please type a double."); }
            }
            FirstCat.SetBudget(firstBudget);
            categoryManager.AddCategory(FirstCat);
            Console.WriteLine();
            FirstCat.Display();
            Console.WriteLine("Category successfully created!");
            Console.WriteLine();
            Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
            Console.ReadLine();
            //Display the Menu//
            AddMenuItem(new MenuAddTransaction(menuManager, transactionManager, categoryManager));
            AddMenuItem(new MenuViewAnotherCategory(menuManager, categoryManager));
            mainMenuItems.Add(new Menu_AddNewCategory(categoryManager));
            mainMenuItems.Add(new Menu_EditBudget(categoryManager));
            mainMenuItems.Add(new Menu_DeleteTransaction(menuManager, categoryManager, transactionManager));
            mainMenuItems.Add(new Menu_DeleteCategory(menuManager, categoryManager));
            StartMenu();
        }
        public void StartMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("---MAIN MENU---");

                MenuManager mainMenuManager = new MenuManager(mainMenuItems);

                mainMenuManager.RunMenu();
            }
        }

        public void AddTransactionMenu()
        {
            new MenuAddTransaction(menuManager, transactionManager, categoryManager).Action();
        }

        //View another category
        public void ViewAnotherCategory()
        {
            new MenuViewAnotherCategory(menuManager, categoryManager).Action();
        }
        //Add New Category
        public class Menu_AddNewCategory : IMenuItem
        {
            private CategoryManager categoryManager;
            //private BudgetManager budgetManager;
            public Menu_AddNewCategory(CategoryManager categoryManager)
            {
                this.categoryManager = categoryManager;
            }
            public int OptionNumber => 3;
            public string OptionName => "Add New Category.";
            public void Action()
            {
                Console.Clear();
                Console.Write("Please enter the name of your new Category: ");
                string categoryName = Console.ReadLine();
                Category newCategory = new Category(categoryName);
                Console.Write("Please enter the Budget Goal for " + categoryName + ": ");
                string newBudgetGoal = Console.ReadLine();
                double newBudget = Convert.ToDouble(newBudgetGoal);
                newCategory.SetBudget(newBudget);
                categoryManager.AddCategory(newCategory);
                Console.WriteLine("Category added successfully!");
                Console.WriteLine();
                newCategory.Display();
                Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
                Console.Read();
            }
        }
        //Edit chosen Category 
        public class Menu_EditBudget : IMenuItem
        {
            private CategoryManager categoryManager;
            public Menu_EditBudget(CategoryManager categoryManager)
            {
                this.categoryManager = categoryManager;
            }

            public int OptionNumber => 4;
            public string OptionName => "Edit Budget for a Catagory.";
            public void Action()
            {
                Console.Clear();
                Console.WriteLine("Please select a category:");
                Console.WriteLine("Would you like to change the name of this category?[Y/N]");
                Console.WriteLine("Please input a new name.");
                Console.WriteLine("Would you like to change the Budget for this category?[Y/N]");
                Console.Write("Please input the value for your Budget: ");
                Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
                Console.Read();
            }
        }
        //Delete chosen Transaction
        public class Menu_DeleteTransaction : IMenuItem
        {
            private MenuManager menuManager;
            private CategoryManager categoryManager;
            private TransactionManager transactionManager;

            public Menu_DeleteTransaction(MenuManager menuManager, CategoryManager categoryManager, TransactionManager transactionManager)
            {
                this.menuManager = menuManager;
                this.categoryManager = categoryManager;
                this.transactionManager = transactionManager;
            }
            public int OptionNumber => 5;
            public string OptionName => "Delete Transaction.";
            public void Action()
            {
                Console.Clear();
                Console.WriteLine("Please select the Category you would like to view: ");
                categoryManager.ListCategories();
                Console.ReadLine();
                //View the category.Display() info for the chosen category
                Console.WriteLine("Please input the ID of the transaction you would like to delete: ");
                Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
                Console.Read();
            }
        }
        //Delete chosen Category
        public class Menu_DeleteCategory : IMenuItem
        {
            private MenuManager menuManager;
            private CategoryManager categoryManager;

            public Menu_DeleteCategory(MenuManager menuManager, CategoryManager categoryManager)
            {
                this.menuManager = menuManager;
                this.categoryManager = categoryManager;
            }
            public int OptionNumber => 6;
            public string OptionName => "Delete Category.";
            public void Action()
            {
                Console.Clear();
                categoryManager.ListCategories();
                Console.WriteLine("Please select the Category you would like to delete.");
                Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
                Console.Read();
            }
        }

    }
}
