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

            //Initialisation of Preset Categories
            Category presetJan = new Category("January");
            Category presetFeb = new Category("February");
            Category presetMarch = new Category("March");
            Category presetApril = new Category("April");
            Category presetMay = new Category("May");
            categoryManager.AddCategory(presetJan);
            categoryManager.AddCategory(presetFeb);
            categoryManager.AddCategory(presetMarch);
            categoryManager.AddCategory(presetApril);
            categoryManager.AddCategory(presetMay);

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

            //Inititialisation of Menu Options
            AddMenuItem(new MenuAddTransaction(menuManager, transactionManager, categoryManager));
            AddMenuItem(new MenuViewAnotherCategory(menuManager, categoryManager));
            AddMenuItem(new Menu_AddNewCategory(categoryManager));
            AddMenuItem(new Menu_EditBudget(categoryManager));
            AddMenuItem(new Menu_EditTransaction(categoryManager, transactionManager));
            AddMenuItem(new Menu_DeleteTransaction(menuManager, categoryManager, transactionManager));
            AddMenuItem(new Menu_DeleteCategory(menuManager, categoryManager));

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

        //1-Add transaction
        public void AddTransactionMenu()
        {
            new MenuAddTransaction(menuManager, transactionManager, categoryManager).Action();
        }

        //2-View another category
        public void ViewAnotherCategory()
        {
            new MenuViewAnotherCategory(menuManager, categoryManager).Action();
        }

        //3-Add New Category
        public void AddNewCategory()
        {
            new Menu_AddNewCategory(categoryManager).Action();
        }

        //4-Edit chosen Category 
        public void EditBudget() 
        {
            new Menu_EditBudget(categoryManager).Action();
        }

        //5-Edit chosen Transaction
        public void EditTransaction()
        {
            new Menu_EditTransaction(categoryManager, transactionManager).Action();
        }

        //6-Delete chosen Transaction
        public void DeleteTransaction()
        {
            new Menu_DeleteTransaction(menuManager, categoryManager, transactionManager).Action();
        }
        
        //7-Delete chosen Category
        public void DeleteCategory()
        {
            new Menu_DeleteCategory(menuManager, categoryManager).Action();
        }
        //8-Print a chosen Category's info (including Budget, Spending and Transactions)
        public void PrintCategory()
        {
            Console.WriteLine("Printing goes here"); //Remove this later
        }

    }
}
