using BudgetApp;
using System;
using System.Transactions;
using BudgetApp.Managers;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using BudgetApp.Menu;
using static BudgetApp.Menu.MenuCategories;
using BudgetApp.Managers;

class Program
{
    public static void Main(string[] args)
    {
        CategoryManager categoryManager = new CategoryManager();
        BudgetManager budgetManager = new BudgetManager();
        BudgetApp.Managers.TransactionManager transactionManger = new BudgetApp.Managers.TransactionManager();
        List<IMenuItem> menuItems = new List<IMenuItem>();
        MenuManager menuManager = new MenuManager(menuItems);
        MenuCategories menuCategories = new MenuCategories(menuManager, menuItems);


        //HEADER
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("           BUDGETING APP              ");
        Console.WriteLine("--------------------------------------");
        //DEFAULTS
        Category defaultCat = new Category("Default");
        categoryManager.AddCategory(defaultCat);
        //Overall spending 

        Console.Write("Category: " + defaultCat.GetCategory());
        Console.WriteLine();
        defaultCat.Display();
        Console.WriteLine();


        //TESTING
        //Transactions Test
        //DateTime datetest;
        /*TransactionID transaction1_ID = new TransactionID();
        TransactionID transaction2_ID = new TransactionID();
        IncomeTransaction testIncome_1 = new IncomeTransaction(transaction1_ID, "MURAL COMMISSION", 120.00, DateTime.ParseExact("10/05/2024", "dd/MM/yyyy", null), defaultCat, false, "One-off payment", "CHARLOTTE.H.");
        IncomeTransaction testIncome_2 = new IncomeTransaction(transaction2_ID, "STICKER SALES", 25.85, DateTime.ParseExact("14/05/2024", "dd/MM/yyyy", null), defaultCat, false, "One-off payment", "STICKER SHOP.");
        //ExpenseTransaction testExpense_1 = new ExpenseTransaction("");
        transactionManager.AddTransaction(defaultCat, testIncome_1);
        transactionManager.AddTransaction(defaultCat, testIncome_2);
        transactionManager.ListTransactions(defaultCat);
        transactionManager.DeleteTransaction(defaultCat, testIncome_1.GetTransactionID());
        Console.WriteLine("Deletion Test: Mural Commission deleted.");

        //GeneralCommands
        transactionManager.ListTransactions(defaultCat);
        */

        //#----------------------------------------------------------------------------------------------------------------------#

        //Display the Menu//
        menuCategories.FirstTimeUserScene();

        //4
    }
}