using BudgetApp;
using System;
using System.Transactions;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using BudgetApp.Menu;
using static BudgetApp.Menu.MenuCategories;

class Program
{
    public static void Main(string[] args)
    {
        BudgetManager budgetManager = new BudgetManager();
        MenuCategories menuCategories = new MenuCategories(budgetManager);


        //HEADER
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("           BUDGETING APP              ");
        Console.WriteLine("--------------------------------------");
        //DEFAULTS
        Category defaultCat = new Category("Default");
        Budget defaultBudget = new Budget(defaultCat, 0.00);
        //Overall spending 

        Console.Write("Category: " + defaultCat.GetCategory());
        Console.WriteLine();
        Console.Write("Budget: " + defaultBudget.GetBudgetValue() + " - Remaining Budget: " + " - Total Spending: ");
        Console.WriteLine();


        //TESTING
        //Transactions Test
        //DateTime datetest;
        TransactionID transaction1_ID = new TransactionID("test1");
        TransactionID transaction2_ID = new TransactionID("test2");
        IncomeTransaction testIncome_1 = new IncomeTransaction(transaction1_ID, "MURAL COMMISSION", 120.00, DateTime.ParseExact("10/05/2024", "dd/MM/yyyy", null), defaultCat, "One-off payment", "CHARLOTTE.H.");
        IncomeTransaction testIncome_2 = new IncomeTransaction(transaction2_ID, "STICKER SALES", 25.85, DateTime.ParseExact("14/05/2024", "dd/MM/yyyy", null), defaultCat, "One-off payment", "STICKER SHOP.");
        //ExpenseTransaction testExpense_1 = new ExpenseTransaction("");
        budgetManager.AddTransaction(testIncome_1);
        budgetManager.AddTransaction(testIncome_2);
        budgetManager.ListTransactions(defaultCat);
        budgetManager.DeleteTransaction(testIncome_1.GetTransactionID());
        Console.WriteLine("Deletion Test: Mural Commission deleted.");

        //GeneralCommands
        budgetManager.ListTransactions(defaultCat);


        //#----------------------------------------------------------------------------------------------------------------------#

        //First time users will be directed to create a new catagory and a budget
        Console.WriteLine("Welcome, First Time User.");
        Console.WriteLine("Please input your current account information: ");
        //TO BE DONE. This part is entirely option tbh
        Console.WriteLine(); 
        Console.WriteLine("Please create a new Category:");
        string firstCat = Console.ReadLine();
        Category FirstCat = new Category(firstCat);
        Console.WriteLine();
        Console.WriteLine("Please set a Budget Goal for this Category (Please type a double):");
        string firstBudgetGoal = Console.ReadLine();
        Budget FirstBudget = new Budget(FirstCat, Convert.ToDouble(firstBudgetGoal));
        Console.Write("Category: " + FirstCat.GetCategory());
        Console.WriteLine();
        Console.Write("Budget: " + defaultBudget.GetBudgetValue() + " - Remaining Budget: " + " - Total Spending: ");
        Console.WriteLine();
        Console.WriteLine();
        //Show allocated budget + money remaining. default: £0
        Console.WriteLine("");

        //Display the Menu//
        menuCategories.StartMenu();

        //4
    }
}